# Modular Switchboards 0.13.109

Stavový displej má pevnou velikost textu: ERR0 až ERR999 ukazují číslo řádku, od řádku 1000 zobrazuje vždy ERR---. Přesné číslo a detail chyby dál pocházejí z původního čipu/Lua runtime a zůstávají v nápovědě. Zkracuje se pouze text na displeji; chyba ani síťově přenášený řádek se neupravují. Automatické zmenšování z místní 0.13.108 bylo odstraněno. RUN, IDLE a zhasnutí bez napájení beze změny. Zahrnuje také opravu duplicitní nápovědy z 0.13.107.

Ověření: Release build bez chyb a varování; 20 stavových kontrol včetně hranice 999/1000, řádku 4398, int.MaxValue a zachování plného řádku z Lua hlášení. Vzhled ve hře zbývá potvrdit.

## Předchozí návrhy a verze

# Modular Switchboards 0.13.108

Dlouhé stavové hlášení (například ERR4398) se nyní automaticky vejde do nativního displeje. Šířka se počítá ze skutečných nativních glyphů a rozestupů. Při překročení šířky plochy se pouze text rovnoměrně zmenší a znovu vystředí s okrajem jednoho pixelu; rámeček ani tělo modulu se nemění. RUN a kratší chyby si zachovávají původní velikost. Po návratu ke krátkému textu se původní měřítko obnoví; opakovaná aktualizace nezpůsobuje postupné zmenšování. Číslo řádku se nekrátí.

Ověření: Release build bez chyb a varování; 19 kontrol skutečné produkční metody přes fixture transformů ověřuje dlouhá čísla včetně ERR4398, vystředění, rovnoměrné měřítko, stabilitu při 100 opakováních a obnovení RUN/ERR1/prázdného displeje. Živé vykreslení ve hře zbývá potvrdit. Obsahuje také opravu duplicitního tooltipu z 0.13.107.

## Předchozí verze

# Modular Switchboards 0.13.107

Oprava duplicitního řádku chyby v nápovědě osazeného čipu Smart modulu. Po sestavení nápovědy slotu se ponechá jediný výskyt přesného hlášení nativního čipu, a to i mezi ExtendedMessage a stavovou zprávou. Jiné informace a upozornění se zachovávají; ostatní zařízení se nemění. Stavový displej RUN/ERR zůstává. Release build a 9 kontrol formátovaných zpráv prošly; potvrzení ve hře zbývá.

## Předchozí verze

# Modular Switchboards 0.13.106

Oprava ztráty natažených vnitřních kabelů při načtení Medium a Medium Reverse. Zápis ukládal trasy správně, ale kontrola Load používala pevné rozměry Small: X ±0,18 m (±0,20 m s Bridge) a Y ±0,24 m. Platné větší trasy se proto při načítání vyřadily.

Validace nyní vychází z CabinetShape.Width/Height konkrétního prefabu: Medium a Medium Reverse přijímají trasy do X ±0,38 m (±0,40 m s Bridge) a Y ±0,49 m. Small a Small Reverse mají stejné limity jako dříve. Zachované jsou kontroly konečných souřadnic, hloubky, identit kontaktů, verze trasy, množství kabelu, počtu bodů a spojitelnosti. Uložení i síťové načtení pro připojení do hry používají stejnou opravenou validaci. Schéma save se nemění, není potřeba přepočet již uložených tras.

Kabely lze znovu načíst z původního save, ve kterém jsou jejich záznamy stále přítomné. Pokud se svět po zahození kabelů znovu uložil, chybějící záznamy tato oprava nevytvoří.

Ověření: 62 kontrol ukládání Small/Small Reverse/Medium/Medium Reverse přes XML a binární síťový přenos, přesné souřadnice, koncové kontakty včetně Output 3 a Bridge, barva, fan slot, verze a odmítnutí vadných dat. Celý stávající wiring balík prošel včetně routování všech variant, migrace a napájení. Release build bez chyb a varování. Ve hře je třeba zkontrolovat načtení původního Medium save. Náhledy, autor KreeZy a volitelná Lua kompatibilita z 0.13.105 zůstávají.

## Nabídka IC editoru

Podle dalšího herního screenshotu se dva řádky objevují i v 0.13.105. Kontrola je proto nyní také přímo před zobrazením hotového dropdownu, nezávisle na tom, která cesta seznam sestavila. Zahrnuje obaly stejného základního modulu a vyřazuje neaktivní nebo odpojené instance bez hostitelské skříně. Drží dvojice popisek/čip spolu a po přestavbě Lua seznamu obnovuje původní výběr pro Edit/Import/Export. Dva různé platné moduly se stejným názvem stále zůstávají dvě položky; neslučují se podle názvu.

Pokud by se duplicita opakovala, soubor LocalLow/.../ModularSwitchboards/Diagnostics/SmartEditor-devices.txt obsahuje skutečné typy včetně sestavení, ID, skříně a počty řádků před/po kontrole. Přesnou příčinu dvou uživatelových položek bez těchto runtime údajů zatím neznáme. 21 kontrol editoru pokrývá obaly, neaktivní instance, finální položky, přiřazení názvů, obnovení výběru a diagnostiku. Volitelné Lua napojení má 23 ověřených kontrol včetně kontraktu původní DLL.

## Stavový displej místo diody

Aktuální požadavek nahrazuje programovatelný LED text stavovým displejem housingu. Zeleně RUN, oranžově ERR a číslo chybného řádku podle čipu (například ERR4). Chybí-li údaj o řádku, jen ERR; bez programu IDLE a bez napájení či při vypnutí displej zhasne. Detail chyby zůstává v nápovědě. Pro Lua se číslo řádku čte z hlášení původního runtime, pokud je dostupné. Stav a řádek se přenášejí také klientům a při připojení do hry.

