# Modular Switchboards — 0.2.0 test

Kit už má stavební variantu **Switchboard Cabinet** a výrobní recept v **Autolathe**.
Identita `ItemKitModularSwitchboard` zůstává stejná jako v 0.1.0, takže dříve
uložené kity mohou stavět nový rozvaděč. Ve hře to musí potvrdit test.

## Instalace / aktualizace

1. Úplně vypni hru.
2. Nahraď předchozí složku `Documents/My Games/Stationeers/mods/ModularSwitchboards`
   novou složkou `ModularSwitchboards` z testovacího ZIPu. Neponechávej druhou kopii
   staré DLL v jiné podsložce mods; LaunchPad načítá DLL i z podsložek.
3. Zapni mod v LaunchPadu a načti testovací svět.
4. Ve spawn menu nebo v Autolathe hledej **Kit (Switchboard)**.

Potřebuje BepInEx a StationeersLaunchPad s LaunchPadBooster. Další knihovny ani
Unity projekt se neinstalují. Zdrojový ZIP do složky mods nepatří.

## Výroba kitu

**Autolathe, Tier 1: 20 jednotek Iron → 1 Kit (Switchboard)**.
Základní recept má čas 5 s a energii 1000 J; výsledný čas a energie podléhají
běžným násobičům výrobního stroje. Jde o první návrh ceny pro testování.

## Stavba a demontáž

| Krok | Aktivní ruka | Druhá ruka / spotřeba | Výsledek |
| --- | --- | --- | --- |
| Umístění | Kit (Switchboard) | 1 kit | Skříň, stav 0 |
| Montáž základu pro lišty | Wrench | 2 Iron Sheets | Stav 1 |
| Příprava kabeláže | Screwdriver | 2 Cable Coil | Dokončená prázdná skříň, stav 2 |

Nástroje se nespotřebují. Akce mají základní délku 2 s před herními násobiči.
Demontáž probíhá obráceně:

1. **Wire Cutters**: vrátí 2 Cable Coil, stav 2 → 1.
2. **Wrench**: vrátí 2 Iron Sheets, stav 1 → 0.
3. **Drill**: odstraní skříň a vrátí 1 Kit (Switchboard).

Návrat materiálů zajišťuje standardní herní ToolUse.Deconstruct. V kreativním
režimu hra může spotřebu při umístění obejít; výrobní cenu a spotřebu ověř také
v survival režimu. Při poničení skříně se uplatní běžná pravidla hry pro poškození.

## Dočasný vzhled a další vývoj

Skříň používá kopii nativního prefabu třídy Locker (přednostně malou skříňku,
pokud ji daná verze hry obsahuje). Velikost, umisťování a otevírání odpovídají
této herní skříňce. Není to finální nástěnný model rozvaděče.
Inventář skříňky je odstraněn; neslouží jako běžný sklad.

**Všechny tři stavební stavy mají stejný dočasný vzhled.** Jejich postup určují
herní stavební stavy a požadované nástroje. Popis ve Stationpedii uvádí postup.

Tato verze připravuje jen skříň. Lišty a kabeláž jsou zatím montážní fáze,
nikoli samostatné viditelné moduly. Skříň ještě nemá funkční přívod ani vývody,
nepřepíná síť, neměří proud a nepodporuje osazení jističů.
Další plán: vlastní skříň a viditelné lišty, osazované moduly (hlavní vypínač,
jističe, měření, kontrolky), následně propojení se současnou sítí Stationeers.

## Stav ověření a test u hráče

Kompilace proti dodané Assembly-CSharp.dll, LaunchPadBooster.dll, 0Harmony.dll
prošla. Pro sestavení zde byly použity referenční UnityEngine.Modules 2021.3.33
z NuGet; pro vlastní build použij knihovny ze své instalace hry.
Stationeers zde nelze spustit. 0.2.0 tedy zatím nemá herní ověření výroby,
stavby, demontáže, ukládání skříně ani multiplayeru. Verzi 0.1.0 už hráč ověřil
pro registraci, spawn, držení kitu a načtení uloženého kitu.

Ověř ve zkušebním světě:

- Starý kit z uložené hry nabízí Switchboard Cabinet.
- Nově vyrobený kit se objeví v Autolathe a výrobní suroviny se odečtou.
- Jedna stavba v survival režimu spotřebuje přesně jeden kit, dva plechy a dva kabely.
- V každé rozestavěné fázi lze uložit a načíst svět a pokračovat.
- Demontáž podle tabulky vrátí stejný kit i montážní materiály.
- Původní herní skříňky a Kit (Logic Switch) zůstaly funkční.

V `BepInEx/LogOutput.log` hledej:

- `[Modular Switchboards] 0.2.0 loaded.`
- `Registration verified: kit + cabinet, 3 build states.`
- `Autolathe recipe added: 20 Iron -> 1 kit.`
- `Autolathe recipe verified.`

Při potížích pošli celý log a napiš, který krok selhal.

## Přestavení ze zdrojů (Windows, .NET SDK 8+)

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

`LaunchPadDirectory` musí obsahovat `LaunchPadBooster.dll`.
Výstup: `ModularSwitchboards/Assemblies/ModularSwitchboards.dll`.

## Implementace

LaunchPad volá `OnLoaded(List<GameObject>)`. Harmony prefix před `Prefab.LoadAll`
připraví kopie herního kitu a skříňky pod neaktivním trvalým kontejnerem. Až po
úplné konfiguraci zveřejní oba prefaby do `WorldManager.SourcePrefabs`.
Každý má vlastní PrefabName a Animator.StringToHash. Nativní prefaby se nemění.
Tři stavební stavy mají vlastní ToolUse a seznamy; zachovávají data vykreslování
z kopie skříňky. Hra zajišťuje stavbu, ukládání stavebního stavu a demontáž.

Prefix `DynamicThingRecipeComparable.GenerateRecipieList` přidává recept jen pro
Autolathe, po načtení datových souborů a před tvorbou seznamů a hashů receptů.
Používá nativní AddRecipe, včetně registrace recyklace a synchronizace receptů.
Přítomnost receptu i záznamu v tiskové nabídce kontroluje callback po načtení dat.

Lokalizační prefixy obsluhují pouze dvě jména tohoto modu a doplňují anglický
název a popis bez chybového tokenu. Multiplayer vyžaduje shodnou verzi modu na
obou stranách; praktický multiplayer test zatím neproběhl.
