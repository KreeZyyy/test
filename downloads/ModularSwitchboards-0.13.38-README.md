# Modular Switchboards 0.13.38 — automatický analyzer a hezčí trasy vodičů

Cable Analyzer vybírá síť podle skutečného zapojení:
- Input -> Analyzer -> Breaker/Fuse Holder -> Output: měří Input.
- Input -> Breaker/Fuse Holder -> Analyzer -> Output: měří tento Output.
- Input -> Analyzer -> Output bez ochrany: měří Output.
- Samostatná odbočka Input -> Analyzer IN bez OUT a bez ochrany před analyzérem: měří Input.

Poloha vůči ochranným prvkům se určuje z fyzické topologie včetně rozepnutého jističe/spálené pojistky. Samotné vypnutí ochrany proto nesmí zaměnit měřenou stranu. Pasivní analyzery a Battery Backup se nepočítají jako ochranné prvky. Mezi dvěma ochranami má přednost poloha za předchozí ochranou (Output); není-li výstupní cesta průchozí, tooltip hlásí chybějící cestu a nepřepne na Input. Přímé zapojení bez ochrany má podle zvoleného pravidla přednost Output.

Tooltip pojmenuje měřený Input / Output 1 / Output 2 a nadále používá původní Actual, Required, Potential z CELÉ této nativní kabelové sítě. Jde o celosíťové hodnoty, nikoliv proud samotným vnitřním vodičem. Chybějící kabel/síť nevymýšlí nulové hodnoty; dvě odlišné výstupní sítě zůstávají chybou. Nemění se vedení výkonu ani vypínání ochran.

Nový generátor tras jemněji upřednostňuje vodorovné pásy (poplatek přepočítaný na délku místo vysoké ceny za každý 3mm krok), více upřednostňuje méně zatáček a penalizuje vizuální křížení existujících vodičů i mezi hloubkovými vrstvami. Křížení není absolutně zakázané, pokud není rozumná alternativa. Skutečné 3D odstupy od vodičů, modulů, kontaktů a lišt zůstávají pevnou podmínkou. Sdílený vstupní uzel má dál výjimku pro úmyslné spojení. Nový výpočet se použije při natažení nového vodiče; existující uložené trasy a jejich formát se nemění, RouteVersion zůstává 4.

Ověření: Release proti herním DLL bez chyb/varování; 14 nových kontrol automatické volby sítě před/za ochranou, přímého zapojení, rozepnutí, sériových senzorů, izolace a neúplného zapojení. Kompletní wiring harness prošel 10051 kontrolami obvodů, rozpočtu, ukládání a vedení tras (navíc samostatné sady ochran a 2023 kontrol bateriového mostu). Nové geometrické příklady kontrolují vyhnutí křížení v jiné hloubce, zachování odstupů a odstranění zbytečné vysoké okliky. Testy bez Unity, skutečné vzhledy a hodnoty ověřte ve hře.

Verze nevyžaduje přepínač analyzeru ani nové nastavení/síťový formát. Host i klienti mají mít stejnou verzi, aby se shodoval výpočet tooltipu i náhledu vodičů. Kit analyzeru nadále vyžaduje 3 modulové kity a nemá nový recept.

Zdrojový ZIP obsahuje zdroje a authoring data bez přeložené DLL; hotový mod je v test ZIPu.

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