Samostatná malá dioda byla odstraněna. Setting zůstává hodnotou housingu; neurčuje zobrazený text. Mode a Color už nejsou programovatelné LED vstupy Smart modulu. Nativní LED renderer slouží pouze ke kreslení stavových znaků. Technická dědičnost LogicDisplay zůstává kvůli existujícím save a vykreslování; nejde o převod uložených entit na jiný prefab. Přidaných 15 kontrol ověřuje formát textu, stav a parsování chyb Lua; živé vykreslení ve hře zbývá ověřit.

## Smart jako housing s integrovanou LED

Smart zůstává jediným zařízením a jediným držákem čipu. Podle nativního CircuitHousing má nyní také IMemoryReadable/IMemoryWritable: ReadMemory, WriteMemory, ClearMemory a GetStackSize pracují přímo s pamětí vloženého čipu. Bez čipu vrací velikost 0 a paměťové operace vyvolají chybu stejně jako housing. LineNumber bez čipu je -1; slotové čtení čísla řádku i výběr sítě základní jednotky odpovídají housing kontraktu. Základní vazba se jmenuje HOUSING. Fyzické voliče d0–d5 nepřibývají.

Kvůli nativnímu vykreslování LED a kompatibilitě existujících uložených modulů zůstává implementačním předkem LogicDisplay. Nejde o nahrazení třídy ani přidání druhého samostatného zařízení. V předchozím návrhu řídily Mode 10 a Setting STR("PACEP") text displeje. Aktuální návrh výše je nahrazuje stavem housingu; Setting nikdy nepřejmenovává zařízení. Sprej se nyní předává nativnímu ISprayer i přes přítomnost LED Color stavu; barva těla a barva znaků zůstávají samostatné. Tím se nemění všechny materiály patice a kontaktů na barvu těla.

Odstranění Smart modulu nyní vrací a odpojuje jeho vnitřní kabely stejně jako u jističů. Deregistrace i zánik uvolňují obsazený kontakt; opakované odpojení nevrací kabel dvakrát. Nápověda zapojování má vlastní nadpis Switchboard wiring.

Ověření navíc: 20 kontrol demontáže a kapacity kontaktů, 8 kontrol směrování spreje a zachování LED hodnot, 11 kontrol paměťového kontraktu housingu. Testy používají izolované fixture; vzhled, sprej, IC/Lua a načtení světa je nutné potvrdit v běžící hře.

## Předchozí verze

# Modular Switchboards 0.13.105

Autor: **KreeZy**. Mod list má vlastní obrázky About/Preview.png (1600 × 900) a About/thumb.png (640 × 360), aktuální popis, autora, verzi a tagy. Hra přímo načítá About/Preview.png. Obrázky jsou vlastní rendery našich modelů, nikoli převzaté náhledy jiného modu. Verze v registraci modu, sestavení i About.xml je sjednocena na 0.13.105.

## Volitelná kompatibilita se StationeersLua

Běžný IC10 funguje bez StationeersLua. Není přidaná žádná povinná závislost, reference sestavení ani cizí DLL v balíčku. Adaptér se zapne při nalezení podporovaného běhového prostředí. Pro Lua je nutný Integrated Circuit (Lua) a samotný StationeersLua; IC10 assembler a Lua nejsou zaměnitelné jazyky.

Smart Module spouští Lua přes původní LuaChipRuntimeManager, nikoli jako IC10. Dodržuje serverovou autoritu, napájení, On/Off, pauzu a probíhající ukládání. Oznamuje změny aktivity a při vyjmutí čipu nebo zániku modulu žádá původní Lua runtime o snapshot a ukončení; vlastní serializaci Lua čipu nadále zajišťuje StationeersLua. Zelená dioda používá stav Lua VM místo IC10 instruction pointeru, oranžová ukazuje Lua chybu a nápověda přebírá její detail.

Čip má přes svůj nativní ICircuitHolder přístup k vlastnímu LED displeji jako základní jednotce a k datové větvi na IN. Ukázka čítače je v Examples/DinSmartModule.lua. Fyzické voliče d0–d5 nejsou přidané; jiné přístroje používejte přes ReferenceId nebo batch v připojené větvi.

Lua mod si přestavuje seznam v IC motherboard editoru vlastní cestou. Kontrola duplicit je proto navíc připojená k jeho závěrečnému řazení seznamu: stejný Smart Module se odstraní současně z položek i popisků, různé moduly stejného názvu se zachovají. Import/export a zdrojový editor zůstávají na původní implementaci StationeersLua. Zachovaná je i oprava základního seznamu a registrace ze 0.13.104.

Adaptér byl ověřen proti nahrané StationeersLua.dll 1.0 (SHA-256 b5244ed772c021c07ea5d5124a4cbf5b934f3e033e282d9fb3fecbfa9b07c214). Používá existující runtime API reflexí; u jiné verze s nekompatibilním API se Lua nespustí a zobrazí se informace o chybějícím/nepodporovaném prostředí. Standardní IC10 tím není zablokován.

Ověření: 23 kontrol volitelného adaptéru a kontraktu skutečné DLL, včetně nepřítomnosti Lua reference v produkční sestavě, a 13 kontrol identity editoru včetně dvojic popisek/čip v Lua seznamu. Release build bez chyb a varování. Živé ověření Lua programu, napájení, save/load, síťových klientů, IC editoru a náhledu v mod listu je ještě nutné. Herní runtime zde není k dispozici.

## Předchozí verze

# Modular Switchboards 0.13.104

Oprava dvojího zobrazení stejného DIN Smart Modulu v nabídce IC editoru. Nativní Computer.DeviceList předává editoru kopii DataDeviceList bez deduplikace. Pro Smart Module nyní nabídka zachová jednu položku pro jednu instanci/síťové ReferenceId a vynechá kurzor, šablony bez ID a odstraňované instance. Dva různé moduly se stejným názvem se neslučují. Ostatní nativní zařízení se nemění.

