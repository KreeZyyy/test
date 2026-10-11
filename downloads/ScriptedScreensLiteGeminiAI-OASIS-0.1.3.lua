-- OASIS example — ScriptedScreensLiteGeminiAI 0.1.3, standalone.
local TOKEN = "PASTE_LOCAL_BRIDGE_TOKEN_HERE"
local BASE = "http://localhost:18766"
local GeminiAI = (function()
local GeminiAI = {}

function GeminiAI.new(config)
    config = config or {}
    local host = ic.host_info()
    local self = {
        base = config.base or "http://localhost:18766",
        token = config.token or "PASTE_LOCAL_BRIDGE_TOKEN_HERE",
        source_ref_id = tostring(config.source_ref_id or (host and host.ref_id) or ""),
        conversation_id = config.conversation_id,
        system_prompt = config.system_prompt,
        speech_style = config.speech_style,
        voice = config.voice,
        sound_id = "geminiai_voice",
        audio_elapsed = nil, audio_deadline = nil, last_audio_key = nil,
        audio_start_grace = math.max(0, math.min(10, tonumber(config.audio_start_grace) or 0)),
        request = nil, kind = nil, job = nil, elapsed = 0, poll_elapsed = 0,
        timeout = config.timeout or 240, callback = nil,
    }
    local headers = {["X-Station-Token"] = self.token}
    local function complete(result, err)
        local callback = self.callback
        self.request, self.kind, self.job, self.callback = nil, nil, nil, nil
        if callback then callback(result, err) end
    end
    function self:busy() return self.request ~= nil or self.job ~= nil end
    function self:ask(question, preferences, callback)
        if self:busy() then return nil, "Dotaz už probíhá." end
        if self.token == "PASTE_LOCAL_BRIDGE_TOKEN_HERE" or #self.token < 24 then
            return nil, "Doplň místní Bridge Token; Gemini klíč do Lua nepatří."
        end
        if type(question) ~= "string" or not question:find("%S") then return nil, "Napiš zprávu." end
        if not self.source_ref_id:match("^%d+$") then return nil, "Chybí ReferenceId hostitelského zařízení." end
        preferences = preferences or {}
        local payload = {
            question = question, source_ref_id = self.source_ref_id,
            conversation_id = preferences.conversation_id or self.conversation_id,
            remember = preferences.remember ~= false, speak = preferences.speak ~= false,
            system_prompt = preferences.system_prompt or self.system_prompt,
            speech_style = preferences.speech_style or self.speech_style,
            voice = preferences.voice or self.voice,
            model = preferences.model, tts_model = preferences.tts_model,
            max_output_tokens = preferences.max_output_tokens, temperature = preferences.temperature,
        }
        local ok, encoded = pcall(util.json.encode, payload)
        if not ok then return nil, "Nastavení dotazu nelze převést na JSON." end
        local posted, id = pcall(ic.http.post, self.base.."/ask", encoded, "application/json", headers, 10)
        if not posted or id == nil then return nil, "HTTP není dostupné. Ověř AllowHttp a AllowHttpLocalhost." end
        self.request, self.kind, self.callback = id, "ask", callback
        self.elapsed, self.poll_elapsed = 0, 0
        return true
    end
    function self:reset(callback)
        if self:busy() then return nil, "Nejdřív počkej na dokončení dotazu." end
        if self.token == "PASTE_LOCAL_BRIDGE_TOKEN_HERE" or #self.token < 24 then return nil, "Doplň Bridge Token." end
        local payload = util.json.encode({source_ref_id=self.source_ref_id, conversation_id=self.conversation_id})
        local ok, id = pcall(ic.http.post, self.base.."/memory/reset", payload, "application/json", headers, 10)
        if not ok or id == nil then return nil, "Paměť se nepodařilo resetovat." end
        self.request, self.kind, self.callback = id, "reset", callback
        self.elapsed, self.poll_elapsed = 0, 0
        return true
    end
    function self:test_memory(callback)
        if self:busy() then return nil,"Dotaz už probíhá." end
        if self.token == "PASTE_LOCAL_BRIDGE_TOKEN_HERE" or #self.token < 24 then return nil,"Doplň Bridge Token." end
        local ok,id=pcall(ic.http.post,self.base.."/memory/test",util.json.encode({}),"application/json",headers,10)
        if not ok or id==nil then return nil,"Test ukládání se nepodařilo spustit." end
        self.request,self.kind,self.callback=id,"test_memory",callback
        self.elapsed,self.poll_elapsed=0,0
        return true
    end
    function self:test_piper(callback)
        if self:busy() then return nil,"Dotaz už probíhá." end
        if self.token == "PASTE_LOCAL_BRIDGE_TOKEN_HERE" or #self.token < 24 then return nil,"Doplň Bridge Token." end
        local payload=util.json.encode({source_ref_id=self.source_ref_id})
        local ok,id=pcall(ic.http.post,self.base.."/speech/test",payload,"application/json",headers,10)
        if not ok or id==nil then return nil,"Test Piperu se nepodařilo spustit." end
        self.request,self.kind,self.callback=id,"ask",callback
        self.elapsed,self.poll_elapsed=0,0
        return true
    end
    function self:test_audio(callback)
        if self:busy() then return nil, "Dotaz už probíhá." end
        if self.token == "PASTE_LOCAL_BRIDGE_TOKEN_HERE" or #self.token < 24 then return nil, "Doplň Bridge Token." end
        local payload=util.json.encode({source_ref_id=self.source_ref_id})
        local ok,id=pcall(ic.http.post,self.base.."/audio/test",payload,"application/json",headers,10)
        if not ok or id==nil then return nil,"Místní test zvuku se nepodařilo spustit." end
        self.request,self.kind,self.callback=id,"test_audio",callback
        self.elapsed,self.poll_elapsed=0,0
        return true
    end
    -- For chips using other HTTP APIs: call handle_completion from ONE central poll loop.
    function self:handle_completion(id, ok, code, body, err)
        if self.request == nil or id ~= self.request then return false end
        local kind = self.kind
        self.request, self.kind = nil, nil
        local decoded, data = pcall(util.json.decode, body or "")
        local status = tonumber(code) or 0
        if not ok or status < 200 or status >= 300 then
            local message = decoded and type(data)=="table" and type(data.error)=="string" and data.error
            local fallback = status == 409 and "Konverzace ještě zpracovává dotaz. Počkej a zkus to znovu." or
                status == 429 and "Limit požadavků nebo kvóta. Počkej a zkus to ručně znovu." or
                ("HTTP "..status..". Ověř mod a jeho konfiguraci.")
            complete(nil, message or fallback)
        elseif not decoded or type(data) ~= "table" then
            complete(nil, "Mod nevrátil platný JSON.")
        elseif kind == "test_audio" then
            if tostring(data.source_ref_id) ~= self.source_ref_id then complete(nil,"Test patří jinému zařízení.")
            else complete(data,nil) end
        elseif kind == "reset" or kind == "test_memory" then
            complete(data, nil)
        elseif kind == "ask" then
            if type(data.id) ~= "string" or not data.id:match("^[a-f0-9]+$") or #data.id ~= 32 then
                complete(nil, "Neplatné ID úlohy.")
            else self.job = data.id; self.poll_elapsed = 0 end
        elseif data.state == "done" then
            if tostring(data.source_ref_id) ~= self.source_ref_id then complete(nil, "Odpověď patří jinému zařízení.")
            elseif type(data.text) ~= "string" then complete(nil, "Odpověď neobsahuje text.")
            else complete(data, nil) end
        elseif data.state == "error" then
            complete(nil, type(data.error)=="string" and data.error or "Gemini neodpovědělo.")
        elseif data.state ~= "queued" and data.state ~= "running" then
            complete(nil, "Neznámý stav úlohy.")
        end
        return true
    end
    function self:play_audio(result, replay)
        if not result or tostring(result.source_ref_id) ~= self.source_ref_id then return nil, "Jiné zařízení." end
        if type(result.audio_url) ~= "string" or not result.audio_url:match("^https?://") then return nil, "Hlas není dostupný." end
        if not ss or not ss.play_sound then return nil, "ScriptedScreens není dostupný." end
        local audio_key = result.id or result.audio_url
        if not replay and audio_key == self.last_audio_key then return self.sound_id end
        local duration = tonumber(result.audio_duration_seconds)
        if not duration or duration ~= duration or duration <= 0 or duration > 360 then
            return nil, "Chybí platná délka hlasu. Aktualizuj DLL modu na 0.1.3."
        end
        local stop_after = tonumber(result.audio_stop_after_seconds) or duration
        if stop_after ~= stop_after or stop_after <= 0 or stop_after > duration then
            return nil, "Neplatné časování hlasu."
        end
        self:stop_audio()
        -- Explicit one-shot; the backend's silent tail absorbs coarse game-tick timing.
        local sound_id = "geminiai_"..tostring(result.id or "voice")
        local ok, sound = pcall(ss.play_sound, result.audio_url, {volume=0.8, loop=false, id=sound_id})
        if not ok then return nil, "Přehrávání hlasu selhalo. Ověř nastavení médií a dostupnost URL u hráčů." end
        self.sound_id = sound or sound_id
        self.last_audio_key = audio_key
        self.audio_elapsed, self.audio_deadline = 0, stop_after + self.audio_start_grace
        return self.sound_id
    end
    function self:stop_audio()
        self.audio_elapsed, self.audio_deadline = nil, nil
        if ss and ss.stop_sound then pcall(ss.stop_sound, self.sound_id) end
    end
    -- poll_http=false when your script drains HTTP itself through handle_completion.
    function self:tick(dt, poll_http)
        dt = math.max(0, tonumber(dt) or 0.5)
        -- Advance before completions: a clip started this tick must not lose one dt.
        if self.audio_elapsed then
            self.audio_elapsed = self.audio_elapsed + dt
            if self.audio_elapsed >= self.audio_deadline then self:stop_audio() end
        end
        if poll_http ~= false then
            for _ = 1, 8 do
                local polled, id, ok, code, body, err = pcall(ic.http.poll)
                if not polled then
                    if self:busy() then complete(nil, "HTTP polling není dostupný.") end
                    break
                end
                if id == nil then break end
                self:handle_completion(id, ok, code, body, err)
            end
        end
        if self:busy() then
            self.elapsed = self.elapsed + dt
            if self.elapsed > self.timeout then complete(nil, "Časový limit. Úloha na serveru ještě může doběhnout."); return end
        end
        self.poll_elapsed = self.poll_elapsed + dt
        if self.job and not self.request and self.poll_elapsed >= 1 then
            self.poll_elapsed = 0
            local ok, id = pcall(ic.http.get, self.base.."/jobs/"..self.job, headers, 10)
            if not ok or id == nil then complete(nil, "Výsledek se nepodařilo načíst.")
            else self.request, self.kind = id, "poll" end
        end
    end
    return self
end
return GeminiAI

end)()
local ai = GeminiAI.new({
    token=TOKEN, base=BASE,
    audio_start_grace=0, -- Stop at WAV duration without the extra 0.25 seconds.
    system_prompt="Jsi Oasis. Odpovídej přímo a přirozeně česky, stručně pro čtení nahlas. Nepředstavuj se opakovaně. Herní stav znáš jen z informací ve zprávě.",
    voice="Kore", speech_style="Speak naturally in Czech, calm and friendly.",
})
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
local question = ""
local speak, active = true, nil
local input, status, voice_button, scroll
local history, drawn = {}, {}
local STORE = "oasis.geminiai.chat.v1"
local VOICE_STORE = "oasis.geminiai.voice.v1"
local last_voice
if ic.persist then
    local ok, raw = pcall(ic.persist.get, VOICE_STORE)
    if ok and type(raw)=="string" then
        local decoded, saved = pcall(util.json.decode, raw)
        if decoded and type(saved)=="table" then last_voice=saved end
    end
