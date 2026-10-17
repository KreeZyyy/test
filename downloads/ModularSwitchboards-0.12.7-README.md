# Modular Switchboards 0.12.7 — opravené zaoblení zadní krabičky

Pouze úprava modelu; žádná funkce přípojek ani elektrické propojení.

Výřez 0.12.6 byl chybný: hranice +/-121 mm vynechala část zaobleného krytu, který dosahuje přibližně +/-124.061 mm. Rozšířený výběr +/-125 mm nyní zachovává celý původní kryt, zkosení/zaoblení, původní UV blesku a čtyři šrouby. Původní geometrie se nezvětšuje ani nerekonstruuje z kvádrů. Nyní 283 původních trojúhelníků místo 191.

Dva otvory po odstraněných přípojkách jsou uzavřené bočními plochami (12 nových trojúhelníků), které se opírají o skutečné hraniční vrcholy APC. Nepřidávají se konektory, hitboxy přípojek, Connection objekty ani sítě. Původní montážní otvor je zakrytý zadním pláštěm rozvaděče. Bílý plášť a velká šedá část včetně zkosení zůstávají byte-for-byte geometricky stejné.

Blender/GLB a F1 reference jsou aktualizované podle stejného výběru. F1 náhled nemá offline nativní atlas blesku; původní symbol se přebírá z APC za běhu hry.

Instalace: při vypnuté hře zazálohuj a nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Ponech stávající závislosti. Klient a server potřebují stejný mod.

Ověřeno: skutečná kompilace proti herním knihovnám bez chyb a varování, úplný rozsah původního zaobleného krytu, absence otevřených bočních hran po zaslepení přípojek, zachování Cabinet.meshbin, integrita ZIPů. Ve hře zde netestováno.
