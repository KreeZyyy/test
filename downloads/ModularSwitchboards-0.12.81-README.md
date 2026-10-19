# Modular Switchboards 0.12.81

Bateriová zásuvka se vrací k původnímu vzhledu APC včetně původních šesti zlatých kontaktů. Šedé ploché náhradní kontakty z0.12.80 jsou odstraněné. Zásuvka obsahuje všech134 původních trojúhelníků:86 pro tělo a48 pro kontakty. Přesné UV souřadnice jsou obnovené z dodané reference APC.

Za běhu se použije skutečný původní materiál APC, jeho textura, shaderové nastavení, globální i dílčí MaterialPropertyBlock a původní nastavení stínů/probes. Materiál APC se nemění. Na zásuvku se neaplikuje šedá/černá paleta pouzdra ani vymyšlený bílý či zlatý materiál.

Čtyři rohové mezery mezi osmibokým obrysem APC a obdélníkovým otvorem DIN jsou nově vyplněné v rovině předního rámečku. Výplň používá materiál čela pouzdra a respektuje původní osmiboký otvor zásuvky.

Měřítko a umístění v DIN modulu, skutečný bateriový slot, vložení/vyjmutí, kapacita a nabíjení zůstávají stejné. Opravené pojistky z0.12.79 se nemění.

Ověření: Release build bez chyb a varování. Produkční geometrické testy ověřují všech134 původních trojúhelníků vůči APC, šest pozic kontaktů, orientaci, UV pro všech402 vrcholů, výplň všech čtyř rohů v přední rovině a původní usazení baterie. Obnovené UV jsou přímo z dodaného exportu; herní barvu dodává originální materiál/textura načteného APC. Vzhled a světlo je ještě potřeba potvrdit ve hře, protože zde neběží Unity scéna.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
