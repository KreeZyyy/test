# Modular Switchboards 0.13.29 — pět krytů a bedýnka se šroubky

Kit (Switchboard Cover) je nový přepravní balík: pět původních bílých krycích panelů v plné velikosti, lehce natočených o -3, +2, -1, +4 a 0 stupňů, a nahoře menší otevřená bedýnka se šroubky. Dva pásy obepínají bedýnku i celou vrstvu krytů. Panely nejsou zmenšené dovnitř přepravky; jejich rozměr zůstává původních 386 × 486 mm a tloušťka 2 mm.

Bedýnka je stejný typ a stejná geometrie jako u schválených kitů modulů a lišt, ale v tomto balíku má 42 % původních autorských rozměrů, aby mohla stát na panelech a nezakrývala je. Obsahuje 200 dekorativních šroubků různých délek v deseti hustších vrstvách, tedy přesně o 100 % více než 0.13.28. Hromada dosahuje blíž k lemu bedýnky. Pásy se odvozují z průřezů skutečné sestavy včetně hran všech pěti natočených panelů; horní části přecházejí přes lem otevřené bedýnky. Jde jen o vzhled, počet vyrobených kitů a recept se nemění.

Source/ModuleKitModel.cs nyní umí také nezávislý CoverKit.meshbin se stejným atlasem a materiálem jako ostatní přepravky. Pro cover balík zůstává měřítko 1, aby se původní panely nesmršťovaly do obálky Logic kitu. Ostatní kity mají původní cestu i kalibraci beze změny. Model ve světě, ruce, náhled položení i F1 ikona používají stejnou geometrii balíku. Zachované jsou nativní úchopy a kolizní obálka původního kitu; velké panely mají vizuální přesah.

Ověření: sestavení proti herním DLL; přesná shoda embedded binární geometrie, indexů, normál a UV s exportem; render ikony; bezezměnná shoda všech schválených ostatních modelů a ikon. Unity zde není dostupné, vzhled a manipulaci je potřeba ověřit ve hře.

Reprodukce: blender -b -t 2 --python-exit-code 1 --python Tools/create_cover_bundle.py -- .42; python Tools/create_module_kit.py CoverKit; blender -b -t 2 --python-exit-code 1 --python Tools/render_cover_kit.py. Nutný Blender a Python/Pillow. Regenerovatelné pile-input.json, Art/ModuleKit/model.json a Art/CoverKit/model.json + source.json nejsou ve zdrojovém ZIPu. CoverKit/source.json obnoví první příkaz výše z kanonického původního krytu a schválené bedny; druhý příkaz obnoví model.json a binární model. Parametry jsou uložené také v Art/CoverKit/layout.json.

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