Při aktualizaci vazby Smart Modulu se také odstraní opakované registrace přesně stejné instance v jeho aktuální CableNetwork.DeviceList. Jedna registrace zůstane, mapa kabelů se zachová, odvozené datové/napájecí seznamy se zneplatní a počítače dostanou nativní upozornění na změnu. Datové sítě se nepropojují a výběr větve se nemění. Přesná cesta vzniku duplicity v uživatelově běžícím světě není z obrázku určitelná; oprava pokrývá opakovanou registraci i opakovaný záznam ve výsledném datovém seznamu.

Ověření: 9 kontrol identity v nabídce a 33 kontrol výběru a registrace sítě včetně opravy duplicity a zachování registrace kabelu. Release build bez chyb a varování. Oprava zvuků a zelená/oranžová dioda z 0.13.103 zůstávají. Ve hře je třeba ověřit nabídku s jedním modulem a se dvěma různými moduly stejného názvu.

## Předchozí verze

# Modular Switchboards 0.13.103

Doplněná oprava opakovaných zvukových výjimek po vypnutí a zapnutí napájení. Uživatel potvrdil pád i s 0.13.102: přepojení při tvorbě prefabu nestačilo. DIN Smart Module nyní před base.Awake vytvoří vlastní kopie zvukových událostí a nastaví jejich vlastníka přímo na vznikající instanci. Zachová nativní zvukové klipy, kanály, podmínky, podmínky stavebních stavů a sdílené reference uvnitř jedné instance. Zvukové události ani jejich seznamy se nesdílejí mezi herními instancemi. Zvuky nejsou vypnuté ani globálně potlačené. Ještě je nutné ověřit skutečné přepnutí napájení ve hře.

Nad paticí IC10 je malá stavová dioda. Zelená znamená zapnutý a napájený modul s běžícím programem, včetně sleep/yield. Oranžová znamená chybu kompilace nebo běhu. Červená se nepoužívá. Bez napájení, při vypnutí, bez čipu, bez programu, po dokončení nebo při pauze dioda nesvítí. Nápověda modulu ukazuje stav a nativní detail chyby včetně řádku z IC10. Stav diody se přenáší serverem včetně připojení do běžící hry; nový save formát není potřeba. Multiplayer musí používat stejnou verzi modu.

Ověření: 24 kontrol zvukových referencí včetně dvou nezávislých herních instancí a cyklu napájení, 10 kontrol inicializace Smart Modulu a 259 kontrol stavů diody. Release build bez chyb a varování. Původní rozměry, funkce LED displeje/db, IC10 a datová větev se nemění; přidaná stavová dioda má vlastní materiál a nezávisí na barvě displeje. Herní ověření zvukové opravy, nové diody a síťového přenosu je stále nutné.

## Předchozí verze

# Modular Switchboards 0.13.102

Oprava zvukových referencí při nahrazení původního komponentu prefabu. Interakce už mířily na nový modul, ale jejich GameAudioEvent.Parent mohl dál odkazovat na odstraněný původní komponent. Nativní GameAudioEvent.IsValid pak při změně stavu četl neplatného vlastníka, což odpovídá nahlášenému zásobníku AudioManager.LateUpdate / PlayScheduledSounds.

Před odstraněním původního komponentu se nyní přepojí vlastník zvukových událostí v AudioEvents, v interakcích a v interakcích stavebních stavů. Zvuky, jejich podmínky i nativní přehrávání zůstávají zachované. Oprava se použije při přípravě všech nahrazovaných prefabů, včetně DIN Smart Modulu. Geometrie a datová logika se nemění.

Ověření: 14 kontrol reprodukujících odstraněného vlastníka, přepojení všech tří cest, zachování sdílených referencí, živých podmínek a zvuku a oddělení původního prefabu. Dalších 10 kontrol inicializace Smart Modulu. Release build bez chyb a varování. Ještě je nutné ověřit načtení světa a změny stavu ve hře.

## Předchozí verze

# Modular Switchboards 0.13.101

Patice IC10 navazuje přímo na čelo DIN Smart Modulu: lem je v rovině čelní stěny místo původního přesahu 0,5 mm. Otvor respektuje osmiboký obrys patice; čtyři rohy doplňuje původní tmavá čelní plocha, takže kolem patice nezůstává obdélníková mezera. Vnitřní stěny a dno kapsy navazují na stejný otvor. Model patice, čip i nativní slot zůstávají ve společné transformaci.

Displej, IC10 a datová logika se nemění. Geometrické kontroly na původních exportech Air/LED a procedurálním těle zahrnují rovinu lemu, návaznost všech čtyř rohů, průchod kapsou, UV a nedegenerované trojúhelníky. Skutečné usazení je třeba ověřit ve hře.

## Předchozí úprava 0.13.100

Čelo DIN Smart Modulu: vpravo zůstává pouze originální patice IC10 z Air Conditioneru, bez přenesených bílých a šedých panelů. Výběr podle změřeného originálního meshe zachovává 166 celých trojúhelníků a původní UV/materiálové role. Patice je zvětšená na přibližně 46 × 49,5 mm.

Postup odpovídá Battery Backup: nejprve model patice a kapsa v těle, potom nativní slot. Model, slot a čip mají jednu společnou transformaci. Rámeček patice je jen 0,5 mm před čelem; její zadní část leží v kapse s bočními stěnami a dnem. Hloubka kapsy zohledňuje zadní mez původního čipu. Žádné okolní části Air Conditioneru se nepřenášejí.

LED displej je o 2,7 mm zapuštěnější. Pixelová plocha zůstává před čelem, rámeček vystupuje přibližně o 3,8 mm. Odstraněno je také všech 10 trojúhelníků původního šedého uchycení tlačítka nad LED. Horní svorka IN zůstává. Funkce displeje, db, IC10, napájení a výběr datové větve jsou beze změny; nativní vykreslování textu už potvrdil herní screenshot verze 0.13.99. Oprava startovací inicializace z 0.13.99 zůstává zachovaná.

