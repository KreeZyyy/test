# ModularSwitchboards 0.12.89 — barvení a demontáž modulů

Herním sprejem lze nyní barvit těla jističů, pojistkových držáků, bateriových modulů a analyzátorů. Zamiř na modul v otevřeném rozvaděči a použij sprej běžným herním způsobem.

Barví se pouze bílé tělo (materiálová role 1 hlavního DinBreakerModel). Páčky zůstávají podle výkonu, pojistkové vložky a jejich bílé čepičky si ponechávají barvy; kontakty, šrouby, čela a displeje zůstávají původní. Nativní APC držák i čelo analyzátoru jsou vynechané z automatického přebarvování.

Používá se původní herní CustomColor, CustomColorMapping a replikace. Nové moduly jsou bílé. Staré uložené moduly, které dosud měly napevno bílé tělo, se při prvním načtení převedou na výchozí bílou; dříve skrytá barva původní šablony se nezobrazí. Nový BodyPaintVersion=1 rozlišuje nově uložené barvy, takže následující načtení hráčovu barvu zachovají. Vlastní názvy se zachovávají.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards. Závislosti ponech. Ověřeno sestavení a test skutečného DTO a migrace uložených modulů: starý save, nová barva po XML roundtripu, jméno/stav jističe a nezměněná barva skříně. Barvení sprejem a síťovou replikaci je potřeba ověřit ve hře; Unity zde nebylo spuštěno.

Demontáž: při dokončení demontáže modulu vrtačkou se automaticky odstraní jeho připojené vnitřní vodiče a odpovídající počet kabelových jednotek se vrátí přes původní herní CreateOrStack do druhé ruky nebo do světa. Ostatní větve zůstávají nedotčené. Náhled, zrušená akce ani poškození kabel nevracejí; refundace běží jen na autoritě a před závěrečným deregistrováním, takže se neopakuje. Před vyjmutím držáku je stále třeba vyndat vloženou pojistku nebo baterii.

Ověřen i produkční hook demontáže a odstranění vodičů: přesná refundace, síťová autorita, ochrana při poškození, zachování ostatní větve, smazání rozpracovaného výběru a opakované volání bez dvojího vrácení.
