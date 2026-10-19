# Modular Switchboards 0.12.79

Svorky pojistek jsou nově vytvořené jako dva hranaté držáky. Každý má zadní podpěru, dvě boční čelisti se širokou plochou obrácenou dopředu a koncovou zarážku. Původní kruhové objímky jsou odstraněné. Zaoblení hran je malé, aby zůstala dostatečně široká rovná čelní plocha.

Předchozí zakřivené objímky měly zepředu velkou část dobře osvětlených ploch zakrytou čepičkou; viditelné boky byly obrácené hlavně do stran. Nová geometrie tento konkrétní problém obchází. Ponechává skutečný materiál pouzdra se šedou herní paletou z0.12.78. Nejde o kovový ani samostatný bílý shader.

Vanička, čepičky, barevná pojistka, baterie a elektrické chování jsou beze změny. Čelisti jsou oddělené od čepiček dostatečnou mezerou a montážní deska leží za jejich zadní hranou.

Ověření: Release build bez chyb a varování. Produkční geometrický harness ověřil36 čelních paprsků přes kompletní držák včetně vložené pojistky: zasahují přímo viditelné svorky, jejich normály míří dopředu a nezakrývá je čepička ani pouzdro. Rovná část každé čelisti přesahuje3pixely při čelním promítnutí40pixelového modulu; jde o geometrickou kontrolu, nikoli simulaci herního shaderu. Prošly kontroly mezer, normál, obálek a původní kontrola bateriové geometrie. Náhled vychází ze skutečných vrcholů, ale není snímkem z Unity. Skutečný vzhled při různém světle a vzdálenosti je potřeba potvrdit ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods. Server a klienti musí mít stejnou verzi.
