namespace OasisBrowser;
public static class BrowserPage
{
    // Fullscreen stays inside the captured viewport instead of resizing a hidden OS window.
    public const string Script = @"(() => {
if (window.__oasisPageInstalled) return;
window.__oasisPageInstalled = true;
let expanded = null;
const fullscreenGetter = Object.getOwnPropertyDescriptor(Document.prototype, 'fullscreenElement');
const originalRequest = Element.prototype.requestFullscreen;
const originalExit = document.exitFullscreen.bind(document);
const style = document.createElement('style');
style.textContent = '.oasis-full-window{position:fixed!important;inset:0!important;width:100vw!important;height:100vh!important;max-width:none!important;max-height:none!important;margin:0!important;z-index:2147483646!important;background:black!important;transform:none!important;overflow:hidden!important}.oasis-full-window .html5-video-container{position:absolute!important;inset:0!important;width:100%!important;height:100%!important}.oasis-full-window video{position:absolute!important;inset:0!important;width:100%!important;height:100%!important;object-fit:contain!important;transform:none!important}video.oasis-full-window{object-fit:contain!important}';
const installStyle = () => { if (!style.isConnected && document.documentElement) document.documentElement.appendChild(style); };
installStyle();document.addEventListener('DOMContentLoaded',installStyle,{once:true});
Object.defineProperty(document,'fullscreenElement',{configurable:true,get:()=>expanded || (fullscreenGetter ? fullscreenGetter.get.call(document) : null)});
function changed(){document.dispatchEvent(new Event('fullscreenchange'));}
function leave(){if(expanded){expanded.classList.remove('oasis-full-window');expanded=null;changed();return true;}return false;}
Element.prototype.requestFullscreen = function(options){
 if(this.matches('video') || this.querySelector('video')){
  leave();installStyle();expanded=this;this.classList.add('oasis-full-window');changed();return Promise.resolve();
 }
 return originalRequest.call(this,options);
};
document.exitFullscreen = function(){return leave()?Promise.resolve():originalExit();};
window.__oasisVideoMode = async () => {
 if(expanded){leave();return true;}
 if(location.pathname!=='/watch')return false;
 const video=document.querySelector('#movie_player video');
 if(!video || !video.videoWidth)return false;
 await document.getElementById('movie_player').requestFullscreen();return true;
};
document.addEventListener('keydown',e=>{if(e.key==='Escape'&&expanded){leave();e.preventDefault();}},true);
window.__oasisFocusedEditable = () => {
 const e=document.activeElement;
 const editable=e && (e.isContentEditable || e.tagName==='TEXTAREA' || (e.tagName==='INPUT' && ['text','search','email','url','tel','number'].includes(e.type)));
 if(!editable || e.disabled || e.readOnly) {window.__oasisEditable=null;return null;}
 const token=String(Date.now())+'-'+Math.random();
 window.__oasisEditable={element:e,token};
 return {token,value:e.isContentEditable?e.textContent:e.value};
};
window.__oasisSelectEditable = token => {
 const target=window.__oasisEditable;
 if(!target || target.token!==token || !target.element.isConnected)return false;
 const e=target.element;e.focus();
 if(typeof e.select==='function')e.select();
 else {const range=document.createRange();range.selectNodeContents(e);const selection=getSelection();selection.removeAllRanges();selection.addRange(range);}
 return true;
};
})();";
}
