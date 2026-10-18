# Modular Switchboards 0.12.23 — tři vnitřní svorkovnice

Pevná dvoukontaktní svorkovnice Input nahoře uprostřed, Output 1 dole vlevo a Output 2 dole vpravo při pohledu do otevřené skříně. Každá má šedé izolátory na tmavé patce, dva šrouby s drážkou, dvě přední vstupní plošky pro budoucí vlastní vodiče a popisek. Červený a černý pevný vodič vycházejí ze svorkovnice, zahýbají za ni a mizí v zadní montážní desce. Popisky jsou čitelné zepředu; nejsou obarvovány lakováním skříně.

Rozměr patky 72 × 32 mm; svorkovnice jsou připevněné ke skříni, nezabírají pozice na DIN lištách. Umístění (CompletedShell, metry): Input (0, 0.195, 0.014), Output 1 (-0.108, -0.195, 0.014), Output 2 (0.108, -0.195, 0.014). Všechny části jsou uvnitř dokončené stavby; kolize jsou přidané pouze do dokončeného stavu.

Každá svorkovnice má stabilní identifikátor, roli a dvojici lokálních předních/zadních bodů pro následný systém vnitřního drátování. Input odkazuje na existující elektrický vstup z 0.12.22. Output 1 a Output 2 jsou v tomto kroku model a připravené kontaktní body: nové venkovní výstupní porty nejsou registrované. Pevné zadní vodiče jsou zatím vizuální; vnitřní elektrické propojení svorek, jističů ani tří rozhraní se samo nevytváří. Tím zůstává prostor pro další vlastní drátování. Stávající venkovní model a funkce horního Input zůstávají zachované.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Předchozí verze a potvrzená záloha 0.12.7 zůstávají na GitHubu.

Ověření: kompilace bez chyb a varování. Rozměrová kontrola patky, popisků a zadních vodičů vůči okrajům desky, oběma řadám DIN modulů a zavřeným dveřím. Při registraci mod kontroluje tři různé svorkovnice a dvojice kontaktních bodů. Zdroj původní vnější geometrie a meshe skříně beze změn. Integrita ZIPů ověřena. Vzhled, velikost textu a chování ve hře je třeba potvrdit.
