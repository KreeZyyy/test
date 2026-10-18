# Modular Switchboards 0.12.31 — oprava opakovaného Output lug has no geometry

Výjimka vznikala v CabinetPowerOutputs.Fit volaném z CabinetWallFit.LateUpdate: přepočet vyžadoval živé MeshFilter komponenty u každého přímého potomka výstupního kořene. To je nevhodné pro náhled stavby, ve kterém mohou být komponenty původního modelu odstraněné nebo nahrazené blueprintem. Výjimka navíc zabránila dokončení wall-fit aktualizace a ta se znovu opakovala.

Oprava: skutečné lokální rozměry každého konektoru se změří a uloží do jeho CabinetOutputSocket při instalaci modelu. Wall-fit používá tyto uložené rozměry a transformy přesně dvou označených konektorů, nikoli všechny přímé potomky či znovu MeshFiltery. Náhled IsCursor přepočet T krytu přeskočí; používá nezávislý blueprint.

Runtime přepočet má vlastní obálku. Pokud narazí na další neočekávanou chybu, ponechá současný model, vypíše jednu konkrétní hlášku a další pokusy pro tuto instanci pozastaví. Nemá tak opakovaně zaplavovat konzoli ani bránit dokončení přizpůsobení zbytku skříně.

Rozměry, původní povrchy APC, poloha na mřížce a rozsah modelu zůstávají z 0.12.30. Spodní výstupy stále pouze model, horní Input funkční, vnitřní drátování zatím bez propojení.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti.

Ověření: kompilace bez chyb a varování. Produkční runtime obálka ověřena se zástupnými objekty: náhled bez modelové hierarchie se přeskočí, běžný přepočet proběhne a 100 opakovaných volání po vložené chybě způsobí pouze jeden pokus a jednu hlášku. Zkouška je v Verification/OutputRuntime. Integrita ZIPů ověřena. Náhled a postavenou skříň ještě vyžaduje ověřit ve hře.
