# Modular Switchboards — 0.10.15 test

Dvě samostatně montovatelné DIN lišty pro nástěnnou skříň. Každá má vlastní kit,
vlastní uložený předmět a vlastní profil TH35. Nově obsahuje mechanický prototyp jednomodulového jističe. Kabeláž, elektrické propojení,
měření proudu a vybavování při přetížení tato verze ještě neobsahuje.

## Změny v 0.10.15

DIN lišty mají o dva políčkové odstíny tmavší šedou v nativní paletě APC.
Šedá vrstva i matný povrch zůstávají, posouvá se pouze UV výběr odstínu lišty.
Tmavší i F1 náhled; profil, perforace, odsazení a osazení beze změn.
Kompilace a geometrické testy včetně posunu UV prošly. Odstín ověřit ve hře.

## Změny v 0.10.14

DIN lišty mají hlubší profil TH35/15 (35 × 15 mm), 4mm koncové podložky
pro odsazení od montážní desky a skutečné průchozí podélné otvory 16 × 6 mm
se zaoblenými konci. Na délce 324 mm je osm otvorů. Celý profil používá
jednotnou matnou šedou. Montážní rovina jističů je posunuta o stejných 11,5 mm
jako čelo profilu; šířka, kapacita a pozice řad se nemění.
F1 náhled a Blender model lišty vznikají přímo z exportu skutečného C# meshe.
Opravena také chyba generátoru náhledů s nepodporovaným odšuměním; ikony lišty
i jističe znovu vykresleny a vizuálně zkontrolovány.

Boční žebrovaný panel je přesunut do spodní části boku (střed 155 mm pod
středem skříně). Tvar žeber i barva sdílená s pláštěm zůstávají stejné.

Kompilace a testy prošly: průchod paprsků otvory, pevné příruby, orientace ploch,
rozměry ve třech délkách, barevné role skříně, ukládání a pravidla LibConstruct
se stubovaným enginem. Ve hře ověřit vzhled i načtení již osazených jističů.

## Změny v 0.10.13

Celý boční žebrovaný panel včetně podkladu používá stejnou barvu jako plášť.
Pevný tmavý podklad odstraněn. Žebra mají nový trojúhelníkový profil s výraznou šikmou plochou a spodním lemem podle krytu APC. Odstín a geometrie DIN lišt se v této verzi nemění.
Aktualizovaný model, GLB a F1 náhled skříně. Kompilace a kontrola materiálových
rolí prošly; vzhled ověřit ve hře.

## Změny v 0.10.12

F1 náhled DIN Breakeru znovu sestaven: současné tělo a vyšší výřez,
prodloužená žlutá páčka v OFF poloze, žlutá osička, dvě šedá boční uložení
bez pevné příčky a červený ukazatel. Náhled používá referenční geometrii páčky;
původní mesh a UV APC se nadále přebírají až za běhu hry.

Na boku dokončené skříně je nový čtvercový panel 76 × 76 mm se šesti šikmými
žebry nad tmavým podkladem. Žebra sdílejí barvu pláště, podklad je pevně tmavý.
Je to vzhledová úprava; nemění montáž ani funkce skříně. Upraven také Blender
model, GLB a náhled skříně. Barevné boky, pevná tmavá deska a šrouby zachovány.

Kompilace, kontrola orientace ploch, rozměrů, barevných rolí a shody vložených
assetů prošly. Výsledek ve hře zde ověřit nelze.

## Změny v 0.10.11

Celá DIN lišta má nyní stejný tmavý matný odstín jako dosavadní vnitřní žlábek,
včetně boků a přírub. Rozměry a montáž zůstávají stejné. Upraven i náhled F1.
Kompilace a kontrola geometrie prošly; vzhled ověřit ve hře.

## Změny v 0.10.10

