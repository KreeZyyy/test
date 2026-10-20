# Modular Switchboards 0.13.22 — dvě krabice, plastové desky a šikmý rám

Nový Kit (Switchboard): dospodu tři lehce odsazené světlé plastové desky, na ně dvě samostatné vyšší kartonové krabice vedle sebe a nahoru náš otevřený montážní rám, natočený o přibližně 14 stupňů přes obě víka. Vše je svázané dvěma světlými pásy s kovovými sponami. Hrany desek, mezera mezi krabicemi, přelepená víka a vlastní montážní štítky zůstávají viditelné. Větší půdorys používá stejnou kalibraci jako schválené bedny modulů a lišt.

Pásy vznikají až po sestavení geometrie: vypočítají se skutečné průřezy obou krabic, desek i natočeného rámu a obepnou jejich konvexní obrys s malým odstupem pro tloušťku pásu. Nevisí tedy v ploše podle samotné nejvyšší hrany rámu.

Procedurální model je celý náš (Source/SwitchboardKitGeometry.cs), stejně jako soukromá sada pěti materiálů (Source/CabinetKitSurface.cs). Žádná geometrie nebo textura Modular Consoles se nekopíruje. Referencí byla pouze uživatelova skladba balíku. Barvy materiálů a exportovaná produkční geometrie se používají i pro ikonu.

Oprava náhledu z 0.13.21 zůstává: cílový mesh před CombineMeshes používá UInt32, pokud součin počtu vrcholů a submeshů překračuje 65535. Zachovaný je i záložní shader StandardInstanced. Recepty, stavba, stabilní identity kitů a kompatibilita savů se nemění. Schválené bedny lišt a modulů včetně obsahu a ikon jsou beze změny.

Ověření: sestavení proti herním DLL; kontrola produkční geometrie včetně indexů, normál a neobrácených trojúhelníků; regresní hranice blueprintu z Player.log; shoda všech ostatních ikon a binárních modelů. Unity zde není dostupné, velikost a manipulaci je potřeba ověřit ve hře. Zachované jsou nativní úchopy a kolizní obálka původního kitu, větší model má vizuální přesah.

Reprodukce ikony: KIT_GEOMETRY_EXPORT=<absolutní cesta>/Art/KitGeometry.json dotnet run --project Verification/KitGeometry/Check.csproj -c Release; poté ICON_FILTER=KitCabinet blender -b -t 2 --python-exit-code 1 --python Tools/create_catalog_icons.py. Nutný .NET 8 a Blender. Zdrojový ZIP neobsahuje regenerovatelné pile-input.json a Art/ModuleKit/model.json; ten obnoví Tools/bake_kit_contents.py ModuleKit. Veškeré kanonické podklady, finální rozmístění i binární modely jsou přiložené.

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
