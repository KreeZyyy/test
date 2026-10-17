# Modular Switchboards 0.12.14 — zaoblené přechodové tělo IN

Pouze tvarová úprava nového šedého přechodu mezi střední krabičkou a horním panelem. Svislé rohy mají poloměr 4 mm, horní a spodní hrany jsou zaoblené 2mm čtvrtkruhovým profilem. Plynulé normály nahrazují ostré hrany původního klínu. Spodek dál navazuje do střední krabičky; vršek zůstává pod panelem a otevřený pod zapuštěným konektorem.

OvenInputPanel.cs je beze změny oproti 0.12.13: stejný panel, konektor, kotva a natočení. Původní Cabinet.meshbin také beze změny. Žádná nová elektrická funkce, Connection ani drátování. Každá skříň má vlastní přizpůsobený mesh přechodu a kolizi.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Závislosti ponech.

Ověřeno: sestavení proti herním DLL bez chyb a varování. Produkční výpočet geometrie byl spuštěn s matematickými stuby pro pět wall-fit offsetů: platné nedegenerované trojúhelníky, vnější orientace, jediná otevřená hranice nahoře pod panelem, zachovaná výška a konečný rozsah. 281 vrcholů, 532 trojúhelníků. Integrita ZIPů ověřena. Ve hře zde netestováno; zkontrolovat vzhled hran a návaznost.
