# Modular Switchboards — 0.6.3 test

Prázdná nástěnná skříň, 400 × 500 × 180 mm. Dvě skutečné stavební fáze a vlastní
náhledy rámu a hotové skříně; kit má standardní herní ikonu elektrické stavebnice. DIN lišty, kabeláž a elektrické moduly přijdou později.

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
náhled v `BuildState.Thumbnail`. Hotová skříň má vlastní `Thing.Thumbnail`; zděděné barevné náhledy Lockeru jsou
odstraněné. Kit má původní ikonku i model elektrické stavebnice (Logic Switch),
ne obrázek hotové skříně. Vlastní obrázky F1 pocházejí z offline modelu; nativní
výstražný znak se doplňuje až ve hře a na těchto obrázcích není.

## Změny 0.6.3

Sprej nově barví celou skříň včetně vnitřních boků, horní a spodní stěny a obou
stran dvířek. Pouze samostatná zadní montážní deska zůstává světle šedá. Madlo
a případný výstražný znak mají stále pevné barvy. Odsazení, panty a výroba se nemění.
Hledání znaku APC je stejné jako v 0.6.2 a není potvrzené ve hře.

## Diagnostika znaku z 0.6.2

Dodané `Player.log` potvrdilo `Native APC warning not located`, bez chyby při
čtení textur. 0.6.1 tedy znak nevytvořila, protože ho omezené hledání nenašlo.
0.6.3 prohledává barevné vlastnosti materiálů všech rendererů APC včetně skinned
meshů, všechny vrstvy texturových polí a nativní index materiálu/property blocku.
Respektuje také scale/offset UV příslušné textury.

Toto je rozšířené hledání a diagnostický build; nejde o potvrzenou opravu znaku
na skutečné textuře APC. Pokud se znak znovu nenajde, automaticky uloží původní
náhledy textur, seznam materiálů a geometrii APC do vlastní složky:

`%USERPROFILE%/AppData/LocalLow/Rocketwerkz/Stationeers/ModularSwitchboards/Diagnostics`

Pro další opravu pak stačí tuto složku zazipovat společně s `Player.log`.
Díky skutečným podkladům půjde přesně určit nativní výřez nebo oddělenou geometrii
znaku, pokud jeho vzhled nevzniká v jediné barevné textuře.
Do této složky se zapisuje pouze diagnostika modu; nativní herní soubory se nemění.

## Zachované změny a aktuální stav

- Podle nového zadání je pant při pohledu zepředu vpravo a madlo vlevo; znaménko animace je
  obrácené současně s geometrií. Dveře se otvírají ven. Změna platí pro nově
  načtený model; rotace celého předmětu ve světě se nepřepisuje.
- Zvětšené odsazení hotové skříně vůči nezměněnému montážnímu rámu o 80 mm.
- Kit dostává nativní ikonku stavebnice, skříň není ikonou kitu.
- Ručně vytvořený žlutý trojúhelník a přibližný blesk jsou odstraněné.
  Nový kód hledá žlutočerný trojúhelník v původních texturách použitých na APC,
  ověří, že výřez používají UV jeho modelu, a přebírá původní texturu i materiál.
  Znak na dvířkách má šířku 100 mm a leží dole vlevo. Nejde o ručně překreslený znak.
  Přesný obrys a blesk poskytuje herní textura; poměr stran se zachovává.
- Hledání znaku je nový runtime postup, zde ověřený jen na syntetických testovacích
  obrazcích. Pokud skutečný znak nenajde nebo nelze přečíst GPU texturu, zaloguje
  chybu a znak nevykreslí; náhradní přibližný trojúhelník se nepoužije.

## Materiály a opravy modelu

Předchozí export obracel trojúhelníky i při převodu souřadnic s determinantem +1.
Pořadí vrcholů proto nesouhlasilo s normálami. Opravený export a kontrola všech
1512 trojúhelníků nyní ověřují, že jejich orientace souhlasí s normálami.
To opravuje konkrétní chybu geometrie; výsledné osvětlení je ještě nutné ověřit ve hře.

Nová verze už nenahrazuje herní textury jednobodovými texturami. Ponechává nativní
materiál pro barvení včetně jeho textur a shaderu. Při registraci vyhledá velký
lakovaný trojúhelník na nativním APC a UV našich plechů promítne do malého výřezu
uvnitř tohoto trojúhelníku. Nejde o překopírování celého atlasu na každý plech ani
o reprodukci větracích drážek APC. Normálové mapování používá přepočítané tangenty.
Nativní herní textury nejsou součástí ZIPu a originální APC se neupravuje.

