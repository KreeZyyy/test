# Modular Switchboards 0.12.66

Opravená bílá plocha viditelná kolem zásuvky: nebyla to chybějící textura. Kontrola produkčního těla společně s původním APC socketem potvrdila, že u rohů a okrajů otvoru lze vidět zadní bílou stěnu těla. Na čelní mřížce45x45 paprsků dopadlo60 paprsků na tuto zadní stěnu a1965 na geometrii zásuvky. Příklady bílých průhledů byly na x=-22mm,y=-22 až-18mm v hloubce modelu z=.004.

Zadní plocha bateriového těla nyní používá stejný šedý materiál jako čelo, takže přes tyto mezery neprosvítá bílý kryt. Vnější tělo, otvor, původní zásuvka a její textura, zlaté kontakty, orientace APC a bateriové funkce zůstávají beze změny. Běžných jističů se změna netýká.

Ověření: Release build bez chyb a varování. Nový test4 rohových průhledů potvrzuje šedou zadní plochu. Prošly původní kontroly povrchu bez spár, volného místa pro baterii,2slotových rozměrů, čelní interakce, orientace APC a geometrie pojistek. Výsledný vzhled je třeba potvrdit ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
