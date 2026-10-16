# Modular Switchboards — základní skříň, návrh modelu 0.1

Menší nástěnná skříň: **400 × 500 × 180 mm** (šířka × výška × hloubka,
bez pantů a madla). **Dvě DIN lišty**, každá s prostorem pro 12 pozic po 18 mm.
Pro první umístění je zapotřebí **1 Kit (Switchboard)**.

## Soubory

- `SwitchboardCabinet.blend`: upravitelný projekt Blender 4.3.2, materiály,
  oddělené části a animace dvířek.
- `SwitchboardCabinet_Stage0.glb`: skříň a dvířka.
- `SwitchboardCabinet_Stage1.glb`: skříň + montážní deska + dvě DIN lišty.
- `SwitchboardCabinet_Stage2.glb`: kompletní základ s kabelovými žlaby a přípravou kabeláže.
- `SwitchboardCabinet-open.png`, `SwitchboardCabinet-closed.png`: renderované náhledy.
- `create_cabinet.py`: skript pro opakované vytvoření modelu, exportů a náhledů.
- `model-info.json`: rozměry a technické údaje modelu.

GLB exporty jsou kumulativní varianty jedné skříně; ve hře je nevkládej na sebe.
Pro Unity prefab je vhodné použít jeden model s oddělenými skupinami odpovídajícími
kolekcím `Stage_0_Housing`, `Stage_1_Mounting`, `Stage_2_Wiring` v Blenderu.
Postupné zobrazování částí teprve nastavíme při integraci do hry.

## Montáž ve hře — zachovaný návrh

1. 1 kit: umístění základní skříně.
2. Wrench + 2 Iron Sheets: montáž desky a lišt.
3. Screwdriver + 2 Cable Coil: kabelové žlaby a příprava kabeláže.

Kit se podle verze modu 0.2.1 vyrábí v Electronics Printeru:
**10 Copper + 10 Iron + 10 Electrum** za jeden kus.
Tento balíček modelů výrobní ani stavební recept nemění.

## Souřadnice a dvířka

Blender používá metry, +Z nahoru, přední stranu -Y. Root je uprostřed zadní
montážní plochy; zadní hrana skříně je Y=0 a skříň vystupuje do prostoru -Y.
GLB používá standardní převod glTF na +Y nahoru. Při importu do Unity je potřeba
ověřit orientaci vůči hernímu uchycení na stěnu a nastavit kolize i blueprint.

`Door_Hinge_PIVOT` je skutečný levý pant. Animace: snímek 1 zavřeno, snímek 30
otevřeno o 110 stupňů. Animace v Blenderu je příprava pro Unity; sama o sobě
nezajišťuje klikání na dvířka ve Stationeers. Výchozí poloha exportů je zavřená.
Náhled otevřené skříně zobrazuje finální třetí stavební fázi.

Materiály jsou jednoduché PBR barvy, bez externích textur. Tmavé okénko je
neprůhledný tónovaný panel pro tento první návrh. Unity materiály budeme při
integraci převádět na shader používaný hrou.

## Stav dodávky

Toto je skutečný model a Blender projekt, **nikoli nová herní verze modu**.
V testovacím modu 0.2.1 je stále dočasná herní skříňka. K použití těchto modelů
ještě potřebujeme Unity prefab, materiály, collidery, nastavení stavebních fází,
herní interakci dvířek a asset bundle kompatibilní s hrou.

Jističe, vypínače a měřáky nejsou součástí modelu. Lišty zůstávají volné pro
pozdější osazování. Funkční propojení se současnou elektrickou sítí přidáme později.
