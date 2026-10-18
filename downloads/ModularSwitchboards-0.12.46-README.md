# Modular Switchboards 0.12.46

Přepracovaný vzhled pojistky a držáku. Vložka má hladký 32segmentový barevný váleček s plynulými bočními normálami a o něco subtilnější bílé koncovky. Spálená vložka si zachovává přerušený očazený střed. Barvy páček z0.12.45 se nemění.

Koncovky nyní používají vlastní běžný herní shader StandardInstanced s Texture2D.whiteTexture a explicitně bílou barvou, kovovostí0 a leskem0.20. Už nepoužívají Custom/StandardTextureArray ani paletové property blocks. Původní herní materiály se nemění. Nový export0.12.45 potvrdil, že kovovost0/lesk0.18 byly skutečně použité, ale vizuální problém přetrvával; změna shaderu je nová cesta vyžadující kontrolu ve hře, ne definitivně prokázaná příčina.

Kontakty jsou vlastní trvale aktivní objekt FuseContacts, oddělený od barevného středu i koncovek vložky a automatického přebarvování. Mají dva otevřené kovové úchyty nahoře/dole a samostatný světle šedý materiál. Jsou i ve stavebním náhledu. Prázdný držák nechává kontakty viditelné; koncovky a vložka se zobrazují pouze při osazení nebo ve spáleném stavu. Zadní prohlubeň je světlejší, zachovaná obálka modulu a místa kabelových vstupů.

Diagnostika zůstává a nově zahrnuje také geometrii/UV/normály samostatných kontaktů. ModularSwitchboards-fuse-diagnostics.json se ukládá do Application.persistentDataPath; konzole vypíše přesnou cestu u FUSE DIAG saved. Jednou za kombinaci výkon/stav, maximálně20 vzorků. Elektrika, ochrany, inventář, vkládání jednoho kusu ze stacku, kity a ukládání se nemění.

Ověření: Release build0 chyb/varování. Geometrický test tentokrát používá skutečný produkční RoundedGeometry, ne náhradní nezaoblené krabice. Kontroluje dutý střed, všechny mesh indexy/obálku, čtyři čelní paprsky na horní/dolní úchyty proti úplné geometrii rámu (kontakt musí být vpředu), fyzickou mezeru spálené vložky, odstranění paletových bloků z koncovek a přepínání prázdná/zdravá/spálená/odstraněná. Herní objekty jsou náhrady; výsledek shaderu a nasvícení stále potřebuje kontrolu ve skutečné Unity hře.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards ve složce mods; server i klienti musí mít stejnou verzi. Zkontroluj plný i prázdný držák zepředu a zešikma.
