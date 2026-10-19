# Modular Switchboards 0.12.61

Bateriový modul má čelo ve stejné hloubce jako ostatní DIN moduly (modelová rovina z=.0635). Zásuvka a baterie se nyní jednotně přizpůsobují výšce i dostupné hloubce, takže modul zbytečně nevyčnívá. Zachovaná je původní relativní poloha zásuvky a baterie z APC, plná šedá čelní deska, bílý kryt, zadní volný prostor a šířka2 DIN pozice. Materiály zůstávají společné s ostatními moduly.

Opravena překrytá interakční plocha: předchozí slot byl za přední hranou celkového BoxCollideru těla, takže míření vybíralo celý modul místo zásuvky. Kolider BatteryControl je nyní před nejpřednější částí těla a přísluší původnímu nativnímu slotu. Vložení/vyjmutí/výměnu nadále řeší původní HandleSwitch se stejnými podmínkami a typy baterií jako APC. Nabíjení, záloha, náboj a přenos stavu se nemění.

Ověření: Release build bez chyb a varování. Geometrický test kontroluje shodnou rovinu čela s DIN, interakční plochu před skutečným maximem těla, plnou čelní desku ze4 stran, volný prostor pro baterii,2slotovou šířku a původní relativní usazení APC. Produkční geometrie pojistek také prošla. Skutečné vložení baterie a vzhled je ještě třeba ověřit ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze. Miř na zásuvku s baterií v aktivní ruce v otevřeném rozvaděči; měl by se ukázat popisek nativního slotu namísto pouze názvu modulu.
