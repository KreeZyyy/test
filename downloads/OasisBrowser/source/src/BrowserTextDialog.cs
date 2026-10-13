using System;
using System.Linq;
using System.Reflection;
namespace OasisBrowser;
internal static class BrowserTextDialog
{
    public static bool Show(string initial, Action<string> confirmed)
    {
        var type=BrowserView.FindType("Assets.Scripts.UI.InputWindow");
        if(type==null || type.GetField("Instance",BindingFlags.Static|BindingFlags.Public)?.GetValue(null)==null)return false;
        object? state=type.GetField("InputState",BindingFlags.Static|BindingFlags.Public)?.GetValue(null)
            ??type.GetProperty("InputState",BindingFlags.Static|BindingFlags.Public)?.GetValue(null);
        if(state?.ToString()!="None")return false;
        var show=type.GetMethods(BindingFlags.Static|BindingFlags.Public).FirstOrDefault(m=>m.Name=="ShowInputPanel" && m.GetParameters().Length==4 && m.GetParameters()[2].ParameterType==typeof(Action<string,string>));
        if(show==null)return false;
        Action<string,string> callback=(text,unused)=>confirmed(text);
        show.Invoke(null,new object[]{"Oasis Browser • text do webu",initial,callback,600});
        return true;
    }
}
