# Modular Switchboards 0.12.8 — diagnostika napájecího panelu Automated Ovenu

Nemění model potvrzeného základu 0.12.7. Žádný IN ani jiná elektrická přípojka se v této verzi nepřidává. Účel: získat původní šedý napájecí panel s bleskem z Automated Ovenu pro pozdější přidání do modelu IN nahoře uprostřed.

Po načtení světa jednou vyhledá původní prefab AutomatedOven a exportuje jeho mesh renderery: původní lokální vrcholy v metrech, UV, trojúhelníky podle submeshe, materiály, shadery a jejich vlastnosti, globální i submesh property blocks a polohy přípojek. Dostupné 2D barevné textury materiálů se čtou přes GPU do PNG. Texturová pole a nepodporované či příliš velké textury se přeskočí s vysvětlením v JSON; jejich reference zůstávají. PNG slouží pro identifikaci a náhled, originální herní materiál lze později převzít přímo.

Výsledek: %USERPROFILE%/AppData/LocalLow/Rocketwerkz/Stationeers/ModularSwitchboards-Oven-reference.zip
Obsah ZIPu: ModularSwitchboards-Oven-reference.json a dostupné diffuse-*.png. Přesná cesta je také v Player.log jako `OVEN DIAG upload this file:`. Pokud ZIP chybí, pošli Player.log; případný JSON a PNG jsou v podsložce ModularSwitchboards-Oven-reference.

Instalace: při vypnuté hře zálohuj a nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Ponech závislosti. Spusť hru, načti svět a pošli výše uvedený exportní ZIP. Původní potvrzená záloha 0.12.7 zůstává na GitHubu.

Ověřeno: kompilace proti dodaným herním knihovnám bez chyb a varování; původní Cabinet.meshbin beze změny; integrita distribučních ZIPů. Export je nutné ověřit ve hře, tu zde nespouštíme.
