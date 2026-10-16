# Modular Switchboards — 0.6.0 test

Prázdná nástěnná skříň, 400 × 500 × 180 mm. Dvě skutečné stavební fáze a vlastní
náhledy kitu, rámu a hotové skříně. DIN lišty, kabeláž a elektrické moduly přijdou později.

## Instalace

Úplně vypni hru a nahraď celou složku
`Documents/My Games/Stationeers/mods/ModularSwitchboards` složkou z testovacího ZIPu.
Neponechávej staré DLL v podsložkách mods. Potřebuje BepInEx a StationeersLaunchPad
s LaunchPadBooster. Zdrojový ZIP do mods nepatří.

## Výroba a stavění

**Electronics Printer: 10 Copper + 10 Iron + 10 Electrum → 1 kit.**

| Krok | Nástroj / předmět | Spotřeba | Výsledek |
| --- | --- | --- | --- |
| Umístění | Kit (Switchboard) | 1 kit | Holý montážní rám, bez panelů a dvířek |
| Dokončení | Wrench | 2 Iron Sheets v druhé ruce | Kompletní prázdná skříň s otevíracími dvířky |

Demontáž: Wrench vrátí plechy, Drill vrátí kit. Kabely nejsou potřeba.
Před dokončením není dostupná interakce Open. Každá fáze má vlastní kolize a
náhled v `BuildState.Thumbnail`. Kit i hotová skříň mají vlastní `Thing.Thumbnail`;
zděděné barevné náhledy Lockeru jsou odstraněné. Fyzický kit v ruce zatím používá
původní model stavebnice, jeho vlastní ikona ukazuje zabalenou skříň.

## Materiály a opravy modelu

Předchozí export obracel trojúhelníky i při převodu souřadnic s determinantem +1.
Pořadí vrcholů proto nesouhlasilo s normálami. Opravený export a kontrola všech
1517 trojúhelníků nyní ověřují, že jejich orientace souhlasí s normálami.
To opravuje konkrétní chybu geometrie; výsledné osvětlení je ještě nutné ověřit ve hře.

Nová verze už nenahrazuje herní textury jednobodovými texturami. Ponechává nativní
materiál pro barvení včetně jeho textur a shaderu. Při registraci vyhledá velký
lakovaný trojúhelník na nativním APC a UV našich plechů promítne do malého výřezu
uvnitř tohoto trojúhelníku. Nejde o překopírování celého atlasu na každý plech ani
o reprodukci větracích drážek APC. Normálové mapování používá přepočítané tangenty.
Nativní herní textury nejsou součástí ZIPu a originální APC se neupravuje.

- Plášť a vnější strana dvířek používají nativní `CustomColorMapping` a barvu objektu.
- Pevné vnitřní plochy používají světlý herní odstín; výstražný znak žlutou a černou.
- Po nativní změně barvy se znovu nastaví pevné indexy vnitřku a znaku.
- Nastavení světelných sond, stínů, odrazů a index lesku se přebírají z APC.
- Nepřidává se světlo ani umělé svícení povrchu.

Čtení UV podporuje čitelné CPU meshe i GPU vertex/index buffery pro importované
meshe bez Read/Write. Pokud žádný lakovaný panel APC nejde přečíst, registrace
skončí chybou v logu místo použití náhodného výřezu atlasu. Tento runtime přístup
je nový a zde nebyl ověřen ve spuštěné hře.

## Uchycení a uložené předměty

Uchycení zachovává rastr 0.5 m s offsetem 0.25 m, orientaci podle montážní roviny APC
a distančníky 120 mm. Ověření uchycení na skutečné plné stěně zůstává herním testem.
Prefab ID kitu i skříně zůstávají stejné. Starší dokončený stavební stav 2 se při
načtení převede na stav 1; stav 1 zůstává dokončenou skříní. Starý stav 0 nově
zobrazuje rám. Dříve spotřebované kabely se při migraci automaticky nevracejí.
Barva a otevření používají nativní síťový a ukládací mechanismus.

## Ověření

Prošla kompilace proti dodané herní DLL a Unity referencím, kontrola vloženého
modelu, rozsahů indexů, rozměrů všech částí, normálů a orientace trojúhelníků.
Ikony jsou tři různé PNG 256 × 256 a jsou vložené přímo v DLL. Prošel výpočet
84 případů montážního rastru a integrita ZIPu.

**0.6.0 zde nebyla spuštěna ve Stationeers.** Správnost načtení nativních UV,
světla, barvení, F1, montáže a načítání uložené skříně musí potvrdit test ve hře:

1. Ve F1 se pro konstrukci zobrazí rám a hotová skříň, ne Locker.
2. Z nového kitu se položí pouze rám, bez plných panelů a dvířek.
3. Wrench + 2 plechy přidají celou skříň a funkční kryt.
4. Otevřený vnitřek zůstává světlý; baterka neukazuje černé převrácené plochy.
5. Sprej mění plášť a dvířka; vnitřek a výstražný znak zachovávají barvu.
6. Uložení a načtení zachová stav, barvu a otevření.

Pokud kit zmizí nebo materiály selžou, pošli `BepInEx/LogOutput.log`.
Důležité řádky: `0.6.0 loaded`, `APC painted panel UV anchor`,
`Native APC panel textures retained`, `Native APC texture mapping ready`,
`Registration verified` nebo `Prefab setup failed`.

## Zdrojový projekt

Windows s .NET SDK 8+:

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

`blender -b --python Tools/create_simple_cabinet.py` vytvoří model, GLB, vložená
mesh data i ikony. `python Tools/validate_paint_masks.py` ověří geometrii a ikony.
Herní balíček obsahuje About.xml a jedinou DLL se všemi vlastními vizuálními daty.
