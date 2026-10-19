# Modular Switchboards 0.12.82

Bateriová zásuvka má zcela novou souvislou vaničku: plná záda, boční stěny a přední lem. Vanička přesně vyplňuje nový otvor v pouzdře, takže zde nejsou rohové mezery ani sestava překrývajících se původních výřezů APC.

Kontakty nejsou nahrazené vlastními ploškami. Použitých je všech48 původních trojúhelníků šesti kontaktů APC, včetně všech144 původních vrcholů a přesného UV mapování. Jejich rozestupy a hloubka vůči skutečné baterii zůstávají původní. Kontakty používají přímo originální materiál a původní MaterialPropertyBlock z APC. Pouzdro používá kopii stejného materiálu APC s šedým tónováním a UV z jeho ověřené panelové oblasti. Shader ani textury se nenahrazují novým jednoduchým materiálem.

U kontaktů zůstává vypnuté přijímání drobných vlastních stínů, stejně jako u opravených svorek pojistek. Nativní materiál/textura kontaktů se netónují do šedé ani nepřebarvují vymyšleným zlatým RGB odstínem. Náhled barvy pouze ilustruje a není snímkem z Unity.

Původní bateriový slot, natočení, měřítko, typy baterií, náboj, nabíjení a záloha se nemění. Pojistky z0.12.79 zůstávají stejné. Nový větší otvor mění pouze bateriový modul; původní zahloubená zadní stěna je zachovaná.

Ověření: Release build bez chyb a varování. Produkční geometrické kontroly ověřily uzavřenost vaničky, všech pět vnitřních stěn, přesné převzetí144původních vrcholů/UV kontaktů, čtyři plné rohy,25kontrol prostoru za baterií, správné normály, indexy a přístup k bateriovému slotu. Kontroly původního jističe i pojistek prošly. Skutečný vzhled při různém osvětlení je ještě nutné ověřit ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods. Server i klienti stejná verze.
