# ModularSwitchboards – kontrola modelů 0.13.8 / 0.13.9 / 0.13.10

Kontrola 20. 10. 2026. Jde o statickou kontrolu a reprodukci dat, nikoli verdikt antiviru.

## Výsledek
- Všechny tři vydané DLL byly dekompilovány: 111 C# souborů v každé verzi. Po sjednocení čísla verze je kód shodný; žádné další C# soubory.
- V každé DLL ověřeno 25 vložených zdrojů proti zdrojovému projektu, všechny shodné. DLL v každém vydaném test ZIPu je přesně kontrolovaná DLL.
- Načítací kód ModuleKitModel.cs je totožný. Vlastní MKIT formát čte pouze počty, float souřadnice/normály/UV a celočíselné indexy do Unity Mesh. Nejde o spustitelný modelový skript. Načítání atlasu je rovněž stejné.
- Generátor create_module_kit.py se liší pouze rozšířením mapy UV o šedou a zlatou pro nové součástky. Mění se také vstupní geometrie source.json. Uložené soubory model.json jsou mezivýstup pro tvorbu, nejsou načítané runtime modelem.
- Oba Model.meshbin se z podkladů v oddělených pracovních kopiích vygenerovaly byte-for-byte shodně s vydanými daty.
- Geometrie: konečné hodnoty, jednotkové normály, platné indexy, přesná délka bez přidaných dat, kapacita 16bit indexů a umístění v původním kolizním obalu prošly kontrolou. 0.13.8: 26 100 vrcholů / 9 052 trojúhelníků; 0.13.9: 36 030 / 12 362. Atlas je shodný.

## Pozorování uživatele
- 0.13.8: stažení bez hlášené detekce.
- 0.13.9: Defender blokuje ZIP jako Trojan:Script/Ulthar.A!ml.
- 0.13.10: 0.13.8 s pouze novou PNG ikonou z 0.13.9, uživatel potvrdil stažení.

To ukazuje souvislost s kombinací sestavení a změněné geometrie; nedokazuje konkrétní signaturu ani falešný poplach. Nelze z toho určit, který vnitřní soubor Defender klasifikoval. Chyba generování ani odlišné chování načítače nebyly nalezeny. Defender a Unity nejsou v tomto prostředí dostupné. Soubory nebyly přebaleny ani změněny za účelem obcházení detekce.

## SHA-256 původních test ZIPů a DLL

### 0.13.8

ZIP: `d1f1b307b9ec7cd426550e87ca7887ff8134fe7a1c6875396feb05f89686b278`

DLL: `6feb260440faccdb73cd7e9c2f49563df4c7daac5d186ced743a1446b0648c64`

### 0.13.9

ZIP: `ed171167f6c403a9ca5d12f7c59c3002deb4bd7b70357e665efc7f4f7d1705a9`

DLL: `88c57b803c8f82237573f2267ffdd68a13478c451bb9a34dcc68b64bb08ac6cf`

### 0.13.10

ZIP: `3ebe49e71abebbbe8461fe6823f7c72d419e3f56e951ce2e6c5019ce8906964c`

DLL: `d18be8577daaa9582f4cf36eb516c3cc3699e67a8634140d35d2f5328c562ca2`

## Další krok
Předat nezměněnou blokovanou verzi 0.13.9 Microsoft Security Intelligence k posouzení. Formulář: https://www.microsoft.com/en-us/wdsi/filesubmission . Zvolit Software developer, Defender Antivirus (Windows 10), a požadavek na prověření možné nesprávné detekce. Přiložit původní ZIP; pokud je vyžádána přímo DLL, je její hash výše. Nesdělovat neznámou verzi definic jako ověřený údaj.

Odeslání NEPROBĚHLO: dostupné webové rozhraní zde umí číst stránky, neumí dokončit přihlášení a nahrání vzorku do interaktivního formuláře Microsoftu. Anglický text je připraven v Microsoft-submission.txt. Aktuální použitelná verze zůstává 0.13.10; matnější interiér je samostatná dosud nevydaná změna.
