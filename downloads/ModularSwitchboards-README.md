# Modular Switchboards — 0.3.0 test

Nový model nástěnné skříně **400 × 500 × 180 mm** je součástí modu:

- Prázdná skříň se dvířky, montážní deska se dvěma DIN lištami, kabelové žlaby a příprava vodičů.
- Jednotlivé části se zobrazují podle stavební fáze.
- Dvířka používají nativní herní interakci Open; jejich pohyb obstarává nový model.
- Umísťování na stěny přes FaceMount, nové kolize a náhled při stavbě.

Model se načítá ze zabalených dat přímo do Unity meshů. Nevyžaduje Unity editor,
asset bundle, LibConstruct ani externí GLB importer. DLL obsahuje veškerou geometrii.
Identita kitu i skříně a nativní datový typ skříně zůstávají zachované.

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

Kit používá `ItemKitModularSwitchboard`, skříň `StructureModularSwitchboard`.
Existující skříň tedy dostane novou geometrii při načtení. Její stavební fáze a
stav Open pocházejí z nativního save data. Změnu je ještě třeba ověřit ve hře.
Dříve postavené skříně se automaticky nepřemístí ze svého uloženého místa na stěnu;
pro test správného uchycení postav novou skříň.

## Ověření

Prošlo sestavení proti uživatelem dodaným Assembly-CSharp, LaunchPadBooster a Harmony.
Pro sestavení zde slouží referenční UnityEngine.Modules 2021.3.33 z NuGet.
Ověřena integrita zabalené geometrie: 4 části, 14 641 trojúhelníků, platné indexy,
normály, rozměry a přesná shoda vloženého resource s exportem z Blenderu.
ZIP je kontrolován na integritu a obsahuje jedinou mod DLL.

**Verze 0.3.0 dosud nebyla spuštěná ve Stationeers.** Barvy/shadery, viditelnost,
kolize, FaceMount, stavební náhled, otevírání, save/load a multiplayer vyžadují test.
Hráč dříve potvrdil tisk a kompletní stavbu ve 0.2.0 i nový tiskový recept ve 0.2.1.

Doporučený krátký test:

1. Nový kit nabízí nový malý model a lze ho umístit na stěnu.
2. Dvířka lze otevřít i zavřít a při otevření se nepřekrývají s původní skříňkou.
3. Plechy přidají pouze montážní základ a lišty, kabely přidají až další části.
4. Po uložení/načtení zůstane správný stavební stav a poloha dvířek.
5. Obrácená demontáž vrátí správné materiály a kit.

V `BepInEx/LogOutput.log` hledej:

- `[Modular Switchboards] 0.3.0 loaded.`
- `Blender geometry loaded: housing, mounting, wiring, door.`
- `New wall cabinet mesh installed: 400x500x180 mm, two DIN rows.`
- `Registration verified: kit + cabinet, 3 build states.`
- `Electronics Printer recipe verified.`

Pokud je model růžový, chybí nebo nefunguje náhled/otevírání, pošli celý log a
screenshot konkrétního kroku. Nativní poškozené modely původní skříňky jsou vypnuté;
speciální vizuály poškození tohoto modelu zatím nejsou vytvořené.

## Zdrojový projekt

Windows, .NET SDK 8+:

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

Výstup: `ModularSwitchboards/Assemblies/ModularSwitchboards.dll`.
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
na vlastní skříň, kit a její recept. Importované Unity materiály modelu jsou
jednoduché barevné PBR materiály s náhradou dostupným herním shaderem.
