# Modular Switchboards 0.13.5 — Beta 6

NÁHLED KRYTU: samostatný Switchboard Cover má ve F1 bílý panel. Mění se pouze ikona; kryt ve hře dál přebírá barvu konkrétní skříně.

DIAGNOSTIKA ORIGINÁLNÍCH KITŮ: po načtení hry automaticky vznikne ModularSwitchboards-ConsoleKits-reference.zip v Application.persistentDataPath (na Windows obvykle %USERPROFILE%\AppData\LocalLow\Rocketwerkz\Stationeers). Obsahuje původní modely, UV, transformace a materiály kitů Modular Console/Terminal. Tento export je potřeba pro převzetí původní herní bedny a rámové krabice včetně odpovídajících ikon. V této verzi kity zatím používají modely z 0.13.4.

CENY MODULŮ: Battery Backup vyžaduje 2× Kit (Switchboard Modules), Cable Analyzer 3× kit. Jističe i pojistkové držáky zůstávají za 1 kit. Nativní EntryQuantity řídí zároveň spotřebu při stavbě, kontrolu dostatečné zásoby, požadavky ve F1 a vrácení při demontáži; neprovádí se zvláštní ruční odečítání. Výrobní recept jednoho kitu se nemění.

NÁZEV POJISTKOVÉHO SLOTU: pouze Cable Fuse, bez výkonu. Omezení přijímané pojistky podle výkonu modulu zůstává stejné.

NÁZVY: Kit (Switchboard Cover), Kit (Switchboard Rails), Kit (Switchboard Modules). Samostatné díly: Switchboard Cover a Switchboard Rail. Konkrétní typy modulů zůstávají rozlišené jako Breaker, Fuse Holder, Battery Backup a Cable Analyzer. Stabilní prefab ID se nemění. Staré výchozí názvy kitů/dílů se při načtení převedou, vlastní názvy hráče zůstanou zachované.

VZHLED KITŮ: čtyři propracovanější otevřené přepravky se zesílenými okraji, rohovými výztuhami, nohami a tmavými madly. Switchboard obsahuje panely a rámové profily; Cover několik odsazených panelů s oddělenou přihrádkou na úchyty; Rails tři otevřené U profily s viditelnými otvory; Modules tři neutrální těla modulů s kontakty v oddělených přihrádkách. Ikony jsou rendery stejných produkčních modelů z vyššího pohledu, aby byl obsah čitelný. Neutrální šedá/bílá, bez výkonových barev. Původní identita kitů, kolize, držení, stohování a recepty zůstávají. Geometrie je přizpůsobena původnímu koliznímu obalu.

F1 NÁHLEDY: využívají produkční geometrii modulů s bílým tělem, šedými šrouby/svorkami a tmavými čely. Jističe mají páčky z původního APC modelu. Páčky a pojistky jsou podle výkonu zelené (1 kW), žluté (5), oranžové (50), červené (100), fialové (500). Battery Backup má původní držák APC se zlatými kontakty; Cable Analyzer původní čelo s displejem a bleskem. Obrázky jsou předem vykreslené z modelové geometrie, nejde o živou kameru ve hře; osvětlení je neutrální a bílé tělo neovlivňuje barvu již postavených modulů. Samostatný kryt má plný panel, výřezy vznikají až podle konkrétního osazení skříně.

POJISTKOVÝ SLOT VE F1: Cable Fuse Slot, nyní s mezerou před Slot; Type zůstává Cable Fuse bez výkonu.

NASAZENÍ KRYTU: drž Kit (Switchboard Cover) v aktivní ruce, zamiř dovnitř otevřeného dokončeného rozvaděče a podrž levé tlačítko 2 sekundy. Bez pravého tlačítka, stavebního náhledu, otáčení nebo volby polohy. Při puštění tlačítka či změně cíle/nástroje se akce zruší bez spotřeby. Po dokončení server ověří stav a spotřebuje právě jeden kit původní metodou LibConstruct, která také uloží a replikuje kryt. Druhý kryt nelze nasadit. SUNDÁNÍ: Wrench, vrátí kit; drátování a moduly zůstávají. Původní kryty uložené ve stavu 0.12.94 nadále vracejí původní 1 Iron Sheet.

POJISTKOVÝ SLOT: opraveno zobrazení chybového tokenu ve Stationpedii. Název i typ je Cable Fuse. Přijímá stále jen jednu jednotku správného nativního Cable Fuse kitu odpovídajícího výkonu; samotné chování pojistky se nemění.

F1: Electronics → Modular Switchboards. České a anglické názvy/synonyma zůstávají, jsou dostupné i v Creative Spawn Menu. Doplněna ochrana českých dotazů jako „měřák“ před nativním odstraňováním písmen s diakritikou. Ostatní předměty a vyhledávání jejich hashů zůstávají dostupné. Starý přechodný jistič 20 kW zůstává jen kvůli kompatibilitě savů.

Stavba skříně beze změny z Beta 1: kit vytvoří rám, Wrench + 2× Plastic Sheet dokončí plášť. Tovární recepty kitů se nemění. Kryt dál sahá k vnitřním okrajům a odkrývá celá barevná čela modulů, barva skříně se nepřenáší na vodiče/moduly.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards, ponech LibConstructReloaded a LaunchPadBooster. V multiplayeru shodná verze u hosta i klientů. Formát savů a existující instalované díly zachované.

Ověření: 209 676 kontrol nové geometrie kitů, indexů/normál a přizpůsobení obalu; čisté sestavení proti herním DLL; 39 kontrol produkčního přímého nasazení a názvů (preview/klient/zrušení bez spotřeby, dokončení spotřebuje jednu jednotku, duplicity, zavřená či nehotová skříň, dosah, nesprávný kit, zachování vlastních názvů); 47 kontrol hledání/katalogu včetně nativního čištění českých dotazů a Creative menu; 63 kontrol modulů a pojistkového slotu; 37 547 kontrol geometrie/stavu/savů krytu; ověření původní geometrie pojistky, nativního APC držáku a čela analyzátoru použité pro ikony. Unity hra není spuštěná: nové ovládání, živý multiplayer a konečný vzhled ještě vyžadují herní ověření.
