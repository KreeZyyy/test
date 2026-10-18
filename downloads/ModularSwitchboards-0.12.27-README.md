# Modular Switchboards 0.12.27 — spodní T kryt a dva APC výstupy

Pod střední zadní krabičkou je nový šedý T kryt: 50mm svislý krk, spodní ramena a na jejich koncích původní kompletní elektrické konektory APC včetně blesku, obroučky, kontaktů, UV a materiálů. Výstup 1 je vlevo a výstup 2 vpravo při pohledu do skříně, ve stejném pořadí jako vnitřní svorkovnice. T kryt má malé 3mm zaoblení hran půdorysu a přibližně 6mm překrytí do spodku zadní krabičky. Hloubku a délku ramen určuje skutečná poloha nativních konektorů; nenastavuje se odhadem ze screenshotu.

Oba výstupy se umísťují přes NativeCableLayout podle nativních rovných kabelů, do spodní řady a s kabelovou osou vlevo/vpravo. Každý má vlastní ConnectionRole.Output / Output2, vlastní kolizi a samostatnou kabelovou buňku. Kontrola při instalaci odmítne shodu buněk s Inputem či druhým výstupem. Logické transformy jsou přímo v souřadnicích rozvaděče a při wall-fit se neposouvají; mění se pouze geometrie krytu mezi nimi a zadní krabičkou. Kabelové buňky se nerezervují jako tělo skříně.

T je společný mechanický kryt. Elektricky se Input, Output 1 a Output 2 automaticky nepropojují. Obě vnitřní svorkovnice výstupů nyní umějí odkázat na příslušné skutečné porty. Vlastní vnitřní drátování a přenos výkonu přes jističe zatím nejsou zavedené, tedy samotné přivedení napětí na Input nemá napájet výstupní síť. Nové porty používají existující správu kabelových sítí a stavů stavby.

Vnitřní svorkovnice, jejich rozmístění a oprava prosvítání textů zůstávají z 0.12.26. Horní Input beze změny. Vizuál krytu a oba vnější konektory se zobrazují v dokončeném stavu stavby; vnější konektory mají nativní povrchy při lakování.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Předchozí balíčky a potvrzená záloha 0.12.7 zůstávají na GitHubu.

Ověření: kompilace bez chyb a varování. Produkční výpočet T krytu ověřen ve 32 kombinacích rozpětí, spodní polohy a hloubky: triangulace konkávních vík, plošný obsah, orientace, nedegenerované trojúhelníky a uzavřenost hran po sjednocení totožných pozic. Zkouška je v Verification/OutputHousing. Kontrola při načtení vyžaduje tři různé role a tři kabelové buňky. ZIPy ověřeny. Hru ani její síťovou simulaci zde nespouštíme.

Ve hře ověř: tvar a návaznost spodního krytu, původní APC blesky a kontakty, tooltip obou výstupů a připojení kabelu vlevo/vpravo. Potom odstranění/znovupřipojení kabelů a načtení uložené hry. Při chybě pošli hlášku Output1/Output2 native grid nebo T output housing z logu; jejich skutečné souřadnice mají přednost před vizuálním odhadem.
