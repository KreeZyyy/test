using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OasisBrowser;

public sealed class BrowserEngine : IDisposable
{
	public int Width { get; private set; } = 1280;

	public int Height { get; private set; } = 720;
    public volatile bool KeyboardEnabled;

	private readonly CdpClient cdp = new CdpClient();
    public readonly PcmBuffer Audio = new PcmBuffer();
    public Action<string>? Diagnostic;
    public BrowserEngine()
    {
        cdp.EventReceived += evt =>
        {
            if ((string?)evt["method"] == "Page.screencastFrame")
            {
                var args = evt["params"];
                int? session = (int?)args?["sessionId"];
                if (session.HasValue) _ = AcknowledgeFrame(session.Value);
                try
                {
                    string data = (string?)args?["data"] ?? "";
                    if (data.Length > 0 && data.Length <= 6291456)
                        Interlocked.Exchange(ref frame, Convert.FromBase64String(data));
                }
                catch (FormatException) { }
                return;
            }
            if ((string?)evt["method"] != "Runtime.bindingCalled" || (string?)evt["params"]?["name"] != "__oasisPcm") return;
            try { string data=(string?)evt["params"]?["payload"]??""; if(data.Length<=45000) Audio.Write(Convert.FromBase64String(data)); } catch(FormatException) { }
        };
    }

	private readonly CancellationTokenSource stop = new CancellationTokenSource();

	private Process? chrome;

	private string? profile;

	private byte[]? frame;

	private int closed;

	private volatile string status = "Čekám na aktivní browser panel…";

	public string Status => status;

	public byte[]? TakeFrame()
	{
		return Interlocked.Exchange(ref frame, null);
	}

	public static string Navigation(string query)
	{
		query = query.Trim();
		if (query.Length == 0 || query.Length > 1000)
		{
			throw new InvalidOperationException("Napiš hledaný název nebo YouTube odkaz.");
		}
		if (Uri.TryCreate(query, UriKind.Absolute, out var result))
		{
			if (result.Scheme != "https" || !result.IsDefaultPort || result.UserInfo != "" || (!(result.Host == "youtube.com") && !(result.Host == "www.youtube.com") && !(result.Host == "m.youtube.com") && !(result.Host == "youtu.be")))
			{
				throw new InvalidOperationException("Adresní pole přijímá jen HTTPS YouTube odkazy.");
			}
			return result.AbsoluteUri;
		}
		return "https://www.youtube.com/results?search_query=" + Uri.EscapeDataString(query);
	}

