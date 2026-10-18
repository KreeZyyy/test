# Modular Switchboards 0.12.37

Vodiče vycházejí z otvorů na horní/spodní hraně přístrojů. IN nahoře ústí dolů do horních kontaktů jističů. Spodní kontakt jističe vede do horní hrany výstupní svorkovnice. Čelní šrouby zůstávají místem pro namíření a výběr kontaktu.

Průměr vodiče je všude 4,8 mm: u svorek, na rovných úsecích i v ohybech; stejný průměr mají i pevné přívody svorkovnic k zadní desce. Průřezy používají stabilní vedení orientace podél trasy. Kde místo dovolí, ohyby dostanou plynulejší průběh. Zúžení kabelu se nepoužívá jako způsob průchodu překážkou. Náhled, kolize, uložená trasa i vykreslení sdílejí tutéž střednici.

Generátor rezervuje všech 16 pozic pro budoucí moduly v obou řadách, včetně prostoru u jejich horních a spodních vstupů. Platí to i bez osazené spodní lišty. Jen krátký přívod vlastního kontaktu smí vstoupit do vlastního rezervovaného prostoru. Změna hloubky probíhá u přístroje před vstupem do společné trasy, aby první kabel nezablokoval pozdější připojení sousedního jističe. Vedení dál obchází skutečné obrysy DIN lišt a ostatní vodiče, s výjimkou společného elektrického spoje přímo u IN. Když se další vedení nevejde, spoj se nevytvoří.

Starší trasy, včetně 0.12.36, se po načtení přepočítají na verzi geometrie 3. Spoje a spotřeba kabelu zůstávají zachované. Jestli se nepodaří přepočítat celé zapojení, vrátí se všechny původní trasy a log upozorní na potřebné ruční přepojení. Původní přímý bypass IN -> Output ze starého save se zachová; nový takový spoj není nabízen.

Ovládání: obyčejný Cable Coil v aktivní ruce, kliknout na první a poté druhý kontakt. Druhá ruka může být prázdná. Žlutý náhled ukazuje celou trasu; pravé tlačítko nebo stejný kontakt ruší výběr. Wire Cutters v aktivní ruce přestřihnou zvýrazněný vodič a vrátí jednu jednotku coilu. Mimo otevřenou skříň zůstává běžné stavební ovládání hry.

Elektřina a pravidla zapojení se oproti 0.12.36 nemění: IN může napájet více jističů, jističe lze řadit za sebe, OFF přeruší větev. Není nulový vodič. Jeden spoj stojí jednu jednotku kabelu; nejvýše 16 odboček z IN a 64 vodičů v rozvaděči, skutečný počet dále omezuje prostor. Automatické vybavení při nadproudu zatím není implementováno.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Server i klienti musí používat 0.12.37.

Ověření: Release sestavení bez chyb a varování. Prošlo 10 044 kontrol obvodů, účtování výkonu, ukládání a základních tras. Navíc produkční generátor prošel třemi odbočkami IN, oběma výstupy, zapojením přes horní i spodní jistič, kontrolou rezervací všech 16 pozic včetně chybějící spodní lišty, přepočtem starého zapojení a úplným vrácením původních dat při neúspěchu. Geometrie ověřuje jednotný poloměr a kolmé kruhové průřezy celé trasy, orientaci průřezů a výstup z hran. Vstupní hook prošel 17 kontrolami nástrojů, kliknutí, rušení a odesílání autoritě. Testy běží s náhradami herních objektů; skutečný vzhled, ovládání a multiplayer je nutné potvrdit ve hře.
