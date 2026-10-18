# Modular Switchboards 0.12.36 — jednodušší ovládání a opravené trasy

Drž v aktivní ruce obyčejný Cable Coil. Druhá ruka může být prázdná. Jedním kliknutím vybereš kontakt, druhým spojíš. Po výběru zůstanou označené jen použitelné volné kontakty. Při namíření na cíl se před potvrzením zobrazí žlutý náhled celé trasy. Kliknutí na stejný kontakt nebo pravé tlačítko výběr zruší. Držení tlačítka neopakuje výběr ani spojování.

Wire Cutters v aktivní ruce vodič jedním kliknutím odstraní. Nepotřebují coil ve druhé ruce. Vodič pod kurzorem se zvýrazní žlutě. Jednotka kabelu se vrátí do druhé ruky / odpovídajícího svitku, pokud to jde; jinak vznikne běžný coil na místě střihu.

Uvnitř otevřeného rozvaděče se při drátování potlačí běžný stavební náhled coilu. Mimo rozvaděč se vrátí původní stavební ovládání. Změny stále zpracovává autorita přes herní síťové zprávy.

Zapojení: Input -> horní kontakt jističe; spodní kontakt jističe -> Output 1 nebo Output 2. Input může napájet více jističů, jističe lze řadit i za sebe. Nově se nenabízí přímé Input -> Output propojení, aby se omylem neobešel jistič. OFF přeruší větev podle nativních elektrických ticků; výkon a účtování odběru zůstávají z 0.12.35.

Vodiče mají průměr 4,8 mm místo 3,2 mm. Kontrola odstupů počítá se silnějším vodičem. Generátor zohledňuje skutečný obrys obou DIN lišt a vede vodiče kolem jejich konců bočními koridory. Když je potřeba, použije jinou hloubku s odstupem od ostatních vodičů. Přístroje ani lišty nepřekračuje ani ve vyšší hloubce. Zkrácené náběhy u svorek odstraňují zbytečné háčky. Čelní vstupy svorek míří směrem k přístrojům a popisky výstupů jsou vedle svorek, aby je nekřížil vodič.

Po načtení se staré trasy z 0.12.35 přepočítají bez změny spojení a bez spotřeby coilu. Přepočet počká na načtené lišty a jističe. Pokud nelze převést celé zapojení, zachová původní trasy i spojení a vypíše zprávu pro ruční přepojení. Původní přímý bypass Input -> Output ze starého save se zachová: pokud má být takový výstup ovládán jističem, přestřihni bypass a připoj ho přes jistič.

Nový jistič ani DIN lištu nelze položit přes existující vodič. Jeden vodič stojí jednu jednotku obyčejného coilu. Input má nejvýše 16 odboček, ostatní kontakty jeden vodič, celkem nejvýše 64 vodičů; počet dále omezuje skutečné místo. Automatické vybavení jističe při nadproudu zatím není implementované.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Server i klienti musí mít 0.12.36 kvůli rozšířenému formátu přenosu tras.

Ověření: produkční Release sestavení bez chyb a varování. Prošlo 10 044 kontrol obvodů, výkonu, ukládání a základních tras; navíc produkční generátor pro tři větve IN a oba výstupy s oběma DIN lištami, kontrola bočních koridorů, přepočet zapojení z obrázku, zachování spojení a vrácení původního stavu při zablokované trase. Produkční vstupní hook prošel 17 kontrolami samostatných nástrojů, kliknutí versus držení, rušení, odesílání autoritě a návratu stavebního náhledu mimo skříň. Testy používají náhrady herních objektů; skutečné Unity ovládání, vzhled a multiplayer je potřeba potvrdit ve hře.
