# Modular Switchboards 0.13.87

Sjednoceny obě kliky Medium: každá má vlastní fyzický hitbox a nově vytvořenou nativní akci Open se stejným hostitelem, ovládáním, rozměry výběru a synchronizací. Odstraněna asymetrie mezi původní upravenou locker interakcí a dodatečnou interakcí druhého křídla. Výběrové Bounds obou klik odpovídají rozměrům jejich colliderů; dodatečná klika je dříve neměla výslovně nastavené. Obě nadále otevírají společně stejné dvojité dveře. Small a Reverse beze změny.

Ověření87: Releasebuild bez chyb/varování; kontrola obou vazeb na collider, společného vlastníka Open, rozměrů výběru, shodného nastavení, dokončeného stavebního stavu a opakované registrace bez duplicit. Skutečné klikání ve hře a multiplayer zde nejsou dostupné; ověř obě kliky při otevřených i zavřených dveřích.

Změny předchozí86:

Opraven pád ModelBlueprint.Build (cannot build a preview without model geometry) při načtení Medium s DIN lištami skrytými pod krytem. Runtime změna šířky už neprochází viditelné renderery ani nepřepisuje sdílený prefab blueprint. Používá přímo vytvořený mesh lišty a případný vlastní Wireframe kurzoru. Pokud kurzor vznikne později nebo se vymění, dostane správný náhled i bez další změny šířky. Fyzické rozměry, montáž, zapojení a ukládání zůstávají stejné.

První montážní náhled Small/Reverse/Medium na svislé stěně se nově srovná šipkou nahoru. Úprava proběhne jen jednou při aktivaci náhledu před kontrolou montáže; zachová směr do stěny a následné ruční otočení. Výslovný roll nebo smart-rotate v prvním snímku má přednost. Postavené skříně a ostatní prefaby se neotáčejí.

Medium nově vyžaduje3×Kit(Switchboard) pro rám a5×PlasticSheets + Wrench pro skříň. Small/Reverse zůstávají1kit +2PlasticSheets. Počty jsou přímo v nativních BuildStates, které zobrazíF1 a používá stavba/demontáž; registrace kontroluje cenu každé varianty.

Ověření86:52kontrol produkční inicializace natočení (3varianty,4směry stěn, nová aktivace a zachování ručního otočení); Releasebuild0chyb/varování;27kontrol skutečné produkční metody Resize pro skrytý model, odstraněné collidery, náhled vytvořený později/vyměněný, střídání šířek a opakované volání. Předchozí metoda v regresním scénáři vyvolá stejnou výjimku; opravená ji nevyvolá. Unity/runtime zde není dostupný; ověř načtení svého světa s nasazeným krytem.

Změny předchozí85:

Opraven chybějící montážní náhled rámu Medium: původní rám měl geometrii jen v páté materiálové části, ale náhled používal jeden materiál. Společný CabinetPreview nyní slučuje všechny části skutečného rámu do jednoho submeshe. Small, Small (Reverse) i Medium mají v montážním náhledu plnou šipku nahoru; šipka se neobjeví na postavené skříni. Náhled zachovává skutečné rozměry, natočení a offset modelu.

Medium má vlastní obrázky hotové skříně i rámu (F1 a stavební stavy), vyrenderované z původního embedded meshe se skutečnými transformacemi Medium: dvoje dveře, dvě madla, širší/vyšší tělo. Small a Reverse si ponechávají své obrázky.

Ověření85: produkční Releasebuild bez chyb/varování; kontrola skutečného embedded rámu s prázdným prvním submeshem, kompletních indexů v jediném náhledovém submeshi, šipky a transformací pro všechny tři varianty. PNG s průhledností ověřeny a obrázek vizuálně zkontrolován. Unity/herní runtime zde není dostupný; skutečný stavební kurzor a F1 je potřeba ověřit ve hře.

Změny předchozí84:

