# Modular Switchboards 0.13.74

## Montáž Labels kitu

Zaměřeno na nasazování vnitřních i dveřních štítků. Demontáž, skutečné hitboxy již postavených štítků a akce Labelleru se nemění.

Vnitřní štítky nyní při CanConstruct synchronizují přichycenou pozici a rotaci s PlacementBoard.CursorGrid/CursorRotation, stejně jako ostatní board díly. Dříve se posunul pouze náhled, ale statická montážní mřížka mohla zůstat na původním zásahu. Při ztrátě aktuálního boardu se odmítne starý cíl.

Původní pomocná plocha35x34cm přes skoro celý vnitřní kryt je nahrazena dvěma úzkými montážními pásy35x2.6cm, nad příslušnými řadami. Oba collidery patří ke stejnému LibConstruct label boardu. Pomocné plochy se zapnou jen v montážním režimu se správným Labels kitem a vnitřním label kurzorem, při otevřené skříni. Nativní BuildState je samovolně nezapíná. Dveřní montážní plocha má stejnou kontrolu správného Labels kitu a Door/Emergency kurzoru; oba typy se vzájemně nepletou.

Před výběrem cíle se tyto pomocné plochy znovu zkontrolují. S Labellerem, drillem, prázdnou rukou nebo jiným kitem nemají překrývat skutečný štítek. Samotné přejmenování i demontáž používají původní obsluhu.

Zvýraznění při stavění Door Label, Emergency Stop Label a vnitřních štítků přebírá vlastní Bounds štítku a transformaci přichyceného náhledu, nikoliv rozměry celé montážní desky. Nativní zelená/červená barva i viditelnost a pomůcky zamykání se nepřepisují. Celý skutečný zelený model z předchozích oprav zůstává.

## Ověření

Produkční build proti herním DLL0chyb/0varování.90 kontrol skutečné politiky a CanConstruct vnitřních labels včetně shody náhledu/mřížky a odmítnutí starého boardu, názvů a demontážní obsluhy.29 kontrol skutečného výběru a vstupní politiky montážních ploch včetně jejich vypnutí mimo montáž, přepnutí Door/DIN a zavřené skříně.26 kontrol ModelBlueprint/preview včetně přesných rozměrů a transformace label zvýraznění. Audit6save registrací a8XML kontrol zachován.

Živě ověř přichycení a potvrzení vnitřních štítků ve všech třech šířkách, obsazené pozice, přepnutí na Door/Emergency, velikost zvýraznění, zamykání a poté Labeller/drill. Unity/game runtime není dostupný. Mřížka, rozmístění již postavených dílů, save formát, kabely a opravy0.13.73 se nemění. Před testem kopie savu; host i klient stejnou verzi. Záloha0.13.51 zachována.
