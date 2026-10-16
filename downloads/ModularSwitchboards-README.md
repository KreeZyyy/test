# Modular Switchboards — 0.8.0 test

Dvě samostatně montovatelné DIN lišty pro nástěnnou skříň. Každá má vlastní kit,
vlastní uložený předmět a vlastní profil TH35. Nově obsahuje mechanický prototyp jednomodulového jističe. Kabeláž, funkční přepínání,
měření proudu a vybavování při přetížení tato verze ještě neobsahuje.

## Jistič DIN Breaker 1P

- Electronics Printer, Tier One: **2 Iron + 1 Copper → Kit (DIN Breaker 1P)**.
  Jde o prozatímní recept pro první osazovací prototyp.
- Kreativní spawner: `ItemKitDinBreaker1P` / **Kit (DIN Breaker 1P)**.
- Otevři dokončenou skříň s namontovanou lištou. Vezmi kit, pravým tlačítkem
  přejdi do stavění a zamiř na lištu. Zvolená volná pozice zabere jeden modul
  (18 mm); na každé řadě je 18 pozic. Svislá poloha a natočení se přichytí k liště.
- Drill v otevřené skříni vrací kit jističe. Nejprve vyjmi jističe, pak lišty,
  nakonec můžeš rozebrat skříň.
- Bílý vlastní model s modrou páčkou, kovovými svorkami, nativními paletovými
  materiály a vlastním náhledem. Páčka je zatím pouze součást modelu.

Každá lišta nyní vlastní vlastní `DinModuleBoard` LibConstructu. Jistič ukládá
hostitelskou lištu a pozici; lišta ukládá svou montážní plochu pro přístroje.
Vnořená data mají ukládací i síťové hooky. Původní lišty ze savu 0.7.0 dostanou
při načtení prázdnou plochu pro moduly. Zachovávají se dosavadní prefab ID.
Nová ID: `StructureDinBreaker1P`, `ItemKitDinBreaker1P`.

**Ověření:** kompilace proti dodaným herním DLL a LibConstructu prošla. Testy
produkčního kódu se stuby enginu a zdrojovými hooky LibConstructu ověřily
18 pozic, překryvy, hranice, natočení, zavřenou skříň, oddělené řady, zákaz
vyjmutí osazené lišty, migraci staré lišty, XML roundtrip i vnořené síťové vazby.
To nenahrazuje běh ve hře. Ve Stationeers zatím 0.8.0 spuštěná nebyla.
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
na celé modulové pozice po 18 mm, s rezervou po stranách. U současné skříně
vychází **324 mm / 18 budoucích modulových pozic na řadu**. Profil je vysoký
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

**Tady nebyla verze 0.8.0 spuštěna ve Stationeers.** Ve hře je potřeba ověřit:
vytištění/spawn kitu, montáž obou řad, odmítnutí třetí lišty, zavření/otevření,
uložení a opětovné načtení, odmontování s vrácením kitu a případně připojení klienta.
Změna vlastního typu skříně zachovává původní ID, ale vyžaduje tento herní test.

Diagnostika: `%USERPROFILE%\AppData\LocalLow\Rocketwerkz\rocketstation\Player.log`.
Hledej `0.8.0 loaded`, `Breaker 1P registered`, `Breaker recipe verified`, `DIN rail kit + structure registered` a `DIN rail recipe verified`.
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