Opravená zadní sestava Medium: místo zjednodušeného samotného krčku používá stejný generátor jako Small pro celé tělo zadní krabice, zaoblený půdorys, souvislý horní koridor a přechod bez vnitřního víčka. Zůstává původní nativní zadní kryt APC s výstrahou a šrouby, původní povrch a hloubka. Medium jen dodává rozměry svého nového horního konektoru. Spodní společný kryt má stejné nativní plošné zkosení jako Small, vedené kolem všech tří větví. Stejné plošné zkosení (nativní poměr0.5776 a hloubka nejvýše10mm) má i celý horní koridor od zadní krabice až k Inputu; přechod krabice do tohoto profilu používá společný generátor. Přívod Input zůstává na stejné kabelové pozici; výstupy2/3 a jejich vnitřní svorky jsou nově seřazené1–2–3. Existující vnější kabely2/3 přepoj na nové pozice; kontrola uložených vnitřních tras zachovává logické konce a přepočítá posunuté přívody.

Medium má všechny tři výstupy dolů vedle sebe na skutečné kabelové mřížce, s roztečí50cm. Zvenčí i na vnitřní desce jsou zleva Output1, Output2 uprostřed a Output3 vpravo. Identita jednotlivých elektrických větví zůstává stejná; mění se jejich fyzické pozice. Řada krajních konektorů má metr, proto spodní společný kryt přesahuje0,8m skříň. Každý vývod má samostatnou nativní elektrickou pozici a vlastní funkční collider. Nový souvislý spodní kryt má tři svislé větve. Původní boční výstupy Medium je nutné znovu napojit vnějšími kabely; vnitřní propojení a názvy větví se nemění.

Horní Input Medium používá tentýž původní APC konektor jako výstupy, otočený nahoru. Nativní logická pozice Input se nemění. Vizuál sedí na skutečném kabelovém spoji, používá vlastní původní materiály a jeho hitbox přímo obsluhuje Input. Horní krček má odpovídající průřez. Small a Reverse mají dosavadní konektory a rozložení.

Opraven InvalidCastException v DoorModules.CanConstruct při míření dovnitř otevřeného rozvaděče na jiný typ montážní desky/hostitele (například DIN lištu nebo kryt). Kontrola nejprve ověří správný typ hostitele a desky; nevhodná plocha vrátí neplatnou montáž bez pádu. Na správných dveřích zůstává snap a kontrola obsazení. Door Bridge se přichytí k nejbližší pozici u pantu, včetně krajních pozic Small/Reverse/Medium; obsazenou pozici nepřeskakuje a podržený montážní lock uchová konkrétní místo. Obě křídla mají vlastní4x3pozice. Součástí je oprava DIN kurzoru a o25cmnižší poloha Medium z0.13.82.

Stejný Kit (Switchboard), třetí varianta Medium; tři DIN řady po14pozicích, dvojité dveře ovládané společným nativním Open. Žádné automatické elektrické propojení. Vnitřní štítky vyžadují vnitřní kryt.

Ověření84: Releasebuild0chyb/varování;126kontrol nativních vývodů včetně pořadí1–2–3;12464kontrol obvodů/energie/tras/serializace a scénář přepojení vnitřních tras po přesunu svorek2/3 se zachováním identit a spotřeby kabelů;54případů zadní krabice/koridoru a8928trojúhelníků (celé tělo, různé překryvy a délky, otevřený vnitřní spoj);27případů zkosených spodních větví a5076trojúhelníků (orientace ploch, uzavřenost hran, triangulace). Tvorba těla a přechodu převzata přímo z produkčního Small; společný generátor.

Ověření předchozí83: Releasebuild bez chyb/varování;126kontrol nativních kabelových pozic včetně samostatných tří dolů orientovaných výstupů;27rozměrových případů nového krytu (3348trojúhelníků) s kontrolou triangulace, uzavřených hran a orientace ploch;73kontrol skutečných podmínek montáže dveří a přichycení bridge ve všech třech rozvaděčích včetně nevhodných hostitelů; funkčníInputfixture proSmall/Reverse/Medium, stavební stavy, nativní vizuální hitbox, duplicitní a chybné metadata. Testy používají náhrady Unity/nativních objektů. Skutečný herní runtime a multiplayer zde nejsou dostupné.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards vmods; host i klienti stejná verze. Ve hře ověř všechny tři spodní kabely, vzhled a hitbox horního Input, dveřní montáž při otevřeném rozvaděči a save/load. Záloha0.13.51 zachovaná.
