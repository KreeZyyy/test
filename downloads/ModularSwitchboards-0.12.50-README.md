# Modular Switchboards 0.12.50

Při skutečném přepálení DIN pojistky zazní jednou CableSpark, stejný nativní zvuk, který používá CableRuptured.Awake při shoření kabelu. Volání je po spotřebování vložky a nastavení Tripped, pouze v autoritativním DinBreaker.Trip pro pojistkový držák. Vypnutí jističe, vložení/vyjmutí pojistky, náhled, načtení uložené hry ani připojení klienta nový zvuk nespouštějí. Každá nová přepálená vložka může zaznít znovu.

Použitá herní cesta Thing.PlayNetworkSound → AudioEvent.Create provede místní přehrání a zařadí přechodnou zvukovou událost pro klienty. Nejde o uložený stav. Headless server nevykonává místní přehrání. Žádný nový audio asset, jiskry, požár ani zničení skutečného kabelu se touto změnou nepřidávají.

Ověření: Release build0 chyb/varování;59 kontrol produkčního katalogu, HandleSwitch, Trip a save/join/update s náhradami herních objektů. Nové kontroly ověřují jedno volání při přepálení, žádné opakování téhož tripu, opakování až pro další vložku, žádnou událost z klientské mutace, jističe, načtení, join ani aktualizace stavu. Hash a síťová cesta byly ověřené v dekompilované herní implementaci. Skutečnou slyšitelnost, prostorový zvuk a multiplayer je nutné ověřit ve hře.

Vzhled a odstranění automatických diagnostických exportů z0.12.49 zůstávají. Tato změna NEřeší hlášené shoření kabelu po opětovném vložení pojistky; pořadí elektrických ochran zůstává k samostatnému prověření.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards ve složce mods. Server i klienti stejná verze.
