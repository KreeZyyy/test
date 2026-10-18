# Modular Switchboards 0.12.21 — svislý tunel a rovná pata

Tunel má po celé výšce stejný půdorys horního panelu, včetně hloubky. Stěny jsou svislé, bez šikminy a bez náhlého rozšíření nahoře. Panel, jeho otočení a otvor zůstávají na místě.

Napojení na střední krabičku je nové: místo propojení odpovídajících rohů dvou různě posunutých obrysů se vodorovné plochy vypočítají podle skutečného rozdílu jejich půdorysů. Odkrytá horní plocha krabičky je rovná; případný přesah tunelu má vlastní rovnou spodní plochu. Uvnitř překrytí není víko. Oddělené normály vodorovných ploch zachovávají ostré stínování u paty, bez falešného zaobleného záhybu. Obvodové rohy zůstávají s malým 4mm rádiusem.

Mění se geometrie a kolize runtime modelu v Source/OvenInputSupport.cs. Statické Art reference nejsou výsledný sestavený model. Bílá skříň, původní šroubovaný kryt APC, výstraha i šrouby zůstávají beze změny. Pouze model, bez funkční elektrické přípojky a vnitřního drátování.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Potvrzená záloha 0.12.7 zůstává na GitHubu.

Ověření: kompilace bez chyb a varování. Produkční geometrie pro šest wall-fit posunů: přesná shoda dolních a horních X/Z souřadnic svislých stěn, plošný obsah a orientace vodorovného napojení proti průniku půdorysů, nedegenerované trojúhelníky a konečné souřadnice. Počty vrcholů a trojúhelníků se mění podle překrytí. ZIPy ověřeny. Vzhled je třeba potvrdit ve hře.
