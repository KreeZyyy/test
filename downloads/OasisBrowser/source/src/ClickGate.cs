namespace OasisBrowser;
public sealed class ClickGate
{
    private bool downSeen;
    private double next;
    public bool Down(double now)
    {
        downSeen=true;
        if(now<next)return false;
        next=now+0.15;return true;
    }
    public bool Click(double now)
    {
        if(downSeen){downSeen=false;return false;}
        if(now<next)return false;
        next=now+0.15;return true;
    }
}
