# Modular Switchboards 0.12.59

Usazení bateriového konektoru a rámu podle APC. Zásuvka už není nezávisle zmenšená na40mm šířku: původní výška zásuvky se jednotně přizpůsobí skutečné výšce otvoru rámu60.75mm. Zásuvka a vložená baterie používají stejnou transformaci. Čelo rámu vychází z původní přední roviny APC z=.211m, nikoliv ze zadní hrany vybraného meshe. Tím zůstává zachovaná původní vzdálenost mezi čelem APC a jeho bateriovým slotem při daném měřítku.

Hloubka modulu se přizpůsobuje originálním kompatibilním bateriím: jejich mesh bounds se převedou původní polohou slotu a nejzadnější bod se umístí6mm před základnu modulu. Zadní stěna a šedý podklad jsou za tímto prostorem; čelo a boky rámu se protáhnou do odpovídající hloubky. Modul zůstává3 DIN pozice. Původní baterie, textury, UV, stavové materiály, nabití a ovládání zůstávají zachované; zásuvka je uprostřed. IN/OUT ani elektrické chování se nemění.

Ověření: Release build bez chyb a varování. Původní APC fixture134 trojúhelníků potvrzuje shodnou výšku zásuvky s otvorem, vystředění a stejný relativní odstup čela a slotu jako u APC. Zachycená velká baterie má zadní hranici6mm nad základnou;25 paprsků kontroluje volný prostor zadní stěny. Produkční geometrické kontroly pojistek také prošly. Vzhled a usazení se musí potvrdit ve hře; odstranění všech hlášených artefaktů nelze ověřit bez Unity scény. Rozšířená omezená diagnostika zůstává dostupná.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