DIN lišty místo bílé používají šedé boky a příruby s tmavším středovým žlábkem.
Nativní základní matný povrch (smoothness index 0) je pevný, nezávislý na povrchu
skříně. Cílem je čitelnější profil pod baterkou bez přepálených bílých ploch.
Náhled F1 i Blender model mají stejnou kombinaci odstínů.
Kompilace a kontrola přiřazení materiálů, orientace ploch a nezměněných rozměrů
TH35 prošly. Výsledné osvětlení ověřit ve hře.

## Změny v 0.10.9

Pevná zadní montážní deska je tmavší šedá a rozšířená na 384 × 484 mm,
ke krajům vnitřního prostoru s přibližně 2mm spárou. V rozích jsou čtyři
světlé hlavičky šroubů s tmavou drážkou. Boční stěny a obě strany dvířek
nadále přebírají barvu rozvaděče; deska a šrouby se nepřebarvují.
DIN lišty nyní používají světlou nativní paletu místo tmavšího kovu.
Vzhled lišty aktualizován také v F1 náhledu a zdrojovém Blender modelu.

Kompilace a kontroly rozměrů, materiálových rolí, orientace ploch a TH35 profilu
prošly. Pozice lišt a kapacita jističů se nemění. Vzhled ověřit ve hře.

## Změny v 0.10.8

Pivot páčky se přebírá ze skutečného počátku animovaného MasterLever transformu APC.
Přepočet již nezaměňuje kraj bounding boxu za střed žluté osičky. Nativní pivot
zůstává mezi šedými bočními uloženími; při animaci se mění jen úhel.
Dosah destičky od osy je prodloužen na 21 mm. Výřez, ukazatel a oblast klikání
jsou upraveny pro delší páčku. Vlastní šedá příčka se nevrací.

Kompilace a test skutečné metody přepočtu potvrdily neměnnou polohu středu osy
při 0–180°, včetně odsazeného zdrojového pivotu a obou výchozích natočení.
Prošly testy geometrie a animace. Převzetí pivotu a vzhled ověřit ve hře.

## Změny v 0.10.7

Odstraněna pevná šedá příčka přes páčku; zůstávají jen boční uložení.
Žlutý nativní mesh včetně vlastní osičky a nápisů se dál překlápí jako celek.
Destička je prodloužena ze 14 na 18 mm (o 29 %) a vysunuta o 2 mm.
Výřez je vyšší (39 mm) a interakční oblast upravena na celý pohyb delší páčky.
Boční uložení jsou posunuta se skutečnou osou překlápění.
Kompilace, geometrie a test animace prošly. Vzhled ověřit ve hře.

## Změny v 0.10.6

Páčka sedí blíž čelu jističe. Na obou stranách má pevná zaoblená šedá
uložení a příčnou osičku, souosou s animací překlápění. Destička má vůli
mezi bočními uloženími; v krajních polohách zůstává před podkladem výřezu.
Rozteč, šířka jističe a elektrické/síťové stavy se nemění.
Kompilace, kontrola geometrie a test animace prošly. Vzhled ověřit ve hře.

## Změny v 0.10.5

Páčka je plochá překlápěcí destička podle APC: 180° kolem krajní vodorovné osy,
nikoli malý vyčnívající knoflík. Z nativního meshe se určí široká plocha,
odstraní jeho výchozí náklon a rozměry se upraví na výřez jističe.
Zůstávají původní UV a nápisy na obou stranách páčky. OFF dole/červená,
ON nahoře/zelená, plynulý přechod a uložený/síťový stav zachovány.
Orientaci původních nápisů musí potvrdit herní test.

Text štítku se vykresluje jen při pohledu z vnější strany dvířek; otevření
ho neschovává. Samostatný BoxCollider pokrývá celé madlo s malou rezervou
(25 × 73 × 36 mm); fyzická kolize dveří dál sleduje přesný zaoblený mesh.

Průhled do skříně ve spáře zakrývá souvislý zaoblený vratný lem, včetně rohů.
Lem se barví se skříní. Kompilace, test překlápění a kontrola geometrie lemu
včetně paprsků přes spáru prošly. Ve hře zde verze spuštěna nebyla.

