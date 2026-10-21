# Modular Switchboards 0.13.47

LED opět používá přímé přepínání zelené čočky podle 0.13.41, kde uživatel potvrdil funkční svit. Zapnutá čočka má stejné barvy a emisi jako tehdy; zhasnutá si ponechává schválenou tmavě zelenou. Jeden ovladač na skutečném modulu si při vytvoření najde vlastní čočku a vlastníka, vytvoří svůj materiál a nastavuje barvu i emisi na materiálu i obou úrovních vykreslovacích bloků. Původní pomocný ovladač v podobjektu a přepínání polí materiálů jsou odstraněné. Stav „Powered“ se přímo promítá do čočky i světla.

K funkční emisi z 0.13.41 přibylo skutečné malé světlo: zelený Unity Light před čočkou, dosah nejvýše 12 cm, jas podle 1 % původní herní LED. Přebírají se její nastavení a případný originální flare; neklonuje se další napájené zařízení se svým ovladačem. Pokud původní parametry nelze najít, zůstane funkční malé lokální světlo. Světlo se vykresluje na pixelech, aby osvětlilo i velkou plochu dveří, a nemá stíny. OFF vypíná emisi, světlo i flare; stavební náhled nikdy nesvítí.

Ověřeno produkčním sestavením bez chyb / varování a 93 kontrolami skutečné třídy DoorLedView: vazba na správný objekt i při chybných referencích prefabu, zelená OFF/ON, jas a emise, zapnutí/vypnutí skutečného světla, oddělené materiály více LED, později přidané světlo, úklid a stavební náhled. Test používá náhrady Unity API; skutečný vzhled, odlesk a osvětlení vyžadují herní ověření.


Oprava propojení bridge → Output 1 / Output 2 při hlášce „The route would intersect its own contact lead“. Hledání trasy nyní rezervuje vlastní přívody obou svorek, naváže na směr výstupu z přívodu a ke koncovému přívodu dorazí z odpovídající strany. Používá se stejný postup pro bridge i ostatní moduly; elektricky zůstává bridge obousměrný. Kontrola skutečného křížení se nevypíná.

Nový regresní test nejprve chybu reprodukoval v předchozím generátoru. Nyní prochází všech 72 kombinací: 18 pozic bridge × oba výstupy × prázdné okolí / sousední již zapojený bridge. Kontroluje se vlastní křížení, geometrie i průchod reálné trasy ukládáním a síťovým načtením. Dále prošlo kompletní zapojení 9 LED / 18 dveřních vodičů a stávající kontroly modulů, obvodů a ukládání. Sestavení bez chyb a varování; skutečný herní test je stále potřeba.


Obě bridge svorky jsou otočené o 180° oproti 0.13.44. Vstupy pro běžné vodiče míří do prostoru desky / dveří; pružný modrý kabel míří k pantu. Modrý kabel má opět původní plynulý oblouk bez vystupujícího zalomeného vedení. Kostka na desce je posunutá o 6 mm dovnitř, aby přívod i oblouk zůstaly před vnitřní stěnou skříně.

Krajní koridor z 0.13.44 byl pod boční stěnou skříně a schovával svislou část červeného vodiče. Byl odstraněný: trasy opět používají původní vnitřní hranice a přívod bridge ústí do mezery u zkrácené lišty. Zaměřovací body odpovídají novému natočení šroubků. Červené a modré přívody mají protilehlé otvory.

Šroubky hlavního IN/OUT zůstávají na straně kabelových vstupů. DIN lišty mají 7 pozic na řadu, zkrácené jen u pantu; protější konec a souřadnice ostatních modulů jsou zachované. Starší modul v odříznuté pozici se nemaže; přemísti jej ručně.

LED si ponechává opravu z 0.13.44: vlastní kulatá čočka, vlastní zelený materiál pro vypnutý i zapnutý stav, zelená emise pouze při zapnutí. Nepoužívá nativní atlasový materiál, který způsoboval béžovou barvu. Z herní LED se přebírají jen drobné světelné efekty. Světlo má 1 % původní intenzity a nejvýše 12 cm dosahu. Skutečný vzhled a svit je nutné ověřit ve hře.

## Použití

Kit Switchboards Doors Module používá model Logic Kitu. Electronics Printer: 2 g Iron + 1 g Copper za kit. Jeden kit staví jednu zelenou LED nebo jeden samostatný obousměrný bridge. LED má 3×3 pozice na vnější straně dokončených dveří. Bridge má 18 pozic podél pantu, montuje se při otevřené skříni bez vnitřního krytu. Každý je samostatný průchod, nikoli společná sběrnice; oba konce jsou rovnocenné.

Cable Coilem klikni na dva kontakty; pravé tlačítko ruší výběr. Wire Cutters odstraní vodič. LED má IN nahoře a volitelný průchozí OUT dole, bez fyzických nápisů. Svítí při napětí na IN i bez zapojeného OUT. Demontáž Hand Drillem po odstranění připojených vodičů vrací jeden kit.

Jističe a pojistkové držáky dovolují dvě odbočky z OUT se společným limitem výkonu. Ostatní svorky modulů i jednotlivé konce bridge přijmou jeden vodič. Přechod mezi deskou a dveřmi vede přes bridge.

## Ověření a ukládání

Produkční sestavení proti herním DLL: bez chyb a varování. 67 889 kontrol bridge / mřížky / geometrie včetně skutečné hranice skříně a rozestupů kabelů při 24 úhlech otevření; všech 18 bridge v obou řadách a směrech, plné zapojení 9 LED / 18 tras. Nově se testují i skutečně vygenerované trasy přes produkční ukládání a síťové načtení. Dalších 12 464 kontrol obvodů / tras / ukládání a stávající testy analyzeru, baterií a jištění prošly. Unity ani běžící hra zde nejsou k dispozici.

Přítomné trasy bridge ze starších verzí se při změně jejich kontaktních bodů přepočítají bez změny zapojení a množství kabelu. Pro načtení původních tras z 0.13.44 jsou přijaty i jejich krajní body, které by stará kontrola hranic odmítla. Pokud přepočet nelze dokončit, zachová se původní zapojení a do logu se zapíše požadavek na ruční přepojení.

Test ZIP obsahuje hotový mod. Source ZIP obsahuje zdrojové soubory bez přeložené DLL. Host a klienti musí mít stejnou verzi. Záloha 0.13.40 zůstává nedotčená. Pro návrat ke starší verzi použij také odpovídající zálohu savu.

Source ZIP vynechává regenerovatelné pile-input.json a velké mezisoubory Art/ModuleKit/model.json, Art/CoverKit/model.json + source.json a Art/LabelKit/model.json. Nástroje jsou v Tools.
