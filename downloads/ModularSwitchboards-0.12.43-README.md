# Modular Switchboards 0.12.43

Žlutá páčka znovu používá původní APC UV, materiály a property blocks včetně potisku. U ostatních výkonů se zachovává původní UV a mění pouze nativní barevný index. Dodatečné ON/OFF mesh nápisy se na nativní páčku nepřidávají. Výsledné přebarvení a orientaci původního potisku je nutné ověřit ve hře.

Koncovky pojistek mají samostatné kopie materiálů s bílým indexem, bílé renderer property blocks a nejsou registrované do automatického nativního přebarvování. Předchozí 0.12.42 ve hře stále zobrazovala černé koncovky; tuto opravu je nutné vizuálně ověřit. Barvy středů, elektrika, inventář a ukládání se nemění.

Release sestavení: 0 chyb a 0 varování. Produkční geometrie a přepínání stavů pojistek prošly testem s náhradami Unity objektů. Skutečný Unity render zde není dostupný.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards ve složce mods. Server i klienti musí používat stejnou verzi.
