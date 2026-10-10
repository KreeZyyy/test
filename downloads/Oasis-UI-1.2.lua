-- OASIS UI 1.2 — works with Station Assistant 0.2.1 (no DLL update).
-- Keep your LOCAL Bridge.Token here. Never paste a Gemini API key into Lua.
local TOKEN = "PASTE_LOCAL_BRIDGE_TOKEN_HERE"
local BASE = "http://localhost:18765"
local headers = { ["X-Station-Token"] = TOKEN }
local ui = ss.ui.surface("assistant")
ss.ui.activate("assistant")
ui:set_resolution(0, 0)
local native = ui:size() or {w=800,h=600}
-- Preserve the device aspect ratio; raise small screens' virtual resolution for crisp text.
if native.w > 0 and native.w < 960 then ui:set_resolution(960, math.floor(native.h*960/native.w)) end
local size = ui:size() or native
local W, H = size.w, size.h
local S = math.min(W/800, H/600)
local M, gap, font = 20*S, 10*S, 18*S
local headerH, footerH = 94*S, 112*S
local chatY, chatH, chatW = headerH, H-headerH-footerH, W-2*M
local question, job, request, elapsed = "", nil, nil, 0
local request_kind, speak, active = nil, true, nil
local input, status, voice_button, scroll
local history, drawn = {}, {}
local STORE = "oasis.chat.v1"
local function plain(text) return tostring(text or ""):gsub("<", "‹"):gsub(">", "›") end
local function cut(text, n)
    if #text <= n then return text end
    local last=n
    while last>0 and text:byte(last+1)>=128 and text:byte(last+1)<192 do last=last-1 end
    return text:sub(1,last).."…"
