# Modular Switchboards — 0.6.7 test

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
náhledy. Montáž používá nativní rastr 0.5 m / offset 0.25 m. Skříň při načtení změří
nativní plochou stěnu a za běhu také konkrétní stěnu, na kterou je připevněná.
Zadní plášť, rám, vnitřní deska, dvířka a jejich kolize leží před jejím povrchem
s rezervou **0.0005 m (0.5 mm)**. Kořen předmětu zůstává na rastru.
Předchozí pevné odsazení 120 + 80 mm a oba páry dlouhých držáků jsou odstraněné.
Náhled a výběrové bounds se posouvají s modelem. U volně spawnuté skříně bez
podpůrné stěny se použije předběžné měření dokončené nativní ploché stěny.
Tloušťka a skutečný odstup se zapisují do Player.log; konkrétní hodnotu
nativního modelu zde bez spuštěné hry neuvádíme.

Sprej mění plášť zvenku i zevnitř a obě strany dvířek. Samostatná zadní montážní
deska zůstává světlá; madlo, panty a výstražný znak mají pevné barvy.
ID předmětů jsou zachovaná; původní dokončený stav 2 se při načtení převádí na 1.
Uložená poloha, rotace, otevření a barva předmětu používají nativní mechanismus.

## Značka APC v 0.6.7

Značka je nově **nahoře uprostřed a má 65 % původní velikosti APC**. Tvar,
černý obrys, blesk a materiály pocházejí z původní geometrie. Pod ní zůstává
prostor pro budoucí tlačítka a kontrolky; tato verze je ještě nepřidává.
Výchozí barva nové i právě dokončené skříně je bílá. Barvy už dokončených
uložených skříní se zachovávají.

Dodané podklady ukázaly, že ColorWhite/ColorRed/ColorOrange jsou barevné palety;
žlutočerný výstražný symbol v nich jako samostatný obrázek není. Předchozí export
geometrie přes JsonUtility vytvořil pouze `{}`.

Nový kód nejdřív čte původní geometrii dvířek APC. Podle vzorků palety vybere
spojené žluté plochy v dolní části dvířek a sousední černé plochy obrysu/blesku.
Přenáší tyto původní trojúhelníky, UV, materiály a nastavení světla na
naše dvířka, nahoře uprostřed, s měřítkem 0.65. Originální APC se nemění; herní data nejsou v ZIPu.
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

- `0.6.7 loaded`
- `Flat wall measured: ...`
- `Cabinet fitted to ...; wall thickness=...; clearance=0.000500 m`
- `APC geometry exported: ... meshes`
- `APC Door geometry: ... faces, ... yellow faces`
- `Native APC warning geometry reused: ...`
- případně `Native APC warning not located` nebo `Native warning geometry read`

## Ověření

Test skutečné funkce pro průnik ploch stěny ověřil obě strany, posunutý model,
vyřazení zvýšených okrajů při měření centrální plochy a rezervu 0.5 mm.
Prošlo také 84 regresních případů malého rastru. Herní kontrola uchycení,
kolizí a náhledu na skutečné stěně je ještě potřeba.

Prošla kompilace proti dodané Assembly-CSharp a Unity referencím, kontroly 1512
vložených trojúhelníků, jejich orientace vůči normálám, indexů, rozměrů a
materiálových rolí. Jen samostatná montážní deska má pevné světlé plochy.

Test skutečného výběrového kódu na syntetické geometrii ověřil převzetí žluté
výplně, černého obrysu a blesku a vyřazení nesouvisejících dílů. Test skutečného
JSON zapisovače ověřil platné pole meshů, číselné souřadnice, escapování názvů a
nezávislost na desetinné čárce systému. To neověřuje výběr z reálného APC.

**0.6.7 zde nebyla spuštěna ve Stationeers.** Ve hře ověř z boku téměř těsné přiléhání ke stěně, umístění náhledu a kolizí
a menší značku nahoře uprostřed. Zkontroluj také otevření a barvení.
Pokud znak stále chybí, pošli nový export a Player.log.

## Zdrojový projekt

Windows s .NET SDK 8+:

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

`blender -b --python Tools/create_simple_cabinet.py` vytvoří vlastní model,
GLB, vložená mesh data a vlastní náhledy. `python Tools/validate_paint_masks.py`
ověří geometrii a materiálové role. Herní ZIP obsahuje About.xml a jedinou DLL.