## Změny v 0.10.4

Odstraněny samostatné texty ON/OFF pod jističem; zůstávají původní popisy páčky APC.
Páčka vyplňuje šířku výřezu a má vlastní neutrální polohu: aktuální animované
natočení páčky zdrojového APC se již nezapéká do nového meshe. Překlápění kolem
pevné osy, OFF dole/červená a ON nahoře/zelená zůstávají.
Štítek rozvaděče zůstává na vnější straně i otevřených dvířek a otáčí se s nimi.
Kompilace a test přepínání prošly; orientaci a velikost ověřit ve hře.

## Změny v 0.10.3

Značka interakce dvířek má počátek u madla místo pantu. Přesný zaoblený
kolizní mesh se přesunem souřadnic nemění a stále následuje otevírání dvířek.
Kompilace prošla, polohu zelené značky ověřit ve hře.

## Změny v 0.10.2

Páčka jističe se otáčí kolem pevné osy, bez posouvání celého přepínače.
Dole OFF/červená, nahoře ON/zelená; změna má plynulý náběh a doběh (0,22 s).
Rychlé přepnutí během animace navazuje na aktuální úhel. Načtení uloženého stavu
se zobrazí rovnou; nové jističe zůstávají vypnuté. Stav stále vlastní nativní
síťově synchronizovaný OnOff, animace pouze zobrazuje jeho hodnotu.
Původní APC páčka je nižší a méně vystouplá; doplněný text ON/OFF pod přepínačem.
Kompilace, geometrie a test přechodů prošly. Vzhled a animaci ověřit ve hře.

## Změny v 0.10.1

Zaoblená je nyní také celá skříň: plášť, přední rám a dvířka mají
vnější poloměr rohů 20 mm. Kolize dokončeného pláště a dvířek sledují mesh.
Rozměry, osazení, štítek, směr otevírání a barvení zůstávají zachované.

Opraveno falešné selhání kontroly registrace DIN lišty a jističe:
hra klonuje zdrojové prefaby, proto se porovnává jejich stabilní ID,
nikoli konkrétní instance objektu. Skutečně chybějící registrace stále hlásí chybu.

Kompilace a kontroly geometrie prošly; spuštění ve hře zde není dostupné.

## Změny v 0.10.0

Jistič má **zaoblené tělo, měkké hrany zapuštěného čela a větší přepínač**.
Rozteč je nyní 40,5 mm: **8 jističů na řadu, 16 v celém Switchboard Small**.
Tělo je široké 39,6 mm a vysoké 101,25 mm. Délka lišt a samotná skříň se nemění.

Za běhu se převezme skutečný mesh `MasterLever` z nativního APC, jeho původní UV,
materiály a material property blocks. Geometrie se úměrně zmenší pro jistič.
APC se neupravuje. Pokud nelze nativní páčku přečíst, použije se vlastní zaoblená
oranžová páčka a důvod se zapíše do Player.log. Náhled v F1 je offline render
vlastního zaobleného modelu; neobsahuje za běhu extrahovanou herní geometrii.

Nový jistič je nadále OFF/červený, po zapnutí ON/zelený. Název DIN Breaker,
štítek vpravo nahoře a přejmenování Labellerem zůstávají. Recepty jsou stejné.
Při načtení staré řady zůstanou pozice 1–8; přebytky se vrátí jako kity u rozvaděče.

Kompilace a test skutečného generátoru oblé geometrie prošly: zakřivené normály,
2100 trojúhelníků těla, orientace ploch a šířka v novém rastru. Prošly také testy
8 pozic, ukládacích hooků, vrácení přebytků, ukazatele a textu štítku.
**Ve hře 0.10.0 zatím spuštěna nebyla.** Převzetí páčky APC ověří až herní test.
V Player.log hledej `Native APC MasterLever reused`; při fallbacku
`Native APC lever unavailable` nebo `APC lever extraction`.

