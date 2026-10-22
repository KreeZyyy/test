# Modular Switchboards 0.13.60

## Menší a jednodušší otočný vypínač

Čelo hlavního vypínače je o 25 % menší. Žlutá základna má 49,5 mm místo 66 mm, černá podložka 54 mm místo 72 mm. Červené čelo je jednoduché mělké kolo s vyšším obvodovým lemem. Nízká hranatá rukojeť vyčnívá přibližně 21 mm místo 46 mm. Zadní tělo a svorky mají původní rozměry pro stejné kabelové napojení.

**Otočná clona i jedno okénko zůstávají.** V poloze 0 vlevo je vidět bílá nula, při plynulém přepnutí se okénko otočí k I nahoře. Druhou značku zakrývá červená clona.

Bílé vložky i černé značky jsou na rovné ploše. Clona má vlastní uzavřenou geometrii ve vyšší rovině: zadní povrch 9,8 mm, přední 11,8 mm, značky 8,65 mm. Rovné plochy nahrazují předchozí šikmou stěnu a vytvářejí jasný odstup mezi značkami a clonou. Lem dosahuje 14 mm, vršek rukojeti 20 mm.

Elektrické chování, stav uložený v savu a síťová synchronizace se nemění. Stejný prefab, sedmá volba dveřního kitu, jeden kit, původních devět pozic a kontakty. Oprava inicializace bez předčasného OnOff přístupu zůstává.

## Ověření

Produkční build bez chyb/varování. 15062 kontrol skutečných meshů: uzavřené těleso, rozměry, normály/winding, otvor, zakrytí všech vrcholů schované značky čelně i šikmo a viditelnost zvolené značky. 43 kontrol ovladače/animace a kontrola bezpečné přípravy prefabu. Ikona renderována z produkčních meshů.

Běžící hra zde není dostupná; vzhled a zakrytí ještě ověř ve hře. Host a klienti musí mít **0.13.60**. Záloha **0.13.51** zůstává zachovaná. Při přechodu z experimentální 0.13.52 nejdřív odmontuj zrušený dveřní analyzer a jeho vodiče.
