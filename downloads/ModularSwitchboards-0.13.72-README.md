# Modular Switchboards 0.13.72

## Náhled Emergency Stop Label

Stavební náhled štítků nyní používá existující ModelBlueprint: skutečný model se všemi materiálovými částmi sloučí do jediné části pro nativní zelený/červený wireframe. Emergency Stop Label měl první submesh prázdný a geometrii ve druhém, takže jednobarevný náhled nebyl vidět. Oprava se týká Door Label, Emergency Stop Label i DIN štítků; živé modely a jejich materiálové části se nemění. Inner cover používá stávající dynamický náhled. Barvu platnosti a samotné umístění nadále řídí hra.

## Drobné bílé tečky na držáku

Černý kroužek Door Label má otvor s poloměrem15.8mm místo16.1mm: lehce zasahuje pod zadní obrubu LED/round switche o poloměru16mm, takže se tenkou spárou nemá ukazovat světlý podklad. Přední plocha držákuZ1.2mm leží za předkem obruby; čočka i rukojeť zůstávají volné a klikatelné. Černé vlastní materiály štítků mají vypnuté specular highlights a glossy reflections, aby se na hranách netvořily bílé odlesky. Světlá textová vložka se nemění. Ikona Door Label aktualizovaná.

U bílých teček není bez živé hry možné potvrdit úplné odstranění; zkontroluj pod různým úhlem a osvětlením.

## F1 a krabice kitu

Emergency Stop Label je nově zařazený do F1 Electronics / Modular Switchboards i do vyhledávání emergency/stop/label a českých výrazů. Původně chyběl explicitní záznam v StationpediaCatalog.

Labels kit má nový vizuální obsah v původní krabici:36 DIN štítků ve třech šířkách,8 skutečných Door Label držáků a8 žlutých Emergency Stop kroužků. Původní geometrie krabice i společný atlas zachované;52 kusů podepřených, bez zavěšených dílů. Nová ikona odpovídá skutečnému obsahu.

## Ověření

Produkční build0chyb/0varování. 64 kontrol F1 katalogu/hledání včetně Emergency a opakovaného zařazování. Kontrola binárního Labels kitu: původní shell, správné rodiny obsahu,52 podepřených kusů, platné vrcholy/normály/indexy.22 kontrol skutečného ModelBlueprint včetně regrese prázdného prvního submeshe a geometrie až ve druhém, zachování zdrojového modelu, transformací a nativní zelené/červené.3839 kontrol geometrie/umístění štítků. Zachován audit všech6save registrací a8XML regresních kontrol z0.13.71.

Mřížka, kabely, ukládací formát a oprava registrace DoorLabelSaveData zůstávají. Živě ověř zelený/červený náhled Emergency, osazení, klikání a hrany LED držáků. Host a klienti stejnou verzi; před testem kopie savu. Záloha0.13.51 zachována.
