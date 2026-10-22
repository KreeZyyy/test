# Modular Switchboards 0.13.75

## Společné zamykání montáže

LibConstruct FindCursorBoard při každém novém zásahu myši vymaže původní CursorBoard a nastaví jej podle aktuálního cíle. To mohlo rozbít již zamknutý náhled: pozice vypadala zachovaná, ale ověření ztratilo board a hlásilo chybějící kryt či lištu.

Při držení nativní akce zamykání/QuantityModifier teď u našich board dílů zachováme konkrétní kurzor, kit, board, buňku a rotaci. Po raycastu obnovíme tentýž cíl ještě před běžnou montážní cestou LibConstruct. Při uvolnění akce, změně kitu/kurzoru, opuštění montáže nebo neplatném hostu se zámek zahodí. V prázdném vzduchu se žádný board nevytváří. Používá nastavenou herní akci, nikoliv pevnou klávesu.

Platí společně pro DIN lišty, DIN moduly, dveřní díly, hinge bridge, dveřní štítky a vnitřní štítky. Skříň na stěně dál používá nativní montáž; vnitřní kryt má původní přímou akci kitu. Registrace kitů se nemění.

## Nejbližší podporovaná pozice a obsazenost

Nejprve se vybírá geometricky nejbližší podporovaná pozice. Až pak se kontroluje obsazenost a ostatní pravidla. Obsazené místo se nepřeskakuje na vzdálenější volné: má zůstat červené. Volné povolené místo je zelené; nevhodný cíl zůstává neplatný.

DIN štítky nově vybírají nejbližší začátek/řadu skutečně podloženou instalovanými moduly pro požadovanou šířku. Door/Emergency štítky vybírají nejbližší skutečný kompatibilní ovladač, nikoliv prázdnou buňku. Stávající geometrické přichycení lišt, DIN modulů, dveřních modulů a bridges zůstává; společná oprava jim přidává udržení zámku. Autoritativní validace stále odmítá překryvy, špatné cíle, rozměry a překážky. Zamknutá pozice se znovu ověřuje; odstranění podpůrného dílu nebo obsazení buňky ji neoprávní k montáži.

## Čitelnější vnitřní štítky

Pouze vnitřní DIN štítky: font96 místo64, cílová výška textu až14mm místo12mm a odstraněný limit zvětšení1x. Krátké názvy tak skutečně vyplní větší část bílé plochy; dlouhé se dále zmenšují podle šířky. Fyzické rozměry a montážní pozice štítků stejné. Venkovní štítky se nemění.

## Ověření

Produkční build0chyb/0varování.36 kontrol skutečného MountPlacement/MountSnap pro šest board druhů: ztráta cíle po raycastu, zachování boardu/buňky, přechod raycastu jinam, uvolnění, změna kitu, zavřený host, vzduch bez boardu a nejbližší podporované místo.93 kontrol skutečných vnitřních label pravidel a CanConstruct, včetně mezer mezi moduly a obsazeného nejbližšího místa, které zůstává červené.3839 kontrol Door Label politiky a geometrie;29 kontrol cursor/surface a26 preview kontrol. Audit6save typů a8XML kontrol zachován.

Není dostupný živý Unity runtime. Ověř zejména: volné/obsazené místo, držení zámku při pohledu mimo kryt, uvolnění zámku, potvrzení a změnu varianty u jednotlivých kitů. Kopie savu před testem; host i klienti stejnou verzi. Save formát, již postavené díly a dráty se nemění. Záloha0.13.51 zachována.
