# Modular Switchboards 0.13.41 — dveřní LED a průchozí blok u pantu

Nový samostatný kit **Switchboards Doors Module** zatím používá původní model a textury Logic Kitu. V Electronics Printeru stojí stejně jako kit modulů: 2 g Iron + 1 g Copper. Jedna LED nebo jeden celý průchozí blok spotřebuje 1 kit. Hotové díly se demontují Hand Drillem; nejdřív je nutné odstranit připojené vodiče.

## Zelená LED

Na malých dveřích je mřížka 3×3 se středovou roztečí 100 mm. Zvenku je černý límec a zelená čočka (32 mm vnější průměr), zevnitř tělo se svorkami IN/OUT. LED rozsvítí dostupný napájecí zdroj dosažitelný na IN; nepotřebuje odběr spotřebiče ani zapojený OUT. OUT je průchozí a může vést dál. Kontrolka sama neposkytuje jištění ani výkon. Stav se replikuje ze serveru, včetně připojení klienta do běžící hry. U vybitých/odpojených zdrojů nebo otevřeného jištění zhasne.

Kit pravým tlačítkem přepni do stavby, zvol Door LED Green a zamiř na vnější plochu dokončených dveří. Pro montáž průchozího bloku otevři skříň a sundej vnitřní kryt. Při drátování drž Cable Coil a klikni na dvě zvýrazněné svorky, stejně jako u DIN modulů.

## Door Terminal Bridge

Druhá varianta stejného kitu. Osadí se jednou na vyhrazené úzké místo montážní desky pouze podél levého závěsu. Obsahuje pevnou i pohyblivou svorkovnici a 18 samostatných pružných propojení. Pohyblivá část, dveřní vodiče a LED sledují skutečný pant i během animace.

Liché kanály (1, 3, …, 17) vedou z desky na dveře: plate IN → door OUT. Sudé kanály (2, 4, …, 18) vedou zpět: door IN → plate OUT. Směry se střídají, takže každá dvojice sousedních kanálů umožní přívod i návrat. Každý kanál je oddělený; nejde o společnou sběrnici. Čísla na obou stranách odpovídají. Z desky se vodiče zapojují jen do pevné části, na dveřích jen do pohyblivé části. Přímé vedení vodiče mezi těmito dvěma plochami se odmítne: propojení vede přes blok. Při osazeném bloku vznikne v krytu průchod pro pohyblivý svazek.

Příklad:
Input → jistič IN; jistič OUT → Output 1.
Druhý kabel z téhož jističe OUT → bridge 1 plate IN.
Bridge 1 door OUT → LED IN.
Volitelně LED OUT → bridge 2 door IN → bridge 2 plate OUT → další modul / výstup.

## Dvě odbočky za ochranou

Jističe a pojistkové držáky nyní přijímají až dva kabely na existující OUT svorce. IN zůstává pro jeden kabel. Limit jištění se vztahuje na součet skutečného výkonu všech navazujících větví. Třetí kabel se odmítne; LED, analyzer, bateriový modul a jednotlivé průchody nadále mají jen jeden kabel na OUT. Generátor dovoluje úmyslný společný rozbočovací úsek pouze v přívodním prostoru této konkrétní OUT svorky. Ostatní kolize a vzdálenosti zůstávají povinné.

## Kompatibilita a ověření

Staré XML savy bez dveřních montážních desek zůstávají podporované; existující trasy se automaticky nepřepočítávají. Nové dveřní moduly i vodiče používají vlastní souřadnice montážní desky / dveří. V síťovém připojení přibyly montážní desky a stav LED, proto musí mít všichni účastníci 0.13.41. Uloženou hru s novými díly neotvírej ve starší verzi modu.

Ověřeno: produkční sestavení bez chyb a varování proti skutečným herním DLL; 50 408 kontrol dveřních modulů včetně skutečných 18 tras pro všech 9 LED, 12 464 kontrol obvodů/tras/ukládání a 43 218 kontrol krytů. Dále stávající testy analyzeru, ochrany, bateriového mostu, kabelů, ukládání a geometrie. Nové kontroly testují 3×3 pozice, izolaci všech 18 průchodů, LED bez OUT, návrat přes LED OUT, druhou odbočku a společný limit, skutečné vedení tras, pohyb pružných přívodů a průchod krytem. Testy nevyžadují Unity. Ve hře je ještě nutné ověřit interakce montáže, vzhled, animaci a obnovení po save/load.

Instalace: použij hotový test ZIP. Zdrojový ZIP je bez přeložené DLL. Host a klienti mají mít shodnou verzi kvůli stejnému náhledu/generátoru tras.

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
