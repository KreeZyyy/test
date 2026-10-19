# Modular Switchboards 0.12.64

Vnitřek bateriové zásuvky je vrácený na původní APC mesh, původní UV a původní shader/materiálové nastavení. Odstraněné nahrazení materiálem čela a přemapování UV z0.12.63. Místo toho soukromá kopie původní textury přebarvuje jen světlé neutrální bílé pixely na šedé. Zlaté kontakty, barevné části, tmavé detaily a průhlednost se zachovávají. Nativní assety, UV a materiály vložené baterie se nemění; texture scale/offset a původní renderer blocks zůstávají zachované.

Hotové dvoupozicové tělo jističe bez dělicích spár, slot, náboj, nabíjení a záloha se nemění. Textura se připraví a uloží do cache jednou pro původní materiál, nikoliv při každém vložení baterie nebo při každém snímku.

Ověření: Release build bez chyb a varování. Test převodu potvrdil bílé pixely na šedé a zachování zlatých, tmavých, barevných a průhledných pixelů. Prošlo i1010 původních barevných případů. Skutečné zobrazení vnitřku zásuvky ještě potřebuje ověření ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
