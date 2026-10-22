# Modular Switchboards 0.13.73

## Položení krabice kitu na zem

Herní akce PrecisionPlace (výchozí klávesa T, respektuje změnu přiřazení) nyní u našich šesti kitů přepne ze stavebního režimu přímo na nativní položení předmětu. Nejprve zruší stavební náhled/menu, přepne do PrecisionPlacement a zavolá původní UpdatePrecisionPlacement se skutečnou drženou krabicí. Platí také v normálním režimu před vlastními akcemi Cover kitu, aby jejich obsluha klávesu neblokovala. Pravé tlačítko a stavební menu se nadále používají pro stavění dílů.

Nativní cache náhledů položených předmětů je oddělená od stavebních náhledů. Před původním UpdatePrecisionPlacement doplníme chybějící nebo null záznam pouze pro naše kity z jejich vlastního Blueprintu, pod nativním rodičem dynamických kurzorů. Existující platný náhled se zachovává. Nativní kód dál řeší rotaci, potvrzení, zrušení a přesun skutečného předmětu i síťové zprávy; vlastní drop/spawn nepřidáváme.

## DIN lišta a zamykání náhledu

Blueprint lišty používá celý skutečný model sloučený do jediného submeshe. Viditelná geometrie byla v materiálových částech3/4 a původní jednobarevný náhled první části byl prázdný. U DIN lišty už neschováváme nativní výběrové zvýraznění, aby zůstalo vidět umístění a nativní pomůcky při zamykání. Snap, obsazenost a zelenou/červenou platnost nadále řídí stávající nativní/LibConstruct cesta.

## Barvení dveřních kabelů s krytem

Nasazený vnitřní kryt už neblokuje barvení kabelů na dvířkách. Vybraný kabel se klasifikuje stejně jako při vykreslení: dveřní je přístupný, kabel na desce pod krytem odmítnutý. Toto pravidlo používá náhled cíle, zvýraznění, dokončení podržení i autoritativní akce. Během podržení se znovu ověřuje stejný dostupný vodič. Spotřeba barvy, zrušení, zavřená skříň a vzdálenost mají původní kontroly. Omezení stavění/stříhání kabelů přes kryt se nemění.

## Ověření

Produkční build proti herním DLL0chyb/0varování. 19 kontrol skutečné obsluhy položení: změna režimu, zrušení konstrukce, jediné nativní zavolání, nastavená akce, cache všech šesti kitů, zachování existujícího náhledu, oprava null a izolace cizích předmětů.22 kontrol skutečného ModelBlueprint včetně zachování nativního zvýraznění lišty. Produkční WirePaint kontroly včetně povoleného dveřního vodiče s krytem, odmítnutého deskového a opět přístupného po sundání krytu. Zachován audit6save typů a8XML kontrol.

Živě ověř přepnutí ze stavění na položení krabice jedním stiskem, přebindování akce, potvrzení/zrušení, rail náhled a zamykání a barvení dveřních kabelů s krytem. Není dostupný Unity/game runtime pro ověření ovládání. Save formát, mřížka a trasy kabelů se nemění. Zálohuj save; host a klienti stejnou verzi. Záloha0.13.51 zachována.