	public async Task StartAsync(string executable, int port, CancellationToken cancellation, bool headlessTest = false, bool allowTestNoSandbox = false)
	{
        status="Spouštím Chrome na pozadí…";
		cancellation.ThrowIfCancellationRequested();
		stop.Token.ThrowIfCancellationRequested();
		if (!File.Exists(executable))
		{
			throw new InvalidOperationException("Chrome nebyl nalezen. Nastav Browser.ChromePath na chrome.exe.");
		}
		if (port < 1024 || port > 65535)
		{
			throw new InvalidOperationException("Neplatný Chrome debug port.");
		}
        var probe=new TcpListener(IPAddress.Loopback,port);
        try { probe.Start(); }
        catch(SocketException) { throw new InvalidOperationException("Chrome debug port je obsazený. Nastav jiný Browser.DebugPort."); }
        finally { probe.Stop(); }
		profile = Path.Combine(Path.GetTempPath(), "OasisBrowser", Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(profile);
		ProcessStartInfo processStartInfo = new ProcessStartInfo
		{
			FileName = executable,
			UseShellExecute = false,
			CreateNoWindow = true
		};
		processStartInfo.Arguments = "--user-data-dir=\"" + profile + "\" --remote-debugging-address=127.0.0.1 --remote-debugging-port=" + port + " --no-first-run --no-default-browser-check --disable-extensions --disable-background-timer-throttling --disable-backgrounding-occluded-windows --disable-renderer-backgrounding --window-size=1280,720 --app=about:blank";
		if (headlessTest)
		{
			processStartInfo.Arguments += " --headless=new";
            if(allowTestNoSandbox) processStartInfo.Arguments += " --no-sandbox --disable-dev-shm-usage";
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.RedirectStandardError = true;
		}
		chrome = Process.Start(processStartInfo) ?? throw new InvalidOperationException("Chrome se nepodařilo spustit.");
		if (headlessTest)
		{
			chrome.StandardOutput.ReadToEndAsync();
			chrome.StandardError.ReadToEndAsync();
		}
		using (HttpClient http = new HttpClient(new HttpClientHandler { UseProxy=false })
		{
			Timeout = TimeSpan.FromSeconds(2.0)
		})
		{
			string endpoint = null;
			for (int i = 0; i < 100; i++)
			{
				if (endpoint != null)
				{
					break;
				}
				cancellation.ThrowIfCancellationRequested();
				stop.Token.ThrowIfCancellationRequested();
				try
				{
					foreach (JToken item in JArray.Parse(await http.GetStringAsync("http://127.0.0.1:" + port + "/json/list").ConfigureAwait(continueOnCapturedContext: false)))
					{
						if ((string?)item["type"] == "page")
						{
							endpoint = (string?)item["webSocketDebuggerUrl"];
							break;
						}
					}
				}
				catch (HttpRequestException)
				{
				}
				catch (TaskCanceledException)
				{
				}
				catch (JsonException)
				{
				}
				if (endpoint == null)
				{
					await Task.Delay(200, cancellation).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			if (endpoint == null)
			{
				throw new InvalidOperationException("Chrome neposkytl místní spojení. Ověř cestu a volný debug port.");
			}
			Uri uri = new Uri(endpoint);
			if (!uri.IsLoopback || uri.Scheme != "ws" || uri.Port != port)
			{
				throw new InvalidOperationException("Neplatné místní spojení Chrome.");
			}
			await cdp.ConnectAsync(uri, cancellation).ConfigureAwait(continueOnCapturedContext: false);
		}
		await cdp.CallAsync("Page.enable", null, cancellation);
		await cdp.CallAsync("Emulation.setDeviceMetricsOverride", new
		{
			width = Width,
			height = Height,
            screenWidth = Width, screenHeight = Height,
			deviceScaleFactor = 1,
			mobile = false
		}, cancellation);
        await cdp.CallAsync("Runtime.enable", null, cancellation);
        await cdp.CallAsync("Runtime.addBinding", new { name="__oasisPcm" }, cancellation);
        await cdp.CallAsync("Page.addScriptToEvaluateOnNewDocument", new { source=AudioCapture.Script }, cancellation);
        await cdp.CallAsync("Page.addScriptToEvaluateOnNewDocument", new { source=BrowserPage.Script }, cancellation);
        status = "Prohlížeč připraven • Chrome bez okna • experimentální zvuk ze zařízení";
	}

	public Task<JObject> Command(string method, object? args, CancellationToken cancellation)
	{
		return cdp.CallAsync(method, args, cancellation);
	}

    public async Task SetViewportAsync(int width, int height, CancellationToken cancellation)
    {
        if (width < 320 || width > 1920 || height < 240 || height > 1920)
            throw new InvalidOperationException("Neplatné rozměry webu.");
        await Command("Emulation.setDeviceMetricsOverride", new {
            width, height, screenWidth = width, screenHeight = height,
            deviceScaleFactor = 1, mobile = false
        }, cancellation).ConfigureAwait(false);
        Width = width; Height = height;
    }

    public async Task<JObject?> FocusedEditableAsync(CancellationToken cancellation)
    {
        var answer=await Command("Runtime.evaluate",new {expression="window.__oasisFocusedEditable ? window.__oasisFocusedEditable() : null",returnByValue=true},cancellation).ConfigureAwait(false);
        return answer["result"]?["value"] as JObject;
    }
    public async Task ConfirmTextAsync(string fieldToken,string text,CancellationToken cancellation)
    {
        if(text.Length>1000)throw new InvalidOperationException("Text je příliš dlouhý.");
        var selected=await Command("Runtime.evaluate",new {expression="window.__oasisSelectEditable && window.__oasisSelectEditable("+JsonConvert.SerializeObject(fieldToken)+")",returnByValue=true},cancellation).ConfigureAwait(false);
        if((bool?)selected["result"]?["value"]!=true)throw new InvalidOperationException("Webové pole už není dostupné. Klikni do něj znovu.");
        await Command("Input.insertText",new {text},cancellation).ConfigureAwait(false);
    }

    public async Task TypeAsync(string text, CancellationToken cancellation)
    {
        foreach (char ch in text)
        {
            if (ch == '\b' || ch == '\r' || ch == '\n')
            {
                string key = ch == '\b' ? "Backspace" : "Enter";
                int code = ch == '\b' ? 8 : 13;
                await Command("Input.dispatchKeyEvent", new { type="keyDown", key, windowsVirtualKeyCode=code }, cancellation).ConfigureAwait(false);
                await Command("Input.dispatchKeyEvent", new { type="keyUp", key, windowsVirtualKeyCode=code }, cancellation).ConfigureAwait(false);
            }
            else if (!char.IsControl(ch))
                await Command("Input.insertText", new { text=ch.ToString() }, cancellation).ConfigureAwait(false);
        }
    }

	public async Task NavigateAsync(string query, CancellationToken cancellation)
	{
        Audio.Clear();
		if ((await Command("Page.navigate", new
		{
			url = Navigation(query)
		}, cancellation))["errorText"] != null)
		{
			throw new InvalidOperationException("Chrome stránku nenačetl. Ověř připojení.");
		}
	}

	public async Task ClickAsync(double x, double y, CancellationToken cancellation)
	{
		if (x < 0.0 || x >= Width || y < 0.0 || y >= Height)
		{
			throw new ArgumentOutOfRangeException();
		}
		await Command("Input.dispatchMouseEvent", new
		{
			type = "mousePressed",
			x = x,
			y = y,
			button = "left",
			clickCount = 1
		}, cancellation);
		await Command("Input.dispatchMouseEvent", new
		{
			type = "mouseReleased",
			x = x,
			y = y,
			button = "left",
			clickCount = 1
		}, cancellation);
	}

	public Task<JObject> ScrollAsync(double amount, CancellationToken cancellation)
	{
		return Command("Input.dispatchMouseEvent", new
		{
			type = "mouseWheel",
			x = Width / 2,
			y = Height / 2,
			deltaX = 0,
			deltaY = Math.Max(-1500.0, Math.Min(1500.0, amount))
		}, cancellation);
	}

	public async Task CaptureAsync(CancellationToken cancellation)
	{
		string text = ((string?)(await Command("Page.captureScreenshot", new
		{
			format = "png",
			fromSurface = true,
			captureBeyondViewport = false
		}, cancellation))["data"]) ?? throw new InvalidOperationException("Chrome nevrátil obraz.");
		if (text.Length > 6291456)
		{
			throw new InvalidOperationException("Obraz překročil limit.");
		}
		Interlocked.Exchange(ref frame, Convert.FromBase64String(text));
	}

    private async Task AcknowledgeFrame(int session)
    {
        try { await cdp.CallAsync("Page.screencastFrameAck", new { sessionId = session }, stop.Token).ConfigureAwait(false); }
        catch (Exception ex) { if (!stop.IsCancellationRequested) Diagnostic?.Invoke("Screencast acknowledgement failed: " + ex.Message); }
    }

    public async Task CaptureLoop(CancellationToken cancellation)
    {
        using var linked = CancellationTokenSource.CreateLinkedTokenSource(cancellation, stop.Token);
        bool started = false;
        try
        {
            await Command("Page.startScreencast", new {
                format = "jpeg", quality = 75, maxWidth = 960, maxHeight = 960, everyNthFrame = 1
            }, linked.Token).ConfigureAwait(false);
            started = true;
            Diagnostic?.Invoke("Continuous JPEG screencast started: 960x540; latest frame only.");
            await Task.Delay(Timeout.Infinite, linked.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException) { }
        catch (Exception ex)
        {
            Diagnostic?.Invoke("Webpage screencast failed: " + ex);
            status = "Přenos obrazu skončil. Restartuj Oasis Browser/hru.";
        }
        finally
        {
            if (started && !stop.IsCancellationRequested)
            {
                try
                {
                    using var timeout = new CancellationTokenSource(2000);
                    await Command("Page.stopScreencast", null, timeout.Token).ConfigureAwait(false);
                }
                catch (Exception) { }
            }
        }
    }

	public async Task CloseAsync()
	{
		if (Interlocked.Exchange(ref closed, 1) != 0)
		{
			return;
		}
		stop.Cancel();
		try
		{
			using CancellationTokenSource timeout = new CancellationTokenSource(2000);
			await cdp.CallAsync("Browser.close", null, timeout.Token);
		}
		catch
		{
		}
		cdp.Dispose();
		try
		{
			if (chrome != null && !chrome.WaitForExit(2000))
			{
				chrome.Kill();
			}
		}
		catch
		{
		}
		chrome?.Dispose();
		try
		{
			if (profile != null)
			{
				Directory.Delete(profile, recursive: true);
			}
		}
		catch
		{
		}
	}

	public void Dispose()
	{
		Task.Run((Func<Task>)CloseAsync);
	}
}
