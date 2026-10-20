# Modular Switchboards 0.13.0 — Beta 1

F1 / Stationpedia: všechny aktuální díly jsou v Electronics → Modular Switchboards. Najdeš skříň a její kit, DIN lištu a její kit, vnitřní kryt a jeho kit, Kit (DIN Modules), výkonové varianty jističů a pojistek, bateriový modul i Cable Analyzer. Starý přechodný jistič 20 kW zůstává kompatibilní se savy, ale v nové nabídce se nezobrazuje.

Hledání funguje přes původní názvy, výkony i přidaná česká/anglická hesla, včetně diakritiky: rozvaděč/skříň/switchboard/cabinet, lišta/rail, kryt/cover, jistič/breaker, pojistka/fuse, baterka/baterie/akumulátor/battery/APC, analyzátor/analizátor/analyzer/analyser/elektroměr/měřák/wattmeter. Fungují i víceslovné dotazy a kombinace typu „jistič 100 kW“. Jde o běžné názvy a synonyma, nikoli obecnou automatickou opravu každého překlepu. Původní vyhledávání ostatních herních stránek se nemění.

Nové náhledy rozlišují pojistkový držák, bateriový modul, analyzátor a vnitřní kryt. Kity používají odpovídající ikony místo převzatého vanilla kitu. Popisy baterie a analyzátoru odpovídají jejich funkci. Regenerace F1 a změna jazyka nevytváří duplicitní záznamy.

STAVBA SKŘÍNĚ: Kit (Switchboard) postaví základní rám. Wrench + 2× Plastic Sheet v druhé ruce dokončí plášť a dveře. Nahrazuje to dřívější 2× Iron Sheet; cena kitu v Electronics Printeru zůstává 10 Iron + 10 Copper + 10 Electrum. Ostatní kity/recepty se nemění. Nativní demontáž tohoto stavebního kroku vrací Plastic Sheets. Původní samostatné kryty ze staré 0.12.94 dál vrací svůj 1 Iron Sheet.

Kryt a vzhled navazují na 0.12.98: zapuštěný panel k vnitřním okrajům, celé barevné přední části modulů odkryté, svorky a vodiče schované. Rozměry určuje profil skříně a otvory skutečné osazení, připravené i pro další rozměry skříní. Nové velikosti rozvaděčů tato beta ještě nepřidává. Barva skříně se nepřenáší na vodiče ani moduly.

Zůstává oprava survival výběru montážní desky krytu z 0.12.99: kit vybere správný rozvaděč i při zásahu do modulu/vodiče, neplatný cíl smaže předchozí desku. Nasazení a odebrání stále používá kit a Wrench. Skutečné survival nasazení a uživatelem zmiňované chování levého tlačítka zatím nejsou potvrzené v běžící hře; tato beta je nezamlčuje jako vyřešené.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards. Ponech LibConstructReloaded a LaunchPadBooster. V multiplayeru stejná verze na hostu a klientech. Identifikátory prefabů a formát savů zůstávají zachované; stávající skříně se nemusejí stavět znovu.

Ověření: sestavení proti herním DLL bez chyb/varování; 41 kontrol produkčního F1 katalogu a hledání; 61 kontrol modulů/pojistek/přenosu stavu; 37 547 kontrol krytu/geometrie/migrace savů; 14 kontrol survival výběru cíle; všech 8 PNG ikon a konfigurace 2 Plastic Sheets ověřené. Nemáme běžící Unity hru: výsledné F1 zobrazení, skutečnou spotřebu/vrácení materiálu a survival ovládání ověř ve hře.
