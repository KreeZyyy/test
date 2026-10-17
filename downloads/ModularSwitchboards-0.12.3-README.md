# Modular Switchboards 0.12.3 — diagnostika zadní části APC

Zachovává vzhled a model verze 0.12.0; zadní přípojky zůstávají vypnuté. Přesný odstín ani délka se v této verzi nově nepřebírají: nejdřív je potřeba identifikovat správnou část skutečného APC z exportovaných dat.

Po načtení světa exportuje původní prefab APC: všechny mesh renderery a jejich hierarchii, vrcholy v metrech, UV, trojúhelníky po submeshech, materiály, shadery a jejich vlastnosti, globální i submesh MaterialPropertyBlock včetně příznaků existence override, polohy a hitboxy konektorů. Export nemění APC ani svět.

Soubor: %USERPROFILE%/AppData/LocalLow/Rocketwerkz/Stationeers/ModularSwitchboards-APC-reference.json
Skutečná cesta se vypíše do Player.log jako `APC REAR DIAG saved:`. Diagnostika běží jednou při přípravě prefabů v každém spuštění hry. Pokud export selže, log obsahuje `APC REAR DIAG failed:` a mod pokračuje.

Pošli JSON soubor z uvedené cesty; pokud se nevytvořil, pošli Player.log z téže složky. Export pomůže oddělit navazující zadní plášť od krabičky s bleskem a konektorů a vybrat správné materiálové nastavení. Nulové block hodnoty bez blockHasProperty nejsou důkazem override.

Instalace: vypni hru, zálohuj původní mod a nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou ze ZIPu. Závislosti ponech stávající. Klient a server musí mít stejnou verzi.

Ověřeno: kompilace proti dodaným herním DLL, 0 chyb a 0 varování; integrita ZIPu. Export nelze provést bez spuštění Stationeers: ve hře zde neověřeno.

Oprava 0.12.3: vlastní JSON serializace nahrazuje Unity JsonUtility, který v uživatelově běhu vynechal seznamy parts a ports. Kontroluje se přítomnost geometrie před zápisem. Samostatně ověřeno: vnořené seznamy, pole, escapování řetězců, desetinná tečka při českém locale a neplatná čísla.

Oprava 0.12.3: kontrola registrace nyní očekává nula vnějších přípojek a absenci jejich modelu; neočekávané přípojky stále hlásí chybu. Při přípravě prefabů se seznam vnějších přípojek explicitně vyprázdní. Opravená diagnostika z předchozí verze zůstává.