Ověření: 332 geometrických kontrol na originálních exportech Air/LED a skutečném těle DIN: přesný výběr patice, nezměněná UV, vyloučení panelů, odstranění držáku tlačítka, odstupy, kapsa průchozí zepředu, dno, orientace stěn a zachování levé části čela. Release build bez chyb a varování. Nové rozměry a usazení čipu je třeba ověřit ve hře. Úplné herní exporty ani dekompilované zdroje nejsou součástí zdrojového ZIPu; původní materiály a slot se načítají ze hry.

## Oprava startu 0.13.99

Oprava pádu při startu verze 0.13.98: výchozí stav DIN Smart Modulu se nastavoval přes živý Interactable.State setter ještě před Unity Awake. Nativní LED callback přečetl neinicializovanou cache InteractOnOff, vyvolal NullReferenceException a zrušil celou přípravu prefabů; následující chyby registrace a receptů byly důsledkem tohoto prvního pádu.

Výchozí ON=1 a Powered=0 se teď zapisují přímo do serializovaného pole _state, bez spouštění LED, zvukových či síťových callbacků. Pak se naplní nativní interakční cache přes CacheStates(true). Ze sestaveného klonu jsou odstraněny staré animátory a odkazy na rodičovské interakce původního ovladače. Za běhu dál fungují nativní callbacky, zapínání i vykreslování.

Regresní test SmartPrefabState reprodukuje původní chybu před Awake a ověřuje deset případů včetně tiché přípravy, cache, oddělení původního prefabu a zachovaných běhových callbacků. Release build: 0 chyb, 0 varování. Ostatní funkce DIN Smart Modulu zůstávají jako v 0.13.98: čtyři DIN místa, jediný IN pro proud/data, vlastní nativní LED přes db a IC10. Ověření skutečného startu a zobrazení ve hře je stále nutné.

## Funkce 0.13.98

DIN Smart Module zabírá čtyři DIN pozice a používá 4 Kit (Switchboard Modules). Vlevo má originální LED Display (Small), vpravo originální usazení IC10 z Air Conditioneru. Páčka, její uchycení a horní stavový indikátor zůstávají odstraněné.

Modul má **jediný horní IN pro proud i data**. Zapoj ho jako spotřebič do odbočky: například jistič OUT -> Output 2 a ze stejného jističe OUT -> Smart IN. Počítač připojený k Output 2 ho v IC motherboardu najde jako **DIN Smart Module**. Před ochranou používá síť Input; za ochranou síť odpovídajícího externího Outputu. Samostatný vstup za jističem bez vedení na externí Output nemá z čeho určit externí datovou síť. Větev vedoucí na různé datové sítě se odmítne; sítě se nespojují. Výběr větve navazuje na pravidla Cable Analyzeru, přizpůsobená spotřebiči bez OUT.

Displej je skutečný nativní LogicDisplay: používá původní pixelovou síť, glyph renderer, režimy, barvy a logické hodnoty. Čip i displej vlastní stejné zařízení; **db je přímo DIN Smart Module**. Krátký program k ověření po nahrání z IC motherboardu:

```mips
s db On 1
s db Mode 0
s db Color 2
s db Setting 42
l r0 db Setting
```

Převezme spotřebu původního LED displeje (50 W). IC10 běží na serveru s nativním rozpočtem 128 instrukcí každých 0,5 s, když je modul zapnutý a napájený. Podporuje db a přímé ID/batch adresování zařízení ve vybrané síti; zatím nemá fyzické voliče d0–d5. IC10 lze zasunout po otevření dveří a sejmutí vnitřního krytu. Logické nastavení displeje zůstává dostupné zvenku přes síť. Modul není jistič a nemá ochranný výkonový limit.

Ukládá nativní stav displeje a inventář čipu, pozici DIN, chybu a posledního editora. Starší prototypek zachová pozici a název Smart Module se převede na DIN Smart Module; vlastní názvy hráče zůstanou. Kabely ze zrušeného OUT staršího prototypu se po načtení vrátí jako Cable Coil; IN zůstává. Původní nativní mesh soubory se dál exportují do LocalLow/.../ModularSwitchboards/Diagnostics. Jejich kompletní obsah ani dekompilované zdroje hry nejsou součástí zdrojového ZIPu.

Ověření: Release build bez chyb a varování; 29 kontrol jednoho IN a síťové registrace; 28 kontrol db, delegace LED logiky, běhu IC10 a ukládání/join; 37 kontrol ořezu originálního LED mesh, UV, orientace a usazení před čelem; produkční geometrie potvrzuje odstranění OUT kontaktu a nezměněné běžné jističe. Regresní testy vedení, napájení a routování prošly. Testy používají místní herní DLL a náhradní běhové prostředí; finální zobrazení LED, skutečné usazení IC10, seznam IC motherboardu a save/load je třeba vyzkoušet ve hře. Ikona zachycuje nové tělo s LED; IC10 socket se sestavuje z originálního Slotu a mesh Air Conditioneru při spuštění hry.

## Předchozí změny

### 0.13.97

Smart Module má čisté čtyřmístné tělo: odstraněná páčka, její spindle uchycení i horní indikátor stavu. Pryč je také původní ovládací hitbox, On/Off interakce a komponenta animace páčky. Náhled stavby, hranice výběru i ikona odpovídají prázdnému tělu; připojovací svorky a čtyřmístná obsazenost zůstávají. Čip a LED displej se doplní v následujícím kroku.

Tělo používá produkční builder s plain:true, shodný způsob odstranění spindle uchycení jako u Analyzeru. Blueprint se přegeneruje až po odstranění ovládacích dílů. Existující běžné jističe se nemění.

