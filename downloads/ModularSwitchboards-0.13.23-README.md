# Modular Switchboards 0.13.23 — kopie konzolových krabic a skutečné Plastic Sheets

Na výslovné přání uživatele jsou dvě krabice převzaté přímo z nativního ItemKitModularConsole: původní souřadnice v metrech 1:1, normály, UV, potisk a příslušný původní atlas color_white. Převzaté jsou i spodní kovové konzoly, nosný rám a spojovací díly. Rolovaný panel ani kabelová oka se nepřebírají. Data jsou vložená v našem DLL; za běhu se Modular Consoles ani jeho prefab nehledá. Texture atlas Assets/ConsoleCartons/Surface.png je byte po bytu kopie z referenčního exportu.

Source/ConsoleCartons.cs vzniká z přiložených dat pomocí Tools/copy_console_cartons.py. Vybrané komponenty [2,20,21,7,8,11..19,38..60] jsou uložené v Art/ConsoleCartons včetně původního exportu, vertex streamu, výběru a finálních floatů. Odstraněné jsou pouze degenerované nulové trojúhelníky. Převzato 1228 nenulových trojúhelníků. Krabice se oproti 0.13.22 už nestlačují fitováním do obálky Logic kitu: vlastní model má měřítko 1.

Pod balíkem se za běhu kopíruje skutečná geometrie vanilla Plastic Sheet prefabu do vlastního čitelného meshe, se zachováním jeho UV a kopiemi materiálů. Tři kusy se pokládají naplocho; delší strana má 0.62 m a výška jednotlivé vrstvy je nejvýše 6 mm, aby šlo o desky pod sestavou. Zdrojový herní prefab, mesh ani materiál se nemění. Nejde o další náklad v receptu. Při případné nekompatibilitě čtení budoucího herního meshe se zapíše konkrétní warning a použijí se původní ploché panely, aby kosmetická chyba nezastavila registraci všech kitů.

Náš šikmý otevřený rám a nově obepnuté světlé pásy zůstávají nahoře. Pásy vznikají kolem skutečných převzatých krabic, konzol a rámu. Oprava UInt32 blueprintu z 0.13.21 zůstává. Po přidání čitelných kopií Plastic Sheets se vytvoří vlastní společný mesh se samostatnými materiály; náhled položení používá stejnou výslednou geometrii.

F1 ikona je renderovaná z přesné přibalené geometrie krabic, konzol, rámu a atlasu; spodní Plastic Sheets v offline ikoně zastupují tři ploché desky, protože původní herní prefab je dostupný až za běhu. Ostatní ikony a schválené bedny lišt/modulů jsou beze změny.

Ověření: sestavení proti herním DLL, kontrola indexů/normál/neobrácených ploch exportu, hranice blueprintu, materiálový fallback, přesná shoda kopírované textury a ostatních assetů. Unity zde není dostupné: skutečné kopírování Plastic Sheets, měřítko vedle Console kitu a manipulaci je potřeba ověřit ve hře. Nativní kolizní obálka a úchopy původního kitu zůstaly zachované.

Reprodukce: Tools/copy_console_cartons.py; KIT_GEOMETRY_EXPORT=<absolutní cesta>/Art/KitGeometry.json dotnet run --project Verification/KitGeometry/Check.csproj -c Release; ICON_FILTER=KitCabinet blender -b -t 2 --python-exit-code 1 --python Tools/create_catalog_icons.py. Nutný .NET 8 a Blender. Regenerovatelné pile-input.json a Art/ModuleKit/model.json nejsou ve zdrojovém ZIPu; druhý obnoví Tools/bake_kit_contents.py ModuleKit.

CENY MODULŮ: Battery Backup vyžaduje 2× Kit (Switchboard Modules), Cable Analyzer 3× kit. Jističe i pojistkové držáky zůstávají za 1 kit. Nativní EntryQuantity řídí zároveň spotřebu při stavbě, kontrolu dostatečné zásoby, požadavky ve F1 a vrácení při demontáži; neprovádí se zvláštní ruční odečítání. Výrobní recept jednoho kitu se nemění.

