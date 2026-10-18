# Modular Switchboards 0.12.35 — vnitřní drátování a herní elektřina

Otevři hotový rozvaděč. V aktivní ruce drž Wire Cutters, ve druhé obyčejný Cable Coil. Zobrazí se volné kontakty: zdroje zeleně, vstupy oranžově, vybraný kontakt žlutě.

1. Primární akcí vyber svorku Input, potom horní kontakt jističe.
2. Spodní kontakt jističe spoj se svorkou Output 1 nebo Output 2. Výběr kontaktů můžeš udělat i v opačném pořadí.
3. Připoj skutečné vnější kabely na horní IN a příslušný spodní výstup. Zapnutý a zapojený jistič propouští energii, OFF svou cestu přeruší. Změna proběhne v herním elektrickém ticku.
4. Opakováním můžeš z Inputu napájet další jističe; dvě výstupní větve mají vlastní zapojení. Jističe lze zapojit i do série.
5. Druhou akcí při namíření na vodič ho střihneš a získáš jednotku coilu zpět; ve svitku musí být volné místo. Kliknutí na právě vybraný kontakt zruší výběr.

Jeden vodič stojí jednu jednotku obyčejného Cable Coilu. Jeden vodič představuje jednu herní elektrickou cestu, bez nuláku. Input má nejvýše 16 odboček; ostatní kontakty po jednom vodiči. Rozvaděč má limit 64 vodičů. Skutečný počet omezuje také dostupné místo.

Trasy se generují kolem obrysů jističů a svorkovnic s kontrolou odstupu od existujících vodičů. Pokud je potřeba, použijí jinou hloubku uvnitř skříně, aby se vodiče neprotínaly. Když není volná cesta, spojení se odmítne bez spotřeby coilu. Nový jistič nelze položit přes vodič; před demontáží zapojeného jističe je potřeba jeho vodiče odstranit.

Rozvaděč používá nativní elektrické callbacky stejně jako herní transformátor: výkon dodaný výstupům se účtuje jako odběr na IN. Oba výstupy sdílejí jeden dostupný příkon. Nevytvářejí dvě kopie plného výkonu vstupu. Elektrické sítě zůstávají oddělené; uložené drátování a stav jističů určují aktivní cestu. Přímé propojení IN na výstup vytvoří záměrný bypass jističe. Proudové limity a automatické vybavení jističů zatím nejsou součástí této verze.

Zapojení a přesné trasy se ukládají do save a posílají při připojení hráče i při změně. Změny i spotřeba/vrácení coilu se provádějí na autoritě. Uzavření dvířek vodiče a kontakty skryje a zruší rozpracovaný výběr, elektrické zapojení pokračuje.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej LibConstructReloaded a ostatní závislosti. Server i klienti potřebují stejnou verzi modu.

Ověření: Release sestavení 0 chyb / 0 varování. 10 042 kontrol obvodů, směru průchodu, OFF/ON, rozdělení příkonu, účtování odběru, XML a tras; navíc produkční generátor pro rozbočení IN do tří jističů a dva výstupy, binární přenos tras a hráčských výběrů, kontrola chybných dat. Testy používají malé náhrady herních objektů; skutečné Unity ovládání, grafiku, multiplayer a přenos do spotřebičů je ještě potřeba ověřit ve hře. Reprodukovatelné testy jsou ve zdrojovém ZIPu ve Verification/Wiring.
