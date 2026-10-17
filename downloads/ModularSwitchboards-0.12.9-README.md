# Modular Switchboards 0.12.9 — model IN z Automated Ovenu, původní velikost

K potvrzenému základu přidává model šedého napájecího panelu z dokončeného Automated Ovenu: původní tělo, blesk a dva viditelné kontakty. Původní velikost 98.002 × 176.432 × 127.756 mm, bez škálování; 92 trojúhelníků a 169 původních vrcholů. Všechny čtyři samostatné komponenty výběru jsou zachované celé. Neobsahuje červený kabel, jiné díly pece ani nový přibližný symbol.

Usazení: požadovaná horní buňka ve středu je (0,0.5,0) ve stejné soustavě jako původní nativní kabelový layout modu. Skutečný kotevní bod a osa se odvodí přes NativeCableLayout.Read z nativního kabelového prefabu. Původní napájecí kotva pece přejde přesně na tento bod. Čelo panelu míří po vypočtené ose nahoru. Model sleduje kabelovou mřížku: vizuální odsazení skříně podle stěny se odečítá, aby se panel vůči mřížce neposunul. Šířka zůstává v ose skříně.

Metadata komponenty OvenInputPanelMetadata: SocketPoint, SocketAxis, CableCell, BodyCell, NativeSocketPoint, NativeSocketAxis, FunctionalConnection=false. Nevytváří Connection, nepřidává síť, nepřenáší proud a neumožňuje funkční připojení kabelu. Jde pouze o model a připravené údaje; okolní uchycení a další napojení se budou řešit postupně.

Geometrie a UV se přebírají z původního herního prefabu, stejně jako materiály a property blocks. Model má vlastní kolizi a bounds. Původní geometrie bílé skříně, šedého pláště a zadní krabičky zůstává; Cabinet.meshbin je beze změny oproti potvrzené 0.12.7.

Při prvním načtení hledej v Player.log `IN model only: original Oven panel size; socket=`. Log vypíše skutečný bod, osu a buňky z herního prefabu. Pokud výběr nebo layout neodpovídá ověřenému vzorku, panel se nevloží a objeví se `Oven IN model unavailable; cabinet preserved`. Ostatní části modu pokračují. Export pece se již automaticky nespouští.

Art/OvenInputPanel.blend a GLB obsahují samostatnou referenci s původním atlasem, nikoli předstíraný výsledek herního zarovnání. Statický F1 náhled skříně zatím panel nezobrazuje, protože jeho umístění se určuje z nativního kabelu až za běhu.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Záloha potvrzené 0.12.7 je v repozitáři. Ponech závislosti; klient a server potřebují stejnou verzi.

Ověřeno: kompilace proti dodaným DLL, 0 chyb a 0 varování; úplný výběr nativních komponent, zachování velikosti a původního Cabinet.meshbin, matematické odečtení wall-fit offsetu pro dvě čelní orientace, různá odsazení a otočení, integrita ZIPů. Skutečný socket vypočtený herním prefabrikátem, kolize s okolím a vizuální usazení musí potvrdit test ve hře. Funkční kabelové připojení není implementované.