## Změny v 0.9.2

Výchozí zobrazovaný název skříně i štítku je **Switchboard Small**.
Předchozí výchozí názvy se převedou, ostatní vlastní názvy zůstanou.
Pozice štítku zůstává vpravo nahoře.

## Změny v 0.9.1

Štítek je v pravém horním rohu vnější strany dvířek, 8 mm od hran.
Výchozí název je **Switchboard**, bez slova Cabinet. Vlastní názvy z Labelleru
zůstávají zachované; starý výchozí název se při načtení převede.
Kompilace a test textu prošly; polohu ve hře je potřeba ověřit.

## Změny v 0.9.0

- Jističe jsou o 50 % širší, o 20 % vyšší a o 10 % hlubší. Rozteč přístrojů
  je nyní 27 mm; do stávající skříně se vejde **12 na řadu, 24 celkem**.
  Skříň a délka lišty 324 mm jsou zachované.
- Zobrazované názvy jsou **DIN Breaker** a **Kit (DIN Breaker)** bez „1P“.
  Technická ID prefabů zůstávají stejná kvůli uloženým předmětům.
- Na vnější straně dvířek vpravo je bílý štítek s černým rámečkem a názvem
  rozvaděče. Zobrazuje se jen při zavřených dvířkách dokončené skříně.
  Labeller přejmenuje skříň standardním herním způsobem; štítek čte `CustomName`.
  Název se ukládá a synchronizuje nativně. Dlouhé názvy se zmenší/zkrátí na štítku;
  skutečný název uloženého rozvaděče se tím nemění.

**Převod osazení:** prvních 12 pozic každé staré řady se rozestoupí na nový rastr.
Případné jističe v pozicích 13–18 vrátí server při načtení jako kity u rozvaděče.
Ponechané jističe zachovávají název i uložené ON/OFF. Výchozí staré názvy s „1P“
se převádějí; uživatelské vlastní názvy se nepřepisují.

Kompilace, testy kapacity a vrácení přebytků, vnořeného ukládání, větší geometrie,
přepínače a formátování českého textu prošly se simulovaným enginem.
**0.9.0 tady nebyla spuštěna ve hře.** Ověř Labeller, čitelnost a orientaci štítku,
zavření/otevření, starý zaplněný rozvaděč, větší náhled a opětovné načtení.

## Přepínání v 0.8.1

Nový jistič začíná **vypnutý (OFF)**: páčka dole, ukazatel **červený**.
V otevřené skříni zamiř na páčku a použij běžnou herní interakci On/Off.
Po zapnutí je páčka nahoře a ukazatel **zelený**. Další interakce vypne.
Ukazatel je barevný stavový proužek, nikoliv světlo. Barvy odpovídají zadání.

Stav vlastní nativní `OnOff` interactable s `JoinInProgressSync=true`, takže
používá herní ukládání a replikaci změn. Awake, načtení a vizuální komponenta
uložené zapnutí nepřepisují. Starší jističe 0.8.0 bez stavu začnou OFF.
Přepínání je blokované se zavřenými dvířky nebo bez namontované lišty.
Jde stále o mechanické ovládání: zatím nic elektricky nespíná ani nechrání.

Kompilace, test dvou poloh a barev s Unity stuby, kontrola geometrie a regresní
testy montáže/ukládacích hooků prošly. Nativní uložení stavu OnOff a multiplayer
je ještě nutné ověřit ve hře. Při herním testu přepni jistič ON, ulož a načti svět;
měl by zůstat ON a zelený. Ověř také nově namontovaný jistič: OFF a červený.

## Jistič DIN Breaker

- Electronics Printer, Tier One: **2 Iron + 1 Copper → Kit (DIN Breaker)**.
  Jde o prozatímní recept pro první osazovací prototyp.
