# Modular Switchboards 0.12.68

Světlý zadní lem samotné bateriové zásuvky je nyní oddělený přímo v geometrii. Z původních134 APC trojúhelníků zásuvky se50 zadních ploch (v původních APC souřadnicích celé pod z=.145m) vykresluje samostatným submeshem se stejným šedým materiálem a paletovým indexem jako čelo. Tato část má vlastní odpovídající UV pro čelní materiál. Zbylých84 trojúhelníků vnitřku a kontaktů si zachovává dosavadní nativní nastavení a původní UV. Není překreslen celý socket materiálem čela, což dříve změnilo vzhled kontaktů.

Šedá zadní stěna těla z0.12.66 zůstává. Orientace APC, jednoduché tělo na2 pozice, ovládání a bateriové napájení se nemění. Kontakty pojistek se touto verzí nesjednocují ani nemění: sjednocená jsou jejich těla z0.12.67, původní samostatné kovové kontakty zůstávají zachované.

Ověření: Release build bez chyb a varování. Původní APC fixture potvrzuje přesné rozdělení50 zadních a84 ostatních trojúhelníků bez ztráty geometrie; kontakty mají zachované souřadnice UV. Prošly původní kontroly spár, vyplněného čela, průhledů do šedé zadní stěny, otvoru, rozměrů a orientace. Vzhled světlého lemu je třeba potvrdit ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
