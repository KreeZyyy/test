# Modular Switchboards 0.12.57

Oprava dutiny bateriového modulu podle dodané diagnostiky 0.12.56. Velká baterie používá původní battery_cell_big, původní spaceships_dif a nativní zelený stavový materiál. Měřítko je rovnoměrné .3702079 a bez záporného determinantu. Diagnostika potvrdila název Battery a shodný lokalizační hash 529780018 s APC.

Plný zadní blok modulu a šedá deska zasahovaly do skutečné baterie: zadní hrana velké baterie je při naměřené pozici přibližně z=.014096 m, dosavadní tělo sahalo k z=.0391 m a deska byla kolem z=.0397 m. Modul má nyní skutečnou dutinu s tenkou zadní stěnou a šedým podkladem za baterií. Zásuvka, vložená baterie, její původní materiály a měřítko zůstávají zachované. Jde o odstranění prokázaného geometrického průniku; zda tím zmizí všechny hlášené vizuální artefakty, je třeba potvrdit ve hře.

Ověření: Release build bez chyb a varování; 25 paprsků přes zachycený prostor velké baterie ověřuje, že tělo nepřekračuje její zadní rovinu. Fixture 134 původních trojúhelníků zásuvky i produkční geometrické kontroly pojistek prošly. Elektrické chování se nemění. Omezená diagnostika z 0.12.56 zůstává k dispozici.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
