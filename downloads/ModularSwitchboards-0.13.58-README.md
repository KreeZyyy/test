# Modular Switchboards 0.13.58

## Hlubší otočný vypínač a značky uvnitř talíře

Door Main Switch má souvislý červený obvodový lem, výrazně hlubší prohlubeň a delší tvarovanou rukojeť vystupující nad lem. Bílé vložky jsou větší a zapuštěné uvnitř: kopírují vnitřní šikmou stěnu talíře. Černé značky **0 / I** jsou geometrické a leží těsně nad bílým povrchem.

**0 vlevo, I nahoře při pohledu na dveře ve hře.** Opravena stranová orientace podle živého screenshotu: poloha 0 a směr otočení rukojeti zohledňují zrcadlený pohled na dveřní modul. Špička končí před bílou vložkou, aby ji nezakrývala. Obrázek kitu vzniká ze skutečných produkčních meshů.

Změněn pouze model, odpovídající bounds/collider, ikona a směr vizuálního otočení. Elektrické chování a nativní uložený/síťový OnOff zůstávají stejné: 0 rozpojí, I propojí, bez ochrany proti přetížení. Sedmá volba stejného dveřního kitu, jeden kit, stejné zadní svorky a devět pozic.

Oprava inicializace z 0.13.56 zachována: příprava modelu nepřistupuje k nedostupnému OnOff a nepřepisuje uložený stav.

## Ověření

Produkční build proti herním DLL bez chyb/varování. 5591 kontrol skutečné geometrie: uzavřená tělesa a orientace ven, nenulové trojúhelníky, normály, rozměry, bílé vložky a značky uvnitř lemu, správná strana a výška rukojeti. 43 kontrol skutečného ovladače a animace včetně nedostupného stavu při přípravě prefabu a načteného ON. Kontrola produkčních registračních zdrojů proti předčasnému čtení OnOff.

Běžící hra zde není dostupná; vizuální test ve hře ještě zbývá. Host a klienti musí mít **0.13.58**. Záloha **0.13.51** zůstává zachovaná. Při přechodu z experimentální 0.13.52 nejdřív odmontuj zrušený dveřní analyzer a jeho vodiče.
