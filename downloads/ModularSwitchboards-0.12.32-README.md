# Modular Switchboards 0.12.32 — domodelované konektory a zaoblený tunel

Doplněné chybějící stěny, které původní APC konektor přebíral z těla APC: zadní šestiboké uzavření, rovná přední plocha u kořene a přechod k vyvýšené části. Nových 10 trojúhelníků má šedý APC povrch. Přední ústí ani kontakty se nezakrývají.

Opravený výběr původní geometrie. Horní hranice předchozího ořezu zasahovala do vyvýšeného blesku. Nový výběr obsahuje 124 původních celých trojúhelníků včetně úplného blesku, jeho podkladu a kontaktů; originální UV se nemění. Nesouvisející velké plochy skříně APC zůstávají mimo výběr. Se změřenými doplněnými stěnami se původní otvor do těla uzavírá.

Tunel T má nyní zaoblené zadní hrany namísto hranatého vytlačeného profilu. Přechod odpovídá změřeným krajním bodům APC profilu: inset 5.776 mm přes hloubku 10 mm, doplněný malým 1.5mm změkčením předních hran. Vzorkované zaoblení a sdílené vrcholy umožňují plynulé stínování. Napojení se odvozuje z kořenového průřezu konektoru, nikoli z obálky vyvýšeného blesku. Nemá tak logo ani vyvýšený podklad způsobovat schod ve velikosti tunelu.

Zachovaná poloha ústí a plánovaných kabelových buněk, ochrana náhledu a runtime přepočtu z 0.12.31. Spodní část stále pouze model, horní Input funkční. Vlastní vnitřní drátování není automaticky propojené.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti.

Ověření: kompilace bez chyb a varování. Na nativní referenci: 124 původních + 10 nových trojúhelníků, žádné otevřené nebo ne-manifold hrany při sjednocení pozic na 1 a 10 mikrometrů, souhlas orientace doplněných ploch s originálem. Ústí zůstává nedotčené; doplněné plochy končí před ním. Produkční zaoblené T ověřeno ve 33 variantách (triangulace vík, obsah, orientace, nedegenerované trojúhelníky a uzavřenost). Zkoušky a referenční výřez jsou ve Verification. ZIPy ověřeny. Vzhled a návaznost ve hře vyžadují potvrzení.
