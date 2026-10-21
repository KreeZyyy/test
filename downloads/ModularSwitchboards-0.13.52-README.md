# Modular Switchboards 0.13.52

**0.13.51 zůstává záloha.** Nová verze přidává **Door Cable Analyzer** do stávajícího kitu **Switchboards Doors Module**.

## Dveřní analyzer

Přední panel je zapuštěný do dvířek. Zachovává celý původní panel DIN analyzeru: zelenou plochu, původní rámeček a blesk. Nový poměr stran je kompaktnější, 72 × 60 mm, takže samotná zelená plocha je téměř čtvercová. Přibyl tenký černý montážní lem. Bílé DIN tělo a lištové úchyty zvenku nejsou; malá elektronika a obě svorky jsou zevnitř dveří.

Přebírá se totožná vybraná nativní geometrie: 68 trojúhelníků rámečku/blesku a 6 trojúhelníků zelené plochy, původní materiály, textury, UV a všechny vrcholové kanály. Mění se pouze rozměr panelu v jeho ploše; hloubka reliéfu zůstává zachovaná. Neklonuje se další napájené zařízení ani jeho síťový ovladač.

Zabírá **jednu z devíti pozic** na dveřích a stojí **1 kit**. Pořadí původních variant kitu zůstává zachované; analyzer je přidaný na konec. Recept kitu nadále Electronics Printer: 2 g Iron + 1 g Copper. Demontáž Hand Drillem po odstranění vodičů.

## Zapojení a měření

Zezadu IN nahoře, OUT dole, bez nápisů. Propojení na montážní desku přes jednotlivé obousměrné bridge u pantu, stejně jako LED a TOTAL STOP. Geometrie zadních kontaktů je stejná jako u ostatních dveřních modulů.

Chování je stejné jako u DIN Cable Analyzeru: je průchozí, neslouží jako jistič a nemá vlastní výkonový limit. Při zamíření používá stejný tooltip s **Actual / Required / Potential** a původní herní formátování W/kW. Jde o stejnou logiku výběru sítě a stejné nativní hodnoty, včetně aktuálního odběru dané sítě.

- Input → analyzer → jistič/pojistka → Output: měří Input.
- Input → jistič/pojistka → analyzer → Output: měří příslušný Output.
- Input → analyzer → Output: automaticky měří Output.
- Rozpojení ochrany nepřehazuje automaticky měřenou stranu. Chybějící síť nebo dvě různé výstupní sítě mají stejnou hlášku jako DIN varianta.

LED, TOTAL STOP s ochranným límcem, vedení kabelů i původní DIN analyzer se touto změnou neupravují.

## Ověření

Produkční sestavení proti herním DLL bez chyb a varování. Nově 471 kontrol skutečné geometrie panelu a extrahovaných produkčních metod pro výběr sítě a tooltip: kompletní nativní předek, rozměr a hloubka, téměř čtvercová zelená plocha, dva bridge, Input/Output, rozpojené jističe, nejednoznačné výstupy a shodné výsledky s DIN variantou. 65 kontrol katalogu/vyhledávání včetně „dveřní analyzátor“. Původních 67 889 kontrol bridge a 12 464 kontrol tras/obvodů/ukládání prošlo, stejně jako scénáře baterií a ochrany.

Ikona je přibalená a vizuálně zkontrolovaná. Unity ani běžící hra nejsou zde dostupné; ve hře ověř umístění, vzhled nativních materiálů, připojení obou svorek, údaje při zamíření a načtení savu. Host i klienti musí mít stejnou verzi **0.13.52**.

Záložní ZIPy **0.13.51** se nemění. Při návratu použij i odpovídající zálohu savu. Test ZIP obsahuje hotový mod; Source ZIP zdroje a ověřovací nástroje bez přeložené DLL a bez regenerovatelných velkých JSON mezisouborů jako dříve. Ikonu lze znovu vytvořit exportem z Verification/DoorAnalyser do Art/DoorAnalyserFront.json a nástrojem Tools/render_door_icons.py.
