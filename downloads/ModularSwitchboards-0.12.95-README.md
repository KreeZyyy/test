# ModularSwitchboards 0.12.95 — Kit (Inner Cover)

Vnitřní kryt má vlastní Kit (Inner Cover), stejně jako DIN lišta. Vyrobíš ho v Electronics Printeru (Tier 1): 1 Iron → 1 kit. Otevři dokončený rozvaděč, pravým tlačítkem aktivuj umístění kitu a zamiř dovnitř na desku. Jeden kit nasadí celý kryt; Wrench ho sundá a vrátí kit. Vodiče, moduly a jejich nastavení zůstanou zachované.

Otvory krytu se generují podle skutečných modulů, jejich pozic a šířek 1/2/3 DIN. Neobsazená místa jsou zakrytá. Pod krytem zůstává drátování skryté a nelze je upravovat ani demontovat celé moduly/lišty. Ovládání jističů, výměna baterie/pojistek a tooltipy měření zůstávají přístupné přes okna. Rozvaděč funguje také bez krytu. Barva krytu odpovídá skříni; barvy vodičů jsou samostatné.

Kryt je samostatná konstrukce LibConstruct s vlastním montážním povrchem, ukládáním a přenosem při připojení hráče. Nezabírá pozice DIN lišt. Ověření na serveru odmítá nesprávný kit, cizí desku, duplicitní kryt, zavřenou skříň a nesprávnou polohu/rotaci.

KOMPATIBILITA: kryty už uložené ve verzi 0.12.94 zůstávají nasazené v původním stavebním stavu. Sundáš je Wrenchem a vrátí svůj původní 1 Iron Sheet. Nové kryty se nasazují už pouze samostatným kitem. Starší rozvaděče bez krytu zůstávají bez něj. Prázdný vnější plášť a rám se dál demontují Hand Drillem po odebrání vnitřního vybavení.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards. LibConstruct a LaunchPadBooster ponech. Pro multiplayer musí mít host i klienti 0.12.95; rozšířil se přenos montážní desky krytu.

Ověření: sestavení proti herním DLL; 26 588 kontrol produkční geometrie, pravidel umístění a přístupu a migrace/XML savů; 61 kontrol modulů, pojistek a přenosu jejich stavu; kontroly barvení vodičů a izolace barvy skříně. Neproběhl běh Unity hry: skutečné umístění, vzhled, vrácení kitu a živý multiplayer je potřeba vyzkoušet ve hře.

Záloha před kryty je ModularSwitchboards-0.12.93-backup.zip (mod + zdroják + README); verze 0.12.94 zůstává také dostupná samostatně. Vychází z plně barvených těl 0.12.89, bez experimentálních proužků 0.12.90.
