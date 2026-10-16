# Modular Switchboards — 0.4.0 test

Tato verze řeší materiály, barvení a průnik skříně montážní konstrukcí:

- Plášť a rám dvířek používají nativní systém herních barev; lze je přebarvovat sprejem.
- Nová skříň začíná šedá. Barva samotného dočasného kitu se už nepřenáší na novou skříň.
- Lišty, kabely, okénko, madlo, oranžový pruh a výstražný symbol mají pevné barvy.
- Žlutý trojúhelník s černým bleskem je samostatná geometrie na přední straně dvířek.
- Model je posunutý 120 mm před nativní montážní rovinu; dva kovové distančníky vyplňují odstup.
- Stavební náhled, kolize a výběrové bounds zohledňují stejné odsazení.
- Přichycení používá opravený nativní rastr z 0.3.3; bod podpěry zůstává na stěně.

Inspirací je APC. Používá se stejný herní mechanismus palety a přebarvování jako
u nativních zařízení; z dostupného AreaPowerControl se přebírá nastavení lesku a
záložní materiál. Texturu APC nelze jednoduše natáhnout přes jinou geometrii bez
odpovídající UV mapy. Tato verze má vlastní jednoduché projekční UV a nativní
barevné materiály, nikoli překopírovaný vzhled celého APC.

Příčina předchozí červené: nativní CustomColorMapping automaticky přepsal všechny
materiály s Texture2DArray a přiřadil jim společnou výchozí barvu. Nyní se pro
vlastní prefaby renderery registrují výslovně a paint mapping vzniká pouze pro
dva neprázdné submeshe (plášť a rám dvířek). Ostatní submeshe dostávají pevný
barevný index a neúčastní se přebarvování. Materiály mají doplněné UV a tangenty.

## Instalace / aktualizace

1. Úplně vypni Stationeers.
2. Nahraď celou starou složku `Documents/My Games/Stationeers/mods/ModularSwitchboards`
   složkou `ModularSwitchboards` z nového testovacího ZIPu.
3. Neponechávej druhou kopii staré DLL v podsložkách mods.
4. Zapni mod v LaunchPadu. Ověř ho nejdřív ve zkušebním světě.

Potřebuje BepInEx a StationeersLaunchPad s LaunchPadBooster.
Zdrojový ZIP do složky mods nepatří.

## Výroba

**Electronics Printer, Tier 1: 10 Copper + 10 Iron + 10 Electrum → 1 Kit (Switchboard).**
Základní čas je 5 s a energie 1000 J před násobiči stroje.
Cena ani počet potřebných kitů se oproti 0.2.1 nemění.
Ikona a model samotného kitu jsou zatím stále převzaté z vanilla kitu.

## Stavba

Vyber variantu **Switchboard Cabinet** a zamiř na stěnu, která umožňuje montáž
(například stěnu nebo rám podporující herní FaceMount). Připrav dost místa pro
otevření levých dvířek. Geometrie má dvě lišty po 12 pozicích; moduly zatím nejsou dostupné.

| Krok | Aktivní ruka | Druhá ruka / spotřeba | Co přibude |
| --- | --- | --- | --- |
| Umístění | Kit (Switchboard) | 1 kit | Skříň a dvířka |
| Montáž | Wrench | 2 Iron Sheets | Montážní deska a dvě DIN lišty |
| Kabeláž | Screwdriver | 2 Cable Coil | Kabelové žlaby a příprava vodičů |

Otevři dvířka běžnou interakcí a sleduj přidávání částí. Nástroje se nespotřebují.
Demontáž jde obráceně: Wire Cutters → Wrench → Drill; vrací kabely, plechy a kit.
Spotřebu a návrat materiálů řídí standardní ToolUse hry. Kreativní režim může spotřebu obejít.
Skříň zatím nemá elektrické přívody, jističe, měření ani osazovací systém.

## Uložené předměty

Kit i skříň si zachovávají prefab ID a nativní save typ. Při načtení dostane i
stará skříň nový vzhled a odsazení. **Dříve uložená červená barva může zůstat na
plášti** — zkus ji přebarvit sprejem, nebo pro kontrolu výchozí šedé postav novou.
Vnitřek a výstražný symbol mají být barevné nezávisle na barvě pláště.
Nové distančníky jsou z téhož kitu, další materiály pro jejich stavbu nepřibyly.

## Stav ověření

Kompilace prošla proti dodané herní DLL a referenčním Unity knihovnám.
Ověřena vložená geometrie, rozsahy indexů, normály a materiálové role:
barvitelná geometrie se nachází pouze v plášti a dvířkách; varovný trojúhelník,
blesk, lišty a vodiče mají oddělené pevné materiály. Prošel regresní výpočet
přichycení na stěnu z 0.3.3. Přebarvování, vzhled pod světlem a odstup ve 0.4.0
zde nelze spustit ve Stationeers, vyžadují herní test.

Hráč potvrdil ve 0.3.3 položení nové skříně, otevření dvířek a viditelný vnitřek;
nahlásil průnik rámu a nesprávné červené/přesvětlené materiály. Předchozí verze
mají ověřenou výrobu kitu a montáž. Nová verze zachovává výrobní i montážní cenu.

Krátký test:

1. Postav novou skříň na stěnu a z boku zkontroluj, že rám neprochází vnitřkem.
2. Otevři dvířka, dokonči montáž a pod baterkou ověř pevné barvy vnitřku.
3. Zavři dvířka: musí být vidět žlutý trojúhelník s černým bleskem.
4. Sprejem změň barvu skříně. Změnit se má plášť a rám dvířek; symbol a vnitřek zůstanou stejné.
5. Ulož a načti svět: barva, stavební fáze a stav otevření se mají zachovat.

V `BepInEx/LogOutput.log` hledej:

- `[Modular Switchboards] 0.4.0 loaded.`
- `APC paint style: ...`
- `Selective paint mappings ready: 2; fixed internals and warning symbol.`
- `New wall cabinet mesh installed: 400x500x180 mm, two DIN rows, 120 mm stand-off.`
- `Registration verified: kit + cabinet, 3 build states.`
- `Electronics Printer recipe verified.`

Při potížích pošli log a screenshot. Skříň zatím nemá funkční elektrickou síť,
osazované jističe ani speciální vizuál poškození. Ikona kitu zůstává dočasná.

## Zdrojový projekt

Windows, .NET SDK 8+:

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

Výstup: `ModularSwitchboards/Assemblies/ModularSwitchboards.dll`.
Pro kontrolu rolí materiálů spusť `python Tools/validate_paint_masks.py`.
Geometrie `Assets/Cabinet.meshbin` je vložený resource. Čte ji `CabinetGeometry.cs`.
`CabinetModel.cs` při registraci nahradí vizuální a kolizní části kopie nativního
prefabu, nastaví FaceMount a přiřadí tři renderery do BuildStates.
`CabinetDoor.cs` zobrazuje uložený/synchronizovaný stav `Thing.IsOpen`.
Identita modu a požadavek shodné multiplayer verze používají LaunchPadBooster.

Přegenerování mesh dat ze samostatně dodaného Blender projektu:

```text
blender -b --python Tools/export_runtime_mesh.py -- path/to/SwitchboardCabinet.blend Assets/Cabinet.meshbin
```

Nativní herní prefaby se nemění; veškeré zásahy a Harmony prefixy jsou omezené
na vlastní skříň, kit a její recept. Materiály vycházejí z nativní herní palety; klonují její materiály včetně shader variant a textur.
