using System;
using BepInEx.Logging;
namespace OasisBrowser;
internal static class BrowserLog
{
    static ManualLogSource? log;
    public static void Initialize()=>log=BepInEx.Logging.Logger.CreateLogSource("OasisBrowser");
    public static void Info(string text)=>log?.LogInfo(text);
    public static void Warn(string text)=>log?.LogWarning(text);
    public static void Error(string text)=>log?.LogError(text);
}
