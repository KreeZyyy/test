# ModularSwitchboards 0.12.86 — Cable Analyzer diagnostika

Tato verze přidává pouze automatický export původního Cable Analyzeru; nový třípozicový modul ještě neregistruje. Předchozí změny štítků, baterie a pojistek zůstávají zachované.

1. Při vypnuté hře nahraď složku ModularSwitchboards testovacím balíčkem. Závislosti LibConstruct a LaunchPadBooster ponech.
2. Spusť hru a nech doběhnout načtení prefabů. Analyzátor nemusíš stavět ani připojovat na kabel.
3. V datové složce hry vznikne ModularSwitchboards-CableAnalyzer-reference.zip. Přesnou cestu vypíše log s označením ANALYSER DIAG upload this file.
4. Pošli tento ZIP. Při chybě exportu pošli příslušné řádky ANALYSER DIAG z Player.log nebo BepInEx logu.

Export obsahuje JSON geometrie a UV, submeshe, materiály a shaderové vlastnosti včetně property bloků, hierarchii a odkazy komponent, transformace, popisy všech vertexových atributů a původní binární vertexové streamy. Podporované 2D textury přiloží jako PNG; nepodporované formáty nebo chyby jsou uvedeny ve výpisu. Originální prefab ani jeho materiály se nemění.

Zjištění z dodaných herních knihoven: třída CableAnalyser dědí DeviceCableMounted. CurrentLoad, RequiredLoad a PotentialLoad čte z CableNetwork. GetPassiveTooltip z nich vytváří Actual/Required/Potential; GetLogicValue zpřístupňuje PowerActual/PowerRequired/PowerPotential. Samotná třída nemá aktualizaci displeje. Případné další komponenty displeje musí potvrdit runtime export. Dva analyzátory připojené na tutéž síť proto samy neoddělí odběry jednotlivých větví našeho rozvaděče.

Cílový vzhled: tři DIN pozice, bílé tělo modulu, pouze displej a šedé čelo s bleskem z originálu, bez žlutého obalu. Výběr konkrétních ploch provedeme až podle exportu.

Ověřeno sestavení proti dodaným herním knihovnám. Unity export vyžaduje spuštění hry; zde nebyl spuštěn.
