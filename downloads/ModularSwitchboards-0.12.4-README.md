# Modular Switchboards 0.12.4 — zadní plášť podle exportu APC

Integrovaný šedý plášť v modelu Housing má hloubku 86.239442 mm. Změřeno z původního hlavního meshe APC mezi zadní vnější rovinou z=0.043759793 m a přechodem šedá/bílá z=0.129999235 m. Středová krabička s bleskem (sahá do záporného Z) ani přípojky nejsou součástí tohoto měření. Předchozí heuristika od nuly byla nahrazena touto hodnotou.

Šířka 400 mm, výška 500 mm a poloměr rohů 20 mm navazují na rozvaděč. Zadní část je nadále součástí hlavního modelu a jeho kolize. Původní předek, rám, dvířka a vnitřek mají nezměněné vrcholy a normály.

Povrch: pouze zadní část používá kopii skutečného materiálu hlavního APC (materiál 0), jeho shader, textury a property block. UV vzorek je uvnitř původního širokého šedého boku APC (trojúhelník 15). Nejde o obecné ColorType.Gray ani o přebarvení celé skříně. Původní materiály pantů a vnitřku zůstávají. Vizuální shodu pod skutečným herním osvětlením je potřeba ověřit ve hře.

Přípojky zůstávají vypnuté; jejich kontrola správně očekává nulu a nehlásí falešnou chybu. Diagnostický export už není automaticky spouštěn. Původní export se nemusí znovu posílat.

Instalace: vypni hru, zálohuj původní mod a nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej stávající závislosti; klient a server potřebují stejnou verzi. Již položené kabely se nemažou.

Ověřeno: sestavení proti dodaným herním DLL, 0 chyb a 0 varování; geometrické rozměry, přiřazení zadní části, jednotkové normály, platné indexy, nezměněná původní geometrie, integrita ZIPu. Ve Stationeers zde netestováno. Pokud je hloubka nebo povrch stále jiný, pošli boční pohled na APC a rozvaděč a Player.log.
