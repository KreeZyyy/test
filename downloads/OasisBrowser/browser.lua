-- Oasis Browser 0.2.3. Starts installed Chrome headlessly for an active panel. Separate token.
local TOKEN="PASTE_OASIS_BROWSER_TOKEN_HERE"
local BASE="http://localhost:18767"
local headers={["X-Oasis-Browser-Token"]=TOKEN}
local ui=ss.ui.surface("oasis_browser")
ss.ui.activate("oasis_browser")
ui:set_resolution(0,0)
local native=ui:size() or {w=1280,h=900}
if native.w>0 and native.w<1280 then ui:set_resolution(1280,math.floor(native.h*1280/native.w)) end
local size=ui:size() or native
local W,H=size.w,size.h
local S=math.min(W/1280,H/900)
local M=16*S
local text,request,kind,elapsed,next_health="",nil,nil,0,0
local ready=false
ui:clear()
local function el(id,typ,x,y,w,h,props,events)
 local d={id=id,type=typ,rect={unit="px",x=x,y=y,w=w,h=h},props=props or {},style={bg="#132D35",text="#E5FFF5",color="#E5FFF5",font_size=20*S}}
 for k,v in pairs(events or {}) do d[k]=v end
 return ui:element(d)
end
el("bg","panel",0,0,W,H,{})
el("title","label",M,8*S,W-2*M,36*S,{text="O A S I S  /  BROWSER"})
local status=el("status","label",M,45*S,W-2*M,30*S,{text="Čekám na automatické spuštění browser panelu…"})
local availableH=H-82*S-140*S
local width=math.min(W-2*M,availableH*16/9)
local height=width*9/16
-- The companion native mod claims this reserved host and adds a live RawImage plus pointer events.
el("oasis_browser_view","oasis_browser",(W-width)/2,82*S+(availableH-height)/2,width,height,{})
local function message(t) status:set_props({text=tostring(t):gsub("<","‹"):gsub(">","›")});ui:commit() end
local function action(name,value)
 if request then return end
 if TOKEN=="PASTE_OASIS_BROWSER_TOKEN_HERE" then message("Vlož Bridge.Token z nastavení Oasis Browser.");return end
 if not ready then message("Chrome není připraven. Zkontroluj Oasis Browser a cestu k Chrome.");return end
 local ok,id=pcall(ic.http.post,BASE.."/action",util.json.encode({action=name,value=value}),"application/json",headers,15)
 if not ok then message("HTTP není dostupné. Zapni AllowHttp a AllowHttpLocalhost.");return end
 request,kind,elapsed=id,"action",0;message("Odesílám akci do Chrome…")
end
local input
input=el("query","textinput",M,H-126*S,W-2*M-172*S,42*S,{value="",placeholder="Hledat na YouTube nebo vložit odkaz…",title="Oasis Browser"},{on_change=function(v) text=tostring(v or "");input:set_props({value=text});ui:commit() end})
el("navigate","button",W-M-160*S,H-126*S,160*S,42*S,{text="Hledat / Otevřít"},{on_click=function() action("navigate",text) end})
local labels={{"home","YouTube"},{"reload","Obnovit"},{"scroll_up","Nahoru"},{"scroll_down","Dolů"},{"text","Vložit text"},{"enter","Enter"}}
for i,v in ipairs(labels) do
 local name,label=v[1],v[2]
 el(name,"button",M+(i-1)*160*S,H-72*S,150*S,36*S,{text=label},{on_click=function() action(name,name=="text" and text or nil) end})
end
el("note","label",M,H-28*S,W-2*M,24*S,{text="Prototyp • Chrome bez okna • experimentální zvuk ze zařízení"})
el("interface","interface_button",M+6*160*S,H-72*S,150*S,36*S,{text="Ovládat web"},{on_click=function(value)
 if tostring(value)=="1" then message("Ovládání webu zapnuto • Alt/Escape pro návrat") else message("Ovládání webu vypnuto") end
end})
if type(ui.on_keydown)=="function" then
 ui:on_keydown(function(key)
  if key=="Escape" or key=="LeftAlt" then ss.exit_interface_mode() end
 end)
end
ui:commit()
function tick(dt)
 dt=tonumber(dt) or 0;next_health=next_health-dt
 if request then
  elapsed=elapsed+dt
  if elapsed>20 then request=nil;ready=false;message("Spojení vypršelo. Ověř Oasis Browser a Chrome.") end
  for i=1,8 do
   local polled,id,ok,code,body=pcall(ic.http.poll)
   if not polled then request=nil;ready=false;message("Zapni HTTP v nastavení StationeersLua.");return end
   if not id then break end
   if id==request then
    request=nil
    local decoded,data=pcall(util.json.decode,body or "")
    if not decoded or type(data)~="table" then ready=false;message("Mod nevrátil odpověď. Ověř Oasis Browser a port 18767.");return end
    if not ok or code<200 or code>=300 then message(data.error or "Spojení s prohlížečem selhalo.");return end
    if kind=="health" then ready=data.ready==true end
    message(data.status or "Prohlížeč připraven");next_health=3
   end
  end
 end
 if not request and next_health<=0 then
  next_health=3
  if TOKEN=="PASTE_OASIS_BROWSER_TOKEN_HERE" then message("Vlož Bridge.Token z nastavení Oasis Browser.");return end
  local ok,id=pcall(ic.http.get,BASE.."/health",headers,10)
  if ok then request,kind,elapsed=id,"health",0 else message("HTTP není dostupné. Zapni AllowHttp a AllowHttpLocalhost.") end
 end
end