end
local function save_history()
    if not ic.persist then return end
    -- Persistent copy respects the default 8192-byte value limit without truncating live replies.
    local saved={}
    for _,t in ipairs(history) do
        saved[#saved+1]={question=cut(t.question,2000),reply=cut(t.pending and "Odpověď nebyla dokončena." or (t.reply or ""),3000),error=cut(t.error or "",500)}
    end
    local ok,raw=pcall(util.json.encode,saved)
    while ok and #raw>7500 and #saved>1 do table.remove(saved,1); ok,raw=pcall(util.json.encode,saved) end
    if ok and #raw<=7500 then pcall(ic.persist.set,STORE,raw) end
end
if ic.persist then
    local ok,raw=pcall(ic.persist.get,STORE)
    if ok and type(raw)=="string" then
        local decoded,saved=pcall(util.json.decode,raw)
        if decoded and type(saved)=="table" then
            for _,t in ipairs(saved) do
                if type(t)=="table" and type(t.question)=="string" then
                    history[#history+1]={question=cut(t.question,2000),reply=type(t.reply)=="string" and cut(t.reply,3500) or "",error=type(t.error)=="string" and t.error~="" and cut(t.error,500) or nil}
                end
            end
        end
    end
end
while #history>12 do table.remove(history,1) end
ui:clear()
local function rect(x,y,w,h) return {unit="px",x=x,y=y,w=w,h=h} end
local function element(id,kind,r,props,style,events)
    local def={id=id,type=kind,rect=r,props=props or {},style=style or {}}
    for k,v in pairs(events or {}) do def[k]=v end
    return ui:element(def)
end
-- Solid fallbacks keep the screen usable even if the optional Vector renderer is disabled.
element("bg","panel",rect(0,0,W,H),nil,{bg="#071319"})
element("header_bg","panel",rect(0,0,W,headerH-gap),nil,{bg="#10262D",gradient="#0B1B22",gradient_dir="horizontal"})
element("footer_bg","panel",rect(0,H-footerH+gap,W,footerH-gap),nil,{bg="#10262D"})
-- Vector: client-side breathing halo; no per-frame Lua/network redraw.
element("oasis_art","vector",rect(0,0,W,H),{scene="oasis-shell",w=W,h=H,root={
    {op="R",x=0,y=0,w=4*S,h=H,f="#5FE3BB"},
    {op="C",cx=M+23*S,cy=40*S,rx=19*S,ry=19*S,f="none",s="#5FE3BB",sw=1.4*S,so="=0.55+0.25*sin(t*1.4)"},
    {op="C",cx=M+23*S,cy=40*S,rx=9*S,ry=9*S,f="#5FE3BB"},
    {op="R",x=M,y=headerH-13*S,w=W-2*M,h=1*S,f="#26434A"}
}})
element("title","label",rect(M+58*S,12*S,W-2*M-58*S,42*S),{text="O A S I S"},{font_size=29*S,color="#E8FFF6",align="left"})
element("subtitle","label",rect(M+58*S,51*S,W-2*M-58*S,23*S),{text="Tvůj palubní společník  /  Gemini + český hlas"},{font_size=12*S,color="#88ACA8",align="left"})
scroll=element("chat","scrollview",rect(M,chatY,chatW,chatH),{content_height=tostring(chatH)},{bg="#071319",scrollbar_bg="#10262D",scrollbar_handle="#3B746A",scroll_speed=tostring(35*S),padding_bottom="0"})
local function text_height(text,width)
    local ok,measured=pcall(ui.measure_text,ui,plain(text),width,font,true)
    if ok and measured and type(measured.h)=="number" then return math.max(font*1.5,measured.h+font*0.3) end
    return font*1.5*math.max(1,math.ceil(#plain(text)/math.max(1,width/(font*0.6))))
end
local function render_history()
    for _,id in ipairs(drawn) do ui:remove(id) end
    drawn={}
    local y=gap
    local function add(id,kind,r,props,style)
        drawn[#drawn+1]="chat/"..id
        return scroll:element({id=id,type=kind,rect=r,props=props or {},style=style or {}})
    end
    local function bubble(id,who,text,user)
        local x=user and chatW*0.12 or 0
        local width=chatW*0.88-12*S
        local th=text_height(text,width-26*S)
        local height=th+42*S
        add(id.."_bg","panel",rect(x,y,width,height),nil,{bg=user and "#163B3B" or "#10262D"})
        add(id.."_who","label",rect(x+13*S,y+7*S,width-26*S,18*S),{text=who},{font_size=11*S,color=user and "#8DF3CC" or "#F0CB8A",align="left"})
        add(id.."_text","label",rect(x+13*S,y+29*S,width-26*S,th),{text=plain(text)},{font_size=font,color="#E1ECEB",align="left"})
        y=y+height+gap
    end
    if #history==0 then
        bubble("welcome","OASIS","Ahoj, jsem Oasis. Napiš mi otázku — odpovím ti česky a můžu ji i přečíst.",false)
    end
    -- Chat order: oldest at the top, newest at the bottom; each question precedes its answer.
    for i=1,#history do
        local t=history[i]
        bubble("turn_"..i.."_you","TY",t.question,true)
        bubble("turn_"..i.."_oasis","OASIS",t.pending and "Přemýšlím…" or (t.error and "Nepodařilo se odpovědět: "..t.error or t.reply),false)
    end
    scroll:set_props({content_height=tostring(math.max(chatH,y))})
end
status=element("status","label",rect(M,H-footerH+14*S,chatW,20*S),{text="Připraven  •  starší zprávy najdeš posunutím historie"},{font_size=12*S,color="#88ACA8",align="left"})
local function finish(message)
    job,request,request_kind=nil,nil,nil
    if active and active.pending then active.pending=false; active.error=message; save_history(); render_history() end
    active=nil
    status:set_props({text=message})
    ui:commit()
end
local function conversation_prompt(current)
    local instruction="Jsi Oasis. Nepředstavuj se v každé odpovědi. Odpovídej přímo a přirozeně na aktuální zprávu. Nevymýšlej sci-fi fakta o skutečném světě. Omezení senzorů připomínej jen při dotazu na stav hry.\n"
    local ending="\nAktuální zpráva hráče: "..current
    local budget=1950-#instruction-#ending
    if budget<0 then return nil end
    local context={}
    for i=#history,math.max(1,#history-3),-1 do
        local t=history[i]
        if not t.pending and not t.error and t.reply and t.reply~="" then
            local piece="Hráč: "..cut(t.question,250).."\nOasis: "..cut(t.reply,500).."\n"
            if #piece<=budget then table.insert(context,1,piece); budget=budget-#piece end
        end
    end
    return instruction..table.concat(context)..ending
end
local function send()
    if job or request then return end
    if TOKEN=="PASTE_LOCAL_BRIDGE_TOKEN_HERE" then finish("Doplň místní Bridge Token do skriptu."); return end
    if not question:find("%S") then finish("Nejdřív napiš zprávu pro Oasis."); return end
    local prompt=conversation_prompt(question)
    if not prompt then finish("Zpráva je moc dlouhá. Prosím zkrať ji."); return end
    active={question=question,reply="",pending=true}
    history[#history+1]=active
    while #history>12 do table.remove(history,1) end
    local ok,id=pcall(ic.http.post,BASE.."/ask",util.json.encode({question=prompt,speak=speak}),"application/json",headers,10)
    if not ok then finish("HTTP není dostupné. Ověř AllowHttp a AllowHttpLocalhost."); return end
    request,request_kind,elapsed=id,"ask",0
    question=""; input:set_props({value=""})
    save_history(); render_history()
    status:set_props({text="Oasis přemýšlí…"}); ui:commit()
end
local inputY, inputH = H-70*S, 42*S
input=element("question","textinput",rect(M,inputY,chatW-120*S-gap,inputH),{value="",placeholder="Napiš zprávu pro Oasis…",title="Zpráva pro Oasis"},{bg="#19363B",text="#F1FFF9",placeholder_color="#789793",font_size=font},{on_change=function(value)
    local changed=tostring(value or "")
    if changed~=question then question=changed; input:set_props({value=question}); ui:commit() end
end})
element("send","button",rect(W-M-120*S,inputY,120*S,inputH),{text="Odeslat"},{bg="#59D6AD",text="#08231E",font_size=16*S},{on_click=send})
voice_button=element("voice","button",rect(M,H-22*S,130*S,18*S),{text="Hlas: zapnutý"},{bg="#10262D",text="#9EE3CE",font_size=11*S},{on_click=function()
    speak=not speak; voice_button:set_props({text=speak and "Hlas: zapnutý" or "Hlas: vypnutý"}); ui:commit()
end})
local clear_armed=false
local clear_button
clear_button=element("clear_history","button",rect(W-M-150*S,H-22*S,150*S,18*S),{text="Vymazat historii"},{bg="#10262D",text="#88ACA8",font_size=11*S},{on_click=function()
    if job or request then return end
    if not clear_armed then clear_armed=true; clear_button:set_props({text="Potvrdit vymazání"}); ui:commit(); return end
    history={}; clear_armed=false
    if ic.persist then pcall(ic.persist.delete,STORE) end
    clear_button:set_props({text="Vymazat historii"}); render_history(); ui:commit()
end})
render_history(); ui:commit()

function tick(dt)
    -- Drain completions even after a UI timeout so late responses cannot poison the next request.
    for _=1,8 do
        local polled, id, ok, code, body, err = pcall(ic.http.poll)
        if not polled then
            if job or request then finish("HTTP není dostupné. Ověř nastavení StationeersLua.") end
            break
        end
        if id == nil then break end
        if id == request then
            local kind = request_kind
            request, request_kind = nil, nil
            local decoded, data = pcall(util.json.decode, body or "")
            local http_code = tonumber(code) or 0
            if http_code >= 400 then
                local message = decoded and type(data) == "table" and data.error
                finish(message or (http_code == 401 and "Neplatný bridge token." or "Mod vrátil HTTP "..http_code))
            elseif not ok then
                local detail = tostring(err or "bez podrobností")
                if detail:find(TOKEN, 1, true) then detail = "podrobnosti obsahovaly token" end
                finish("HTTP "..http_code..": "..detail:sub(1,180))
            elseif not decoded or type(data) ~= "table" then finish("HTTP "..http_code..": odpověď není platný JSON.")
            elseif kind == "ask" then
                if type(data.id) == "string" then job=data.id else finish("Mod nevrátil ID úlohy.") end
            elseif data.state == "done" then
                if active then active.reply = data.text or ""; active.pending = false end
                save_history(); render_history()
                finish(data.voice_error or (data.voice_queued and "Odpověď připravena • hlas ve frontě" or "Odpověď připravena"))
            elseif data.state == "error" then finish(data.error or "AI odpověď selhala.") end
        end
    end
    if job or request then
        elapsed = elapsed + (dt or 0.5)
        if elapsed > 100 then finish("Časový limit. Zkus novou otázku."); return end
    end
    if job and not request then
        local ok, id = pcall(ic.http.get, BASE.."/jobs/"..job, headers, 10)
        if ok then request, request_kind = id, "poll" else finish("Nepodařilo se načíst odpověď.") end
    end
end
