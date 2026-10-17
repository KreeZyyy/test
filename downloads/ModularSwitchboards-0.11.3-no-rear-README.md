# Modular Switchboards 0.11.3 — bez zadního korpusu

Testovací úprava původního DLL 0.11.3: vypnuté vytváření tmavého zadního korpusu včetně jeho úchytů. Bílá skříň, přípojky a ostatní metody zůstávají zachované. Přípojky zatím nemají podpěry zadního korpusu.

Stáhni `ModularSwitchboards-0.11.3-no-rear-test.zip`. Vypni hru, zazálohuj původní mod a nahraď složku `ModularSwitchboards` v `Documents/My Games/Stationeers/mods/` složkou ze ZIPu. Závislosti ponech stávající. Klient a server potřebují stejný balíček.

DLL bylo upraveno přímo, bez nové kompilace. Změnilo se pouze 5 bajtů uvnitř metody `InstallRearBody`; metoda nyní ihned vrací řízení. Integrita ZIPu a nezměněné bajty mimo tuto metodu ověřeny. Ve Stationeers zatím netestováno.

Odpovídající zdrojáky vycházejí z přesné verze 0.11.3. `InstallRearBody` je prázdná metoda a `CabinetRearModel.cs` byl odstraněn. Zdrojový ZIP obsahuje stejné upravené DLL; není to výsledek nového sestavení.
