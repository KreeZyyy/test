# Modular Switchboards 0.13.79 — venkovní štítky a nápověda krytu

Door Label: tučné písmo96 pro LED i otočný switch. U switche větší název a samostatné pevné znaky0/I na stejném druhém řádku (vlevo0, vpravoI); mezery už nezmenšují jejich velikost. Název zůstává editovatelný,0/I pevné. Text už nemá umělý limit zvětšení měřítka1. Držák ani montáž se nemění.

Emergency Stop Label: větší tučné nápisy EMERGENCY/STOP, stále na stejném žlutém kroužku a s hloubkovým testováním. Kryt ani svícení se nemění.

Vnitřní štítky: při chybějícím krytu jasná hláška Install an inner cover first. Internal labels mount on the cover. Zavřená skříň má vlastní výzvu k otevření; při existujícím krytu nápověda pro míření nad DIN moduly. Požadavek krytu je i v popisu kitu a vnitřních štítků. Vnitřní typografie0.13.78, ukládání a pravidla montáže/demontáže beze změny.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards ve složce mods; host a klienti stejná verze. Ve hře ověř LED text, switch název a0/I, kroužek STOP, míření bez krytu i s krytem a zavřenými dveřmi. Unity runtime není dostupný, skutečné fontové metriky a čitelnost vyžadují ověření ve hře. Záloha0.13.51 zachovaná.

Ověření: Release build bez chyb/varování;93 kontrol montáže DIN štítků,104 integrovaných kontrol včetně chybějícího/existujícího krytu a zavřené skříně,3839 geometrických a montážních kontrol Door/Emergency štítků. Izolované fixture nenahrazují Unity scénu. Emergency placement nápověda navíc správně odkazuje na TOTAL STOP, nikoli LED.
