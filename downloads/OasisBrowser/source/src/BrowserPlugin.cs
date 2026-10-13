using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using StationeersMods.Interface;
using UnityEngine;

namespace OasisBrowser;

[StationeersMod("kreezyyy.stationeers.oasisbrowser", "Oasis Browser", "0.2.2")]
public sealed class BrowserPlugin : ModBehaviour
{
	internal static BrowserPlugin? Current;
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
    private bool firstFrame;

	public override void OnLoaded(ContentHandler handler)
	{
        BrowserLog.Initialize();Current=this;
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
            bridge.Diagnostic=BrowserLog.Info;
			bridge.Start();
            headless=Config.Bind("Browser","Hidden",true,"Run Chrome without a visible window. Normal Chrome sandbox remains enabled. Restart after changes.").Value;
            if(!OwnerPatch.Install()) BrowserLog.Warn("Oasis Browser: ownership hook unavailable; in-game positional audio cannot be attached.");
            BrowserLog.Info("Oasis Browser 0.2.2: waiting for an active browser panel; no Chrome process started yet.");
		}
		catch(Exception ex)
		{
			bridge?.Dispose();
			browser?.Dispose();
			BrowserLog.Error("Oasis Browser initialization failed: "+ex);
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
                OwnerPatch.Owners.TryGetValue(gameObject.GetInstanceID(),out var owner);
                AttachHost(gameObject,owner);
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
        if(!firstFrame) { firstFrame=true;BrowserLog.Info("First webpage image received: "+array2.Length+" bytes; views="+views.Count); }
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
				BrowserLog.Warn("Oasis Browser: webpage texture update failed.");
			}
		}
	}

    internal void AttachHost(GameObject host,Component? owner)
    {
        if(browser==null)return;
        GameObject? child=null;
        try
        {
            var imageType=BrowserView.FindType("UnityEngine.UI.Image");
            var fallback=imageType==null?null:host.GetComponent(imageType);
            if(fallback!=null)
            {
                imageType!.GetProperty("color")?.SetValue(fallback,Color.clear);
                imageType.GetProperty("raycastTarget")?.SetValue(fallback,false);
            }
            var existing=host.GetComponentInChildren<BrowserView>(true);
            if(existing!=null) { if(owner!=null)existing.Owner=owner;if(!views.Contains(existing))views.Add(existing);return; }
            child=new GameObject("OasisBrowserImage",typeof(RectTransform));child.layer=host.layer;
            child.transform.SetParent(host.transform,false);
            var rect=(RectTransform)child.transform;rect.anchorMin=Vector2.zero;rect.anchorMax=Vector2.one;rect.offsetMin=Vector2.zero;rect.offsetMax=Vector2.zero;
            var view=child.AddComponent<BrowserView>();view.Owner=owner;view.Initialize(browser);views.Add(view);
            BrowserLog.Info("Panel attached. UI active="+host.activeInHierarchy+" owner="+(owner?.GetType().FullName??"unknown")+" hasOnState="+(owner==null?"unknown":OwnerPatch.Member(owner,"HasOnState")?.ToString()??"unknown"));
        }
        catch(Exception ex) { if(child!=null)Destroy(child);BrowserLog.Error("Panel attachment failed: "+ex); }
    }
    private void StartBrowser()
    {
        BrowserLog.Info("Starting Chrome for active panel. Hidden="+headless+" DebugPort="+debugPort);
        browser=new BrowserEngine();browser.Diagnostic=BrowserLog.Error;bridge!.SetEngine(browser);
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
                bridge.Ready=true;BrowserLog.Info("Chrome connected; YouTube navigation accepted; starting image capture.");
                await engine.CaptureLoop(cancellation);
            }
            catch(OperationCanceledException) { }
            catch(Exception e) { bridge.StartupError=e.Message;BrowserLog.Error("Browser startup/connection failed: "+e); }
        });
    }
    private void StopBrowser()
    {
        BrowserLog.Info("No active panel; closing browser session.");
        started=false;firstFrame=false;run?.Cancel();bridge!.Ready=false;
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
