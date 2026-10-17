# Modular Switchboards 0.12.13 — model konektoru a návaznost na střední krabičku

Do otvoru horního panelu přidává původní zapuštěné lůžko napájecího konektoru Automated Ovenu se dvěma viditelnými kontakty. Zachované původní UV, materiál a velikost. Celý panel včetně blesku a konektoru má 78 původních trojúhelníků; hluboké tělo pece se nevrací.

Nový šedý přechodový díl navazuje od horní části střední krabičky k dolní ploše horního panelu. Spodní část mírně zasahuje do těla krabičky pro spojení bez mezery, horní obrys sleduje rozměry panelu. Tvar se přepočítá po usazení rozvaděče na stěnu; každá instance má vlastní mesh. Horní víko spojovacího dílu není přidáno přes lůžko, takže nezakrývá zapuštěné kontakty. Používá stejný šedý povrch jako zadní plášť.

Stále pouze model: FunctionalConnection=false, žádná Connection, síť, přenos výkonu, funkční připojení kabelu ani vnitřní drátování. Polohu a první tvar spojovacího těla je nutné ověřit ve hře a případně dále upravit. Metadata navrženého kabelového bodu zůstávají oddělená od skutečné vizuální kotvy na horní ploše.

Potvrzený základ 0.12.7 a jeho záloha zůstávají v repozitáři. Bílá skříň a původní zadní plášť mají původní Cabinet.meshbin. Samostatný Blender/GLB panelu je aktualizovaný o zapuštěný konektor; spojovací tělo se přizpůsobuje podle skutečných souřadnic až za běhu. Statický F1 náhled nové runtime díly nezobrazuje.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Ponech závislosti, klient i server potřebují stejnou verzi.

Ověřeno: kompilace proti dodaným DLL bez chyb a varování, nativní výběr 78 trojúhelníků, shoda kotvy otvoru a konektoru, návaznost přechodu a absence víka zakrývajícího lůžko, integrita ZIPů. Ve Stationeers zde netestováno.
