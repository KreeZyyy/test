# Modular Switchboards 0.12.12 — šedý panel na horní straně

Opravena výška vizuálního panelu: nyní leží na horní ploše rozvaděče y=0.25 m, s 0.5mm rezervou proti blikání překrytých ploch. Čelo míří vzhůru, nikoli podle znaménka osy kabelového protikusu. Zachovaná původní šířka a výška, plochý výběr z Ovenu s bleskem a otvorem; žádný kvádr pod panelem.

Výška panelu se již nepřebírá z výšky navrženého kabelového socketu. Poloha budoucího nativního napojení zůstává v SocketPoint a buňkách, skutečná poloha vizuální kotvy je VisualAnchorPoint a jejich rozdíl SocketToVisualOffset. Souřadnice v rovině stěny zůstávají odvozené od mřížky. Při budoucím funkčním připojení je nutné tento rozdíl vyřešit; současná verze žádný kabel elektricky nepřipojuje. Kabel ve světě se nemaže ani neposouvá.

Pouze model; další tělo a návaznosti se budou domodelovávat postupně. Potvrzený základ skříně zůstává zachovaný.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu, ponech závislosti.

Ověřeno: kompilace bez chyb a varování, výška plochých vrcholů po přepočtu souřadnic, integrita ZIPů. Skutečný vzhled a návaznost ověřit ve hře.
