# Modular Switchboards 0.12.55

Oprava názvu bateriového slotu: společně se StringKey se z původního slotu APC přebírá také StringHash. Herní Localization.GetName(Slot) hledá překlad právě podle tohoto hashe; samotný textový klíč nestačil a vedl k chybovému označení <N:EN:Battery>. Typ baterie, procenta nabití a nativní akce zůstávají zachované.

Ověření: Release build bez chyb a varování. Kontrola původní implementace Localization.GetName(Slot) potvrdila vyhledávání v SlotsName a FallbackSlotsName podle StringHash. Zobrazení překladu je třeba potvrdit ve hře.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards v mods. Server a klienti stejná verze.
