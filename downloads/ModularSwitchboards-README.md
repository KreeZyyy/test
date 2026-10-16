# Modular Switchboards — 0.5.0 test

Jednoduchá prázdná skříň. Žádné DIN lišty ani kabeláž; ty přijdou později jako
samostatně osazované díly. Rozměry zůstávají 400 × 500 × 180 mm bez distančníků.

## Instalace

Úplně vypni hru a nahraď celou složku
`Documents/My Games/Stationeers/mods/ModularSwitchboards` složkou z testovacího ZIPu.
Neponechávej starou DLL v podsložkách mods. Potřebuje BepInEx a StationeersLaunchPad
s LaunchPadBooster. Zdrojový ZIP do mods nepatří.

## Výroba a montáž

**Electronics Printer: 10 Copper + 10 Iron + 10 Electrum → 1 kit.**

| Krok | Aktivní ruka | Spotřeba | Výsledek |
| --- | --- | --- | --- |
| Umístění | Kit (Switchboard) | 1 kit | Základ prázdné skříně |
| Smontování | Wrench | 2 Iron Sheets v druhé ruce | Dokončená skříň s plným kovovým krytem |

Kryt se objeví po dokončení. Jde otevřít a zavřít herní interakcí Open.
Demontáž: **Wrench** vrátí 2 plechy, **Drill** vrátí kit.
Kabely, šroubovák ani štípačky pro tuto skříň nejsou potřeba.

## Vzhled a barvení

- Plášť a vnější strana plného krytu jsou přebarvitelné sprejem.
- Vnitřní povrchy, prázdná zadní deska a vnitřní strana krytu zůstávají světle šedé.
- Žlutý trojúhelník s černým bleskem a černé madlo mají pevnou barvu.
- Nejsou tu sklo, lišty, kabelové žlaby, kabely ani elektronické prvky.

Používá se nativní herní shader a nastavení odrazů, světelných sond, stínů a lesku
podle dostupného APC. Každý renderer má vlastní kotvu světelných sond na geometrii,
nikoli ve stěně. Nejsou přidaná světla ani umělé svícení materiálu.

Barevné pruhy z 0.4.0 byly důsledkem vzorkování nativního atlasu cizími UV.
Nově mají povrchy jednobodové textury v nativním formátu Texture2DArray.
Všechny vrstvy barvitelné textury mají aktuálně zvolenou herní barvu, takže UV
ani volba vrstvy nemohou ukázat jiný atlasový výřez. Barva se aktualizuje při
nativní změně barvy objektu. Pevné části mají vlastní jednobarevné textury.

## Uchycení

Bod uchycení používá opravený nativní malý rastr (0.5 m, offset 0.25 m).
Orientace vizuálního modelu se přizpůsobí znaménku středu nativního APC vůči
jeho montážní rovině. Pokud nativní rozměry neposkytují směr, použije se -Z.
Model, kolize, náhled a bounds používají stejnou orientaci a odsazení 120 mm.
Vnější pohled a odstup od skutečné stěny je ještě nutné potvrdit ve hře.

## Uložené skříně

Prefab ID kitu i skříně zůstávají zachované. Dříve dokončený stavební stav 2 se
při načtení převede na nový dokončený stav 1. Starší stav 1 už také znamená hotovou
skříň. Dřívější barva skříně může zůstat uložená; pro výchozí šedou postav novou
skříň nebo použij sprej. Barva, stav krytu a nový stavební stav používají herní save.
Předchozí spotřebované kabely se při migraci automaticky nevracejí.

## Co je ověřeno

Prošla kompilace proti dodané herní DLL a referenčním Unity knihovnám.
Ověřena nová geometrie: 1085 trojúhelníků, tři části a pět materiálových rolí,
platné indexy a normály, oddělené barvitelné plochy a žlutý/černý symbol.
Prošel regresní výpočet malého rastru. Balíček se kontroluje na integritu.
**0.5.0 zde nebyla spuštěna ve Stationeers**; mapování barev, světlo, orientace,
montáž, barvení a migrace uložené skříně potřebují herní test.

Krátký test:

1. Nově položená skříň se z boku celá nachází před stěnou.
2. Klíč + 2 plechy dokončí skříň a objeví se kovový kryt.
3. Otevřený vnitřek je světle šedý a prázdný.
4. Pod baterkou nejsou barevné pruhy; srovnej reakci na světlo s APC.
5. Sprej mění jen plášť a vnější kryt. Vnitřek, madlo a symbol se nemění.
6. Po uložení a načtení přetrvají barva, stav konstrukce a otevření.

V logu se hodí:

- `[Modular Switchboards] 0.5.0 loaded.`
- `APC mounting orientation: front sign ...; APC bounds centre ...`
- `Simple native surfaces loaded; flat palette, no atlas UV tiles; shader ...`
- `Selective paint mappings ready: 2; light-grey interior and fixed warning symbol.`
- `Registration verified: kit + cabinet, 2 build states.`

Při chybě pošli `BepInEx/LogOutput.log` a screenshot. Ikona kitu zůstává dočasná.
Elektrická síť a osazované moduly nejsou součástí této verze.

## Zdrojový projekt

Windows s .NET SDK 8+:

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

`Art/SimpleSwitchboard.blend` a `.glb` obsahují nový jednoduchý model.
`blender -b --python Tools/create_simple_cabinet.py` přegeneruje model i vložená
mesh data v `Assets/Cabinet.meshbin`. Starý exportér pro složitou skříň již nepoužívej.
`python Tools/validate_paint_masks.py` kontroluje geometrii a materiálové role.
Herní balíček obsahuje jen About.xml a mod DLL s vloženými mesh daty.
