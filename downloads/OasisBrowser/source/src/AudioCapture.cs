namespace OasisBrowser;
public static class AudioCapture
{
    public const string Script = @"(() => {
      if(window.__oasisCaptureInstalled) return;
      window.__oasisCaptureInstalled=true;
      const hooked=new WeakSet(); let context;
      function hook(v) {
        if(hooked.has(v)) return;
        try {
          context=context||new AudioContext({sampleRate:24000});
          const src=context.createMediaElementSource(v);
          const proc=context.createScriptProcessor(4096,2,1);
          const mute=context.createGain(); mute.gain.value=0;
          proc.onaudioprocess=e=>{
            if(v.paused||v.ended) return;
            const a=e.inputBuffer.getChannelData(0);
            const b=e.inputBuffer.numberOfChannels>1?e.inputBuffer.getChannelData(1):a;
            const bytes=new Uint8Array(a.length*2);
            for(let i=0;i<a.length;i++){
              const s=Math.round(Math.max(-1,Math.min(1,(a[i]+b[i])*0.5))*32767);
              bytes[2*i]=s&255;bytes[2*i+1]=(s>>8)&255;
            }
            window.__oasisPcm(btoa(String.fromCharCode.apply(null,bytes)));
          };
          src.connect(proc);proc.connect(mute);mute.connect(context.destination);
          v.addEventListener('play',()=>context.resume().catch(()=>{}));
          document.addEventListener('pointerdown',()=>context.resume().catch(()=>{}));
          if(!v.paused) context.resume().catch(()=>{});
          hooked.add(v);
        } catch(e) { console.warn('Oasis audio capture failed',e.message); }
      }
      function scan(){ document.querySelectorAll('video,audio').forEach(hook); }
      new MutationObserver(scan).observe(document,{childList:true,subtree:true});
      document.addEventListener('DOMContentLoaded',scan);scan();
    })();";
}
