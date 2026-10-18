# Modular Switchboards 0.12.42

ON/OFF je zpět přímo na obou stranách barevné pohyblivé páčky jističe. Text tvoří vlastní geometrie, otáčí se s páčkou a používá běžný materiál s hloubkovým testem. Dodatečné CB/EMPTY/FUSE/TRIP/kW štítky se nevracejí.

Koncovky vložených pojistek mají oddělený renderer s výslovně bílou barvou pro celý renderer i jednotlivé materiály. Zdravý střed zůstává barevný podle držáku: 1 kW zelená, 5 kW žlutá, 50 kW oranžová, 100 kW červená, 500 kW fialová. Spálený střed zůstává očazený a přerušený, koncovky bílé. Prázdný držák nemá vložku ani koncovky.

Elektrika, ochrany, kabelové trasy, kity a ukládání se v této verzi nemění. Ze stacku Cable Fuses se dál vkládá jeden kus. Starší 20kW prefab zůstává načitatelný.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Server i klienti musí mít stejnou verzi.

Ověření této změny: Release sestavení bez chyb a varování; test skutečného nativního byte enumu a všech pěti barev; produkční geometrie dutého držáku, zdravého a spáleného středu, oddělených koncovek; bílá globální i všech pět materiálových hodnot; přepínání prázdná/zdravá/spálená/odstraněná; geometrie ON/OFF na obou stranách, orientace trojúhelníků a umístění v obálce páčky. Geometrický test nahrazuje zaoblené krabičky konzervativními nezaoblenými. Vzhled a čitelnost za skutečného osvětlení Unity je ještě nutné ověřit ve hře.
