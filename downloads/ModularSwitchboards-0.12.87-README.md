# ModularSwitchboards 0.12.87 — DIN Cable Analyzer (3 slots)

Nový modul v Kit (DIN Modules): DIN Cable Analyzer (3 slots). Zabírá tři sousední DIN pozice. Tělo vzniká stejným generátorem jako jistič, pouze je rozšířené na tři pozice a nemá páčku ani její ložiska. Svorky jsou uprostřed nahoře a dole, ve stejném provedení jako u jističů.

Čelo tvoří původní šedý rámeček s bleskem (68 trojúhelníků) a zelená plocha (6 trojúhelníků) z herního Cable Analyzeru. Žlutý plech, šrouby a kabelový držák jsou vynechané. Materiály, property bloky a všechny vertexové kanály zůstávají původní; kopie streamů se při načtení ověřuje bajt po bajtu. Čelo je chráněno před přebarvením materiály rozvaděče.

Zapojení: Input -> jistič/pojistka -> analyzátor IN (horní kontakt) -> analyzátor OUT (spodní kontakt) -> Output 1 nebo Output 2. Konkrétní měřený výstup určuje vnitřní drátování, případně přes další průchozí moduly. Dva analyzátory můžete zapojit každý do jiné výstupní větve. Pokud vedou do stejné kabelové sítě, zobrazí stejné hodnoty jako původní analyzátor.

Tooltip používá stejné síťové hodnoty a lokalizované texty jako CableAnalyser: Actual = CurrentLoad, Required = RequiredLoad, Potential = PotentialLoad, s původním formátováním W/kW/MW. Čísla se nevykreslují na zelené ploše, stejně jako u původního přístroje. Nepřidává se datový výstup ani IC10 port.

Analyzátor je pasivní průchozí prvek: nic nevypíná, nejistí a nevytváří výkon. Je vynechaný z ochranných limitů. Jističe/pojistky před ním fungují dál. Pokud otevřete jistič až ZA analyzátorem, přestane vést cesta k výstupní síti; při otevření jističe PŘED ním dál čte připojenou výstupní síť, přesně jako původní kabelový analyzátor. Hodnoty jsou hodnoty kabelové sítě výstupu, ne samostatné sčítání spotřeby jen vybraných zařízení.

Instalace: vypněte hru a nahraďte složku ModularSwitchboards testovacím balíčkem. LibConstruct a LaunchPadBooster ponechte nainstalované. Vyberte DIN Cable Analyzer (3 slots) z Kit (DIN Modules), otevřete rozvaděč a umístěte na tři volné sousední pozice lišty. Před demontáží odpojte vnitřní vodiče.

Ověření: sestavení proti dodaným herním knihovnám; geometrie vybraná z uživatelského reference ZIPu; původní geometrie jističů, pojistek a baterie; třípozicová šířka a konce lišty; dva samostatné výstupy, sériové analyzátory, rozpojená cesta, rozdělení výkonu, ochrana jističe a provoz s bateriovou zálohou. Existující sada drátování prošla 10044 kontrolami, bateriová sada 2023 kontrolami. Unity renderování, GPU kopírování při načtení, tooltip v reálné hře a multiplayer vyžadují herní ověření.

Automatický export Cable Analyzeru z 0.12.86 zůstává dostupný pro případ diagnostiky. Verze 0.12.87 zachovává předchozí změny štítků a APC držáku.
