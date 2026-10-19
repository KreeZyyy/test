# Modular Switchboards 0.12.65

Zásuvka i skutečná vložená baterie jsou otočené oproti předchozímu modulu o90 stupňů do původní orientace APC. Odstraněná dodatečná rotace v mapování mesh i v rotaci slotu; nativní vodorovná osa zůstává vodorovná a kontakty jsou ve dvou řadách nahoře a dole. Mesh zásuvky, její kolider a slot vycházejí ze stejného mapování. Usazení do hloubky, vystředění,2pozicové tělo a napájení se nemění.

Převod bílého vnitřku na tmavě šedý nyní zahrnuje také tlumené neutrální odstíny textury (předchozí filtr vybíral jen jasné bílé pixely). Zachovaný zůstává původní APC shader, UV a texturové detaily; zlaté kontakty, barevné pixely a nejtmavší oblasti se nepřebarvují. Původní herní materiály ani asset baterie se nemění. Jde o úpravu soukromé kopie textury; konečnou shodu s odstínem APC je třeba ověřit ve hře.

Ověření: Release build bez chyb a varování. Test orientace potvrzuje shodné osy s APC a společné mapování mesh/slotu. Prošly kontroly stěn bez spár, otvoru, usazení a interakční plochy. Barevné kontroly potvrzují převod jasné i tlumené bílé na šedou a zachování zlata, tmavých ploch, barev a alpha;1010 původních případů také prošlo. Skutečný vzhled a natočení jednotlivých typů baterie ještě potřebují potvrzení ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
