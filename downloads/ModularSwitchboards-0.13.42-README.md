# Modular Switchboards 0.13.42

DIN lišty, DIN moduly, dveřní LED a jednotlivé bridge se přichytávají k nejbližší pevné pozici. Obsazená pozice se nepřeskakuje: náhled je neplatný (červený). Náhled a pokládání sdílejí stejnou pozici i natočení. Dveře mají 3×3 pozice LED, podél závěsu je 18 pozic pro bridge.

## Jednotlivý průchozí bridge

Jeden kit staví jeden bridge, nikoli celou svorkovnici. Oba konce jsou rovnocenné a elektricky průchozí oběma směry. Každý bridge je samostatný; nejde o společnou sběrnici. Oba kontakty mají modré zvýraznění, bez nápisů IN/OUT. Kostky používají geometrii a materiály původních svorek rozvaděče, zmenšené pro rozteč pozic. Druhá kostka je otočená o 180° a sleduje dveře; spojuje je pružný kabel. Vnitřní kostky a pružné kabely nevrhají hřebenový stín. Kryt vytvoří průchod jen u osazených bridge.

Původní celý 18kanálový blok z 0.13.41 je odstraněný. Při načtení zmizí i jeho osiřelé vodiče; je nutné osadit jednotlivé bridge a znovu je zapojit. Záloha 0.13.40 zůstává nedotčená.

## Dveřní LED

Zvenku malá zelená kontrolka, zevnitř horní IN a dolní OUT bez fyzických nápisů, stejně jako DIN moduly. LED svítí při dostupném napětí na IN i bez zapojeného OUT. OUT umožňuje pokračovat dál. Stav se ukládá a replikuje; otevřené jištění nebo odpojené zdroje LED zhasnou.

Při načtení se vyhledá původní LED z herního Lights Kitu a převezmou se její model, materiály a světelné efekty. Rozměr je přibližně 29 mm; intenzita světla je 1 % původní, dosah nejvýše 12 cm, odlesky jsou výrazně zmenšené. Pokud se nativní LED nepodaří najít, zůstane náhradní model a do logu se vypíše důvod. Skutečný výběr nativního prefabu a vzhled je nutné ověřit ve hře.

## Použití

Switchboards Doors Module používá model Logic Kitu. Electronics Printer: 2 g Iron + 1 g Copper za kit. Každá LED i každý bridge spotřebuje jeden kit. LED se staví zvenku na dokončené dveře. Bridge vyžaduje otevřenou skříň bez vnitřního krytu a pokládá se na stranu závěsu. Vodiče se propojují Cable Coilem. Demontáž Hand Drillem po odstranění připojených vodičů vrací jeden kit.

Jističe a pojistkové držáky dovolují dvě odbočky z OUT; společný výkon stále hlídá jejich jmenovitý limit. Ostatní svorky modulů i jednotlivé konce bridge přijmou jeden vodič. Přechod mezi deskou a dveřmi vede přes bridge.

## Ověření a instalace

Produkční sestavení proti herním DLL: bez chyb a varování. Kontroly zahrnují nejbližší pozice, 18 izolovaných obousměrných průchodů, 9 LED a jejich 18 tras, pružné kabely, kryty, analyzer, baterie, jištění a ukládání. Unity ani běžící hra zde nejsou k dispozici; vzhled, červený náhled, kliknutí a save/load vyžadují herní test.

Test ZIP obsahuje hotový mod. Source ZIP obsahuje zdrojové soubory bez přeložené DLL. Host i klienti musí používat stejnou verzi. Pro návrat ke starší verzi použij odpovídající zálohu savu.

Zdrojový ZIP vynechává regenerovatelné pile-input.json a velké mezisoubory Art/ModuleKit/model.json, Art/CoverKit/model.json + source.json, Art/LabelKit/model.json. Nástroje pro jejich obnovu jsou v Tools.
