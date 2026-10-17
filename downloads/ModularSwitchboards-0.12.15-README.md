# Modular Switchboards 0.12.15 — zaoblený tunel, rozšíření až nahoře

Nahrazuje klín rozšiřovaný po celé výšce užším svislým tunelem od horní části střední krabičky. Tunel má stálý průřez 50 × 50 mm a 10mm zaoblení rohů. Teprve posledních 30 mm pod panelem se plynule rozšíří na jeho rozměry a posune k jeho skutečné poloze. Horní hrany zachovávají 2mm zaoblení. Horní otvor zůstává otevřený pod původním zapuštěným konektorem.

Panel, otvor, původní konektor a jejich polohy jsou beze změny; zdroj OvenInputPanel.cs je shodný s 0.12.14. Stále jen model, bez elektrické přípojky a bez vnitřního drátování. Každá skříň má vlastní přizpůsobenou geometrii tunelu a kolizi.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Ponech závislosti.

Ověřeno: kompilace bez chyb a varování. Produkční výpočet meshe zkontrolován matematickým harness pro pět odsazení stěny: konstantní průřez dříku, rozšíření pouze nahoře, platné nedegenerované trojúhelníky a jejich vnější orientace, pouze horní otevřená hranice. 449 vrcholů a 868 trojúhelníků. Integrita ZIPů ověřena. Ve hře zde netestováno; vzhled posledního rozšíření je třeba potvrdit.
