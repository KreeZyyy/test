using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OasisBrowser;

public sealed class BrowserBridge : IDisposable
{
	private readonly HttpListener listener = new HttpListener();

	private readonly CancellationTokenSource stop = new CancellationTokenSource();

	private BrowserEngine browser;
    public void SetEngine(BrowserEngine value) { Ready=false;StartupError=null;browser=value; }

	private readonly string token;

	private int busy;
    private int diagnosed;
    public Action<string>? Diagnostic;

	public volatile bool Ready;

	public string? StartupError;

	public BrowserBridge(BrowserEngine browser, string token, int port)
	{
		if (token.Length < 24 || port < 1024 || port > 65535)
		{
			throw new ArgumentException();
		}
		this.browser = browser;
		this.token = token;
		listener.Prefixes.Add("http://localhost:" + port + "/");
		listener.Prefixes.Add("http://127.0.0.1:" + port + "/");
	}

	public void Start()
	{
		listener.Start();
		Task.Run((Func<Task>)Listen);
	}

	private async Task Listen()
	{
		while (!stop.IsCancellationRequested)
		{
			try
			{
				Handle(await listener.GetContextAsync());
			}
			catch when (stop.IsCancellationRequested)
			{
				break;
			}
			catch
			{
			}
		}
	}

	private async Task Handle(HttpListenerContext c)
	{
		_ = 19;
		try
		{
			if (c.Request.Headers["X-Oasis-Browser-Token"] != token)
			{
				await Json(c, 401, new
				{
					error = "Neplatný token Oasis Browser."
				});
				return;
			}
            if(System.Threading.Interlocked.Exchange(ref diagnosed,1)==0)Diagnostic?.Invoke("First authenticated Lua HTTP request received.");
			string text = c.Request.Url?.AbsolutePath;
			if (c.Request.HttpMethod == "GET" && text == "/health")
			{
				await Json(c, 200, new
				{
					ready = Ready,
					status = (StartupError ?? browser.Status),
					version = "0.2.4"
				});
				return;
			}
			if (c.Request.HttpMethod != "POST" || text != "/action")
			{
				await Json(c, 404, new
				{
					error = "Neznámá cesta."
				});
				return;
			}
			if (!Ready)
			{
				await Json(c, 503, new
				{
					error = (StartupError ?? "Chrome se ještě spouští.")
				});
				return;
			}
			if (c.Request.ContentLength64 < 0 || c.Request.ContentLength64 > 8192)
			{
				await Json(c, 413, new
				{
					error = "Příliš dlouhý vstup."
				});
				return;
			}
			if (Interlocked.CompareExchange(ref busy, 1, 0) != 0)
			{
				await Json(c, 429, new
				{
					error = "Počkej na předchozí akci."
				});
				return;
			}
			try
			{
				string json;
				using (StreamReader r = new StreamReader(c.Request.InputStream, Encoding.UTF8))
				{
					json = await r.ReadToEndAsync();
				}
				JObject input;
				try
				{
					input = JObject.Parse(json);
				}
				catch (JsonException)
				{
					await Json(c, 400, new
					{
						error = "Neplatný JSON."
					});
					return;
				}
				string text2 = ((string?)input["action"]) ?? "";
				using (CancellationTokenSource timeout = CancellationTokenSource.CreateLinkedTokenSource(stop.Token))
				{
					timeout.CancelAfter(12000);
					switch (text2)
                    {
                    case "viewport":
                        await browser.SetViewportAsync((int?)input["value"]?["w"] ?? 1280, (int?)input["value"]?["h"] ?? 720, timeout.Token);
                        break;
                    case "keyboard":
                        browser.KeyboardEnabled = (bool?)input["value"] == true;
                        break;
					case "navigate":
						await browser.NavigateAsync(((string?)input["value"]) ?? "", timeout.Token);
						break;
					case "home":
						await browser.NavigateAsync("https://www.youtube.com/", timeout.Token);
						break;
					case "reload":
						await browser.Command("Page.reload", null, timeout.Token);
						break;
					case "scroll_up":
						await browser.ScrollAsync(-500.0, timeout.Token);
						break;
					case "scroll_down":
						await browser.ScrollAsync(500.0, timeout.Token);
						break;
					case "text":
					{
						string text3 = ((string?)input["value"]) ?? "";
						if (text3.Length > 1000)
						{
							throw new InvalidOperationException("Text je příliš dlouhý.");
						}
						await browser.Command("Input.insertText", new
						{
							text = text3
						}, timeout.Token);
						break;
					}
					case "enter":
						await browser.Command("Input.dispatchKeyEvent", new
						{
							type = "keyDown",
							key = "Enter",
							code = "Enter",
							windowsVirtualKeyCode = 13
						}, timeout.Token);
						await browser.Command("Input.dispatchKeyEvent", new
						{
							type = "keyUp",
							key = "Enter",
							code = "Enter",
							windowsVirtualKeyCode = 13
						}, timeout.Token);
						break;
					default:
						await Json(c, 400, new
						{
							error = "Neznámá akce."
						});
						return;
					}
				}
				await Json(c, 200, new
				{
					status = "Akce odeslána • klikni přímo na webový přehrávač"
				});
			}
			finally
			{
				Interlocked.Exchange(ref busy, 0);
			}
		}
		catch (InvalidOperationException ex2)
		{
			await Json(c, 400, new
			{
				error = ex2.Message
			});
		}
		catch
		{
			try
			{
				await Json(c, 502, new
				{
					error = "Spojení s Chrome selhalo. Zkontroluj jeho okno."
				});
			}
			catch
			{
			}
		}
		finally
		{
			c.Response.Close();
		}
	}

	private static async Task Json(HttpListenerContext c, int code, object value)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value));
		c.Response.StatusCode = code;
		c.Response.ContentType = "application/json; charset=utf-8";
		c.Response.ContentLength64 = bytes.Length;
		await c.Response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
	}

	public void Dispose()
	{
		stop.Cancel();
		listener.Close();
	}
}
