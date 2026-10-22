# Modular Switchboards 0.13.59

## Jedno otočné okénko za špičkou

Otočný hlavní vypínač má novou tenkou červenou clonu na vnitřní stěně talíře. V cloně je jediné otevřené okénko přímo za špičkou rukojeti. Obě bílé značky zůstávají pevně pod clonou.

V poloze **0** vlevo okénko ukazuje bílou nulu a červená clona zakrývá I nahoře. Při přepnutí se clona plynule otáčí společně s rukojetí k horní poloze **I**, odkryje I a schová nulu. Není to okamžité přepnutí textu: značky fyzicky zakrývá pohyblivá geometrie. Zpět funguje stejným způsobem.

Clona zůstává pod vyvýšeným lemem a nad pevnými bílými vložkami. Je součástí skutečného náhledu modelu a ikony.

Chování vypínače je beze změn: sedmá volba dveřního kitu, jeden kit, stejné svorky a devět pozic; 0 rozpojí, I propojí, bez ochrany proti přetížení. Ukládání a síťový OnOff se nemění. Oprava inicializace z 0.13.56 zachována.

## Ověření

Build proti herním DLL bez chyb a varování. 16071 kontrol produkční geometrie včetně uzavřené clony, směru normál a skutečného překrytí obou značek v krajních i prostřední poloze. 43 kontrol ovladače a animace; kontrola přípravy prefabu bez předčasného přístupu OnOff.

Vzhled je ještě potřeba ověřit ve hře; běžící Unity hra zde není dostupná. Host a klienti musí mít **0.13.59**. Záloha **0.13.51** zůstává zachovaná. Při přechodu z experimentální 0.13.52 nejdřív odmontuj zrušený dveřní analyzer a jeho vodiče.