Ověření97: Release build bez chyb/varování; produkční geometrie ověřuje šířku a střed čtyřmístného plain těla. Ikona znovu vykreslená ze skutečného modelu a vizuálně zkontrolovaná bez páčky/indikátoru. Herní zobrazení je třeba ověřit ve hře.

Změny předchozí96:

První základ Smart Module: samostatná volba v Kit (Switchboard Modules), stabilní prefab StructureDinSmartModule. Původní jističové tělo rozšířené na čtyři DIN pozice; páčka, indikátor, svorky a hitbox jsou vystředěné, obsazenost a náklady jsou4modulové kity. Vlastní ikona z produkčního čtyřmístného modelu. Zatím zachovává ruční On/Off a výchozí1kW ochranu původního jističe; IC10, čip ani LED displej ještě nejsou osazené.

DinSmartLayout poskytuje společnou šířku a střed pro model, kontakty a počet míst. BreakerSwitchView dostal CenterX, aby animace nepřesouvala páčku širokého modulu zpátky vlevo. Ostatní jističe mají výchozíCenterX0 a původní chování. Nová varianta používá stávající ukládací typ DIN modulů.

Při startu hry se původní modely Air Conditioneru a StructureConsoleLED5 načtou a vyexportují stejně jako dřívější APC. Soubory AirConditioner-geometry.json a ConsoleLED5-geometry.json vzniknou v Application.persistentDataPath/ModularSwitchboards/Diagnostics (herní LocalLow). Obsahují původní mesh části, vrcholy převedené do souřadnic zařízení, UV, materiály/ID a trojúhelníky. Úplná cesta se zapíše do logu jako Smart native geometry exported. V paměti se uchovají i původní meshe/materiály a transformační matice pro následnou montáž čela. Tyto reference se v této verzi zatím na modul nemontují. Původní Unity assety nejsou součástí místních DLL; skutečná data tedy vyexportuje až hra, připravený exportér byl ověřen na fixture modelech.

Žlutá výstraha na Medium a Medium Reverse posunutá výš: ze skutečného Small door meshe změřená horní hranaY0.25m a střed výstrahyY0.17m, tedy80mm pod horní hranou. Medium má horní hranuY0.5m, proto se původní nezvětšená značka posune o250mm nahoru. Zachová se i přesný odstup horního okraje výstrahy; ten se změří z aktuálního nativního meshe a vypíše do logu. Small i Small Reverse se nemění.

Ověření96: Release build bez chyb/varování;98kontrol katalogu a modulových pravidel včetně Smart názvu/šířky/volby; produkční geometrie těla ověřuje fyzickou šířku čtyř pozic a vystředění;22kontrol nativního přepínání/animace/zvuku včetně zachování nenulového středu páčky. Ikona vykreslená ze skutečných produkčních meshů a vizuálně zkontrolovaná. Ověřený export obou JSON souborů včetně souřadnic, UV, materiálů a indexů; skutečný Medium mesh fixture kontroluje zachování odstupu výstrahy. Umístění, zapojení, skutečné nativní exporty a save/load vyžadují herní ověření.

Změny předchozí95:

Přidaný Switchboard Medium (Reverse), samostatný čtvrtý výběr ve stejném Kit (Switchboard). Vzpřímená skříň se dvěma dveřmi, Input dole a tři Outputs nahoře. Výstupy jsou zleva doprava1/2/3 také na vnitřní desce. Zachované rozměry0.8×1m, tři DIN řady po14pozicích, dveřní moduly/Bridge, kryt a cena3kitů za rám +5Plastic Sheets s klíčem za plášť.

Stabilní prefab StructureModularSwitchboardMediumReverse. Profil sdílí Medium geometrii a Small Reverse mapováníY. Input používá skutečnou dolní kabelovou buňku a společnou fyzickou plochu; všechny tři Outputy míří nahoru. Přesné nativní šestibodové profily koridorů se před generováním převedou do společných souřadnic a hotový mesh se zrcadlí s opravou windingu. Vnitřní svorky i středový popisek jsou zrcadlené, text zůstává vzpřímený. F1/popisy/vyhledávání i kontrola registrace zahrnují nový profil. Existující profily a jejich prefab ID se nemění.

Ověření95: Release build bez chyb/varování;428kontrol skutečných profilů, rozmístění a kabelové mřížky všech čtyř variant; produkční Input installer také pro Medium Reverse;3220kontrol přesných output spojů a trojúhelníků u obou Medium variant v pěti posunech stěny;10308kontrol zadního/Input koridoru včetně zrcadlených spojových vrcholů a normál;12464kontrol obvodů/tras/serializace. Herní vytvoření nového prefabu, dveře, kabely a save/load je třeba ověřit ve hře.

Změny předchozí94:

Dveřní moduly, Door Bridge a popisky nyní při stavění přes Authoring Tool používají stejné přichytávání a držení montážní pozice/natočení jako při použití příslušného kitu. Dveřní i vnitřní popisky zapínají správnou montážní plochu také při authoringu. DIN lišty a moduly zůstávají součástí stejného postupu.

Společná MountPlacementTool rozlišuje skutečný konstrukční cursor a odpovídající kit nebo nativní InventoryManager.IsAuthoringMode. MountBoardResolver, MountPlacement a BoardPlacementInput ji používají místo výhradní kontroly MultiConstructoru. Držení modifikátoru zachová desku, mřížku i rotaci; uvolnění tlačítka, změna nástroje/cursoru a znepřístupnění desky lock zruší. Požadavky na dokončenou skříň, kryt pro vnitřní popisky, obsazenost a vzdálenost se nemění. Zachovaná je také podpora kitu vnitřního krytu.

