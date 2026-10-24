# Modular Switchboards 0.13.80 — Switchboard Small (Reverse)

Nová druhá volba v původním Kit (Switchboard): Switchboard Small (Reverse). Přívod Input dole, Output1 vlevo nahoře a Output2 vpravo nahoře. Odpovídají tomu externí nativní elektrické konektory, jejich kolizní/cable-grid pozice, kryty přípojek, vnitřní svorky a jejich popisy. Dveře, panty, výstraha, jmenovka, DIN lišty i moduly zůstávají vzpřímené. Původní Small zůstává první volbou a zachovává původní uspořádání.

Stejný kit a cena:1kit na rám, Wrench a2Plastic Sheets na skříň. Stejné kity pro lišty/moduly/kryt/dveřní díly/štítky. Pravým tlačítkem s kitem vyber Reverse. Vnitřní propojení je stále potřeba sestavit kabely, žádný automatický bridge.

Reverse má vlastní stabilní prefab StructureModularSwitchboardReverse, ale sdílí stávající typ ukládání, power graph, montážní desky a síťovou synchronizaci. Běžné savy Small se na Reverse nepřevádějí. Upravena geometrie rozvětvení pro spodní společný Input; u horních výstupů delší rovný vstup do svorky nechává místo pro oblouk kabelu. Mimo vlastní vstupní spoj zůstává kontrola kolizí kabelů.

Ověření: Release build bez chyb/varování; produkční IN installer pro oba typy a oba stavy,108 případů native output layoutu,65 případů geometrie T krytu včetně obrácených ploch;68 F1/katalogových kontrol;12464 kontrol obvodů, energie, kolizí, tras a serializace plus Reverse scénář3vstupních větví/2výstupů a300porovnání zrcadleného společného vstupu; všech6save typů registrováno a16XML kontrol včetně obou kabinetů, desek a tras. Testy používají náhrady Unity/native assetů; skutečný herní runtime a multiplayer zde nejsou dostupné.

Instalace při vypnuté hře: nahraď ModularSwitchboards ve složce mods; server/host a klienti stejná verze. Ve hře ověř variant selector, oba typy vedle sebe, rám/dokončení/demontáž, Input dole a oba Outputs nahoře na několika stěnách, napojení skutečných kabelů, vnitřní svorky a propojení přes jističe, kryt/dveřní díly/štítky, barvení a save/load. Záloha0.13.51 zachovaná.
