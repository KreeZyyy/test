# Modular Switchboards 0.13.82 — Switchboard Medium (first test version)

Skříň Medium je posunutá o 25 cm níž než v0.13.81: spodní hrana je u vodorovné větve T. Posun platí i pro rám, dveře, desku, kryt, montážní plochy a stavební náhled. Vnější nativní kabelové pozice zůstávají stejné; horní přívod má proto delší viditelný krček. Při načtení existujícího Medium se přesune jeho model i namontované díly; vnitřní lokální kabelové trasy se nemění. Small a Reverse beze změny.

Nová třetí varianta v původním Kit (Switchboard): **Switchboard Medium**. Společná skříň široká 0,8 m a vysoká 1 m, dvě křídla otevíraná od středu do stran. Obě používají společný nativní stav Open a otevírají se současně. Small i Small (Reverse) zůstávají v kitu.

- Jeden horní Input, tři nezávislé výstupy dole: Output 1 vlevo, Output 2 vpravo, Output 3 směrem dolů. Každý má vlastní nativní kabelovou pozici a vnitřní svorku. Žádný automatický vnitřní propoj.
- Tři DIN řady, každá 14 použitelných pozic. Stávající kit lišty se přizpůsobí kabinetu; stejné DIN moduly.
- Každé křídlo má vlastní mřížku 4×3 pro dveřní moduly, vlastní štítky, kabelovou plochu a průchodky u svého pantu. Kabely různých křídel se neposuzují jako na jedné ploše. Mezi křídly se propojuje přes desku a průchodky.
- Společný vnitřní kryt se přizpůsobí větší skříni a má tři řady pro vnitřní popisky. Stejné kity krytu, dveřních modulů a Labels.

První prototyp zatím sdílí ikonu a stavební cenu Small. Pravým tlačítkem vyber Medium v Kit (Switchboard). Nová stabilní identita StructureModularSwitchboardMedium, existující Small savy se nepřevádějí. Desky pravého křídla se ukládají odděleně a přenášejí při připojení klienta; všichni hráči musí mít stejnou verzi.

Opraven pád montážního náhledu DIN lišty při změně šířky: hra odstraňuje collidery z kurzoru; Resize nyní upravuje module surface jen pokud existuje. Regresní test skutečné produkční metody reprodukoval původní NullReferenceException a po opravě prošel22kontrolami kurzoru bez colliderů, ghost mesh, hotové lišty a přepínání Small/Medium.

Ověření předchozí Medium verze: Release build bez chyb a varování. Produkční testy ověřily rozdělení energie do tří větví, společné přetížení jističe, vypnutí jediné větve, záložní baterii a účtování energie. Trasy přes všechny tři řady, 42 rezervovaných modulových pozic, dvě samostatné dveřní plochy a zákaz přímého propoje různých křídel prošly. Původních 12464 kontrol obvodů/tras/ukládání a scénáře Small/Reverse prošly. Ověřeny montážní podmínky všech 24 dveřních štítků, zrcadlení geometrie bez změny zdrojových mesh, opačný pohyb pantů, 6 registrovaných save typů a XML záznamy pravých desek. Testy používají náhrady Unity/nativních objektů; skutečný herní runtime a multiplayer zde nejsou dostupné.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards v mods; host i klienti stejná verze. Před testem zálohuj svět. Ve hře ověř zejména montážní náhled, oba dveřní směry, lišty a kryt, napojení všech čtyř vnějších kabelových konektorů, popisky na obou křídlech, jejich průchodky a save/load. Záloha 0.13.51 zachovaná.
