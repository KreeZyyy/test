# Modular Switchboards 0.13.14 — volně uložené součástky v kitech

DIN lišty v bedně jsou nepravidelně posunuté a pootočené, horní kusy leží šikmo přes ostatní a delší lišta vyčnívá nad okraj. Čtyři různé délky a skutečné otvory zůstávají. Jistič, prázdný pojistkový držák a Battery Backup v bedně modulů mají každý jiný mírný náklon, natočení a posunutí. Všechny detaily se pohybují společně se svým modulem.

Rozložení je pevně navržené, nikoli náhodně měněné při každém načtení. Modely ve světě, v ruce, vlastní náhled položení i F1 ikony používají stejné nové rozmístění. Obě původní bedny, atlas a runtime kód jsou beze změny kromě čísla verze; automatické přizpůsobení zachovává původní kolizní obal kitu i s vyčnívajícími díly. Počty dekorativních součástek nejsou počty skutečných kitů.

Autorské podklady lze reprodukovat: Tools/arrange_module_kit.py používá uložené původní packed-contents.json, Tools/create_rail_kit.py vytváří nepravidelné DIN profily, společný create_module_kit.py zapisuje meshbin. Ikony vytvoří odpovídající render_module_kit.py a render_rail_kit.py. Pro render je potřeba Blender s Pythonem bpy; generátor dat používá Python a Pillow.

Záloha před úpravou: 0.13.13 test i source ZIP zůstávají dostupné. Unity zde není k dispozici, proto držení, položení a skutečné nasvícení čekají na ověření ve hře.

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

Ověření: shodné původní bedny a runtime zdroje s 0.13.13, kontrola binární geometrie, indexů, normál a kolizního obalu, vizuální kontrola obou nových ikon a sestavení proti herním DLL.