DIN: přidané samostatné montážní pásy v každé řadě, registrované na RailBoard a aktivní jen při stavění lišty (kit i authoring). Pásy mají výšku35mm a jejich Y odpovídá přesně souřadnicím řad. Při stavění popisků se vypnou. Hitbox pro osazování modulů na namontovanou DIN lištu zúžený z105mm na35mm. Doors: resolver při míření na oddělený namontovaný ovladač/popisek hledá správné křídlo podle jeho skutečné montážní desky.

Ověření94: Release build bez chyb/varování; 95 kontrol skutečných tříd pro lock, volbu nástroje a label plochy, šest typů přes kit i Authoring Tool; 151 kontrol skutečného resolveru a pozdní validace Bridge včetně nových authoring scénářů pro dveřní moduly a oba druhy popisků. Herní umístění a následné načtení je nutné ověřit ve hře.

Změny předchozí93:

Oprava stavebních značek: odstraněné vlastní piktogramy92. Výchozí nativní křížky u všech přípojek Small, Reverse a Medium se nahrazují přímo původními prefaby hry z InventoryManager.HelperIndicators pro Input/Output s typem PowerAndData. Jsou to stejné nativní značky, které používá APC; oba symboly jsou součástí původního prefabu. Output2/3 použijí původní Output variantu, pokud tabulka nemá vlastní kombinovanou variantu jejich role.

Postfix HandleStructurePrefab běží po vytvoření skutečného construction cursoru. Zachová přesnou pozici, otočení, velikost, rodiče a tag původní značky, nastaví Connection.HelperRenderer na nový nativní renderer a starý křížek odstraní. Tím dál fungují původní zelené/žluté/červené barvy hry. Funkční ConnectionRole, ConnectionType a registrace elektrických sítí se nemění; rám i orientační šipka zůstávají.

Příčina92: nativní HandleStructurePrefab vybírá HelperIndicators podle role a typu přípojky. Nedokončená skříň má NetworkType.None, takže použil výchozí křížek. Přidání vlastních značek do blueprintu jej nenahradilo.93 vybírá přímo původní kombinovaný vizuál, bez změny reálných síťových parametrů.

Ověření93: Release build bez chyb/varování; skutečná produkční třída s Unity náhradami ověřena napříč třemi profily: volba původního kombinovaného prefabu, správná role, odstranění křížku, zachování všech transformací/tagu a nezměněný typ přípojky. Skutečnou tabulku prefabů a vzhled je třeba ověřit ve hře; pokud původní kombinovaný prefab chybí, zapíše se konkrétní chyba a původní značka zůstane.

Změny předchozí92 (nahrazené v93):

Stavební náhled Small, Reverse a Medium nyní zobrazuje u Inputu i všech Outputů směrovou šipku a oba piktogramy: blesk pro proud a tříuzlovou síť pro data. Input míří dovnitř, Outputs ven; náhled zachovává horní orientační šipku i rám. Značky jsou oboustrannou geometrií samostatného blueprint meshe a přebírají zelenou/červenou barvu náhledu. Nejsou součástí dokončené skříně ani hitboxů.

Náhled se sestavuje až po instalaci funkčních přípojek a bere jejich skutečné lokální pozice. Směry používají společný CabinetLayout/OutputPlacement pro normální, Reverse i Medium. Tato změna je vizuální: nemění registraci elektrických sítí, průchod dat přes moduly ani budoucí IC10 chování.

Ověření92: Release build bez chyb a varování; osm geometrických případů Input/Output ve čtyřech směrech kontroluje směr šipky, konečné souřadnice, čelní rovinu a nenulovou plochu trojúhelníků. Nativní rendering a čitelnost při otáčení je třeba ověřit ve hře.

Změny předchozí91:

Medium Bridge: pevné svorky vrácené o 30 mm k pantu oproti90 (celkově20mm dovnitř oproti89). Dveřní svorky posunuté o10mm od pantu do plochy dveří, včetně kontaktů a rezervací pro ruční vodiče. Flex používá stejné Bezierovy odchylky jako Small, zrcadlově pro obě křídla.

Medium horní Input koridor nyní používá stejné oddělené normály rovinných ploch jako Outputs. Vyhlazování nepřechází přes hrany zkosení do dlouhých stěn. Přesný nativní šestibodový připojovací profil, geometrie, kabelové buňky a Small/Reverse zůstávají zachované.

Ověření91: Release build bez chyb/varování; 54 případů zadního koridoru, 8958 kontrol trojúhelníků a spojových vrcholů. U pěti poloh přesného Input profilu ověřeno oddělení všech normálových vrcholů bez jakékoli změny souřadnic trojúhelníků. Dále12464kontrol obvodů/tras/serializace a46zrcadlových poloh propoje0–110°. Kontrola středu i příčných posunů o poloměr2.4mm proti nativním dveřím bez průniku; rám mimo první dva koncové úseky u pevné svorky bez průniku. Vzhled je nutné ověřit ve hře.

Změny předchozí90:

Medium: pevné Door Bridge svorky jsou na obou stranách posunuté o 50 mm směrem do středu desky. Propoj používá jeden kratší plynulý oblouk mezi skutečnými otvory svorek, bez vynucené okliky před rámem. Small a Reverse mají původní umístění i propoj.

Medium Input a Outputs: generovaný koridor přebírá šest skutečných vrcholů připojovacího profilu nativního konektoru. Zachovává jejich přesné XYZ souřadnice; zkosení těla už neřeže rohy dosedacího profilu a neposouvá konec podle hloubky vrstvy. Kabelové buňky a logické porty se nemění.

Ověření90: Release build bez chyb a varování; přesné spojové vrcholy, uzavřenost a orientace output meshe napříč pěti posuny stěny; sdílený zadní koridor a přesné vrcholy Inputu; 12464 kontrol obvodů, tras a serializace; 46 zrcadlových poloh Bridge při otevření 0–110°. Střední úseky oblouku nekříží skutečné trojúhelníky Frame/Housing. Herní runtime není dostupný; tloušťku kabelu a vzhled při pohybu je třeba ověřit ve hře.

