# Modular Switchboards 0.13.83

Medium má všechny tři výstupy dolů vedle sebe na skutečné kabelové mřížce, s roztečí50cm. Zvenčí zleva Output1, Output3 uprostřed a Output2 vpravo: čísla a vnitřní svorky zůstávají stejné jako předchozí verze. Řada krajních konektorů má metr, proto spodní společný kryt přesahuje0,8m skříň. Každý vývod má samostatnou nativní elektrickou pozici a vlastní funkční collider. Nový souvislý spodní kryt má tři svislé větve. Původní boční výstupy Medium je nutné znovu napojit vnějšími kabely; vnitřní propojení a názvy větví se nemění.

Horní Input Medium používá tentýž původní APC konektor jako výstupy, otočený nahoru. Nativní logická pozice Input se nemění. Vizuál sedí na skutečném kabelovém spoji, používá vlastní původní materiály a jeho hitbox přímo obsluhuje Input. Horní krček má odpovídající průřez. Small a Reverse mají dosavadní konektory a rozložení.

Opraven InvalidCastException v DoorModules.CanConstruct při míření dovnitř otevřeného rozvaděče na jiný typ montážní desky/hostitele (například DIN lištu nebo kryt). Kontrola nejprve ověří správný typ hostitele a desky; nevhodná plocha vrátí neplatnou montáž bez pádu. Na správných dveřích zůstává snap a kontrola obsazení. Door Bridge se přichytí k nejbližší pozici u pantu, včetně krajních pozic Small/Reverse/Medium; obsazenou pozici nepřeskakuje a podržený montážní lock uchová konkrétní místo. Obě křídla mají vlastní4x3pozice. Součástí je oprava DIN kurzoru a o25cmnižší poloha Medium z0.13.82.

Stejný Kit (Switchboard), třetí varianta Medium; tři DIN řady po14pozicích, dvojité dveře ovládané společným nativním Open. Žádné automatické elektrické propojení. Vnitřní štítky vyžadují vnitřní kryt.

Ověření83: Releasebuild bez chyb/varování;126kontrol nativních kabelových pozic včetně samostatných tří dolů orientovaných výstupů;27rozměrových případů nového krytu (3348trojúhelníků) s kontrolou triangulace, uzavřených hran a orientace ploch;73kontrol skutečných podmínek montáže dveří a přichycení bridge ve všech třech rozvaděčích včetně nevhodných hostitelů; funkčníInputfixture proSmall/Reverse/Medium, stavební stavy, nativní vizuální hitbox, duplicitní a chybné metadata. Testy používají náhrady Unity/nativních objektů. Skutečný herní runtime a multiplayer zde nejsou dostupné.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards vmods; host i klienti stejná verze. Ve hře ověř všechny tři spodní kabely, vzhled a hitbox horního Input, dveřní montáž při otevřeném rozvaděči a save/load. Záloha0.13.51 zachovaná.
