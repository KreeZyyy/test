# Modular Switchboards 0.13.55

## Otočný hlavní vypínač na dveře

Nový **Door Main Switch** je sedmá varianta ve stejném dveřním kitu. Jeden kus spotřebuje jeden kit. Původních šest variant a jejich pořadí zůstávají stejné.

Žlutá čtvercová základna, červený otočný kotouč a vystouplá rukojeť. Pevné značky **0 / I**, animované otočení o 90°. Nový vypínač je v poloze **0 (vypnuto)**. Kliknutí přepne na I a zpět; není potřeba držet reset.

**0** rozpojí cestu mezi zadní horní a spodní svorkou. **I** ji propojí. Jde o ruční vypínač bez nadproudové ochrany, nikoli jistič ani TOTAL STOP. Odpojí jen cesty vedené přes jeho svorky; případná jiná přívodní cesta nebo baterie může dál napájet další části rozvodu.

Ovládání funguje bez napájení, při otevřených i zavřených dveřích. Používá nativní OnOff a serverovou interakci: stav se ukládá, synchronizuje a načítá při připojení klienta. Načtení ani animace stav neresetují.

Pokládání používá existujících devět dveřních pozic a skutečný zelený/červený model. Zadní svorky a zapojování přes hinge bridge používají stejné rozměry jako LED a STOP. Kabely připojuj z vnitřní strany po otevření dveří. Před demontáží odstraň připojené vodiče.

## Ověření

Produkční build proti herním DLL bez chyb a varování. 41 kontrol skutečného ovladače/animace a extrahovaného produkčního Conducting/Trip: zapnutí/vypnutí, zrušené interakce, serverový požadavek, neplatný/rozestavěný díl, stav po načtení, nezávislé instance, přerušení/propojení skutečného WireCircuit a absence automatického vybavení. Regresní kontroly: 125 LED a 36 TOTAL STOP.

Unity a běžící hra zde nejsou dostupné; ověř ve hře pokládání, natočení rukojeti, svorky, napájení a opětovné načtení savu. Host a klienti musí mít verzi **0.13.55**. Test ZIP obsahuje hotový mod; source ZIP zdroje a ověřovací nástroje.

Záloha **0.13.51** zůstává zachovaná. Při přechodu z experimentální 0.13.52 nejdřív odmontuj zrušený dveřní analyzer a jeho vodiče.
