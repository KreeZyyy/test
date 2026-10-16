# Modular Switchboards — 0.3.3 test

Oprava 0.3.3: používá SmallGrid.SmallGridSize=0.5 a SmallGrid.SmallGridOffset=0.25.
Předchozí nulový offset byl chybný: nativní GridCenter přičítá polovinu velikosti
buňky. S nulovým offsetem tak rovinu stěny posunul o čtvrt metru a nativní
CanMountOnWall mohl odmítnout pozici mimo Face/Edge/Corner. Nyní odpovídá offset
malému rastru hry a základna modelu zůstává v lokální rovině Z=0.

Předchozí oprava 0.3.2: resetuje zděděné přichytávání původní skříňky. Vypíná její
privátní snapování podle os (které jinak přebíjí veřejné GridSize/GridOffset),
nastavovala rovnoměrný 0,5m rastr, ale ještě s chybným nulovým offsetem a vypíná požadavek výhradně
na podpěrný rám, aby fungovala i montáž na podporovanou stěnu. Resetuje také
zděděné rozšíření registračních bounds. Nativní kontrola podpěry a kolizí zůstává aktivní.
Tuto úpravu je nutné ověřit ve hře. Uživatel upřesnil, že 0.3.0 nešlo umístit
a náhled byl odsazený od stěny.

Součástí je také oprava materiálů z 0.3.1: materiály už nevybírají Standard/URP shader přes Shader.Find.
Kopírují nativní barevné materiály hry včetně nastavení a vazeb textur.
Stavební náhled při vytvoření použije CursorManager.CursorShader. Pokud není
k dispozici, ponechá podporovaný nativní materiál. Odstíny modelu jsou zatím
přibližné podle herní palety. Tvar, recept i montážní fáze jsou stejné.

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

**Verze 0.3.0 se ve hře načetla, ale hráč nahlásil růžový model/náhled. Hráč potvrdil odstranění růžové ve 0.3.2, ale uchycení zůstalo chybné. Korekce rastru ve 0.3.3 ještě nemá herní ověření.** Barvy/shadery, viditelnost,
kolize, FaceMount, stavební náhled, otevírání, save/load a multiplayer vyžadují test.
Hráč dříve potvrdil tisk a kompletní stavbu ve 0.2.0 i nový tiskový recept ve 0.2.1.

Doporučený krátký test:

1. Nový kit nabízí nový malý model a lze ho umístit na stěnu.
2. Dvířka lze otevřít i zavřít a při otevření se nepřekrývají s původní skříňkou.
3. Plechy přidají pouze montážní základ a lišty, kabely přidají až další části.
4. Po uložení/načtení zůstane správný stavební stav a poloha dvířek.
5. Obrácená demontáž vrátí správné materiály a kit.

V `BepInEx/LogOutput.log` hledej:

- `[Modular Switchboards] 0.3.3 loaded.`
- `Wall mount reset: native small grid (0.5 m, offset 0.25 m), wall/frame support.`
- `Cabinet native shader: ...`
- `Native cursor shader applied: ...` (při vytvoření stavebního náhledu)
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
na vlastní skříň, kit a její recept. Materiály vycházejí z nativní herní palety; klonují její materiály včetně shader variant a textur.
