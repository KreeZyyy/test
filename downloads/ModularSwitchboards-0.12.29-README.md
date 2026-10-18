# Modular Switchboards 0.12.29 — čelo konektoru, kabelová mřížka a průřez T

Obnovené přední a boční plochy APC konektoru. Výběr celých trojúhelníků v 0.12.28 vynechal velké plochy sdílené s tělem APC. Nyní se původní trojúhelníky ořezávají přesně na stejnou oblast lugu a původní UV se interpolují. Referenční geometrie dává 155 trojúhelníků místo 107 při předchozím výběru. Původní materiály, blesk i kontakty zachované; zadní uzavírací víčko má šedý APC povrch.

Opravená fyzická poloha otvoru vůči kabelové mřížce. Logický bod buňky a skutečný konec kabelu jsou dvě různá místa. NativeCableLayout nyní vrací i ContactPoint = poloha nativního vnitřního konce kabelu. Viditelný otvor konektoru se umísťuje právě tam; počátek jeho meshe je v rovině nativního ústí. Logická metadata buňky zůstávají oddělená. Kontrola při instalaci ověřuje shodu polohy viditelného ústí s ContactPoint. Souřadnice buňky i ústí jsou v logu. Výstupní modely zůstávají připevněné k souřadnicím rozvaděče, takže wall-fit nehýbe jejich ústím.

Tunel má stejný průřez jako skutečné konektory: výška ramen a šířka krku vychází z nativní výšky lugu (cca 70 mm), hloubka z jeho skutečných předních/zadních ploch (cca 75 mm). Žádná pevná zmenšená hodnota 32 × 28 mm ani velká obálka mezi krabičkou a mřížkou. Ramena zasahují do kořenů konektorů, takže je mají souvisle podpírat po celém průřezu.

Stále jen model spodních výstupů. Nejsou registrované výstupní Connection ani elektrická síť. Horní funkční Input a vnitřní svorkovnice zůstávají zachované. Vlastní vnitřní drátování zatím není zavedené.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti.

Ověření: kompilace bez chyb a varování; porovnání ořezu proti uložené APC referenci; produkční výpočet T v 32 kombinacích (triangulace, obsah, orientace, uzavřenost hran); integrita ZIPů. Skutečné dosednutí kabelu, čelní povrch a návaznost na krabičku vyžadují ověření ve hře.
