# Modular Switchboards 0.12.30 — oprava pádu registrace při T krytu

Oprava výjimky Native output grid does not leave space for the T housing, která v 0.12.29 přerušila PreparePrefabs a následně způsobila chyby registrace lišt, jističů, svorkovnic a receptů.

Spodní přípojky se nově počítají vůči explicitní buňce těla rozvaděče (0, -0.5, 0), nikoli přímo vůči počátku nativního kabelového prefabu. Nativní reciproční socket se přeloží podle své BodyCell, takže se odstraní původní souřadnicový posun. Viditelná ústí leží uprostřed společné stěny mezi odpovídající buňkou kabelu a těla, logická buňka zůstává oddělená. Pro dolní boční řadu jsou tak oba otvory v půlmetrové řadě a nemají se sbíhat uprostřed nebo zasahovat do zadní krabičky.

Model T nadále přebírá výšku a hloubku nativního konektoru, zachovává opravené přední plochy/UV a je pouze modelem. Výstupní Connection se neregistrují. Horní Input zůstává funkční.

Instalace spodního modelu je nyní oddělená od přípravy ostatních prefabů. Pokud selže, uklidí své části, obnoví původní seznamy kolizí a propojených objektů a nechá pokračovat registraci skříně, Inputu, DIN lišt a jističů. Případná další chyba vypíše skutečné rozměry a souřadnice T místo obecného hlášení.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti.

Ověření: kompilace bez chyb a varování. Produkční ReadForBody ověřeno pro 54 různých počátků nativního prefabu a oba směry: pevná spodní řada, samostatné buňky, poloha ústí a svislá vůle. Produkční T geometrie ověřena ve 33 variantách včetně reálných rozměrů odvozených z APC reference. Produkční instalační obálka ověřena při třech vložených chybách a úspěšném průchodu: úklid a zachování původních seznamů. Zkoušky používají zástupné objekty; nejsou spuštěním Unity ani hry. ZIPy ověřeny.

Ve hře ověř především dokončení načtení modu a dostupnost skříně, lišt i jističů. Potom polohu spodního T a obou ústí. Pokud model znovu selže, nové hlášení Lower output MODEL unavailable obsahuje konkrétní rozměry, ale nemá zastavit registraci ostatních částí.
