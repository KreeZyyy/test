# Modular Switchboards 0.12.72

Zásuvka baterie je zapuštěná: její nejpřednější hrana nyní přesně lícuje s čelní plochou držáků pojistek a jističe. Přepočet hloubky je ukotvený na skutečné přední hraně původního APC profilu z=.1980004m, nikoliv na zadní obálce baterie. Všechny proporce původního APC profilu i orientace skutečné baterie se zachovávají.

Po upřesnění požadavku je měřítko zvolené podle toho, aby zásuvka hezky seděla v existujícím těle. Současně musí zůstat místo pro zadní část baterie. Výsledné měřítko je přibližně45% původního APC (předchozí56%), šířka zásuvky přibližně48.5mm. Nejde o striktních60% z jedné z dříve nabídnutých referencí. Tělo zůstává na2 DIN pozicích a nemění hloubku. Baterie přirozeně vystupuje před čelo jen přibližně6.5mm, nikoliv celý okraj zásuvky. Interakční plocha zůstává před ní, zadní obálka baterie6mm nad základnou.

Kontakty pojistek mají matný světlý povrch RGB(.90,.91,.92), kovovost0 a lesk0. Vypnutá je i mapa kovovosti, zrcadlové odlesky a lesklé odrazy v shaderových přepínačích. Zůstává běžné nasvícení a stínování, bez přidaného záření. Geometrie kontaktů a funkční sloty/napájení se nemění.

Ověření: Release build bez chyb a varování. Geometrický test porovnává skutečné maximum čela pojistkového těla a maximum hrany zásuvky, shodují se do1 mikrometru. Původní tvar APC je zachovaný, nativní baterie má volný prostor a interakční plocha je před tělem. Prošly kontroly otvorů, stěn, kontaktů a spár. Původní modulové a elektrické kontroly také prošly. Výsledné nasvícení a vzhled je třeba potvrdit ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
