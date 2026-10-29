# Modular Switchboards 1.0.30

Autor: KreeZy

## Stažení

- [Testovací mod](ModularSwitchboards-1.0.30-test.zip)
- [Zdrojáky](ModularSwitchboards-1.0.30-source.zip)

Po výměně modu restartuj hru. V multiplayeru musí mít všichni stejnou verzi.

## DIN Smart Output Module

- Nově postavený Output zabírá **2 DIN pozice**, stojí 1 Smart kit a přisedá do souvislé řady rozšíření nalevo od Core.
- Používá původní LED rámeček, podklad a číslice Core. Nevytváří další IC housing ani síťové zařízení.
- Dole je původní šroubek IC Housingu: 83 vrcholů, 40 trojúhelníků, původní UV a materiál. Má vlastní hitbox a je zapuštěný do čela.
- Šroubovákem na hlavičce přepínáš mezi volnými adresami d0–d5. Kabinet musí být otevřený a vnitřní kryt sejmutý. Obsazené adresy se přeskočí; změna nejdříve vypne příkaz On.
- Displej adresy svítí s napájeným/zapnutým Core i při příkazu Output OFF. Horní zelená dioda znamená skutečně napájený OUT.
- **Žádný IN ani DATA.** Řízení a napájení bere z Core. Jediný spodní OUT lze připojit pouze na A1 klasického DIN Contactoru.
- Silovou větev zapoj přes samostatně jištěné IN/OUT klasického stykače. A1 lze nadále ovládat obyčejným tlačítkem nebo vypínačem.
- Core OFF, ztráta napájení/sběrnice nebo neplatná adresa OUT odpojí. Adresa zůstává uložená. Příkaz On se ukládá a při návratu Core může výstup opět zapnout; nejde o bezpečnostní blokování restartu.
- Nativní odběr ovládání je 5 W při příkazu On. Samostatný odběr klasické cívky se zatím nemodeluje.

```ic10
loop:
s d0 On 1
sleep 5
s d0 On 0
sleep 5
j loop
```

db zůstává Core. Až šest adresovaných Outputů na Core; NET moduly adresy nezabírají.

## Starší uložené světy

Při načtení se jednomístné Outputy rozšíří na dvě pozice, pokud má jejich souvislá řada rozšíření dost místa. Core a vnitřní NET zůstanou na místě; vnější NET/Output moduly stejné řady se posunou ven. Adresy a vodiče zůstávají zachované, trasy vodičů se přepočítají.

Cizí moduly se nepřesouvají ani nemažou. Záměrné mezery ve sběrnici se nespojují. Pokud chybí místo, starý kus zůstane dočasně úzký s vysvětlením v tooltipu/logu. Uvolni pozici na konci řady a ulož/načti, nebo jej přestav na volné dvě pozice.

Malá lišta má 7 pozic: Core (4) + Output (2) + jeden NET (1) ji zaplní. Druhý NET potřebuje větší kabinet/lištu.

Staré IN, DATA a přímé vodiče Outputu do silové větve se podle migrace z 1.0.29 vracejí jako kabel; platný OUT → A1 zůstává.

## Reference a ověření

Reference IC Housingu už byla získána a je ve zdrojácích; automatický export housingu byl odstraněn. Mod nevyžaduje JSON v AppData.

Release build prošel bez varování a chyb. Prošly místní kontroly geometrie, migrace Small/Medium, adres, obsazenosti, připojení klienta a izolace materiálů; nativní kontrakty byly ověřeny proti herním knihovnám. Nový vzhled, automatická migrace skutečného světa a multiplayer vyžadují ověření přímo ve hře.

Podrobná dokumentace je také uvnitř obou ZIPů. StationeersLua zůstává volitelná.
