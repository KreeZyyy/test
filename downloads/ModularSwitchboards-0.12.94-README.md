# ModularSwitchboards 0.12.94 — vnitřní DIN kryt

Předchozí verze 0.12.93 je zálohovaná v jediném ModularSwitchboards-0.12.93-backup.zip (mod + zdroják + README). Verze 0.12.94 staví na opravě odděleného barvení skříně a vodičů; neobsahuje proužky z 0.12.90.

Kryt je třetí nativní stavební stav rozvaděče: 0 rám, 1 provozní skříň bez krytu, 2 skříň s vnitřním krytem. Bez krytu zůstává rozvaděč funkční. Staré uložené skříně zůstávají bez krytu. Nové CoverSchema=1 chrání uložený stav nasazeného krytu před starou migrací kabinetu.

NASAZENÍ: otevři dokončený rozvaděč; drž Wrench a v druhé ruce 1 Iron Sheet. Zamiř na skříň a dokonči nativní konstrukční akci. SUNDÁNÍ: v otevřeném rozvaděči použij Wrench na kryt; stavební krok vrátí svůj železný plát nativním způsobem. Rozvaděč při tom zachová lišty, moduly, vodiče a zapojení.

Aby se nástroje jednotlivých kroků nepletly, změnil se nástroj pro odebrání prázdného vnějšího pláště z Wrench na Hand Drill. Postup demontáže: Wrench sundá kryt; po odpojení vodičů a odstranění modulů/lišty odebere Hand Drill plášť a následně rám. Původní náklady pláště zůstávají 2 Iron Sheets.

Kryt má pevný rozměr a uchycení v souřadnicích DIN desky. Jen okna se generují podle skutečně osazených modulů: pozice, šířka 1/2/3 DIN a vyšší otvor pro baterii. Neosazené pozice a řady jsou zavřené. Celý plech je souvislý extrudovaný mesh s fyzickým MeshColliderem a průchozími otvory. Je před nejvyšší trasou vnitřních vodičů a před svorkami, pod vnějšími dvířky. Barva krytu odpovídá barvě skříně.

S krytem: páčky jističů, výměna pojistek/baterie a tooltipy analyzátorů zůstávají přístupné přes okna. Přidávání/odebírání lišt či celých modulů a práce s vnitřním drátováním vyžaduje kryt sundat. Vodiče i jejich výběrové kolidery jsou schované; elektrické propojení a měření pokračují.

Po načtení hry se okna sestaví ze skutečných umístěných modulů. Nativní změny stavebního stavu zajišťují ukládání a replikaci nasazeného krytu; další síťový příznak se nepřidává. Pro multiplayer použijte stejnou verzi u hosta i hráčů.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards; LibConstruct a LaunchPadBooster ponech. Ověřeno sestavení proti herním knihovnám, 26575 kontrol produkční geometrie/stavových pravidel a migrace savů (prázdný, plný, smíšený, překrývající se a numericky posunutý layout; uzavřený mesh bez děr mimo okna; průchozí okna; odstup od vodičů), 61 kontrol katalogu/pojistek/přenosu stavu včetně přístupné pojistky při zablokovaném osazování a sada zásahu/spotřeby spreje. Unity hra, skutečné kolize při používání předmětů v oknech, nativní vrácení plátu a živý multiplayer zde nebyly spuštěny; vyžadují herní kontrolu. Jde o testovací vydání.
