# Modular Switchboards 0.13.15 — čela nahoru a promíchané lišty

Bedna modulů obsahuje šest dekorativních dílů: čtyři jističe, prázdný pojistkový držák a prázdný Battery Backup. Moduly leží zadní stranou dolů a čelem nahoru. Rozmístění má různé pozice i natočení; netvoří tři stojící kusy ani pravidelnou řadu. Detaily zůstávají součástí svého modulu. Každý díl je zmenšený pro uložení šesti kusů do stejné bedny.

Dvanáct DIN profilů čtyř délek je promíchaných mezi různými směry a vrstvami; stejné délky již nejsou pohromadě. Původní skutečné otvory a průřezy se nemění. Rozmístění obou beden se vytváří pouze při přípravě dat s pevným seedem, ne náhodně za běhu hry.

Při přípravě se kontroluje obal každého dílu pomocí 15 os oddělujícího testu orientovaných kvádrů. Všechny moduly i lišty mají bezpečný odstup od stěn a zkosených rohů; kontrola vyžaduje mezeru i mezi obaly jednotlivých kusů. Žádný díl už není úmyslně vystrčený přes boční stěnu. Jde o statické modely, nikoli fyzikální simulaci volných dílů.

Obě bedny a atlas zůstávají stejné. Modely v ruce/světě, F1 ikony a náhledy položení vycházejí z téže geometrie. Ikona modulů má vyšší úhel kamery pro čitelná čela. Runtime kód se kromě čísla verze nemění; stavění, ceny, množství kitů a savy zůstávají zachované. Obsah bedny je dekorativní.

Reprodukce: Tools/arrange_module_kit.py, Tools/create_rail_kit.py, odpovídající Blender render skripty. Sdílený kit_layout.py obsahuje rotace, obaly, odstupy a kontrolu rohů. Záloha před úpravou: 0.13.14 test/source ZIP zůstává dostupná. Unity zde není dostupné; skutečný vzhled, držení a pokládání musí potvrdit test ve hře.

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

Ověření: sestavení proti herním DLL, kontrola binárních modelů a 16bit kapacity, indexů, normál a původního kolizního obalu. Šest modulů: 15 oddělených dvojic; dvanáct lišt: 66 oddělených dvojic. Kontrola všech obalů uvnitř bezpečné oblasti se zkosenými rohy; obě ikony vizuálně zkontrolované.
