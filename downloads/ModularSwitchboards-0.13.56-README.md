# Modular Switchboards 0.13.56

Oprava pádu přípravy prefabů v 0.13.55: otočný dveřní vypínač při vytváření modelu předčasně četl nativní OnOff. Bez animatoru tento getter vyžaduje připravenou herní cache InteractOnOff; v této fázi ještě chybí. Výjimka přerušila registraci celého modu a způsobila následné chyby ostatních dílů a receptů.

Počáteční vodorovná poloha 0 se teď nastavuje přímo na modelu bez čtení nebo zápisu nativního stavu. Stav existujícího vypínače se nemění: za běhu se rukojeť nadále řídí skutečným uloženým/synchronizovaným OnOff.

Door Main Switch zůstává sedmou volbou dveřního kitu. 0 rozpojí, I propojí, otočení 90°, jeden kit, devět dveřních pozic. Bez nadproudové ochrany. Ostatní modely, kabely a LED beze změn.

Ověření: produkční build bez chyb/varování; 43 kontrol ovladače/animace včetně nativního getteru simulovaného jako nedostupný při přípravě modelu a načteného ON stavu; kontrola skutečných registračních zdrojů proti předčasnému přístupu OnOff. Unity a běžící hra zde nejsou dostupné; potřebný je test načtení modu ve hře.

Použij místo 0.13.55; host a klienti musí mít **0.13.56**. Záloha 0.13.51 zůstává zachovaná. Při přechodu z experimentální 0.13.52 nejdřív odmontuj zrušený dveřní analyzer a jeho vodiče.
