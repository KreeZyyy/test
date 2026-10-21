# Modular Switchboards 0.13.49

TOTAL STOP, úpravy vedení kabelů a matnější plechy rozvaděče.

## TOTAL STOP

Ve stávajícím kitu **Switchboards Doors Module** je nová varianta **Door TOTAL STOP** s vlastní ikonou: červený hřib na žlutém podkladu. Zabírá jednu z devíti pozic na dveřích a spotřebuje 1 kit. K dispozici nadále zůstávají zelená, modrá a bílá LED i jednotlivý bridge. Recept kitu se nemění: Electronics Printer, 2 g Iron + 1 g Copper.

Normálně propojuje horní IN s dolním OUT. Kliknutím se hřib zamáčkne, přeruší průchod a zůstane zajištěný. **Podržením interakce 1,2 sekundy** se resetuje, pootočí a vyskočí; proud se tím okamžitě znovu propojí. Zrušení podržení nic nepřepne. Ovládání funguje bez napájení, při otevřených i zavřených dveřích. Stav využívá původní herní ukládání a síťovou synchronizaci OnOff, s opačným významem: 0 = připravený/průchozí, 1 = zamáčknutý/rozpojený. Neprovádí se reset při načtení objektu.

Zezadu má dvě svorky bez nápisů, se stejnými kontaktními místy jako LED: IN nahoře, OUT dole. Zapojení na desku vede přes samostatné rovnocenné bridge u pantu. TOTAL STOP přeruší jen větev vedenou přes něj; nejedná se o další jistič ani pojistku. Pro celý rozvaděč jej zapoj před větvení. Demontáž Hand Drillem po odpojení vodičů.

## Kabely

Opravená volba odboček Inputu: větve k modulům vlevo nyní vybírají levé odbočky, větve vpravo pravé. Předchozí znaménko nutilo další vodič nejdřív na opačnou stranu.

Na dveřích se nejprve levně zkoušejí přímé a jednoduché souběžné trasy v rozestupech 9 mm napříč dostupnými hloubkami. Vybírá se podle délky a celkového úhlu zatáček. Jednoduchá trasa musí projít kontrolou fyzického odstupu, vlastních kontaktů, překřížení a souběhu v projekci. Hustší zapojení používá původní mřížkové hledání. Zůstávají zaoblené vodiče, rezervace budoucích modulů, všechny kontaktní body a pohyblivé modré kabely bridge.

Verze tras je 5. Starší trasy se přepočítají transakčně se zachováním zapojení, barev a spotřebovaných kusů kabelu. Pokud některou nelze přepočítat, obnoví se všechny původní trasy; nic se nemaže ani nevrací do inventáře.

## Povrch

Dveře, rám, skříň, vratný lem a vnitřní plechy používají soukromé matné kopie materiálů. Vypínají lesk a odrazy, pro plechy je nastavený matný index i při obnově barev. Barvy a textury zůstávají zachované. Původní herní materiály, moduly, kabely ani schválené barvy/emise LED se nemění. Výsledek pod herní svítilnou je potřeba ověřit ve hře.

## Ověření

- Produkční sestavení proti herním DLL bez chyb a varování.
- 36 kontrol skutečného ovladače TOTAL STOP a animace: okamžitý stisk, zrušené a dokončené podržení, síťový příkaz, neplatné/stavební objekty, uložená poloha, oddělení instancí.
- Průchod proudu přes dva bridge a TOTAL STOP do LED / výstupu; 50 kW skutečného odběru, oddělená větev, výpadky napájení a ruční reset.
- 67 889 kontrol bridge a plného zapojení devíti dveřních modulů; 12 464 kontrol obvodů, tras a ukládání; 2 023 kontrol baterií a 14 voleb analyzeru.
- Nový scénář tří modulů vedle sebe v horní řadě dveří: šest tras, přibližně 103 ms celkem v lokálním geometrickém testu. Nejde o měření ve hře.
- 117 kontrol nezměněného ovladače LED, 62 kontrol katalogu/hledání a 23 kontrol izolace matných materiálů.

Unity ani běžící hra zde nejsou dostupné. Ve hře ověř stisk/reset včetně savu, multiplayer, vzhled tlačítka, nové trasy a odlesky. Host a klienti musí mít shodnou verzi **0.13.49**. Záloha **0.13.40** zůstává nedotčená; při návratu použij i odpovídající zálohu savu.

Test ZIP obsahuje hotový mod. Source ZIP obsahuje zdroje a ověřovací nástroje bez přeložené DLL; vynechává regenerovatelné velké JSON mezisoubory jako předchozí balíčky.
