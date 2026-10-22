# Modular Switchboards 0.13.53

Experimentální dveřní Cable Analyzer z 0.13.52 je odstraněný z modelů, registrace, kitu i katalogu. Verze vychází ze záložní 0.13.51; neobsahuje skrytý náhradní prefab ani další kompatibilní variantu. Záložní balíčky 0.13.51 zůstávají nedotčené.

## Skutečné zelené náhledy

Dveřní LED, TOTAL STOP s ochranným límcem a pevný záchyt jednotlivého bridge používají skutečnou geometrii modelu místo zelené krabice. Náhled zahrnuje čočku, tělo, svorky i límec podle daného dílu.

DIN moduly mají sjednocený náhled ze všech viditelných dílů a všech submeshů hotového modelu. Přenášejí se vnořené transformace, měřítka, natočení i případné zrcadlení. Skryté stavy (například prasklá nebo ještě nevložená pojistka) se nepřidávají. DIN lišta už používá vlastní skutečný mesh.

Nová geometrie náhledu je samostatná kopie pozic a trojúhelníků; původní modely a jejich materiály se nemění. Nepoužité vrcholy nativních meshů nezvětšují náhled. Nezávisí na slučování různých nativních shaderových/UV kanálů a podporuje i více než 65 tisíc vrcholů.

U těchto dveřních dílů, DIN modulů a lišt se při pokládání vypíná dodatečný herní obrysový box, který ke skutečným rozměrům přidával 50 mm. Vidět je vlastní model. Zelenou pro platné místo a červenou pro neplatné/obsazené místo nadále nastavuje původní herní kontrola. Přichytávání k pozicím a kontrola obsazení zůstávají stejné. Ostatních herních staveb a režimu editace kabelů se úprava netýká.

## Ověření a instalace

Produkční build proti herním DLL bez chyb a varování. 20 kontrol skutečných tříd ModelBlueprint/ModelPreviewCursor: všechny submeshe, vnořené a zrcadlené transformace, skryté díly, nepoužité vrcholy, model se 70 tisíci vrcholy, úplný nativní předek DIN analyzeru, správa vlastních/sdílených meshů, zachování zelené/červené a oddělení běžných staveb a nástrojů. 36 kontrol ovládání TOTAL STOP prošlo.

Unity ani běžící hra zde nejsou dostupné. Ve hře ověř zelený/červený model při pokládání LED, STOPu, bridge, DIN jističe/pojistky/analyzeru/baterie a lišty, včetně obsazených pozic a přepnutí na běžnou herní stavbu. Host a klienti musí mít shodnou verzi **0.13.53**.

Pro čistý test použij save ze záložní **0.13.51**, nebo před přechodem z 0.13.52 odmontuj experimentální dveřní analyzer a jeho vodiče. Nová verze tento zrušený prefab záměrně neregistruje. Původní DIN Cable Analyzer a jeho měření jsou nadále součástí DIN kitu.

Test ZIP obsahuje hotový mod. Source ZIP obsahuje zdroje a ověřovací nástroje bez přeložené DLL a bez velkých regenerovatelných JSON mezisouborů stejně jako předchozí balíčky.