- Kreativní spawner: `ItemKitDinBreaker1P` / **Kit (DIN Breaker)**.
- Otevři dokončenou skříň s namontovanou lištou. Vezmi kit, pravým tlačítkem
  přejdi do stavění a zamiř na lištu. Zvolená volná pozice zabere jeden modul
  (27 mm); na každé řadě je 12 pozic. Svislá poloha a natočení se přichytí k liště.
- Drill v otevřené skříni vrací kit jističe. Nejprve vyjmi jističe, pak lišty,
  nakonec můžeš rozebrat skříň.
- Bílý vlastní model s modrou páčkou, kovovými svorkami, nativními paletovými
  materiály a vlastním náhledem. Páčka se ručně přepíná mezi OFF a ON.

Každá lišta nyní vlastní vlastní `DinModuleBoard` LibConstructu. Jistič ukládá
hostitelskou lištu a pozici; lišta ukládá svou montážní plochu pro přístroje.
Vnořená data mají ukládací i síťové hooky. Původní lišty ze savu 0.7.0 dostanou
při načtení prázdnou plochu pro moduly. Zachovávají se dosavadní prefab ID.
Nová ID: `StructureDinBreaker1P`, `ItemKitDinBreaker1P`.

**Ověření:** kompilace proti dodaným herním DLL a LibConstructu prošla. Testy
produkčního kódu se stuby enginu a zdrojovými hooky LibConstructu ověřily
12 pozic, překryvy, hranice, natočení, zavřenou skříň, oddělené řady, zákaz
vyjmutí osazené lišty, migraci staré lišty, XML roundtrip i vnořené síťové vazby.
To nenahrazuje běh ve hře. Ve Stationeers zatím 0.8.1 spuštěná nebyla.
Ve hře ověř montáž dvou sousedních jističů a jednoho v druhé řadě, uložení/načtení,
vrácení kitu a připojení klienta.

## Instalace

Vypni Stationeers a nahraď složku
`Documents/My Games/Stationeers/mods/ModularSwitchboards` složkou z testovacího ZIPu.
Potřebuje BepInEx, StationeersLaunchPad, LaunchPadBooster a zapnutý
**LibConstructReloaded 0.3.0 (Workshop 3751750326)** před naším modem.
Jeho knihovna se skutečně jmenuje `LibConstruct.dll`. Nekopíruj ji podruhé
k našemu modu. Klient i server potřebují stejnou verzi modu i závislosti.

## Jak získat a namontovat lišty

1. V Electronics Printeru vyrob **Kit (DIN Rail)**: **1 Iron → 1 kit**.
   Recept je pouze v Electronics Printeru, Tier One.
2. Otevři dokončenou skříň **Switchboard Cabinet**.
3. Vezmi kit do ruky, pravým tlačítkem otevři režim stavění a zamiř na
   horní nebo dolní polovinu zadní montážní desky. Náhled se vystředí
   a přichytí k příslušné řadě.
4. Umísti lištu. Druhým kitem osadíš druhou řadu. Jedna řada spotřebuje jeden kit.
5. **Drill** lištu odmontuje a vrátí její kit. Dvířka musí být otevřená.
   Před rozebráním skříně nejdřív vyjmi obě lišty.

V kreativním spawneru hledej **Kit (DIN Rail)**, interní ID `ItemKitDinRail`.
Spawnuj kit a montuj do skříně; samostatný spawn struktury bez hostitele není
podporovaný způsob montáže. ID namontované struktury je `StructureSwitchboardDinRail`.

## Rozměry a závislosti

Skříň má 400 × 500 × 180 mm. Její vnitřní šířka určuje délku lišty zaokrouhlenou
na celé modulové pozice po 27 mm, s rezervou po stranách. U současné skříně
vychází **324 mm / 12 budoucích modulových pozic na řadu**. Profil je vysoký
35 mm a hluboký 7,5 mm. Rozteč řad je 216 mm. Pro širší skříně lze použít stejný
profil s jinou délkou; další velikosti skříní tato verze nepřidává.

