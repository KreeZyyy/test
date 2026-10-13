# Oasis Browser 0.2.4 — test

YouTube jako webová stránka uvnitř ScriptedScreens. Mod spouští nainstalovaný Chrome v režimu bez viditelného okna až poté, co najde aktivní browser panel. Nemusíš ručně otevírat další okno ani spouštět Chrome. Je to prohlížeč běžící na pozadí, nikoli browser engine zabudovaný do Unity.

## Plocha a psaní 0.2.4
Web zabírá celou šířku a výšku kromě kompaktní spodní lišty. Viewport Chrome se přizpůsobí poměru panelu, včetně screenWidth/screenHeight pro zvětšení videa. Klikání používá aktuální rozměry.
Nahraj nový scripts/browser.lua se svým tokenem. Ovládat web zapne předávání psaného textu; klikni do webového pole a piš. Podporované jsou i Backspace a Enter. Kurzor při psaní ponech nad webem; opuštění webové plochy uvolní předávání klávesnice. Alt/Escape ukončuje režim. Zkratky Ctrl a složitější editace zatím nejsou implementované. Herní napojení klávesnice vyžaduje ověření; spodní Vložit text zůstává jako záloha.

## Obraz 0.2.3
Průběžný JPEG screencast nahrazuje periodické PNG screenshoty. Pro aktualizaci z 0.2.2 stačí přepsat DLL a About a restartovat hru; Lua ani token se nemění.

## Ovládání 0.2.2
Browser plocha přijímá PointerDown i PointerClick, s potlačením dvojího kliknutí při uvolnění i po delším stisku. Přepočet pozice používá dostupnou kameru stisku, vstupu nebo Canvasu. První přijatá událost a souřadnice pro Chrome se zapisují do LogOutput.log.
Lua panel nově obsahuje Ovládat web (interface_button). Kliknutím aktivuj interaktivní režim, potom zkus cookies nebo vyhledávání na YouTube. Alt/Escape vrací herní ovládání. Proto je pro tuto aktualizaci potřeba nahrát i nový Lua skript a vložit do něj svůj stávající token; konfigurace tokenu se nemění.
Přesná příčina původního nefunkčního klikání není bez herního testu potvrzená. Pokud nepůjde ani Ovládat web či spodní tlačítka, jde o jinou úroveň vstupu než samotný web. Pokud spodní tlačítka jdou, ale web ne, pošli nový log se zprávami Browser pointer event/Pointer mapped.

## Zachované opravy 0.2.1
Přidává přímé napojení při vytváření browser UI, místo spoléhání výhradně na sken názvů objektů. Kontrola napájení už nezaměňuje generický On/Powered čipu za skutečné podporované stavy zařízení. Směrování do lokálního Chrome nepoužívá systémový proxy.
Veškerá diagnostika pluginu jde nově do BepInEx/LogOutput.log pod OasisBrowser: čekání na panel, Panel attached, první autorizovaný Lua HTTP požadavek, Starting Chrome, Chrome connected, First webpage image a podrobnosti případné výjimky. Dodaný předchozí log obsahoval pouze zrušené StationeersLua HTTP úlohy a neměl tyto údaje, takže přesná příčina šedé plochy zatím není potvrzená.
Pro aktualizaci stačí přepsat OasisBrowser.dll a About, úplně restartovat hru a použít stávající čip. Lua kód, token a port se nemění. Pokud zůstane plocha šedá, nový LogOutput.log by už měl určit fázi selhání.

## Instalace
1. Ukonči hru. Rozbal OasisBrowser do Dokumenty\My Games\Stationeers\mods. Při aktualizaci přepiš soubory původního OasisBrowser, nevytvářej druhou kopii.
2. Povol mod v LaunchPadu. Potřebuje StationeersLua, ScriptedScreens a nainstalovaný Google Chrome. Hra se zapíná běžně přes LaunchPad.
3. V Mod Settings najdi Oasis Browser -> Bridge -> Token. V scripts/browser.lua jednou nahraď PASTE_OASIS_BROWSER_TOKEN_HERE tímto tokenem. Gemini ani jiné API klíče se nepoužívají.
4. Vlož Lua skript do čipu připojeného ke ScriptedScreenu a potvrď. StationeersLua musí mít povolené AllowHttp a AllowHttpLocalhost.
5. Zapni zařízení s tímto panelem. Má se automaticky otevřít YouTube na herní obrazovce, bez samostatného okna Chrome. První stránka může vyžadovat souhlas s cookies; video může vyžadovat kliknutí Play.
6. Klikání a kolečko se přenášejí z panelu. Hledání/otevření URL je ve spodním poli Lua UI. Pro psaní do webového pole na něj nejdřív klikni, napiš text do spodního pole a použij Vložit text a Enter.

