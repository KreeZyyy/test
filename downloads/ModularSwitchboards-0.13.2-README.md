# Modular Switchboards 0.13.2 — Beta 3

CENY MODULŮ: Battery Backup vyžaduje 2× Kit (Switchboard Modules), Cable Analyzer 3× kit. Jističe i pojistkové držáky zůstávají za 1 kit. Nativní EntryQuantity řídí zároveň spotřebu při stavbě, kontrolu dostatečné zásoby, požadavky ve F1 a vrácení při demontáži; neprovádí se zvláštní ruční odečítání. Výrobní recept jednoho kitu se nemění.

NÁZEV POJISTKOVÉHO SLOTU: pouze Cable Fuse, bez výkonu. Omezení přijímané pojistky podle výkonu modulu zůstává stejné.

NÁZVY: Kit (Switchboard Cover), Kit (Switchboard Rails), Kit (Switchboard Modules). Samostatné díly: Switchboard Cover a Switchboard Rail. Konkrétní typy modulů zůstávají rozlišené jako Breaker, Fuse Holder, Battery Backup a Cable Analyzer. Stabilní prefab ID se nemění. Staré výchozí názvy kitů/dílů se při načtení převedou, vlastní názvy hráče zůstanou zachované.

VZHLED KITŮ: všechny čtyři kity včetně Kit (Switchboard) mají původní model a ikonu Kit (Logic Switch). Samotné instalované díly se nemění. Náhledy pojistky, bateriového modulu a analyzátoru byly nahrazené rendery testované produkční geometrie včetně nativního APC držáku a nativního čela analyzátoru. Předchozí zjednodušené náhledy s obyčejnými kvádry se už nepoužívají. Samostatný kryt má plný panel, protože výřezy vznikají až podle konkrétního osazení skříně. Světlo a povrch náhledů nemusí přesně odpovídat hernímu shaderu.

NASAZENÍ KRYTU: drž Kit (Switchboard Cover) v aktivní ruce, zamiř dovnitř otevřeného dokončeného rozvaděče a podrž levé tlačítko 2 sekundy. Bez pravého tlačítka, stavebního náhledu, otáčení nebo volby polohy. Při puštění tlačítka či změně cíle/nástroje se akce zruší bez spotřeby. Po dokončení server ověří stav a spotřebuje právě jeden kit původní metodou LibConstruct, která také uloží a replikuje kryt. Druhý kryt nelze nasadit. SUNDÁNÍ: Wrench, vrátí kit; drátování a moduly zůstávají. Původní kryty uložené ve stavu 0.12.94 nadále vracejí původní 1 Iron Sheet.

POJISTKOVÝ SLOT: opraveno zobrazení chybového tokenu ve Stationpedii. Název i typ je Cable Fuse. Přijímá stále jen jednu jednotku správného nativního Cable Fuse kitu odpovídajícího výkonu; samotné chování pojistky se nemění.

F1: Electronics → Modular Switchboards. České a anglické názvy/synonyma zůstávají, jsou dostupné i v Creative Spawn Menu. Doplněna ochrana českých dotazů jako „měřák“ před nativním odstraňováním písmen s diakritikou. Ostatní předměty a vyhledávání jejich hashů zůstávají dostupné. Starý přechodný jistič 20 kW zůstává jen kvůli kompatibilitě savů.

Stavba skříně beze změny z Beta 1: kit vytvoří rám, Wrench + 2× Plastic Sheet dokončí plášť. Tovární recepty kitů se nemění. Kryt dál sahá k vnitřním okrajům a odkrývá celá barevná čela modulů, barva skříně se nepřenáší na vodiče/moduly.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards, ponech LibConstructReloaded a LaunchPadBooster. V multiplayeru shodná verze u hosta i klientů. Formát savů a existující instalované díly zachované.

Ověření: čisté sestavení proti herním DLL; 39 kontrol produkčního přímého nasazení a názvů (preview/klient/zrušení bez spotřeby, dokončení spotřebuje jednu jednotku, duplicity, zavřená či nehotová skříň, dosah, nesprávný kit, zachování vlastních názvů); 46 kontrol hledání/katalogu včetně nativního čištění českých dotazů a Creative menu; 63 kontrol modulů a pojistkového slotu; 37 547 kontrol geometrie/stavu/savů krytu; ověření původní geometrie pojistky, nativního APC držáku a čela analyzátoru použité pro ikony. Unity hra není spuštěná: nové ovládání, živý multiplayer a konečný vzhled ještě vyžadují herní ověření.
