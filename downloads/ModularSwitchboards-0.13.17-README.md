# Modular Switchboards 0.13.17 — plné bedny, podepřené díly a výkonové barvy

Bedna modulů obsahuje 13 dekorativních dílů: šest jističů, pět pojistkových držáků s vloženými ukázkovými pojistkami, Battery Backup a Cable Analyzer. Páčky jističů a pojistky mají stejné výkonové barvy jako herní moduly: 1 kW zelená, 5 kW žlutá, 50 kW oranžová, 100 kW červená, 500 kW fialová. Jistič 5 kW je zastoupený dvakrát. Sloty dekorativních dílů nejsou funkční inventáře; obsah bedny nijak nemění počet skutečných kitů, recepty ani stavěné moduly.

Bedna DIN lišt je zaplněná 24 kusy čtyř různých délek. Horní profily již nemají ručně nastavenou výšku ve vzduchu. Každý díl se při přípravě spouští po svislici na skutečné viditelné trojúhelníky spodních kusů nebo dno. Kandidátní průniky se odmítají přesným testem trojúhelníků. Rozmístění je pevné, zapečené do modelu; hra nesimuluje fyziku jednotlivých součástek.

Nezávislá kontrola povrchů ověřila u všech 13 modulů a 24 lišt návaznost kontaktů až ke dnu. Tolerance kontaktu je 5 mm v autorských jednotkách před přizpůsobením velikosti kitu; běžná mezera mezi dotykovými plochami je přibližně 1–3 mm. Kontrola zároveň ověřuje podlahu, stěny a zkosené rohy pod lemem. Vyšší díly mohou přesahovat nad okraj, stále však mají oporu.

Obě bedny a atlas jsou původní. Model ve světě, ruce, vlastní náhled položení i F1 ikona používají shodné finální rozmístění. Podrobnější bedna modulů má 148402 vrcholů a používá 32bitové indexy; náhled položení přebírá stejný formát. Načítání má omezené maximální počty a nadále kontroluje indexy i délku dat. Menší modely zůstávají na 16bit indexech. Stavění, ceny, identifikátory a savy se nemění.

Reprodukce: Tools/arrange_module_kit.py a Tools/create_rail_kit.py spouštějí kompletní přípravu, usazení, kontrolu opory, zápis meshe a render. Potřebný je Python/Pillow a Blender (ověřeno 4.3.2). pile-input.json, pile-settled.json a support-audit.json uchovávají vstup, finální transformace a výsledky kontroly. Předchozí 0.13.16 test/source ZIP zůstává jako záloha. Unity zde není dostupné; skutečný vzhled, držení, náhled položení a výkon je nutné ověřit ve hře.

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

Ověření: sestavení proti herním DLL, kontrola binárních modelů, indexů, normál a velikosti; podpora všech 13/13 modulů a 24/24 lišt skutečnými povrchy s cestou až ke dnu, kontrola stěn a rohů; obě finální ikony vizuálně zkontrolované.