end
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
element("subtitle","label",rect(M+58*S,51*S,W-2*M-58*S,23*S),{text="Tvůj palubní společník  /  Gemini + prostorový hlas"},{font_size=12*S,color="#88ACA8",align="left"})
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
    if active and active.pending then active.pending=false; active.error=message; save_history(); render_history() end
    active=nil
    status:set_props({text=message})
    ui:commit()
end
local function send()
    if ai:busy() then return end
    if not question:find("%S") then finish("Nejdřív napiš zprávu pro Oasis."); return end
    local asked=question
    local read_voice=speak
    ai:stop_audio()
    active={question=asked,reply="",pending=true}
    history[#history+1]=active
    while #history>12 do table.remove(history,1) end
    local sent,err=ai:ask(asked,{speak=read_voice,remember=true},function(result,error)
        if error then finish(error); return end
        if active then active.reply=result.text; active.pending=false end
        save_history(); render_history()
        local message=result.voice_error or result.memory_error or "Odpověď připravena"
        if read_voice and speak and result.audio_url then
            last_voice={id=result.id,source_ref_id=result.source_ref_id,audio_url=result.audio_url,
                audio_duration_seconds=result.audio_duration_seconds,audio_stop_after_seconds=result.audio_stop_after_seconds}
            if ic.persist then
                local ok, raw=pcall(util.json.encode,last_voice)
                if ok and #raw<=2000 then pcall(ic.persist.set,VOICE_STORE,raw) end
            end
            local sound,play_error=ai:play_audio(result)
            message=play_error or "Odpověď připravena • hlas ze zařízení"
        end
        if result.memory_error and result.audio_url then message=message.." • "..result.memory_error end
        if result.reply_truncated then message=message.." • text dosáhl limitu" end
        finish(message)
    end)
    if not sent then finish(err); return end
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
voice_button=element("voice","button",rect(M,H-22*S,115*S,18*S),{text="Hlas: zapnutý"},{bg="#10262D",text="#9EE3CE",font_size=11*S},{on_click=function()
    speak=not speak; if not speak then ai:stop_audio() end; voice_button:set_props({text=speak and "Hlas: zapnutý" or "Hlas: vypnutý"}); ui:commit()
end})
element("replay_voice","button",rect(M+125*S,H-22*S,90*S,18*S),{text="Znovu hlas"},{bg="#10262D",text="#9EE3CE",font_size=11*S},{on_click=function()
    if ai:busy() then return end
    if not speak then finish("Nejdřív zapni hlas."); return end
    if not last_voice then finish("Zatím není uložený hlas k přehrání."); return end
    local sound, err=ai:play_audio(last_voice,true)
    finish(err or "Přehrávám uložený WAV bez volání Gemini; staré URL už může být smazané.")
end})
element("test_piper","button",rect(M+330*S,H-22*S,100*S,18*S),{text="Test Piperu"},{bg="#10262D",text="#9EE3CE",font_size=11*S},{on_click=function()
    if ai:busy() then return end
    if not speak then finish("Nejdřív zapni hlas."); return end
    local sent,err=ai:test_piper(function(result,error)
        if error then finish(error); return end
        if result.voice_error then finish(result.voice_error); return end
        if not result.audio_url then finish("Piper nevytvořil hlas. Ověř konfiguraci."); return end
        last_voice={id=result.id,source_ref_id=result.source_ref_id,audio_url=result.audio_url,
            audio_duration_seconds=result.audio_duration_seconds,audio_stop_after_seconds=result.audio_stop_after_seconds}
        if ic.persist then
            local ok,raw=pcall(util.json.encode,last_voice)
            if ok and #raw<=2000 then pcall(ic.persist.set,VOICE_STORE,raw) end
        end
        local sound,play_error=ai:play_audio(result,true)
        finish(play_error or "Test Piperu: místní český hlas ze zařízení. Gemini se nevolá.")
    end)
    if not sent then finish(err) else finish("Piper připravuje český hlas bez Gemini…") end
end})
local clear_armed=false
element("test_voice","button",rect(M+225*S,H-22*S,95*S,18*S),{text="Test tónů"},{bg="#10262D",text="#9EE3CE",font_size=11*S},{on_click=function()
    if ai:busy() then return end
    if not speak then finish("Nejdřív zapni hlas."); return end
    local sent,err=ai:test_audio(function(result,error)
        if error then finish(error); return end
        local sound,play_error=ai:play_audio(result,true)
        finish(play_error or "Test: tři tóny jednou, pak ticho a zastavení. Gemini se nevolá.")
    end)
    if not sent then finish(err) else finish("Připravuji místní test zvuku bez Gemini…") end
end})
local clear_button
element("test_memory","button",rect(M+440*S,H-22*S,110*S,18*S),{text="Test paměti"},{bg="#10262D",text="#9EE3CE",font_size=11*S},{on_click=function()
    if ai:busy() then return end
    local sent,err=ai:test_memory(function(result,error)
        finish(error or "Paměť: zápis, přepsání a načtení souboru prošly. Gemini se nevolá.")
    end)
    if not sent then finish(err) else finish("Ověřuji ukládání paměti bez Gemini…") end
end})
clear_button=element("clear_history","button",rect(W-M-150*S,H-22*S,150*S,18*S),{text="Vymazat historii"},{bg="#10262D",text="#88ACA8",font_size=11*S},{on_click=function()
    if ai:busy() then return end
    if not clear_armed then clear_armed=true; clear_button:set_props({text="Potvrdit vymazání"}); ui:commit(); return end
    local reset,err=ai:reset(function(result,error)
        clear_armed=false
        clear_button:set_props({text="Vymazat historii"})
        if error then finish(error); return end
        history={}
        if ic.persist then pcall(ic.persist.delete,STORE) end
        last_voice=nil
        if ic.persist then pcall(ic.persist.delete,VOICE_STORE) end
        ai:stop_audio(); render_history(); finish("Historie i AI paměť vymazány.")
    end)
    if not reset then finish(err) else status:set_props({text="Mažu paměť…"}); ui:commit() end
end})
render_history(); ui:commit()

function tick(dt)
    ai:tick(dt)
end
