# Modular Switchboards 0.13.44

Šroubky hlavního IN / OUT i obou konců bridge jsou na straně příslušného kabelového vstupu. Zaměřovací body odpovídají skutečným šroubkům.

Bridge má dva protilehlé otvory na každé kostce: vnější pro připojený červený vodič, vnitřní pro modrý pružný kabel k pantu. Otvory odpovídají tloušťce vodiče. Pružný kabel vychází rovně z čela a má oddělenou trasu vůči přívodu. Pro přívod pevné svorky je dostupný krajní koridor vedle desky, takže nemusí vytvářet smyčku zpátky dovnitř. Ostatní trasy mají původní hranice.

Obě DIN lišty jsou o jeden modul kratší výhradně u pantu: 7 pozic na řadu, celkem 14. Protější konec a souřadnice ostatních pozic zůstávají stejné. Uvolněná pozice už neblokuje vedení kabelů. Starší osazený modul v odříznuté pozici se nemaže; přemísti jej ručně na zbývající lištu.

LED má vlastní původní kulatý model a vlastní materiál s přímo nastavenou zelenou. Zhasnutá: tmavší zelená bez emise. Zapnutá: jasně zelená s emisí. Nativní atlasové materiály se na naši čočku nepoužívají, protože s jejími UV způsobovaly béžovou barvu. Z původní herní LED se přebírají jen výrazně zmenšené světelné efekty: 1 % intenzity, nejvýše 12 cm dosahu. Pokud efekt nelze převzít, vlastní zelená čočka funguje dál.

Ověřeno: produkční sestavení bez chyb / varování; 63 613 kontrol bridge, obousměrných průchodů, mřížky a geometrie včetně rozestupů červených/modrých vodičů při 24 úhlech otevření, 18 pozicích a všech pěti hloubkách dveřního vedení. Dále 72 tras mezi DIN modulem a pevnou svorkou (obě řady a směry), plných 9 LED / 18 tras, 12 464 kontrol obvodů / tras / ukládání a 43 218 kontrol krytů. Skutečný vzhled, emise a světlo vyžadují ověření ve hře; Unity zde není k dispozici.

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
