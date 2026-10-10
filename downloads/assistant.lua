-- Station Assistant 0.2: single-player / local session host.
-- Copy Bridge.Token from the mod settings here. NEVER put an OpenAI API key here.
local TOKEN = "PASTE_LOCAL_BRIDGE_TOKEN_HERE"
local BASE = "http://localhost:18765"
local headers = { ["X-Station-Token"] = TOKEN }
local ui = ss.ui.surface("assistant")
ss.ui.activate("assistant")
ui:set_resolution(800, 600)
ui:clear()

ui:element({ id="bg", type="panel", rect={unit="px",x=0,y=0,w=800,h=600}, style={bg="#0B1220"} })
ui:element({ id="title", type="label", rect={unit="px",x=24,y=16,w=750,h=38},
    props={text="STATION AI  /  Palubní asistent"}, style={font_size=24,color="#67E8F9"} })
ui:element({ id="disclosure", type="label", rect={unit="px",x=24,y=55,w=750,h=32},
    props={text="Gemini • hlas Windows • zatím bez přístupu k senzorům"}, style={font_size=14,color="#94A3B8"} })
local output = ui:element({ id="reply", type="label", rect={unit="px",x=24,y=100,w=750,h=340},
    props={text="Ahoj! Na co se chceš zeptat?"}, style={font_size=18,color="#E2E8F0",align="left"} })
local status = ui:element({ id="status", type="label", rect={unit="px",x=24,y=445,w=750,h=32},
    props={text="Připraven"}, style={font_size=15,color="#94A3B8"} })
local question, job, request, elapsed = "", nil, nil, 0
local request_kind, speak = nil, true
local function finish(message)
    job, request, request_kind = nil, nil, nil
    status:set_props({text=message})
    ui:commit()
end
local function send()
    if job or request then return end
    if TOKEN == "PASTE_LOCAL_BRIDGE_TOKEN_HERE" then finish("Nejdřív nastav místní bridge token v tomto skriptu."); return end
    if not question:find("%S") then finish("Napiš otázku."); return end
    local ok, id = pcall(ic.http.post, BASE.."/ask",
        util.json.encode({question=question,speak=speak}), "application/json", headers, 10)
    if not ok then finish("HTTP není dostupné. Zapni AllowHttp a AllowHttpLocalhost na hostiteli."); return end
    request, request_kind, elapsed = id, "ask", 0
    status:set_props({text="Přemýšlím…"}); ui:commit()
end
ui:element({ id="question", type="textinput", rect={unit="px",x=24,y=490,w=590,h=42},
    props={value="",placeholder="Napiš otázku…",title="Otázka pro asistenta"},
    style={bg="#1E293B",text="#FFFFFF",font_size=17},
    on_change=function(value) question=tostring(value or "") end })
ui:element({ id="send", type="button", rect={unit="px",x=630,y=490,w=145,h=42},
    props={text="Odeslat"}, style={bg="#0E7490",text="#FFFFFF"}, on_click=send })
local voice_button
voice_button = ui:element({ id="voice", type="button", rect={unit="px",x=24,y=545,w=190,h=32},
    props={text="Hlas: zapnutý"}, style={bg="#334155",text="#FFFFFF"},
    on_click=function() speak=not speak; voice_button:set_props({text=speak and "Hlas: zapnutý" or "Hlas: vypnutý"}); ui:commit() end })
ui:commit()

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
                output:set_props({text=data.text or ""})
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
