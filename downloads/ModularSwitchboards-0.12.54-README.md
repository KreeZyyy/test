# Modular Switchboards 0.12.54

Bateriový modul nyní používá původní kontextový název slotu místo vlastních Insert battery / Remove battery. Přední interakční plocha pokrývá celou zásuvku a leží před jejím čelem, aby paprsek při míření na baterii vybral nativní slot a jeho herní tooltip. Nativní HandleSwitch zajišťuje Take, typ baterie, text slotu a nabití stejně jako u APC, včetně podmínek pro obsah ruky. Vystředění, velikost, nabíjení a zapojení se nemění.

Ověření: Release build bez chyb a varování; geometrické testy zásuvky a pojistek prošly. Rozbor původního Thing._HandleSwitchFreeHands a Tooltip.SetValuesForInteractable potvrdil původní cestu pro popisky baterie. Skutečné míření, tooltip a ovládání ještě vyžadují ověření ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods. Server a klienti stejná verze.
