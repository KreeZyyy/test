namespace OasisBrowser;
public static class AudioCapture
{
    public const string Script = @"(() => {
      if(window.__oasisCaptureInstalled) return;
      window.__oasisCaptureInstalled=true;
      const hooked=new WeakSet(); let context;
      function report(kind,v,extra) {
        if(typeof window.__oasisMedia!=='function')return;
        window.__oasisMedia(JSON.stringify({kind,error:v && v.error?v.error.code:0,network:v?v.networkState:0,ready:v?v.readyState:0,detail:extra||''}));
      }
      function hook(v) {
        if(hooked.has(v)) return;
        try {
          context=context||new AudioContext({sampleRate:24000,latencyHint:'interactive'});
          const src=context.createMediaElementSource(v);
          const proc=context.createScriptProcessor(1024,2,1);
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
          ['pause','seeking','emptied','ended'].forEach(event=>v.addEventListener(event,()=>report('reset',v)));
          v.addEventListener('play',()=>context.resume().catch(()=>report('audio_resume_failed',v)));
          report('audio_hooked',v,'sampleRate='+context.sampleRate+' baseLatency='+context.baseLatency);

          document.addEventListener('pointerdown',()=>context.resume().catch(()=>{}));
          if(!v.paused) context.resume().catch(()=>{});
          hooked.add(v);
        } catch(e) { report('audio_hook_failed',v,e.name); console.warn('Oasis audio capture failed',e.message); }
      }
      function scan(){ document.querySelectorAll('video,audio').forEach(hook); }
      new MutationObserver(scan).observe(document,{childList:true,subtree:true});
      document.addEventListener('DOMContentLoaded',scan);scan();
    })();";
    public const string MonitorScript = @"(() => {
      if(window.__oasisMonitorInstalled)return;
      window.__oasisMonitorInstalled=true;
      function report(kind,v,detail){
        if(typeof window.__oasisMedia==='function')window.__oasisMedia(JSON.stringify({kind,error:v&&v.error?v.error.code:0,network:v?v.networkState:0,ready:v?v.readyState:0,detail:detail||''}));
      }
      const watched=new WeakSet();
      function scan(){document.querySelectorAll('video,audio').forEach(v=>{if(watched.has(v))return;watched.add(v);v.addEventListener('error',()=>report('media_error',v));});}
      new MutationObserver(scan).observe(document,{childList:true,subtree:true});
      document.addEventListener('DOMContentLoaded',scan);scan();
      let lastError='';
      setInterval(()=>{
        const e=document.querySelector('.ytp-error-content-wrap');
        const message=e && e.getClientRects().length && getComputedStyle(e).visibility!=='hidden'?(e.textContent||'').trim().slice(0,250):'';
        if(message && message!==lastError)report('player_error',document.querySelector('video'),message);
        lastError=message;
      },2000);
    })();";

}
