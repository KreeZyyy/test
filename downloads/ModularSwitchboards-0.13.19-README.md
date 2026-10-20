# Modular Switchboards 0.13.19 — nižší a nakloněná hromada modulů

Horní díly jsou nově mírně nakloněné a výška celé hromady klesla z 0.462 na 0.357 autorských jednotek. Všechny díly teď zůstávají těsně pod lemem bedny; všech 13 kusů zůstává podepřených a bez průniku stěnami. Lišty a rozměry beden zůstávají stejné.

Bedna modulů má stejné měřítko a polohu základny jako schválená bedna DIN lišt z 0.13.17. Velikost se už neodvozuje od nejvyššího vystupujícího modulu. Model a ikona lišt zůstávají přesně stejné.

Analyzer je uložený u spodní vrstvy při kraji a překrytý ostatními díly; netvoří horní dominantu uprostřed. Stejných 13 dílů je hustěji rozmístěno i u boků, některé těsně vedle sebe, aby zakryly více dna a stěn. Výkonové barvy a všechny typy zůstávají. Algoritmus upřednostňuje zakrytí dosud volných míst dna, používá skutečnou geometrii bedny a menší odstup přibližně 0.3 mm v autorských jednotkách. Analyzer zůstává menší než ostatní nově zvětšené díly, takže je v hromadě méně nápadný. Kontakt všech 13 kusů má nadále návaznost až ke dnu.

F1 Build States u Switchboard Cabinet ukazuje pouze aktuální dva kroky: Kit (Switchboard) a Wrench + 2× Plastic Sheet. Třetí řádek s Iron Sheetem je odstraněný ze Stationpedie; starší uložené vnitřní kryty nadále mají kompatibilní interní stav a lze je sundat. Samostatný Kit (Switchboard Cover) se nemění.

Model ve světě, ruce, náhled položení a F1 ikona používají stejné nové rozmístění. Původní atlas a obě bedny jsou zachované; mění se rozmístění a měřítko obsahu modulové bedny a její kalibrace proti bedně lišt. Indexy větších modelů dál používají UInt32 z 0.13.17.

Reprodukce: Tools/arrange_module_kit.py spustí kompletní přípravu a render, nutný je Python/Pillow a Blender 4.3.2. pile-input.json a Art/ModuleKit/model.json jsou automaticky regenerované mezisoubory; nejsou přibalené do zdrojového ZIPu. model.json obnoví Tools/bake_kit_contents.py ModuleKit z přiloženého finálního rozmístění. Kanonické původní podklady, skripty, finální transformace, modely a kontroly jsou přiložené. Předchozí 0.13.17 test/source ZIP zůstává jako záloha. Unity zde není dostupné; velikost obou beden vedle sebe, vzhled a F1 je nutné potvrdit ve hře.

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
