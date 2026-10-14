using System;
namespace OasisBrowser;
public sealed class PcmBuffer
{
    private readonly object gate = new object();
    private readonly float[] ring = new float[4800];
    private int read, count;
    public int Count { get { lock(gate) return count; } }
    public void Clear() { lock(gate) { read=0;count=0; } }
    public void Write(byte[] bytes)
    {
        if(bytes.Length%2!=0 || bytes.Length>32768) return;
        lock(gate)
        {
            for(int i=0;i<bytes.Length;i+=2)
            {
                if(count==ring.Length) { read=(read+1)%ring.Length;count--; }
                ring[(read+count)%ring.Length]=(short)(bytes[i]|(bytes[i+1]<<8))/32768f;count++;
            }
        }
    }
    public void Read(float[] output)
    {
        lock(gate) for(int i=0;i<output.Length;i++)
        { if(count==0) output[i]=0; else {output[i]=ring[read];read=(read+1)%ring.Length;count--;}}
    }
}
