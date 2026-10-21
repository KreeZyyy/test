# Modular Switchboards 0.13.43

Obě kostky bridge jsou otočené o dalších 180°, včetně zaměřovacích bodů a přívodů kabelů. Pružný kabel sleduje nové natočení. Přívod pevné svorky nyní ústí do volného krajního koridoru a nezasahuje do rezervace DIN modulů; příchod do bridge není omezen na směr shora. Regresní testy pokrývají všech 18 pozic, obě DIN řady a oba směry propojení (72 tras), vedle plného zapojení 9 LED / 18 dveřních tras. Existující vodiče se při změně jejich bridge kontaktů bezpečně přepočítají.

Kontrolka má opět původní kulatý model a černý límec. Používá zelený nativní materiál i zhasnutá; při zapnutí přepne na emisní materiál a jemné světlo / odlesky původní herní LED. Nekopíruje se její hranatý model. Světlo má 1 % původní intenzity a nejvýše 12 cm dosahu. Herní vzhled a interakce vyžadují ověření ve hře.

DIN lišty, DIN moduly, dveřní LED a jednotlivé bridge se přichytávají k nejbližší pevné pozici. Obsazená pozice se nepřeskakuje: náhled je neplatný (červený). Náhled a pokládání sdílejí stejnou pozici i natočení. Dveře mají 3×3 pozice LED, podél závěsu je 18 pozic pro bridge.

## Jednotlivý průchozí bridge

Jeden kit staví jeden bridge, nikoli celou svorkovnici. Oba konce jsou rovnocenné a elektricky průchozí oběma směry. Každý bridge je samostatný; nejde o společnou sběrnici. Oba kontakty mají modré zvýraznění, bez nápisů IN/OUT. Kostky používají geometrii a materiály původních svorek rozvaděče, zmenšené pro rozteč pozic. Druhá kostka je otočená o 180° a sleduje dveře; spojuje je pružný kabel. Vnitřní kostky a pružné kabely nevrhají hřebenový stín. Kryt vytvoří průchod jen u osazených bridge.

Původní celý 18kanálový blok z 0.13.41 je odstraněný. Při načtení zmizí i jeho osiřelé vodiče; je nutné osadit jednotlivé bridge a znovu je zapojit. Záloha 0.13.40 zůstává nedotčená.

## Dveřní LED

Zvenku malá zelená kontrolka, zevnitř horní IN a dolní OUT bez fyzických nápisů, stejně jako DIN moduly. LED svítí při dostupném napětí na IN i bez zapojeného OUT. OUT umožňuje pokračovat dál. Stav se ukládá a replikuje; otevřené jištění nebo odpojené zdroje LED zhasnou.

## Použití

Switchboards Doors Module používá model Logic Kitu. Electronics Printer: 2 g Iron + 1 g Copper za kit. Každá LED i každý bridge spotřebuje jeden kit. LED se staví zvenku na dokončené dveře. Bridge vyžaduje otevřenou skříň bez vnitřního krytu a pokládá se na stranu závěsu. Vodiče se propojují Cable Coilem. Demontáž Hand Drillem po odstranění připojených vodičů vrací jeden kit.

Jističe a pojistkové držáky dovolují dvě odbočky z OUT; společný výkon stále hlídá jejich jmenovitý limit. Ostatní svorky modulů i jednotlivé konce bridge přijmou jeden vodič. Přechod mezi deskou a dveřmi vede přes bridge.

## Ověření a instalace

Produkční sestavení proti herním DLL: bez chyb a varování. Kontroly zahrnují nejbližší pozice, 18 izolovaných obousměrných průchodů, 9 LED a jejich 18 tras, pružné kabely, kryty, analyzer, baterie, jištění a ukládání. Unity ani běžící hra zde nejsou k dispozici; vzhled, červený náhled, kliknutí a save/load vyžadují herní test.

Test ZIP obsahuje hotový mod. Source ZIP obsahuje zdrojové soubory bez přeložené DLL. Host i klienti musí používat stejnou verzi. Pro návrat ke starší verzi použij odpovídající zálohu savu.

Zdrojový ZIP vynechává regenerovatelné pile-input.json a velké mezisoubory Art/ModuleKit/model.json, Art/CoverKit/model.json + source.json, Art/LabelKit/model.json. Nástroje pro jejich obnovu jsou v Tools.
