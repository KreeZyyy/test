# Modular Switchboards 0.12.71

Zásuvka baterie má přímo původní tvar APC místo hranaté prohlubně z0.12.70. Profil je převzatý z původního exportu APC:134 celých trojúhelníků. Rozdělení podle souvislých částí určuje86 trojúhelníků těla a šest skutečných kontaktů po8 trojúhelnících. Tělo má vlastní tmavě šedý materiál a kontakty samostatný zlatý materiál. Nepoužívají se původní atlasové UV ani přebarvování textury, které měnily vzhled detailů. Souřadnice a proporce jsou z APC, nikoliv ručně navržená aproximace. Profil je vložený přímo do DLL.

Nativní funkční slot APC, skutečná baterie, větší měřítko z předchozí verze, náboj, nabíjení, záloha, ovládání a2pozicové tělo zůstávají. Původní odstup baterie a zásuvky je tím společně zachovaný; zásuvka a baterie mohou podle původního profilu vystupovat před čelo pouzdra.

Kontakty pojistek jsou světlejší stříbrné: barva RGB(.82,.85,.87), bez metalického útlumu a s mírnějším leskem. Jejich zmenšený profil a zasazení z předchozí verze se nemění. Tato úprava má zlepšit viditelnost ve stínu, nepřidává vlastní světlo ani záření.

Ověření: Release build bez chyb a varování. Geometrická kontrola potvrzuje86/48 trojúhelníků a šest kontaktových poloh. Každý mapovaný vrchol odpovídá původnímu APC exportu do1 mikrometru. Prošly původní kontroly těla bez spár, otvoru, vnitřních stěn, polohy baterie, jejího slotu a kontaktů pojistek. Vzhled šedého těla a zlatých/stříbrných materiálů je třeba potvrdit ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