Změny předchozí89:

Door Bridge: před samotným CanConstruct se znovu vybere správná deska (po případném nativním resetu CursorBoard). Rozvaděč se hledá i přes montážní metadata oddělené DIN lišty/modulu/krytu; při míření na desku nebo lištu se náhled přichytí k nejbližší pozici u příslušného pantu. Obsazená pozice zůstane červená, nepřeskakuje se na jinou volnou. Podržený montážní lock má přednost. Platí pro Small, Reverse a obě strany Medium.

Medium Bridge flex: druhé křídlo používá správný opačný otvor pohyblivé svorky. Obě průchodky jsou zrcadlové, včetně lokálního natočení svorek. Modrý propoj má souvislý oblouk přes bezpečný bod před rámem; přechází do otvoru svorky po jeho ose a nezanořuje se střední částí do rámu. Elektrické kontakty a ID se nemění. Small/Reverse oblouk beze změny.

Medium Input nyní používá stejný ReadForBody jako Outputs: explicitní tělová buňka a fyzický spoj přesně uprostřed mezi kabelovou a tělovou buňkou. Vizuál i funkční registrace používají stejný výpočet; původní surový pivot zdrojového kabelu nemění polohu viditelného spoje. Po úpravě ověř napojení existujícího horního kabelu.

Odstraněno4mm překrytí na rozhraní generovaného Medium koridoru a nativních konektorů (Input i Outputs). Oba díly se stýkají na změřené připojovací rovině; jejich souběžné povrchy se v oblasti spoje již nepřekrývají.

Ověření89: Releasebuild0chyb/varování;143integrovaných kontrol skutečného resolveru a CanConstruct (oddělená DIN lišta, chybně zvolená deska, profily, strany, nejbližší/obsazené pozice);131kontrol nativních kabelových pozic včetně Input; produkční Inputinstaller;12464kontrol obvodů/energie/tras/serializace plus46zrcadlových případů propoje při otevírání.1748středních segmentů skutečně generovaných flex tras nekříží trojúhelníky původního Frame/Housing meshe. Testy nenahrazují Unityruntime: tloušťka flex kabelu, koncové úseky u svorek, vzhled švů a připojení skutečných kabelů vyžadují ověření ve hře.

Změny předchozí88:

Oprava nefunkční druhé kliky Medium: nativní Thing.IsOpen u rozvaděče bez animátoru čte pouze InteractOpen.State (první Open akci). Dvě vlastní Open instance proto mají odlišné stavy; změna druhé nemusí pohnout dveřmi. SwitchboardCabinet.InteractWith nyní pro obě kliky předá původnímu nativnímu zpracování tutéž první Open akci. Oba fyzické hitboxy a vlastní výběrové rámečky zůstávají, ale existuje jediný rozhodující a ukládaný/synchronizovaný stav. Druhá kliková interakce se nesynchronizuje samostatně. Small/Reverse a ostatní akce beze změny.

Ověření88: Releasebuild0chyb/varování;62kontrol, včetně reprodukce změny ignorovaného stavu druhé kliky, následného střídání obou klik při otevírání/zavírání, společného Open, jediného synchronizovaného stavu a zachování Small/ostatních akcí. Test používá skutečnou produkční volbu akce a větev Open z dekompilovaného nativního Thing.InteractWith, se serverovou/Unity náhradou. Skutečný herní runtime a multiplayer zde nejsou dostupné.

Změny předchozí87:

Sjednoceny obě kliky Medium: každá má vlastní fyzický hitbox a nově vytvořenou nativní akci Open se stejným hostitelem, ovládáním, rozměry výběru a synchronizací. Odstraněna asymetrie mezi původní upravenou locker interakcí a dodatečnou interakcí druhého křídla. Výběrové Bounds obou klik odpovídají rozměrům jejich colliderů; dodatečná klika je dříve neměla výslovně nastavené. Obě nadále otevírají společně stejné dvojité dveře. Small a Reverse beze změny.

Ověření87: Releasebuild bez chyb/varování; kontrola obou vazeb na collider, společného vlastníka Open, rozměrů výběru, shodného nastavení, dokončeného stavebního stavu a opakované registrace bez duplicit. Skutečné klikání ve hře a multiplayer zde nejsou dostupné; ověř obě kliky při otevřených i zavřených dveřích.

Změny předchozí86:

Opraven pád ModelBlueprint.Build (cannot build a preview without model geometry) při načtení Medium s DIN lištami skrytými pod krytem. Runtime změna šířky už neprochází viditelné renderery ani nepřepisuje sdílený prefab blueprint. Používá přímo vytvořený mesh lišty a případný vlastní Wireframe kurzoru. Pokud kurzor vznikne později nebo se vymění, dostane správný náhled i bez další změny šířky. Fyzické rozměry, montáž, zapojení a ukládání zůstávají stejné.

První montážní náhled Small/Reverse/Medium na svislé stěně se nově srovná šipkou nahoru. Úprava proběhne jen jednou při aktivaci náhledu před kontrolou montáže; zachová směr do stěny a následné ruční otočení. Výslovný roll nebo smart-rotate v prvním snímku má přednost. Postavené skříně a ostatní prefaby se neotáčejí.

Medium nově vyžaduje3×Kit(Switchboard) pro rám a5×PlasticSheets + Wrench pro skříň. Small/Reverse zůstávají1kit +2PlasticSheets. Počty jsou přímo v nativních BuildStates, které zobrazíF1 a používá stavba/demontáž; registrace kontroluje cenu každé varianty.

Ověření86:52kontrol produkční inicializace natočení (3varianty,4směry stěn, nová aktivace a zachování ručního otočení); Releasebuild0chyb/varování;27kontrol skutečné produkční metody Resize pro skrytý model, odstraněné collidery, náhled vytvořený později/vyměněný, střídání šířek a opakované volání. Předchozí metoda v regresním scénáři vyvolá stejnou výjimku; opravená ji nevyvolá. Unity/runtime zde není dostupný; ověř načtení svého světa s nasazeným krytem.

