# Modular Switchboards 0.13.31 — nativní zvuk při spálení pojistky

Při novém spálení pojistky se lokálně volá Singleton<AudioManager>.Instance.PlayAudioClipsData(CableRuptured.CableSparkHash, pozice modulu), stejně jako ve vanilla CableRuptured.Awake. Nepoužívá se předchozí AudioEvent.Create. Přehrává se existující herní zvuk CableSpark přes běžný herní systém, tedy s jeho doslechem, prostředím a nastavenou hlasitostí.

Host/singleplayer přehrává zvuk při Trip na hlavním vlákně (fronta přetížení se vybírá v LateUpdate rozvaděče). Klienti přehrávají nový zvuk při přijetí novějšího čítače spálení v aktualizaci modulu. Čítač je přechodný, neukládá se do savu, a při připojení hráče se načte jako tichý výchozí stav. Další spálení se tak rozpozná i mezi dvěma snímky, které oba mají Tripped=true; duplicitní a starší aktualizace se zvukově neopakují. Při sloučení několika událostí do jedné aktualizace se přehraje jeden aktuální zvuk, ne opožděná zvuková fronta.

Při načítání/starém spáleném stavu se zvuk nehraje. Dedicated server zvuk nepřehrává, běžící klienti si jej přehrají sami. Přístup k AudioManageru má kontrolu existence. Podmínka Running odpovídá nativní herní cestě; při chybějícím manageru se nepřehrává a nevyhazuje chyba.

DŮLEŽITÉ PRO MULTIPLAYER: změnil se paket aktualizace modulu a připojovací stav (přidaný čítač). Host a všichni klienti musí mít 0.13.31. XML savy, spotřeba pojistky, přerušení proudu, vizuální spálená patrona, recepty a všechny modely/ikony jsou stejné jako 0.13.30.

Ověření: sestavení proti herním DLL, 81 kontrol produkční metody Trip, vkládání/spotřeby patron, save/join/update serializace a skutečné třídy DinFuseAudio s testovacím AudioManagerem. Kontroly pokrývají hosta, klienta, opakovaný i starý paket, nové spálení při Tripped→Tripped, tiché připojení/načtení, dedicated režim a nedostupný AudioManager. Unity zde není dostupné, skutečnou slyšitelnost je nutné potvrdit ve hře.

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
