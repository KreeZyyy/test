# Modular Switchboards 0.12.20 — široký tunel od krabičky až nahoru

Tunel má původní šířku horního panelu (cca 98 mm) už od horní plochy střední krabičky. Hloubka přechází přímo od krabičky k celému půdorysu panelu po celé výšce, bez úzkého sloupku a náhlého horního rozšíření. Horní plocha krabičky zůstává rovná v původní výšce. Její stínovací normály jsou oddělené od bočních stěn a tunelu: odlesk už nemá vytvářet dojem oblého náběhu. Malé obvodové rádiusy 4 mm jsou zachované.

Mění se skutečná geometrie a kolize meshe vytvářeného modem při načtení, v Source/OvenInputSupport.cs. Nejde o změnu textury. Statické referenční Art modely nejsou výsledný runtime model. Podstavec s tunelem tvoří uzavřený povrch až po otevřenou horní hranici pod konektorem; šroubovaný kryt APC zůstává původní.

Otočení horního panelu z 0.12.19 je zachované, otvor a kotevní bod beze změny. Bílá skříň beze změn. Pouze model, bez funkční elektrické přípojky a vnitřního drátování.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Potvrzená záloha 0.12.7 zůstává na GitHubu.

Ověření: kompilace bez chyb a varování; produkční výpočet pro pět wall-fit posunů, plná šířka tunelu od krabičky, přímý průběh hloubky, rovná plocha, oddělené normály, topologie po sjednocení shodných pozic, orientace a nedegenerované trojúhelníky. 701 vrcholů včetně stínovacích švů, 1260 trojúhelníků. ZIPy ověřeny. Vzhled je potřeba potvrdit ve hře.