NÁZEV POJISTKOVÉHO SLOTU: pouze Cable Fuse, bez výkonu. Omezení přijímané pojistky podle výkonu modulu zůstává stejné.

NÁZVY: Kit (Switchboard Cover), Kit (Switchboard Rails), Kit (Switchboard Modules). Samostatné díly: Switchboard Cover a Switchboard Rail. Konkrétní typy modulů zůstávají rozlišené jako Breaker, Fuse Holder, Battery Backup a Cable Analyzer. Stabilní prefab ID se nemění. Staré výchozí názvy kitů/dílů se při načtení převedou, vlastní názvy hráče zůstanou zachované.

F1 NÁHLEDY: využívají produkční geometrii modulů s bílým tělem, šedými šrouby/svorkami a tmavými čely. Jističe mají páčky z původního APC modelu. Páčky a pojistky jsou podle výkonu zelené (1 kW), žluté (5), oranžové (50), červené (100), fialové (500). Battery Backup má původní držák APC se zlatými kontakty; Cable Analyzer původní čelo s displejem a bleskem. Obrázky jsou předem vykreslené z modelové geometrie, nejde o živou kameru ve hře; osvětlení je neutrální a bílé tělo neovlivňuje barvu již postavených modulů. Samostatný kryt má plný panel, výřezy vznikají až podle konkrétního osazení skříně.

POJISTKOVÝ SLOT VE F1: Cable Fuse Slot, nyní s mezerou před Slot; Type zůstává Cable Fuse bez výkonu.

NASAZENÍ KRYTU: drž Kit (Switchboard Cover) v aktivní ruce, zamiř dovnitř otevřeného dokončeného rozvaděče a podrž levé tlačítko 2 sekundy. Bez pravého tlačítka, stavebního náhledu, otáčení nebo volby polohy. Při puštění tlačítka či změně cíle/nástroje se akce zruší bez spotřeby. Po dokončení server ověří stav a spotřebuje právě jeden kit původní metodou LibConstruct, která také uloží a replikuje kryt. Druhý kryt nelze nasadit. SUNDÁNÍ: Wrench, vrátí kit; drátování a moduly zůstávají. Původní kryty uložené ve stavu 0.12.94 nadále vracejí původní 1 Iron Sheet.

POJISTKOVÝ SLOT: opraveno zobrazení chybového tokenu ve Stationpedii. Název i typ je Cable Fuse. Přijímá stále jen jednu jednotku správného nativního Cable Fuse kitu odpovídajícího výkonu; samotné chování pojistky se nemění.

F1: Electronics → Modular Switchboards. České a anglické názvy/synonyma zůstávají, jsou dostupné i v Creative Spawn Menu. Doplněna ochrana českých dotazů jako „měřák“ před nativním odstraňováním písmen s diakritikou. Ostatní předměty a vyhledávání jejich hashů zůstávají dostupné. Starý přechodný jistič 20 kW zůstává jen kvůli kompatibilitě savů.

Stavba skříně beze změny z Beta 1: kit vytvoří rám, Wrench + 2× Plastic Sheet dokončí plášť. Tovární recepty kitů se nemění. Kryt dál sahá k vnitřním okrajům a odkrývá celá barevná čela modulů, barva skříně se nepřenáší na vodiče/moduly.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards, ponech LibConstructReloaded a LaunchPadBooster. V multiplayeru shodná verze u hosta i klientů. Formát savů a existující instalované díly zachované.

Ověření: sestavení proti herním DLL; binární geometrie, indexy a normály; kontrola skutečných kontaktů všech 13/13 modulů, neprůniku trojúhelníků bednou a zakrytí dna. Přesná shoda všech dat a ikony lišt s 0.13.17. Kalibrační rozměr a střed vycházejí z původní bedny lišt. F1 oprava je omezena na stránku skříně a nemění interní stavbu/savy.
