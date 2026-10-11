## ScriptedScreensLiteGeminiAI 0.1.1 — KreeZy

[Stáhnout ZIP](ScriptedScreensLiteGeminiAI-0.1.1.zip?raw=true) · [Nový OASIS.lua](ScriptedScreensLiteGeminiAI-OASIS-0.1.1.lua?raw=true) · [Aktualizace](ScriptedScreensLiteGeminiAI-AKTUALIZACE.txt) · [Zdrojový projekt](ScriptedScreensLiteGeminiAI-0.1.1-source.zip?raw=true)

Autor KreeZy, nový About/thumb.png, přenositelné ukládání konverzací s kontextem v RAM při chybě disku. Lua používá unikátní ID zvuku, ochranu proti opětovnému spuštění stejného jobu a časované zastavení podle délky WAV. Aktualizuj DLL i Lua, konfiguraci a data zachovej.

Prošlo 55 C# a 33 Lua kontrol bez živých Google požadavků. Uživatel ověřil Gemini text/TTS i zvuk ve hře v 0.1.0; opravy 0.1.1 potřebují herní test. Příčina opakování uvnitř ScriptedScreens není potvrzená. Multiplayer není ověřen; audio URL musí být dostupná hráčům. WorldId se nastavuje ručně pro každý save.

---

# Oasis — palubní asistent

## Nové rozhraní Oasis UI 1.2

Stáhni [Oasis-UI-1.2.zip](Oasis-UI-1.2.zip?raw=true) nebo otevři [Lua skript](Oasis-UI-1.2.lua).
Používá již nainstalovaný Station Assistant 0.2.1, žádná aktualizace DLL ani restart nejsou potřeba. Doplň svůj místní bridge token a nahraj nový Lua skript do chipu.

Panel využívá W/H konzole, přidává vektorový znak Oasis, historii otázek i odpovědí, uchování nejnovější historie na chipu a opravuje zobrazení napsaného textu. Nové dotazy zahrnují krátký kontext předchozích úspěšných výměn; pokyny potlačují opakované představování a smyšlené sci-fi odpovědi. Ověřeno náhradami API na čtyřech poměrech stran; vzhled ve skutečné hře ještě vyžaduje ověření. Historie je chronologická: starší zprávy nahoře, nové dole. Posouvání je ruční. Podrobnosti v INSTALACE.txt uvnitř ZIPu.

---


## Aktuální verze: 0.2.2 — Gemini + hlas Windows

Stáhni [StationAssistant-0.2.2.zip](StationAssistant-0.2.2.zip?raw=true). Vypni hru a nahraď složku `Dokumenty/My Games/Stationeers/mods/StationAssistant` složkou ze ZIPu. Postup je v `INSTALACE.txt`.

Gemini klíč zadávej jen do `[Gemini] GeminiApiKey` v místním nastavení modu. Zůstaň na projektu Google AI Studio Free tier. Hlas vytváří Windows, přednostně Microsoft Jakub. Žádné OpenAI ani placené hlasové API se nevolá.

Sestavení proti dodaným herním knihovnám prošlo bez chyb. Prošlo 18 kontrol backendu a test Lua panelu. Skutečné Gemini API a hlas Jakub na Windows ve verzi 0.2 ještě vyžadují ověření u uživatele. Určeno pro singleplayer nebo místního session hostitele.

ZIP neobsahuje API klíče ani herní knihovny. Konfigurační soubory nesdílej.

Starší `StationAssistant-0.1.0.zip` používá OpenAI; pro Gemini použij výhradně verzi 0.2.0.

0.2.1: oprava místního HTTP listeneru — přijímá i localhost. Po aktualizaci DLL restartuj hru a v Lua použij `http://localhost:18765`.

0.2.2: opravené systémové pokyny pro přirozený rozhovor bez vesmírné role. Aktualizace DLL vyžaduje restart hry; UI 1.2 v chipu není potřeba měnit.

## Oasis Media 0.1.0 — experimental independent video mod

[Download prototype](OasisMedia-0.1.0.zip) · [Czech installation](OasisMedia-INSTALACE.txt) · [chip script](media.lua). Requires external official yt-dlp.exe + deno.exe and experimental ScriptedScreens media. Progressive public MP4 only, max 128 MB; live YouTube/native playback not yet verified. Assistant installation stays independent.

## Oasis Media 0.1.1 — latest media prototype

[Download](OasisMedia-0.1.1.zip) · [Update from 0.1.0](OasisMedia-AKTUALIZACE.txt). Adds separate H.264/AAC track merging with external FFmpeg. Existing chip script/token/config remain compatible. Requires ffmpeg.exe and ffprobe.exe alongside yt-dlp.exe/deno.exe. 26 backend checks, UI checks and synthetic local FFmpeg merge passed; live YouTube/Unity playback still requires in-game verification.

## Oasis Browser 0.1.0 — separate browser feasibility prototype

[Download](OasisBrowser-0.1.0.zip) · [Czech installation](OasisBrowser-INSTALACE.txt) · [chip script](browser.lua). Projects installed Chrome, using a temporary profile and native Chrome audio, onto a ScriptedScreens panel at about 3–5 FPS. Does not require yt-dlp/FFmpeg. 15 checks passed with real Chromium plus Lua layout/action tests. Actual Unity texture/pointer integration and YouTube video/audio remain unverified until tested in-game. This is an external Chrome projection, not a browser engine embedded into Unity.
