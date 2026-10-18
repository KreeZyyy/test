# Modular Switchboards 0.12.28 — tenké T, čisté APC konektory, jen model

Vrácení požadovaného rozsahu: oba spodní výstupy jsou pouze modely a metadata budoucí kabelové mřížky. Nezakládají Connection a nepřipojují se do elektrických sítí. Horní Input zůstává funkční. Tvar T žádné sítě nepropojuje. Vnitřní výstupní svorkovnice zatím nemají připojenou vnější elektrickou přípojku.

T kryt zmenšený: krk 32 mm místo 50 mm, spodní rameno 32 mm na výšku, pevná hloubka 28 mm místo celé obálky mezi tělem a přípojkami. Hloubková poloha drží krk uvnitř těla zadní krabičky. Rozpětí mezi konci zůstává podle připravených nativních kabelových buněk, protože jejich osy se nesmějí posouvat mimo mřížku. Původní APC konektory zachovávají svou velikost.

APC konektory se nyní vybírají výhradně z původních celých trojúhelníků v přesně změřené oblasti samotného lugu: X 0.11999..0.2588, Y -0.0351..0.0351, Z -0.0309..0.04377 m v referenčních souřadnicích APC. Reference obsahuje 107 takto vybraných trojúhelníků. Zachované původní UV a materiál včetně oranžového blesku a kontaktů. Nevytvářejí se odřezky velkých ploch APC skříně ani helper geometrie.

Původní konektor má v APC otevřený zadní konec do těla zařízení. Pro použití na užším T je tento konec doplněný uzavřeným šedým víčkem s APC povrchem; nemají tak zůstávat průhledné mezery kolem ramene v označených místech. Vizuální návaznost musí potvrdit hra.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti.

Ověření: kompilace bez chyb a varování, kontrola 107 původních trojúhelníků v APC referenci, 32 kombinací T geometrie (triangulace, plošný obsah, orientace a uzavřenost), integrita ZIPů. Kontrola registrace očekává jedinou skutečnou Connection Input. Výsledné povrchy, napojení víček a tloušťku je potřeba ověřit ve hře.
