using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using StationeersMods.Interface;
using UnityEngine;

namespace OasisBrowser;

[StationeersMod("kreezyyy.stationeers.oasisbrowser", "Oasis Browser", "0.2.0")]
public sealed class BrowserPlugin : ModBehaviour
{
	private BrowserEngine? browser;

	private BrowserBridge? bridge;

	private readonly CancellationTokenSource stop = new CancellationTokenSource();

	private readonly List<BrowserView> views = new List<BrowserView>();

	private float nextScan;
    private string executable="";
    private int debugPort;
    private bool headless=true,started;
    private CancellationTokenSource? run;
    private Task closing=Task.CompletedTask;
    private float inactiveSince=-1;

	public override void OnLoaded(ContentHandler handler)
	{
		base.OnLoaded(handler);
		if (browser != null || Application.isBatchMode)
		{
			return;
		}
		try
		{
			if (base.Config == null)
			{
				throw new InvalidOperationException();
			}
			executable = base.Config.Bind("Browser", "ChromePath", FindChrome(), "Dedicated temporary profile; never uses your personal Chrome profile. Restart after changes.").Value;
			debugPort = base.Config.Bind("Browser", "DebugPort", 9223, "Chrome loopback debugging port. Keep local. Restart after changes.").Value;
			int value = base.Config.Bind("Bridge", "Port", 18767, "Local control bridge. Restart after changes.").Value;
			string value2 = base.Config.Bind("Bridge", "Token", Guid.NewGuid().ToString("N"), "Copy only this Oasis Browser token into browser.lua.").Value;
			browser = new BrowserEngine();
			bridge = new BrowserBridge(browser, value2, value);
			bridge.Start();
            headless=Config.Bind("Browser","Hidden",true,"Run Chrome without a visible window. Normal Chrome sandbox remains enabled. Restart after changes.").Value;
            if(!OwnerPatch.Install()) Debug.LogWarning("Oasis Browser: ownership hook unavailable; in-game positional audio cannot be attached.");
            Debug.Log("Oasis Browser 0.2.0: waiting for an active browser panel; no Chrome process started yet.");
		}
		catch
		{
			bridge?.Dispose();
			browser?.Dispose();
			Debug.LogError("Oasis Browser: bridge startup failed. Check ports and configuration.");
		}
	}

	private static string FindChrome()
	{
		string[] array = new string[3]
		{
			Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
			Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
		};
		foreach (string text in array)
		{
			string text2 = Path.Combine(text, "Google", "Chrome", "Application", "chrome.exe");
			if (File.Exists(text2))
			{
				return text2;
			}
		}
		return "";
	}

	private void Update()
	{
		if (browser == null)
		{
			return;
		}
		if (Time.realtimeSinceStartup >= nextScan)
		{
			nextScan = Time.realtimeSinceStartup + 1f;
			views.RemoveAll((BrowserView v) => v == null);
			GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
			foreach (GameObject gameObject in array)
			{
				if (gameObject.name != "Ui:oasis_browser_view" || gameObject.GetComponentInChildren<BrowserView>() != null)
				{
					continue;
				}
				try
				{
					Type type = BrowserView.FindType("UnityEngine.UI.Image");
					Component component = ((type == null) ? null : gameObject.GetComponent(type));
					if (component != null)
					{
						type.GetProperty("color").SetValue(component, Color.clear);
						type.GetProperty("raycastTarget").SetValue(component, false);
					}
					GameObject obj = new GameObject("OasisBrowserImage", typeof(RectTransform));
					obj.layer = gameObject.layer;
					obj.transform.SetParent(gameObject.transform, worldPositionStays: false);
					RectTransform obj2 = (RectTransform)obj.transform;
					obj2.anchorMin = Vector2.zero;
					obj2.anchorMax = Vector2.one;
					obj2.offsetMin = Vector2.zero;
					obj2.offsetMax = Vector2.zero;
					BrowserView browserView = obj.AddComponent<BrowserView>();
                    if(OwnerPatch.Owners.TryGetValue(gameObject.GetInstanceID(),out var owner))browserView.Owner=owner;
					browserView.Initialize(browser);
					views.Add(browserView);
				}
				catch
				{
					Debug.LogWarning("Oasis Browser: could not attach webpage to ScriptedScreens host.");
				}
			}
		}
        BrowserView? active=null;
        foreach(var v in views)
        {
            if(v!=null && v.Owner==null && v.transform.parent!=null && OwnerPatch.Owners.TryGetValue(v.transform.parent.gameObject.GetInstanceID(),out var owner))v.Owner=owner;
            if(v!=null && v.ActiveScreen && active==null)active=v;
            if(v!=null)v.AudioEnabled=v==active;
        }
        if(active!=null) { inactiveSince=-1; if(!started && closing.IsCompleted)StartBrowser(); }
        else if(started)
        {
            if(inactiveSince<0)inactiveSince=Time.realtimeSinceStartup;
            if(Time.realtimeSinceStartup-inactiveSince>10)StopBrowser();
        }
        if(active==null || active.Owner==null)browser.Audio.Clear();
		byte[] array2 = browser.TakeFrame();
		if (array2 == null)
		{
			return;
		}
		foreach (BrowserView view in views)
		{
			try
			{
				if (view != null)
				{
					view.Render(array2);
				}
			}
			catch
			{
				Debug.LogWarning("Oasis Browser: webpage texture update failed.");
			}
		}
	}

    private void StartBrowser()
    {
        browser=new BrowserEngine();bridge!.SetEngine(browser);
        foreach(var v in views)if(v!=null)v.Browser=browser;
        started=true;run=CancellationTokenSource.CreateLinkedTokenSource(stop.Token);
        var engine=browser;var cancellation=run.Token;
        Task.Run(async ()=>
        {
            try
            {
                await engine.StartAsync(executable,debugPort,cancellation,headless);
                await engine.NavigateAsync("https://www.youtube.com/",cancellation);
                if(cancellation.IsCancellationRequested)return;
                bridge.Ready=true;
                await engine.CaptureLoop(cancellation);
            }
            catch(OperationCanceledException) { }
            catch(Exception e) { bridge.StartupError=e.Message;Debug.LogError("Oasis Browser: "+e.Message); }
        });
    }
    private void StopBrowser()
    {
        started=false;run?.Cancel();bridge!.Ready=false;
        var engine=browser;closing=Task.Run(async()=> { if(engine!=null)await engine.CloseAsync(); });
    }
	private void OnDestroy()
	{
		stop.Cancel();run?.Cancel();
		bridge?.Dispose();
		try
		{
			browser?.CloseAsync().Wait(3000);
		}
		catch
		{
		}
		foreach (BrowserView view in views)
		{
			if (view != null)
			{
				Destroy(view.gameObject);
			}
		}
	}
}
