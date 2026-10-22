# Modular Switchboards 0.13.57

## Otočný vypínač podle nové reference

Door Main Switch má černou montážní podložku, žlutou čtvercovou základnu a hlubší červený talíř s vystouplým obvodovým lemem. Nová delší tvarovaná rukojeť má zkosené hrany, ukazovací špičku a středový šroub.

**0 je vlevo, I nahoře.** Obě pevné černé značky jsou na zapuštěných bílých vložkách ve snížených výřezech červeného okraje. Otáčí se jen rukojeť: špička ukazuje vlevo při vypnutí a nahoru při zapnutí. Bílé vložky zůstávají čitelné mimo dosah špičky.

Chování je stejné jako v 0.13.56: sedmá volba dveřního kitu, jeden kit, devět dveřních pozic. 0 rozpojí cestu mezi svorkami, I propojí; bez nadproudové ochrany. Zadní kontakty, kabely, ukládání a síťová synchronizace se nemění. Oprava inicializace z 0.13.56 zůstává: příprava modelu nesahá na nedostupný nativní OnOff.

Náhled pokládání i ikona používají novou geometrii. Mírně rozšířená obálka a přední ovládací collider pokrývají nový model.

## Ověření

Produkční build proti herním DLL bez chyb/varování. 4906 kontrol skutečné geometrie: uzavřené těleso, nenulové trojúhelníky, orientace ven, normály, rozměry a výřezy nahoře/vlevo. 43 kontrol ovládání a animace včetně nedostupného OnOff při přípravě prefabu a načteného ON stavu. Kontrola registračních zdrojů proti předčasnému přístupu OnOff. Ikona renderována ze skutečných produkčních meshů.

Běžící hra zde není dostupná; vizuální ověření ve hře ještě zbývá. Host a klienti musí mít **0.13.57**. Záloha **0.13.51** zůstává zachovaná. Při přechodu z experimentální 0.13.52 nejdřív odmontuj zrušený dveřní analyzer a jeho vodiče.
