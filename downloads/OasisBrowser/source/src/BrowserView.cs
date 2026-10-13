using System;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace OasisBrowser;

public sealed class BrowserView : MonoBehaviour
{
	public BrowserEngine? Browser;
    public Component? Owner;
    public bool AudioEnabled;
    private AudioSource? source;
    private AudioClip? audioClip;
    public bool ActiveScreen
    {
        get
        {
            if(Owner==null) return gameObject.activeInHierarchy;
            bool hasOn=OwnerPatch.Member(Owner,"HasOnState") is bool flag && flag;
            bool hasPower=OwnerPatch.Member(Owner,"HasPoweredState") is bool powerFlag && powerFlag;
            bool? on=(OwnerPatch.Member(Owner,"On")??OwnerPatch.Member(Owner,"IsOn")) as bool?;
            bool? power=(OwnerPatch.Member(Owner,"Powered")??OwnerPatch.Member(Owner,"IsPowered")) as bool?;
            return PanelPower.IsActive(gameObject.activeInHierarchy || Owner.gameObject.activeInHierarchy,hasOn,on,hasPower,power);
        }
    }
    private void Update()
    {
        if(!AudioEnabled || !ActiveScreen || Owner==null || Browser==null)
        { if(source!=null && source.isPlaying)source.Stop(); return; }
        if(source==null)
        {
            var go=new GameObject("OasisBrowserDeviceAudio");
            go.transform.SetParent(Owner.transform,false);
            source=go.AddComponent<AudioSource>();source.playOnAwake=false;
            source.spatialBlend=1;source.rolloffMode=AudioRolloffMode.Logarithmic;
            source.minDistance=1;source.maxDistance=20;source.volume=0.6f;source.loop=true;
            audioClip=AudioClip.Create("OasisBrowser PCM",24000,1,24000,true,ReadAudio);
            source.clip=audioClip;
        }
        if(!source.isPlaying && Browser.Audio.Count>=2048) source.Play();
    }
    private void ReadAudio(float[] data)
    { if(Browser!=null) Browser.Audio.Read(data);else Array.Clear(data,0,data.Length); }

	private Component? image;

	private Texture2D? texture;

	private MethodInfo? loadImage;

	private readonly ClickGate clickGate=new ClickGate();
    private bool pointerLogged;

