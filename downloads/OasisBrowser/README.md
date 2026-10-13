# Oasis Browser 0.2.5 — test

Web na panelu ScriptedScreens, ovládaný místním Chromem bez viditelného okna. Jedna společná relace, dočasný profil a experimentální prostorový zvuk. Chrome není součástí balíčku.

## Opravy 0.2.5
Kliknutí do textového pole webu otevře herní okno **Oasis Browser • text do webu**. Confirm posílá celý potvrzený text do konkrétního webového pole a nahrazuje jeho původní obsah. Není potřeba sledovat jednotlivé stisky kláves přes inputString. Cancel nic neposílá. Pokud se stránka mezitím změní nebo původní pole odstraní, potvrzení se odmítne. Hesla se tímto dialogem nezpracovávají. Prázdný text nemusí standardní herní dialog přijmout.
Spodní Hledat/Otevřít a Vložit text zůstávají záložním ovládáním. Režim Ovládat web slouží pro interaktivní ovládání panelu; z něj se vrací Alt/Escape. Pro text stačí kliknutí do webového pole a následný Confirm.

Zvětšení videa nyní používá režim přes celý webový viewport, místo fullscreen skrytého okna Chrome. Player/video zachovává poměr stran pomocí object-fit:contain; na panelu na výšku mohou zůstat černé pruhy. Stránka dostává událost fullscreenchange, aby ovladače mohly přepnout režim. Opuštění fullscreen obnoví původní stránku. Přesné chování ovladačů skutečného YouTube vyžaduje herní test.

## Aktualizace z 0.2.4
Ukonči hru, přepiš OasisBrowser.dll a About ze ZIPu a znovu spusť hru. Stávající Lua a token se nemění. Můžeš přepsat i celý mod, ale zachovej vlastní token v uloženém browser.lua. Skript už uložený v čipu se přepsáním složky nezmění.

## První instalace
1. Rozbal složku OasisBrowser do Dokumenty\\My Games\\Stationeers\\mods a povol ji v LaunchPadu. Potřebuje StationeersLua a ScriptedScreens a nainstalovaný Google Chrome.
2. V nastavení Oasis Browser zkopíruj Bridge.Token do scripts/browser.lua místo PASTE_OASIS_BROWSER_TOKEN_HERE. Token není Gemini API klíč.
3. Povol AllowHttp a AllowHttpLocalhost ve StationeersLua. Nahraj Lua do čipu připojeného k ScriptedScreenu.
4. Aktivní panel automaticky spustí Chrome. Bez panelu se nespouští, po ztrátě všech panelů se asi za 10 s zavře. Změny nastavení vyžadují restart.
5. Vlož YouTube odkaz nebo hledaný název do spodního pole. Klikání a kolečko se předávají do webu. Video může vyžadovat Play a stránka souhlas s cookies.

## Obraz a zvuk
Web vyplňuje panel nad nízkou spodní lištou. Viewport Chrome respektuje poměr panelu a klikání používá aktuální rozměry. Obraz je průběžný JPEG screencast, kvalita 75, nejvýše 960×960 se zachováním poměru stran. Uchovává se jen nejnovější snímek. FPS závisí na Chrome, CPU a Unity; 60 FPS není zaručeno.
Audio je mono PCM 24 kHz, omezená fronta a běžný Unity prostorový AudioSource u prvního aktivního vlastníka panelu. Není to plná integrace atmosférického zvuku Stationeers. Pokud se vlastník nezjistí, zvuk se neaktivuje. Skutečné YouTube audio, reklamy, přeshraniční média a chování ve Windows vyžadují další ověření.

## Ověření a omezení
36 kontrol prošlo se skutečným Chromiem na Linuxu: animované snímky, klikání, audio, autorizace, rozměry panelu na výšku, potvrzený český text a odmítnutí odstraněného pole. Zvětšené testovací video mělo rozměry 1280×1400 a object-fit:contain; ukončení obnovilo původních 200 px. DLL se sestavila bez chyb, s 16 upozorněními převážně nullability reflektivního UI.
Podpis callbacku ShowInputPanel/Confirm byl ověřen v dodané herní Assembly-CSharp.dll. Samotné vyvolání dialogu v běžící hře a chování skutečného YouTube se zde nedají potvrdit. ZIP je testovací verze, nikoli záruka opraveného provozu ve hře.
Linuxový integrační test má kontejnerový sandbox přepínač; Windows mod jej nepoužívá. Chrome používá standardní sandbox a nový dočasný profil bez rozšíření a kopírování osobního profilu. Přihlášení Google může odmítnout tento browser; přihlášení tímto modem není zaručené.
Podporovaná je jedna místní relace, bez multiplayeru a samostatných browserů pro každý panel. Debug port 9223 a Bridge port 18767 jsou pouze loopback. Neotevírej je do sítě. Při ukončení se vlastní proces Chrome zavře a profil smaže; po pádu může zůstat TEMP/OasisBrowser.

## Diagnostika
BepInEx/LogOutput.log obsahuje zprávy pod OasisBrowser. Pro potvrzování textu: Web text confirmation dialog opened a Confirmed text sent to web field. Log neobsahuje zadávaný text. Pokud selže Confirm, zvětšení nebo obraz, pošli log a screenshot; neposílej konfiguraci s tokenem.
Zdroj je v source/. Build vyžaduje .NET SDK 8 a vlastní lokální cesty k BepInEx, LaunchPadu a Unity; postup je v source/BUILD.txt. Balíček neobsahuje herní ani LaunchPad DLL, Chrome, yt-dlp či FFmpeg. Newtonsoft.Json je přiložen s licencí MIT.
