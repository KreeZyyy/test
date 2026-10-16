# Modular Switchboards — 0.1.0

První experimentální prototyp: samostatný `ItemKitModularSwitchboard` s názvem
**Kit (Switchboard)**. Kopíruje model a ikonu vanilla `ItemKitLogicSwitch` za běhu.
Původní kit nemění. Předmět má jít spawnout, držet a odložit. Stavba je zablokovaná;
skříň, výroba v tiskárně, moduly a elektrické funkce přijdou v dalších verzích.
Budoucí elektrické funkce budou používat současnou síť Stationeers.

## Instalace testovacího balíčku

1. Použij BepInEx + StationeersLaunchPad.
2. Rozbal složku `ModularSwitchboards` do
   `Documents/My Games/Stationeers/mods/`.
3. Zapni mod v LaunchPadu a spusť nový kreativní testovací svět.
4. Ve spawn menu vyhledej `Switchboard`, případně `ItemKitModularSwitchboard`.
5. Spawnuj kit, vezmi jej do ruky a odlož. Má dočasný vzhled vanilla kitu.

Neinstaluj přiložený zdrojový projekt do složky mods. Do testovacího balíčku nejsou
přibalené herní DLL ani DLL loaderu; použije již nainstalované knihovny.

## Ověření ve hře

Tady nebylo možné spustit Stationeers. Kompilace prošla proti uživatelem dodané
Assembly-CSharp.dll, LaunchPadBooster.dll a 0Harmony.dll a referenčním Unity
knihovnám z NuGet `UnityEngine.Modules` 2021.3.33. Shodu s Unity verzí hry je ještě
potřeba ověřit spuštěním. Pro přestavení používej Unity DLL přímo ze své hry.

V `BepInEx/LogOutput.log` hledej:

- `[Modular Switchboards] 0.1.0 loaded`
- `[Modular Switchboards] Prepared ItemKitModularSwitchboard`
- `[Modular Switchboards] Registration verified: ItemKitModularSwitchboard`

Pokud kit chybí nebo při držení nastane chyba, pošli log. Pokud registrace uspěje,
ověř také uložení a opětovné načtení testovacího světa s odloženým kitem.
Multiplayer je označen jako vyžadující mod na obou stranách, ale nebyl ověřen.

## Přestavení ze zdrojů (Windows, .NET SDK 8+)

V kořeni projektu spusť (cesty uprav podle instalace):

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

`LaunchPadDirectory` musí být skutečná složka obsahující `LaunchPadBooster.dll`.
Výsledkem je `ModularSwitchboards/Assemblies/ModularSwitchboards.dll`.

## Registrace

LaunchPad vyvolá `OnLoaded(List<GameObject>)`. Harmony prefix před `Prefab.LoadAll`
vytvoří neaktivní kopii vanilla kitu v trvalém neaktivním kontejneru a přidá ji do
`WorldManager.SourcePrefabs`. Hra pak použije svou běžnou registraci a zapíše kit do
seznamu dynamických předmětů. `PrefabName` a `Animator.StringToHash` určují jeho
samostatnou identitu. Callback `Prefab.OnPrefabsLoaded` ověřuje registraci.

LaunchPadBooster poskytuje identitu modu a požadavek na přítomnost v multiplayeru.
Zdroj se neopírá o interní namespace StationeersLaunchPad. Není potřeba Unity
asset bundle ani LibConstruct pro tento první kit.