Změny předchozí85:

Opraven chybějící montážní náhled rámu Medium: původní rám měl geometrii jen v páté materiálové části, ale náhled používal jeden materiál. Společný CabinetPreview nyní slučuje všechny části skutečného rámu do jednoho submeshe. Small, Small (Reverse) i Medium mají v montážním náhledu plnou šipku nahoru; šipka se neobjeví na postavené skříni. Náhled zachovává skutečné rozměry, natočení a offset modelu.

Medium má vlastní obrázky hotové skříně i rámu (F1 a stavební stavy), vyrenderované z původního embedded meshe se skutečnými transformacemi Medium: dvoje dveře, dvě madla, širší/vyšší tělo. Small a Reverse si ponechávají své obrázky.

Ověření85: produkční Releasebuild bez chyb/varování; kontrola skutečného embedded rámu s prázdným prvním submeshem, kompletních indexů v jediném náhledovém submeshi, šipky a transformací pro všechny tři varianty. PNG s průhledností ověřeny a obrázek vizuálně zkontrolován. Unity/herní runtime zde není dostupný; skutečný stavební kurzor a F1 je potřeba ověřit ve hře.

Změny předchozí84:

Opravená zadní sestava Medium: místo zjednodušeného samotného krčku používá stejný generátor jako Small pro celé tělo zadní krabice, zaoblený půdorys, souvislý horní koridor a přechod bez vnitřního víčka. Zůstává původní nativní zadní kryt APC s výstrahou a šrouby, původní povrch a hloubka. Medium jen dodává rozměry svého nového horního konektoru. Spodní společný kryt má stejné nativní plošné zkosení jako Small, vedené kolem všech tří větví. Stejné plošné zkosení (nativní poměr0.5776 a hloubka nejvýše10mm) má i celý horní koridor od zadní krabice až k Inputu; přechod krabice do tohoto profilu používá společný generátor. Přívod Input zůstává na stejné kabelové pozici; výstupy2/3 a jejich vnitřní svorky jsou nově seřazené1–2–3. Existující vnější kabely2/3 přepoj na nové pozice; kontrola uložených vnitřních tras zachovává logické konce a přepočítá posunuté přívody.

Medium má všechny tři výstupy dolů vedle sebe na skutečné kabelové mřížce, s roztečí50cm. Zvenčí i na vnitřní desce jsou zleva Output1, Output2 uprostřed a Output3 vpravo. Identita jednotlivých elektrických větví zůstává stejná; mění se jejich fyzické pozice. Řada krajních konektorů má metr, proto spodní společný kryt přesahuje0,8m skříň. Každý vývod má samostatnou nativní elektrickou pozici a vlastní funkční collider. Nový souvislý spodní kryt má tři svislé větve. Původní boční výstupy Medium je nutné znovu napojit vnějšími kabely; vnitřní propojení a názvy větví se nemění.

Horní Input Medium používá tentýž původní APC konektor jako výstupy, otočený nahoru. Nativní logická pozice Input se nemění. Vizuál sedí na skutečném kabelovém spoji, používá vlastní původní materiály a jeho hitbox přímo obsluhuje Input. Horní krček má odpovídající průřez. Small a Reverse mají dosavadní konektory a rozložení.

Opraven InvalidCastException v DoorModules.CanConstruct při míření dovnitř otevřeného rozvaděče na jiný typ montážní desky/hostitele (například DIN lištu nebo kryt). Kontrola nejprve ověří správný typ hostitele a desky; nevhodná plocha vrátí neplatnou montáž bez pádu. Na správných dveřích zůstává snap a kontrola obsazení. Door Bridge se přichytí k nejbližší pozici u pantu, včetně krajních pozic Small/Reverse/Medium; obsazenou pozici nepřeskakuje a podržený montážní lock uchová konkrétní místo. Obě křídla mají vlastní4x3pozice. Součástí je oprava DIN kurzoru a o25cmnižší poloha Medium z0.13.82.

Stejný Kit (Switchboard), třetí varianta Medium; tři DIN řady po14pozicích, dvojité dveře ovládané společným nativním Open. Žádné automatické elektrické propojení. Vnitřní štítky vyžadují vnitřní kryt.

Ověření84: Releasebuild0chyb/varování;126kontrol nativních vývodů včetně pořadí1–2–3;12464kontrol obvodů/energie/tras/serializace a scénář přepojení vnitřních tras po přesunu svorek2/3 se zachováním identit a spotřeby kabelů;54případů zadní krabice/koridoru a8928trojúhelníků (celé tělo, různé překryvy a délky, otevřený vnitřní spoj);27případů zkosených spodních větví a5076trojúhelníků (orientace ploch, uzavřenost hran, triangulace). Tvorba těla a přechodu převzata přímo z produkčního Small; společný generátor.

Ověření předchozí83: Releasebuild bez chyb/varování;126kontrol nativních kabelových pozic včetně samostatných tří dolů orientovaných výstupů;27rozměrových případů nového krytu (3348trojúhelníků) s kontrolou triangulace, uzavřených hran a orientace ploch;73kontrol skutečných podmínek montáže dveří a přichycení bridge ve všech třech rozvaděčích včetně nevhodných hostitelů; funkčníInputfixture proSmall/Reverse/Medium, stavební stavy, nativní vizuální hitbox, duplicitní a chybné metadata. Testy používají náhrady Unity/nativních objektů. Skutečný herní runtime a multiplayer zde nejsou dostupné.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards vmods; host i klienti stejná verze. Ve hře ověř všechny tři spodní kabely, vzhled a hitbox horního Input, dveřní montáž při otevřeném rozvaděči a save/load. Záloha0.13.51 zachovaná.
