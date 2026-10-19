# Modular Switchboards 0.12.83

Do bateriového modulu se přenáší celý původní držák APC jako jeden nativní mesh a jeden renderer. Výběr pouze omezí seznam vykreslovaných trojúhelníků na držák; původní vertexová data se neregenerují. Zůstávají původní vertexové indexy, formáty a offsety všech atributů, všechny UV kanály, normály, tangenty a případné vertexové barvy/další data. Zdrojové materiálové sloty a MaterialPropertyBlock se přenášejí beze změny. Žádné samostatně přebarvované kontakty ani náhradní vanička z0.12.82 se nevykreslují.

Přenos kopíruje kompletní GPU vertexové buffery zdrojového APC a po nastavení indexů je za běhu porovná bajt po bajtu. Shodovat se musí i layout atributů a stride streamů. Zdrojový mesh/material APC se nemění. Původní držák se jednotně zmenší a usadí do našeho dvoupozicového pouzdra; mezikus ruší nerovnoměrné vizuální měřítko modulu. Přední výplň čtyř rohů je zachovaná.

Skutečný bateriový slot, orientace a měřítko vloženého předmětu, filtry, náboj, nabíjení a záloha se nemění. Pojistkové moduly zůstávají zachované.

Ověření: Release build bez chyb a varování. Offline test na původním1971vrcholovém APC potvrdil všech134 původních trojúhelníků držáku a původní vertexové indexy. Geometrické/slotové kontroly a1000kontrol kompenzace měřítka prošly. Kontrola GPU bufferů proběhne až při skutečném načtení do Unity; zde hra neběží a výsledný vzhled ještě není vizuálně potvrzený.

Při startu se vytváří malý report ModularSwitchboards-apc-holder-native.json v persistentDataPath hry. Uvádí skutečné atributy, materiály, shadery, textury a úspěch porovnání bufferů, aby případná další závada byla dohledatelná.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards v mods. Server i klienti stejná verze.
