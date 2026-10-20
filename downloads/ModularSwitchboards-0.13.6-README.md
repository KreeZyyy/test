# Modular Switchboards 0.13.6 — Beta 7

NÁHLED KRYTU: samostatný Switchboard Cover má ve F1 bílý panel. Mění se pouze ikona; kryt ve hře dál přebírá barvu konkrétní skříně.

PŮVODNÍ HERNÍ KITY: Modules, Rails a Cover používají skutečnou bednu z Kit (Modular Console Label Plates), s původní geometrií, UV, klipy, materiály a texturami. Původní obsah je oddělený po celých souvislých dílech. Modules obsahuje tři neutrální těla našich modulů; Rails tři skutečné perforované DIN lišty v tmavé výplni; Cover stoh bílých panelů. Switchboard používá celý původní balík Kit (Modular Console) s rámem, profily a popruhy. Ikony jsou rendery stejné geometrie s původními texturami. Vlastní geometrické náhrady beden z 0.13.4 se nepoužívají. Automatická diagnostika Console kitů už se při startu neprovádí.

ZACHOVÁNÍ CHOVÁNÍ: stejné stabilní prefab ID, kity, recepty, držení a původní kolizní obal; mění se vizuál. Nový společný vizuální kořen je rovnoměrně přizpůsoben původnímu obalu. Původní materiály herních kitů se nemění, nepřebarvují se zdrojové prefaby.

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

Ověření: čisté sestavení proti herním DLL bez chyb a varování; 243 363 kontrol skutečné geometrie obsahu, vůlí vůči původní bedně, platnosti indexů, limitu 16bitového mesh indexu a přizpůsobení koliznímu obalu; 41 059 kontrol původu nativních dat — zachované pozice/UV/trojúhelníky jsou shodné s exportem ze hry, celý rámový balík zůstává kompletní. Čtyři výsledné ikony jsou vložené do DLL. Hra Unity není spuštěná: konečný vzhled a držení nových modelů ještě ověř ve hře.