Pravidla vyžadují dokončenou otevřenou skříň, jednu lištu na řadu a vodorovnou
orientaci. Kontrola před spotřebováním kitu probíhá i na serveru. Lišty vlastní
montážní plocha skříně v LibConstructu; ukládá se jejich hostitel, řada a natočení.
Jsou zapojené i hooky pro připojení klienta a zničení hostitele.

Starší prázdné skříně zachovávají prefab ID a mají migrační cestu pro přidání
prázdné montážní plochy. Nová uložená data osazených skříní vyžadují 0.7.0 nebo
novější kompatibilní verzi; downgrade na 0.6.x jejich osazení neumí.

## Stavění skříně a vzhled

**Electronics Printer: 10 Copper + 10 Iron + 10 Electrum → Kit (Switchboard).**
Jeden kit vytvoří holý rám. Wrench + 2 Iron Sheets dokončí plášť a dvířka.
Wrench vrací plechy, Drill poté vrací kit rámu, pokud uvnitř nejsou lišty.

Panty jsou vpravo, madlo vlevo; dvířka se otevírají zleva doprava ven.
Nová a právě dokončená skříň je bílá. Sprej mění plášť a obě strany dvířek;
montážní deska zůstává světlá a DIN lišty kovově šedé. Značka APC je menší
nahoře uprostřed. Nativní APC geometrie, paletové materiály a osvětlení se
přebírají za běhu; herní prostředky ani DLL závislostí nejsou v balíčku.
Montážní rám i plášť mají podle měřeného povrchu stěny rezervu 0,5 mm.

## Ověření a herní test

Prošla kompilace proti dodané Assembly-CSharp, LaunchPadBooster a přesně dodané
Workshop DLL LibConstructu. Prošly testy skutečného kódu pro volbu řad,
obsazenost, přichycení náhledu, ochranu zavřené/nedokončené skříně a demontáž.
Test s původními zdrojovými hooky LibConstructu a stuby herního prostředí ověřil
XML roundtrip dvou lišt, obnovení vlastnictví, migraci staré prázdné skříně,
síťové čtení/zápis hostitele a lišty a pořadí úklidu.
Test skutečného generátoru geometrie ověřil 60 trojúhelníků, orientaci ploch
a zachování profilu pro tři délky. Prošly také dřívější kontroly skříně a stěny.

**Tady nebyla verze 0.8.1 spuštěna ve Stationeers.** Ve hře je potřeba ověřit:
vytištění/spawn kitu, montáž obou řad, odmítnutí třetí lišty, zavření/otevření,
uložení a opětovné načtení, odmontování s vrácením kitu a případně připojení klienta.
Změna vlastního typu skříně zachovává původní ID, ale vyžaduje tento herní test.

Diagnostika: `%USERPROFILE%\AppData\LocalLow\Rocketwerkz\rocketstation\Player.log`.
Hledej `0.9.0 loaded`, `Breaker 1P registered`, `Breaker recipe verified`, `DIN rail kit + structure registered` a `DIN rail recipe verified`.
Při chybě pošli Player.log. Exporty APC zůstávají v podsložce
`ModularSwitchboards/Diagnostics` vedle logu.

## Zdrojový projekt

Windows, .NET SDK 8+:

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad' '-p:LibConstructPath=E:\SteamLibrary\steamapps\workshop\content\544550\3751750326\LibConstruct.dll'
```

`Tools/create_simple_cabinet.py` vytváří model skříně a její náhledy.
`Tools/create_din_breaker.py` vytváří podklad a náhled jističe.
`Tools/create_din_rail.py` vytváří Blender podklad a náhled lišty; herní mesh
profilu generuje `Source/DinRailModel.cs`. Testovací ZIP obsahuje jen náš mod
s About.xml a vlastní DLL, nikoliv DLL knihovny nebo zdrojový projekt.