## Chování
Browser.Hidden=true je výchozí. Změny nastavení vyžadují restart. ChromePath se zkusí najít automaticky, jinak nastav např. C:\Program Files\Google\Chrome\Application\chrome.exe.
Pro diagnostiku můžeš nastavit Hidden=false, ale normální provoz viditelné okno nevyžaduje.
Bez aktivního panelu se Chrome vůbec nespustí. Po ztrátě všech aktivních panelů se asi po 10 sekundách zavře a při dalším zapnutí se založí nová relace. Při ovládání napájení se používá stav nalezeného herního zařízení; toto napojení vyžaduje ověření na tvém screenu.
Prototyp sdílí jednu stránku mezi panely. Zvuk má vycházet pouze z prvního aktivního zařízení, jehož vlastníka se podaří zjistit, ne současně ze všech panelů. Více nezávislých browserů a multiplayer nejsou implementované.
Obraz se přenáší průběžným Chrome screencastem jako JPEG při kvalitě 75, s maximálním rozměrem 960×960 při zachování poměru stran. Viewport se přizpůsobuje ploše Lua panelu. Uchovává se jen nejnovější snímek, bez fronty starých obrázků. Skutečné FPS závisí na CPU, Chrome a Unity; 60 FPS není zaručeno.

## Zvuk
Web Audio zachytává běžná HTML video/audio média jako mono PCM 24 kHz. Chrome přitom nemá posílat zachycený zvuk přímo do desktopového výstupu. Unity dostává omezenou frontu zvuku a audio zdroj se umístí na transform vlastníka panelu, s prostorovým útlumem 1 až 20 metrů.
Je to experimentální napojení: skutečné YouTube video, jeho reklamy/změny přehrávače, křížové domény, umístění zdroje na hardwaru, herní směšovač a vliv atmosféry nejsou ověřené. Není to plná integrace do atmosférického zvukového systému Stationeers. Pokud nejde zjistit vlastník panelu, mod experimentální audio nepřehraje místo toho na celé PC.

## Co bylo ověřeno
DLL se sestavila proti BepInEx, rozhraní LaunchPadu a Unity referencím. Build má 16 upozornění, převážně nullability starého reflektivního UI kódu a nečekané asynchronní návraty; žádné chyby sestavení.
31 kontrol prošlo se skutečným Chromiem na Linuxu proti lokální testovací stránce: spuštění headless, načtení stránky, skutečný obraz, klikání podle souřadnic, převod a omezení PCM fronty, přenos nenulového zvuku z přehrávaného WAVu, autorizace bridge a omezení adres na YouTube.
Linuxový test má zvláštní sandbox přepínač kvůli kontejneru. Windows mod ho nezapíná; běžný sandbox nainstalovaného Chrome zůstává zapnutý. Omezení browser politik v testovacím prostředí se neměnila.
Stationeers/Unity, Windows Chrome a skutečné YouTube v tomto prostředí neběží v ověřeném herním scénáři. Není potvrzená hotová podpora ve hře; tento ZIP je určen pro první test.

## První herní test
Ověř pořadí: (1) bez panelu nevznikne okno Chrome, (2) po aktivaci browser.lua se objeví YouTube, (3) kliknutí funguje, (4) po Play slyšíš zvuk u zařízení a mění se se vzdáleností, (5) vypnutí/zrušení panelu ukončí relaci a další zapnutí funguje.
Pokud selže obraz/kliknutí/zvuk, pošli BepInEx/LogOutput.log, případně Player.log, a screenshot panelu. Zprávy Oasis Browser uvádějí chybějící hook, UI nebo browser. Nikdy neposílej konfiguraci s tokenem.

## Profil a spojení
Chrome používá nový dočasný profil, bez kopírování tvého běžného profilu a rozšíření. Prototyp nepoužívej k osobním přihlášením. Debug port 9223 a ovládací port 18767 jsou pouze místní; neotvírej je do sítě. Obsazený debug port se odmítne před spuštěním, mod se nemá připojit k cizímu browseru. Normální ukončení zavře svůj Chrome a odstraní dočasný profil; po pádu může zůstat profil ve Windows TEMP/OasisBrowser.
Zdroj je v source/. V balíčku není Chrome, game DLL, yt-dlp ani FFmpeg.
