-- Oasis Media 0.1.0: local world/session host. Separate token from Oasis chat!
local TOKEN = "PASTE_OASIS_MEDIA_TOKEN_HERE"
local BASE = "http://localhost:18766"
local headers = {["X-Oasis-Media-Token"]=TOKEN}
local ui = ss.ui.surface("oasis_media")
ss.ui.activate("oasis_media")
ui:set_resolution(0,0)
local n=ui:size() or {w=800,h=600}
if n.w>0 and n.w<960 then ui:set_resolution(960,math.floor(n.h*960/n.w)) end
local size=ui:size() or n
local W,H=size.w,size.h
local S=math.min(W/800,H/600)
local M=18*S
local question,request,job,elapsed,poll_elapsed,playing="",nil,nil,0,0,false
local request_kind,video_path=nil,nil
local volume=0.7
ui:clear()
local function el(id,kind,x,y,w,h,props,events)
 local d={id=id,type=kind,rect={unit="px",x=x,y=y,w=w,h=h},props=props or {},style={bg="#143238",color="#E7FFF6",text="#E7FFF6",font_size=17*S}}
 for k,v in pairs(events or {}) do d[k]=v end
 return ui:element(d)
end
el("bg","panel",0,0,W,H,{},nil)
el("title","label",M,12*S,W-2*M,32*S,{text="O A S I S  /  MEDIA"})
local status=el("status","label",M,46*S,W-2*M,26*S,{text="YouTube prototyp • veřejné MP4 • max. 128 MB"})
local vy,vh=82*S,H-82*S-142*S
local vw=math.min(W-2*M,vh*16/9)
local video=el("video","media",(W-vw)/2,vy,vw,vh,{url="",playing="false",volume=tostring(volume),loop="false"})
local function set_status(text) status:set_props({text=tostring(text):gsub("<","‹"):gsub(">","›")});ui:commit() end
local function finish(text) request,job,request_kind=nil,nil,nil;set_status(text) end
local input
local function load_video()
 if request or job then return end
 if TOKEN=="PASTE_OASIS_MEDIA_TOKEN_HERE" then set_status("Nejdřív vlož Bridge.Token z nastavení Oasis Media.");return end
 if not question:match("%S") then set_status("Vlož odkaz na jedno YouTube video.");return end
 if not ic.http then set_status("Zapni AllowHttp a AllowHttpLocalhost ve StationeersLua.");return end
 local ok,id=pcall(ic.http.post,BASE.."/resolve",util.json.encode({url=question}),"application/json",headers,10)
 if not ok then set_status("HTTP není dostupné. Zkontroluj StationeersLua.");return end
 request,request_kind,elapsed=id,"submit",0
 set_status("Připravuji video… může to trvat až 3 minuty.")
end
local iy=H-126*S
input=el("url","textinput",M,iy,W-2*M-132*S,38*S,{value="",placeholder="https://www.youtube.com/watch?v=…",title="YouTube odkaz"},{on_change=function(v) question=tostring(v or "");input:set_props({value=question});ui:commit() end})
el("load","button",W-M-122*S,iy,122*S,38*S,{text="Načíst video"},{on_click=load_video})
local pause
pause=el("pause","button",M,H-76*S,130*S,32*S,{text="Play / Pauza"},{on_click=function()
 if not video_path then return end
 playing=not playing;video:set_props({playing=tostring(playing)});set_status(playing and "Přehrávání zapnuto" or "Pozastaveno")
end})
el("stop","button",M+140*S,H-76*S,85*S,32*S,{text="Stop"},{on_click=function()
 if request or job then set_status("Příprava ještě běží. Stop zastaví pouze přehrávání.");return end
 playing=false;video:set_props({playing="false",time="0"});set_status("Zastaveno")
end})
local volume_label=el("volume","label",M+240*S,H-73*S,100*S,26*S,{text="Zvuk: 70 %"})
local function adjust(amount)
 volume=math.max(0,math.min(1,volume+amount));video:set_props({volume=tostring(volume)});volume_label:set_props({text="Zvuk: "..math.floor(volume*100+0.5).." %"});ui:commit()
end
el("quieter","button",M+345*S,H-76*S,44*S,32*S,{text="−"},{on_click=function() adjust(-0.1) end})
el("louder","button",M+399*S,H-76*S,44*S,32*S,{text="+"},{on_click=function() adjust(0.1) end})
el("note","label",M,H-34*S,W-2*M,22*S,{text="Zapni ScriptedScreens: EnableExperimentalVideo + AllowMediaPlayback"})
ui:commit()
function tick(dt)
 dt=tonumber(dt) or 0
 if not request and not job then return end
 elapsed=elapsed+dt;poll_elapsed=poll_elapsed+dt
 if elapsed>195 then finish("Časový limit. Zkontroluj yt-dlp a zkus jiné krátké video.");return end
 if request then
  for i=1,8 do
   local polled,id,ok,code,body,err=pcall(ic.http.poll)
   if not polled then finish("HTTP poll není dostupné.");return end
   if not id then break end
   if id==request then
    request=nil
    local decoded,data=pcall(util.json.decode,body or "")
    if not decoded or type(data)~="table" then finish("Mod nevrátil platnou odpověď. Zkontroluj Oasis Media a port 18766.");return end
    if not ok or code<200 or code>=300 then finish(data.error or "Spojení s Oasis Media selhalo.");return end
    if request_kind=="submit" then
     if type(data.id)~="string" then finish("Chybí ID úlohy.");return end
     job=data.id;poll_elapsed=1
    elseif data.state=="done" then
     if type(data.path)~="string" or not data.path:match("^/media/%x+%.mp4$") then finish("Neplatná cesta videa.");return end
     video_path=BASE..data.path;playing=true
     video:set_props({url=video_path,playing="true",time="0",volume=tostring(volume)})
     finish("Video připraveno: "..tostring(data.title or "YouTube").." • spuštění řeší ScriptedScreens")
     return
    elseif data.state=="error" then finish(data.error or "Příprava selhala.");return
    elseif data.state~="pending" then finish("Neznámý stav přípravy.");return end
   end
  end
 end
 if job and not request and poll_elapsed>=1 then
  poll_elapsed=0
  local ok,id=pcall(ic.http.get,BASE.."/jobs/"..job,headers,10)
  if not ok then finish("Nepodařilo se zkontrolovat přípravu.");return end
  request,request_kind=id,"poll"
 end
end
