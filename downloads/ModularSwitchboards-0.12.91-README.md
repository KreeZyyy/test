# ModularSwitchboards 0.12.91 — barvení vnitřních vodičů

Základ: uživatelem přiložená 0.12.89, shoda zdrojového ZIPu ověřena SHA256. Proužky jističů z 0.12.90 nejsou součástí této verze. Zůstává barvení celých těl modulů a demontáž s vrácením připojených vnitřních vodičů.

Nově: otevři rozvaděč, vezmi běžný barevný sprej a zamiř přímo na vnitřní vodič. Primární akcí přebarvíš pouze tento vodič. Lze použít i zapnutou Spray Gun s barvou. Vodiče se základně zobrazují červené. Výběr vodiče štípačkami se dočasně zvýrazní žlutě a pak se vrátí uložená barva.

Barvení používá nativní materiál, dobu použití, spotřebu a zvuk spreje. Stejná barva se znovu nespotřebuje; prázdný sprej, vypnutá pistole, zavřená skříň a neúspěšná spotřeba nic nepřebarví. Náhled a klientská simulace barvu nemění ani nespotřebují. Kliknutí mimo vodič ponechává původní barvení těla/skříně.

Barva je uložená zvlášť u každého vodiče (ColorIndex) a přenáší se s drátováním; zapojení a průchod výkonu se nemění. Staré XML savy a starší síťový formát lze načíst, jejich vodiče se zobrazí červené. Přetrasování uloženou barvu zachovává. Neplatný barevný index se bezpečně vykreslí jako výchozí červená bez odstranění zapojení.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards. Závislosti ponech. V multiplayeru musí mít host i hráči tuto verzi, protože zápis síťového drátování nově obsahuje barvy.

Ověření: sestavení proti dodaným herním knihovnám, produkční logika spreje a zásahu vodiče (náhled, klient/server, spotřeba, jeden vodič, ochrana barvy skříně, prázdný/vypnutý sprej, chybná spotřeba, zavřená skříň, netrefený vodič), XML a síťové roundtripy barvy včetně starých formátů, přetrasování s barvou a původních 10044 kontrol drátování + 2023 kontrol baterie. Skutečný Unity renderer, časování herní akce spreje a živý multiplayer zde nebyly spuštěny a vyžadují herní kontrolu.
