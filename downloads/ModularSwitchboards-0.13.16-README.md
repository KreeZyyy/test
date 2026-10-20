# Modular Switchboards 0.13.16 — plnější bedna s Analyzerem a tři vyčnívající lišty

Bedna modulů obsahuje sedm dekorativních dílů: čtyři jističe, prázdný pojistkový držák, prázdný Battery Backup a Cable Analyzer. Pět dílů je dole, Analyzer a jeden jistič jsou nad nimi, takže bedna už není zaplněná jen u dna. Čela směřují nahoru. Analyzer používá skutečnou geometrii produkčního DIN modulu, zelený displej, šedý rám a oranžový blesk; žlutá skříň nativního analyzátoru se nepoužívá. Prázdné sloty zůstávají prázdné — uživatel upřesnil, že chce zaplnit bednu do výšky.

Dvanáct DIN profilů čtyř délek zůstává promíchaných. Tři vybrané horní lišty vyčnívají nad okraj a částečně přes něj. Ostatní kusy zůstávají uvnitř. Pro vyčnívající kusy kontrola orientovaného obalu vyhodnotí všechny rohy i průsečíky jeho hran s rovinou nad lemem: celá část pod úrovní 0.370 m musí zůstat uvnitř bezpečného obrysu stěn a zkosených rohů. Všechny páry obalů mají vzájemný odstup.

Rozmístění je pevné a vytváří se pouze offline. Ikony a náhledy položení vycházejí ze stejných finálních modelů jako předměty v ruce a ve světě. Při zápisu jsou znovu použity pouze naprosto stejné float32 vrcholy se shodnou pozicí, normálou i UV; to umožňuje přidat Analyzer při zachování 16bit kapacity meshe, bez změny povrchu. Obě původní bedny a atlas se nemění. Runtime kód je kromě čísla verze shodný s 0.13.15; stavění, kity a savy se nemění.

Autorské skripty: arrange_module_kit.py, create_rail_kit.py, create_module_kit.py, kit_layout.py a odpovídající render skripty. Jde o statickou dekorativní geometrii, nikoli fyzikální simulaci jednotlivých dílů. Záloha před změnou: 0.13.15 test i source ZIP zůstává dostupná. Unity zde není dostupné; vzhled a pokládání je nutné ověřit ve hře.

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

Ověření: sestavení proti herním DLL; ModuleKit 254296 kontrol, RailKit 23808 kontrol geometrie, normál, indexů, binárních dat a kolizního obalu. Sedm modulů: 21 oddělených dvojic; dvanáct lišt: 66 oddělených dvojic. Tři horní lišty splňují kontrolu obrysu pod lemem; obě finální ikony vizuálně zkontrolované.
