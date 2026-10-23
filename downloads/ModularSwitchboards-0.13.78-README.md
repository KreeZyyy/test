# Modular Switchboards 0.13.78 — čitelnější vnitřní popisky

Vnitřní štítky mají tučné písmo a menší okraje. Krátký název využije větší dostupnou plochu; dlouhý se podle skutečné šířky textu rozdělí do dvou řádků, pokud tím písmo získá alespoň12% velikosti. Přednost mají mezery mezi slovy; dlouhý identifikátor bez mezer se dělí bezpečně mezi Unicode textovými prvky. Uložený název se nemění. Rozložení se přepočítává jen při změně názvu nebo šířky štítku, nikoli každý frame.

Vnější Door Label, nouzové štítky, geometrie, montáž, demontáž i ukládání se nemění. Úpravy odlesků končí na stavu0.13.77 dle přání uživatele.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards ve složce mods; host i klienti stejná verze. Ve hře ověř krátký a dlouhý název pro1/2/3modulový vnitřní štítek a pojmenování s diakritikou. Unity runtime zde není dostupný; skutečná vizuální kontrola a fontové metriky vyžadují hru. Záloha0.13.51 zachovaná.

Ověření: Release build0 chyb/varování,217 kontrol produkčního rozložení textu s proporcionálními metrikami, včetně1/2/3šířek, krátkých názvů, dlouhých identifikátorů a diakritiky. Zdrojové soubory vnějších Door/Emergency štítků jsou identické s0.13.77.
