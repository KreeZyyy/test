using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using HarmonyLib;
using UnityEngine;
namespace OasisBrowser;
internal static class OwnerPatch
{
    public static readonly Dictionary<int,Component> Owners=new Dictionary<int,Component>();
    public static object? Member(object obj,string name)
    { try { return obj.GetType().GetField(name)?.GetValue(obj)??obj.GetType().GetProperty(name)?.GetValue(obj); } catch { return null; } }
    public static bool Install()
    {
        var type=AccessTools.TypeByName("ScriptedScreens.ScriptableUi.ScriptedScreensScriptableUiSystem");
        var target=type?.GetMethods(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance)
            .FirstOrDefault(m=>m.Name=="ApplyElementInternal" && m.GetParameters().Any(p=>p.ParameterType.Name=="UiElement"));
        if(target==null) return false;
        var parameters=target.GetParameters();
        stateIndex=Array.FindIndex(parameters,p=>p.Name=="state" || p.ParameterType.Name=="BoardState");
        elementIndex=Array.FindIndex(parameters,p=>p.Name=="element" || p.ParameterType.Name=="UiElement");
        surfaceIndex=Array.FindIndex(parameters,p=>p.Name=="surface");
        if(stateIndex<0 || elementIndex<0 || surfaceIndex<0)return false;
        new Harmony("kreezyyy.oasisbrowser.owner").Patch(target,postfix:new HarmonyMethod(typeof(OwnerPatch),nameof(Applied)));
        return true;
    }
    static int stateIndex,elementIndex,surfaceIndex;
    static void Applied(object[] __args)
    {
        try
        {
            var state=__args[stateIndex];var element=__args[elementIndex];var surface=__args[surfaceIndex] as string;
            if(state==null || element==null || surface==null)return;
            if((string?)Member(element,"Id")!="oasis_browser_view")return;
            var tables=Member(state,"SurfaceElementRoots") as IDictionary;
            var roots=tables?[surface] as IDictionary;
            var host=roots?["oasis_browser_view"] as GameObject;
            var owner=__args.OfType<Component>().FirstOrDefault();
            if(host!=null && owner!=null) Owners[host.GetInstanceID()]=owner;
        } catch(Exception e) { Debug.LogWarning("Oasis Browser owner probe: "+e.Message); }
    }
}
