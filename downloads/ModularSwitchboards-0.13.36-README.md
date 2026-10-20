# Modular Switchboards 0.13.36 — vzhled, výběr a plnější kit štítků

Opravy po zkoušce ve hře: zelené výběrové/stavební Bounds se nyní při CachePrefabBounds nastavují přímo podle rozměrů 1/2/3-modulového štítku, bez zděděných rozměrů Lockeru. Fyzický štítek má černý 1,2mm rámeček a bílý vnitřek, vlastní matné Standard materiály nezávislé na původní barevné paletě. Text zůstává černý. Kolize montážní plochy krytu je za štítkem; jeho MeshCollider se registruje přímo na štítek v Thing._colliderLookup, aby míření s Labellerem/vrtačkou vybíralo štítek.

Bedna: 60 štítků místo 36, širší rozložení v původním obalu. Nová gravitační pokládka kontroluje skutečné trojúhelníky bedny, oporu všech 60 dílů a horní limit 0,365 m. Maximální výška obsahu 0,31136 m. Černé rámečky a bílé plochy také v bedně; ikony nově vykreslené.

Ověření opravy: 79 kontrol produkčního umístění a rozměrů rámečku, sestavení bez chyb/varování, validace mesh/indexů a přesné shody shellu/UV s původní DIN bednou. Výběr Labellerem a barvy pod herním osvětlením ještě vyžadují zkoušku ve hře; Unity zde není dostupné.

Nový Kit (Switchboard Labels) nabízí tři šířky: 1, 2 nebo 3 modulové pozice. Každý štítek spotřebuje právě 1 kit, vrtačka jej vrátí. Electronics Printer: 1 g železa -> 1 kit. Vzhled kitu používá přesnou původní DIN bednu a její atlas; místo lišt má 60 podepřených volně rozložených bílých štítků tří délek. Vlastní ikona kitu i tří štítků, F1 kategorie/krátké popisy a vyhledávání label/popisky/štítky.

Použití: osaď moduly, nasaď vnitřní kryt a nech otevřená dvířka. S kitem pravým tlačítkem zapni umístění, vyber šířku a umísti štítek nad moduly. Štítky se zarovnají pouze do horního pásku nad každou řadou; pod moduly je dát nelze. Celá šířka musí ležet nad obsazenými pozicemi a štítky se nesmějí překrývat. Labeller nastaví vlastní text (nativní přejmenování); dlouhý text se zmenší do štítku. Vrtačka odstraní štítek a vrátí jeden kit. Před sundáním krytu nejprve odmontuj štítky.

Každý štítek je samostatný uložený díl s vlastním prefab ID a názvem. Kryt nyní vlastní samostatnou LibConstruct placement board pro štítky, včetně save/join host a board-structure hooků. Starý save bez dat štítků dostane při OnFinishedLoad prázdnou desku podle původního BoardHostHooks. Kryt ve starém vestavěném stavu 2 nemá tuto samostatnou desku; použij samostatný Kit (Switchboard Cover).

MULTIPLAYER: host i všichni klienti musí používat 0.13.36, změnil se join paket krytu. Nové štítky a jejich text/umístění je nutné ověřit také po uložení/načtení a při připojení klienta ve skutečné hře. Unity zde není dostupné, runtime hraní zde ověřené není.

Ověření: sestavení proti herním DLL bez chyb a varování; 79 kontrol skutečné produkční validace štítků (hranice/šířky, pouze horní pásky, osazení, mezery, překrývání, zavřená skříň/chybějící kryt), 51 kontrol F1 katalogu, 39 přímého nasazení krytu a 97 modulů/pojistek. Bedna: binární kontrola přesné shody původního shellu/UV, geometrie/indexů a konečných čísel, opora všech 60 dekorativních štítků a kontrola průniku se stěnami. Nativní Labeller přejmenovává Thing přes původní save/network cestu.

Zdrojový ZIP této verze obsahuje zdroje a authoring data bez přeložené DLL; hotová DLL je v test ZIPu. Tím se archiv vejde do limitu přenosu.

Regenerace label kitu: python Tools/create_label_kit.py (Blender + Pillow). Ikony jednotlivých štítků: blender -b -t 2 --python-exit-code 1 --python Tools/render_labels.py. Art/LabelKit/model.json je regenerovatelný a ve zdrojovém ZIPu vynechaný.

Zdrojový ZIP neobsahuje regenerovatelné pile-input.json, Art/ModuleKit/model.json a Art/CoverKit/model.json + source.json. Cover data obnoví: blender -b -t 2 --python-exit-code 1 --python Tools/create_cover_bundle.py -- .42; python Tools/create_module_kit.py CoverKit. Nutný Blender a Python/Pillow.

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
