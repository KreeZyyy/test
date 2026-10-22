# Modular Switchboards 0.13.76

## Správný montážní board podle zasaženého dílu

Další oprava případu, kdy náhled nad stejným modulem měnil zelenou/červenou při mírném pohybu pohledu a hlásil chybějící kryt. Samotné uchování zámku z0.13.75 nestačilo: LibConstruct při zásahu fyzického krytu mimo úzký montážní pás používá jeho IPlacementBoardStructure.Board, tedy board pro nasazení krytu do skříně, nikoliv cover.Labels pro štítky.

Po původním raycastu nyní pro naše aktivní montážní kity určíme správný board podle skutečně zasaženého collideru a druhu stavěného dílu. Fyzický kryt, již existující vnitřní štítek nebo modul v jeho otvoru vedou na board štítků tohoto krytu. Vlastní collider skříně uvnitř otevřeného prostoru může použít skutečně osazený kryt; dveřní plocha se za vnitřní kryt nezaměňuje. Pohyb po krytu mimo úzké montážní pásy tak neztrácí label board.

Stejná obsluha rozlišuje DIN lištu a její module board, osazený DIN modul, montáž lišt do skříně, dveřní moduly, dveřní štítky a hinge bridge. Kontroluje odpovídající kit/kurzor, dostupný host a EquivalentStructure. Používá původní limit MaxCursorDistance z LibConstruct; pokud jej nelze načíst, rozšířené rozlišení se neprovádí. Cizí předměty a normální režim včetně přejmenování/demontáže se nemění.

Existující držený zámek má přednost: nový zásah mu nesmí změnit board ani buňku. Volba nejbližší podporované pozice a kontrola obsazenosti běží dál jako v0.13.75: volné povolené místo zelené, obsazené či bez podpory červené, bez přeskakování na jinou zelenou pozici. Registrace kitů ani save formát se nemění.

## Ověření

Produkční build0chyb/0varování. Nový integrovaný test používá skutečný MountBoardResolver společně s produkčním CanConstruct/CanSupport/CanPlace vnitřních štítků: před opravou reprodukuje chybu při parent-boardu; po rozlišení tři různé zásahy stejného fyzického krytu přijmou stejné volné podporované místo. Po osazení je stejná buňka odmítnuta pro obsazenost při zachování správného boardu. Celkem100 label kontrol v integračním harnessu.

Dále22 kontrol produkčního resolveru: kryt, jeho label, modul v otvoru, vnitřní zásah skříně, skutečná lišta/module board, dveře/door label/bridge, nepřepsání zámku, limit vzdálenosti, normální režim a nesprávný kit.36 kontrol zámku/nejbližší pozice,29 cursor/surface kontrol, audit6save registrací a8XML kontrol zachované. Testy používají izolované náhrady enginu; živý Unity/game runtime není dostupný.

Ve hře ověř změny úhlu míření na stejný kryt, volnou a obsazenou pozici, držení/uvolnění zámku a potvrzení stavby. Text vnitřních štítků a venkovní vzhled z0.13.75 se nemění. Kopie savu před testem; host a klienti stejnou verzi. Záloha0.13.51 zachována.