	public static Type? FindType(string fullName)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			Type type = assemblies[i].GetType(fullName, throwOnError: false);
			if (type != null)
			{
				return type;
			}
		}
		return null;
	}

	public void Initialize(BrowserEngine browser)
	{
		Browser = browser;
		Type type = FindType("UnityEngine.UI.RawImage");
		Type type2 = FindType("UnityEngine.EventSystems.EventTrigger");
		Type type3 = FindType("UnityEngine.EventSystems.BaseEventData");
		if (type == null || type2 == null || type3 == null)
		{
			throw new InvalidOperationException("Unity UI typy nebyly nalezeny.");
		}
		image = base.gameObject.AddComponent(type);
		type.GetProperty("color").SetValue(image, Color.white);
		type.GetProperty("raycastTarget").SetValue(image, true);
		texture = new Texture2D(1280, 720, TextureFormat.RGBA32, mipChain: false);
		type.GetProperty("texture").SetValue(image, texture);
		loadImage = (FindType("UnityEngine.ImageConversion") ?? Type.GetType("UnityEngine.ImageConversion, UnityEngine.ImageConversionModule", throwOnError: false))?.GetMethod("LoadImage", new Type[3]
		{
			typeof(Texture2D),
			typeof(byte[]),
			typeof(bool)
		});
		if (loadImage == null)
		{
			throw new InvalidOperationException("Unity ImageConversion není dostupné.");
		}
		Component obj = base.gameObject.AddComponent(type2);
		IList entries = (IList)type2.GetProperty("triggers").GetValue(obj);
        AddEvent(type2, type3, entries, "PointerDown", "Pressed");
		AddEvent(type2, type3, entries, "PointerClick", "Clicked");
		AddEvent(type2, type3, entries, "Scroll", "Scrolled");
	}

	private void AddEvent(Type trigger, Type eventData, IList entries, string id, string handler)
	{
		Type nestedType = trigger.GetNestedType("Entry");
		object obj = Activator.CreateInstance(nestedType);
		FieldInfo field = nestedType.GetField("eventID");
		field.SetValue(obj, Enum.Parse(field.FieldType, id));
		object value = nestedType.GetField("callback").GetValue(obj);
		MethodInfo method = value.GetType().GetMethod("AddListener");
		Type parameterType = method.GetParameters()[0].ParameterType;
		MethodInfo method2 = GetType().GetMethod(handler).MakeGenericMethod(eventData);
		method.Invoke(value, new object[1] { Delegate.CreateDelegate(parameterType, this, method2) });
		entries.Add(obj);
	}

	public void Render(byte[] bytes)
	{
		if (texture != null && loadImage != null)
		{
			loadImage.Invoke(null, new object[3] { texture, bytes, false });
		}
	}

    public void Pressed<T>(T e)
    { if(clickGate.Down(Time.realtimeSinceStartupAsDouble)) SendPointer(e,"down"); }
    public void Clicked<T>(T e)
    { if(clickGate.Click(Time.realtimeSinceStartupAsDouble)) SendPointer(e,"click"); }
    private void SendPointer<T>(T e,string phase)
    {
        if(Browser==null || e==null)return;
        if(!pointerLogged)BrowserLog.Info("Browser pointer event received: "+phase);
		try
		{
			object obj = e;
			Type type = obj.GetType();
			Vector2 vector = (Vector2)type.GetProperty("position").GetValue(obj);
			object? value = type.GetProperty("pressEventCamera")?.GetValue(obj) ?? type.GetProperty("enterEventCamera")?.GetValue(obj);
            if(value==null)
            {
                var canvasType=FindType("UnityEngine.Canvas");
                var canvas=canvasType==null?null:GetComponentInParent(canvasType);
                if(canvas!=null)value=canvasType!.GetProperty("worldCamera")?.GetValue(canvas);
            }
			RectTransform rectTransform = (RectTransform)base.transform;
			MethodInfo method = FindType("UnityEngine.RectTransformUtility").GetMethod("ScreenPointToLocalPointInRectangle", new Type[4]
			{
				typeof(RectTransform),
				typeof(Vector2),
				typeof(Camera),
				typeof(Vector2).MakeByRefType()
			});
			object[] array = new object[4]
			{
				rectTransform,
				vector,
				value,
				default(Vector2)
			};
			if ((bool)method.Invoke(null, array))
			{
				Vector2 vector2 = (Vector2)array[3];
				Rect rect = rectTransform.rect;
                if(rect.width<=0 || rect.height<=0)throw new InvalidOperationException("Browser rectangle is empty.");
				double val = (vector2.x - rect.xMin) / rect.width * 1280f;
				double val2 = (rect.yMax - vector2.y) / rect.height * 720f;
                if(!pointerLogged)BrowserLog.Info("Pointer mapped to Chrome: "+val+","+val2+" camera="+(value==null?"none":value.GetType().Name));
                pointerLogged=true;
				Browser.ClickAsync(Math.Max(0.0, Math.Min(1279.0, val)), Math.Max(0.0, Math.Min(719.0, val2)), CancellationToken.None).ContinueWith(delegate(Task t)
				{
					_ = t.Exception;
				});
			}
		}
		catch(Exception ex)
		{
            BrowserLog.Error("Browser pointer conversion failed: "+ex);
		}
	}

	public void Scrolled<T>(T e)
	{
		if (Browser == null || e == null)
		{
			return;
		}
		try
		{
			object obj = e;
			Vector2 vector = (Vector2)obj.GetType().GetProperty("scrollDelta").GetValue(obj);
			Browser.ScrollAsync((0f - vector.y) * 150f, CancellationToken.None).ContinueWith(delegate(Task<JObject> t)
			{
				_ = t.Exception;
			});
		}
		catch
		{
		}
	}

	private void OnDestroy()
	{
        if(source!=null) UnityEngine.Object.Destroy(source.gameObject);
        if(audioClip!=null) UnityEngine.Object.Destroy(audioClip);
		if (texture != null)
		{
			UnityEngine.Object.Destroy(texture);
		}
	}
}