- Celý plášť včetně vnitřních boků a obě strany dvířek používají nativní `CustomColorMapping` a barvu objektu.
- Pouze samostatná zadní montážní deska má pevný světlý herní odstín; výstražný znak žlutou a černou.
- Po nativní změně barvy se znovu nastaví pevné indexy montážní desky a znaku.
- Nastavení světelných sond, stínů, odrazů a index lesku se přebírají z APC.
- Nepřidává se světlo ani umělé svícení povrchu.

Čtení UV podporuje čitelné CPU meshe i GPU vertex/index buffery pro importované
meshe bez Read/Write. Pokud žádný lakovaný panel APC nejde přečíst, registrace
skončí chybou v logu místo použití náhodného výřezu atlasu. Tento runtime přístup
je nový a zde nebyl ověřen ve spuštěné hře.

## Uchycení a uložené předměty

Uchycení zachovává rastr 0.5 m s offsetem 0.25 m, orientaci podle montážní roviny APC
a původní polohu montážního rámu s distančníky 120 mm. Dokončené tělo, vnitřní
deska, dvířka i jejich kolize jsou navíc posunuté o 80 mm dopředu; spojovací
distančníky zachovávají napojení na rám. Ověření uchycení na skutečné plné stěně zůstává herním testem.
Prefab ID kitu i skříně zůstávají stejné. Starší dokončený stavební stav 2 se při
načtení převede na stav 1; stav 1 zůstává dokončenou skříní. Starý stav 0 nově
zobrazuje rám. Dříve spotřebované kabely se při migraci automaticky nevracejí.
Barva a otevření používají nativní síťový a ukládací mechanismus.

## Ověření

Prošla kompilace proti dodané herní DLL a Unity referencím, kontrola vloženého
modelu, rozsahů indexů, rozměrů všech částí, normálů a orientace trojúhelníků.
Dva vlastní náhledy fází jsou PNG 256 × 256 a jsou vložené přímo v DLL. Kit
přebírá nativní ikonku. Test detekce znaku prošel pro čtyři orientace v atlasu a
odmítnutí jednolité žluté plochy; skutečná textura APC v tomto prostředí není. Prošel výpočet
84 případů montážního rastru a integrita ZIPu.

**0.6.3 zde nebyla spuštěna ve Stationeers.** Správnost načtení nativních UV,
světla, barvení, F1, montáže a načítání uložené skříně musí potvrdit test ve hře:

1. Ve F1 se pro konstrukci zobrazí rám a hotová skříň; kit má běžný herní obrázek stavebnice.
2. Z nového kitu se položí pouze rám, bez plných panelů a dvířek.
3. Wrench + 2 plechy přidají celou skříň a funkční kryt.
4. Panty jsou při pohledu zepředu vpravo, madlo vlevo a otevření zleva doprava směřuje ven.
   Dokončená skříň ani její vnitřek neprocházejí plnou stěnou.
5. Nativní znak APC je dole vlevo, špičkou nahoru, s černým obrysem a bleskem.
   Sprej mění plášť i zevnitř a obě strany dvířek; jen zadní montážní deska, madlo a výstražný znak zachovávají barvu.
6. Uložení a načtení zachová stav, barvu a otevření.

Pokud kit zmizí nebo materiály selžou, pošli `BepInEx/LogOutput.log`.
Důležité řádky: `0.6.3 loaded`, `APC painted panel UV anchor`,
`Native APC panel textures retained`, `Native APC texture mapping ready`,
`Native APC warning reused`, `Native APC warning not located`,
`Registration verified` nebo `Prefab setup failed`.

## Zdrojový projekt

Windows s .NET SDK 8+:

```powershell
dotnet build -c Release '-p:GamePath=C:\Program Files (x86)\Steam\steamapps\common\Stationeers' '-p:LaunchPadDirectory=C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins\StationeersLaunchPad'
```

`blender -b --python Tools/create_simple_cabinet.py` vytvoří model, GLB, vložená
mesh data i ikony. `python Tools/validate_paint_masks.py` ověří geometrii a ikony.
Herní balíček obsahuje About.xml a jedinou DLL se všemi vlastními vizuálními daty.
