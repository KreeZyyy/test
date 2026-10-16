# Modular Switchboards — 0.6.5 test

Prázdná nástěnná skříň 400 × 500 × 180 mm. Nativní elektrické moduly, DIN lišty a
kabeláž nejsou součástí této verze.

## Instalace a stavění

Úplně vypni Stationeers a nahraď celou složku
`Documents/My Games/Stationeers/mods/ModularSwitchboards` složkou z testovacího ZIPu.
Potřebuje BepInEx, StationeersLaunchPad a LaunchPadBooster. Ve složce mods ponech
jen jednu verzi DLL. Zdrojový ZIP do mods nepatří.

**Electronics Printer: 10 Copper + 10 Iron + 10 Electrum → 1 kit.**

| Fáze | Spotřeba / nástroj | Výsledek |
| --- | --- | --- |
| Umístění | 1 Kit (Switchboard) | Holý montážní rám |
| Dokončení | Wrench + 2 Iron Sheets v druhé ruce | Prázdná skříň a otevírací dvířka |

Demontáž: Wrench vrátí plechy, Drill vrátí kit. Panty jsou při pohledu zepředu
vpravo, madlo vlevo; dvířka se otevírají zleva doprava směrem ven.
Kit má běžný herní náhled elektrické stavebnice; rám a hotová skříň vlastní
náhledy. Montážní rám zachovává ověřenou polohu. Hotové tělo, deska, dvířka a
jejich kolize jsou oproti rámu posunuté o 80 mm dopředu, spojené distančníky.

Sprej mění plášť zvenku i zevnitř a obě strany dvířek. Samostatná zadní montážní
deska zůstává světlá; madlo, panty a výstražný znak mají pevné barvy.
ID předmětů jsou zachovaná; původní dokončený stav 2 se při načtení převádí na 1.
Uložená poloha, rotace, otevření a barva předmětu používají nativní mechanismus.

## Značka APC v 0.6.5

Jedinou změnou proti ve hře potvrzené 0.6.4 je vodorovné vystředění značky dole
na dvířkách. Původní rozměry, geometrie, materiály a výška umístění zůstávají stejné.

Dodané podklady ukázaly, že ColorWhite/ColorRed/ColorOrange jsou barevné palety;
žlutočerný výstražný symbol v nich jako samostatný obrázek není. Předchozí export
geometrie přes JsonUtility vytvořil pouze `{}`.

Nový kód nejdřív čte původní geometrii dvířek APC. Podle vzorků palety vybere
spojené žluté plochy v dolní části dvířek a sousední černé plochy obrysu/blesku.
Přenáší tyto původní trojúhelníky, UV, materiály, rozměry a nastavení světla na
naše dvířka, dole uprostřed. Originální APC se nemění; herní data nejsou v ZIPu.
Nejde o ručně překreslený symbol. Výběr skutečného symbolu musí potvrdit herní test.

Pokud geometrický výběr selže, zůstává starší hledání v barevných texturách.
Pokud neuspěje ani to, nevykreslí se přibližná náhrada a důvod bude v logu.
F1 náhled skříně pochází z offline modelu; runtime znak APC na něm zatím není.

## Diagnostika

Geometrie APC se při registraci nově exportuje vždy, vlastním JSON zapisovačem:

```text
%USERPROFILE%\AppData\LocalLow\Rocketwerkz\rocketstation\ModularSwitchboards\Diagnostics
```

`APC-geometry.json` má obsahovat objekt `Meshes` s vrcholy, UV, trojúhelníky a
přiřazenými materiály; nemá to být `{}`. Pokud se znak nenajde, doplní se také
`APC-materials.txt` a PNG původních textur. Při problému pošli ZIP této složky a
`Player.log` ze složky `Rocketwerkz/rocketstation` o dvě úrovně výše.
Nativní herní soubory není potřeba kopírovat ani měnit.

Důležité řádky logu:

- `0.6.5 loaded`
- `APC geometry exported: ... meshes`
- `APC Door geometry: ... faces, ... yellow faces`
- `Native APC warning geometry reused: ...`
- případně `Native APC warning not located` nebo `Native warning geometry read`

## Ověření

Prošla kompilace proti dodané Assembly-CSharp a Unity referencím, kontroly 1512
vložených trojúhelníků, jejich orientace vůči normálám, indexů, rozměrů a
materiálových rolí. Jen samostatná montážní deska má pevné světlé plochy.

Test skutečného výběrového kódu na syntetické geometrii ověřil převzetí žluté
výplně, černého obrysu a blesku a vyřazení nesouvisejících dílů. Test skutečného
JSON zapisovače ověřil platné pole meshů, číselné souřadnice, escapování názvů a
nezávislost na desetinné čárce systému. To neověřuje výběr z reálného APC.

**0.6.5 zde nebyla spuštěna ve Stationeers.** Ve hře ověř znak na zavřených
nových dvířkách, jeho orientaci, černý obrys a blesk a zachování barev při spreji.
Pokud znak stále chybí, pošli nový export a Player.log.

## Zdrojový projekt

Windows s .NET SDK 8+:

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

`blender -b --python Tools/create_simple_cabinet.py` vytvoří vlastní model,
GLB, vložená mesh data a vlastní náhledy. `python Tools/validate_paint_masks.py`
ověří geometrii a materiálové role. Herní ZIP obsahuje About.xml a jedinou DLL.
