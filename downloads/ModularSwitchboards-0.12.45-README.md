# Modular Switchboards 0.12.45

Obě úpravy pojistkového modelu: koncovky vložky mají bílý nekovový matný povrch (_Metallic0, _Glossiness0.18). Diagnostika0.12.44 potvrdila správný bílý index6 bez přepisování, ale zděděnou kovovost1 a lesk0.858. Výsledek nového povrchu je nutné vizuálně ověřit ve hře; přesná příčina dřívějšího černého vzhledu není samotným exportem definitivně prokázna.

Držák má vlastní trvale přítomné U kontakty nahoře i dole, vysunuté z prohlubně k vložce. Při vyjmutí zůstávají kontakty držáku viditelné; pouze koncovky a tělo vložky mizí. Kontakty jsou součástí pevného Housing mesh a nepřepínají se se stavem pojistky. Zachována dutá střední část, modulová obálka a vstupy kabelů.

Páčky zelená/oranžová/červená/fialová jsou ztmavené a méně syté, aby se přiblížily tlumeným barvám vložek. Relativní stínování původní textury, neutrální ON/OFF a alpha se zachovávají. Žlutá zůstává původní podle předchozího požadavku. Přesná shoda s pojistkami závisí také na rozdílném materiálu a osvětlení; není tvrzená bez vizuálního testu. Automatická diagnostika z0.12.44 zůstává. Elektrika, přetížení, kity, inventář a ukládání beze změny.

Kontroly: 1010 případů produkčního převodu pixelů proti skutečnému Unity Color ověřuje odstín, ztlumení jasu/sytosti, relativní stínování, neutrální potisk, alpha a původní žlutou. Release sestavení0 chyb/varování; produkční geometrie dutiny, barevné a přerušené vložky, koncovek, indexů a obálky; čtyři kontrolní paprsky na pevné kontakty nahoře/dole ověřují jejich přední hloubku; všech pět kopírovaných materiálů má kovovost0 a lesk0.18; přepínání prázdná/zdravá/spálená/odstraněná. Testy používají náhrady Unity objektů a konzervativní krabičky, ne skutečný Unity render.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards ve složce mods. Server i klienti musí mít stejnou verzi. Pro porovnání vzhledu osazení/vyjmutí nech vždy krátce zobrazit držák. Diagnostika ModularSwitchboards-fuse-diagnostics.json se ukládá do Application.persistentDataPath; přesnou cestu vypíše konzole jako FUSE DIAG saved.
