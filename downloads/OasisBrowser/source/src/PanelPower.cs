namespace OasisBrowser;
public static class PanelPower
{
    // Generic items expose On/Powered even when they have no such interactive state.
    public static bool IsActive(bool hierarchyActive,bool hasOnState,bool? on,bool hasPoweredState,bool? powered)
        =>hierarchyActive && (!hasOnState || on!=false) && (!hasPoweredState || powered!=false);
}
