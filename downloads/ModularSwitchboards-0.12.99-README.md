# ModularSwitchboards 0.12.99 — Kit (Inner Cover)

Oprava 0.12.99: survival umístění krytu vybírá vlastní montážní desku podle aktivního Kit (Inner Cover) v konstrukční nabídce. Není závislé na již vytvořeném náhledu ani na tom, zda paprsek zasáhl volnou desku, vodič nebo modul. Vyžaduje otevřený dokončený rozvaděč bez krytu a stejný dosah jako LibConstruct; při neplatném cíli vymaže předchozí desku. Nativní spotřeba jednoho kitu a serverové ověření umístění zůstávají zachované. Vzhled se nemění. Ověřeno 14 kontrolami produkčního výběru cíle; skutečné survival nasazení vyžaduje hru.

Od 0.12.98: kryt pokračuje až k vnitřním stěnám skříně. Rozměr .386 × .486 m vychází z otvoru pláště .388 × .488 m s 1mm vůlí po obvodu; původně .346 × .466 m. Hloubka, okna a čela modulů beze změny. Již nasazené kryty se upraví po načtení, bez přestavby. Pro jiné skříně rozměry stále určuje jejich profil.

Výřezy odkrývají celé barevné čelní osazení modulů, ne jen zúžený střed. Šířka je podle skutečného počtu DIN pozic s malou montážní vůlí; výška zahrnuje čelní rameno. Barva modulů zůstává jejich vlastní, barva krytu se řídí skříní.

Rozvaděč poskytuje profil šířky/výšky/hloubky/tloušťky krytu (InnerCoverWidth/Height/Depth/Thickness na prefabu). Generátor nemá pevný počet řad ani sloupců: otvory vycházejí ze skutečných pozic osazených modulů. Profil je součástí klíče obnovy meshe. Stejný generátor používají původní i nové kryty. Další skříně tato verze nepřidává; připravuje pro ně kryt.

Oprava hloubky: kryt je zapuštěný o 17,5 mm proti 0.12.95, těsně za čela modulů a před horní/spodní svorky. Posun platí i pro již nasazené kryty; není nutné nic znovu stavět. Výřezy, zapojení a polohy modulů se nemění. Vnitřní vodiče zůstávají při nasazeném krytu skryté a bez výběrových koliderů.

Vnitřní kryt má vlastní Kit (Inner Cover), stejně jako DIN lišta. Vyrobíš ho v Electronics Printeru (Tier 1): 1 Iron → 1 kit. Otevři dokončený rozvaděč, pravým tlačítkem aktivuj umístění kitu a zamiř dovnitř na desku. Jeden kit nasadí celý kryt; Wrench ho sundá a vrátí kit. Vodiče, moduly a jejich nastavení zůstanou zachované.

Otvory krytu se generují podle skutečných modulů, jejich pozic a šířek 1/2/3 DIN. Neobsazená místa jsou zakrytá. Pod krytem zůstává drátování skryté a nelze je upravovat ani demontovat celé moduly/lišty. Ovládání jističů, výměna baterie/pojistek a tooltipy měření zůstávají přístupné přes okna. Rozvaděč funguje také bez krytu. Barva krytu odpovídá skříni; barvy vodičů jsou samostatné.

Kryt je samostatná konstrukce LibConstruct s vlastním montážním povrchem, ukládáním a přenosem při připojení hráče. Nezabírá pozice DIN lišt. Ověření na serveru odmítá nesprávný kit, cizí desku, duplicitní kryt, zavřenou skříň a nesprávnou polohu/rotaci.

KOMPATIBILITA: kryty už uložené ve verzi 0.12.94 zůstávají nasazené v původním stavebním stavu. Sundáš je Wrenchem a vrátí svůj původní 1 Iron Sheet. Nové kryty se nasazují už pouze samostatným kitem. Starší rozvaděče bez krytu zůstávají bez něj. Prázdný vnější plášť a rám se dál demontují Hand Drillem po odebrání vnitřního vybavení.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards. LibConstruct a LaunchPadBooster ponech. Pro multiplayer musí mít host i klienti 0.12.99; rozšířil se přenos montážní desky krytu.

Ověření zahrnuje také širší profil 12 pozic × 3 řady a užší jednořadý profil, různé hloubky a tloušťky; skutečné budoucí skříně zatím neexistují.

Ověření: sestavení proti herním DLL; 37 547 kontrol produkční geometrie, pravidel umístění a přístupu a migrace/XML savů; 61 kontrol modulů, pojistek a přenosu jejich stavu; kontroly barvení vodičů a izolace barvy skříně. Neproběhl běh Unity hry: skutečné umístění, vzhled, vrácení kitu a živý multiplayer je potřeba vyzkoušet ve hře.

Záloha před kryty je ModularSwitchboards-0.12.93-backup.zip (mod + zdroják + README); verze 0.12.94 zůstává také dostupná samostatně. Vychází z plně barvených těl 0.12.89, bez experimentálních proužků 0.12.90.
