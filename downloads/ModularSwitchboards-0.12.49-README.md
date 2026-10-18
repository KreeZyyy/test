# Modular Switchboards 0.12.49

Omezení záseků při změně stavu pojistky: odstraněn automatický Capture z DinFuseView.LateUpdate. Při běžné hře už tento kód nesestavuje ani nezapisuje velký geometrický diagnostický JSON. Dřívější export mohl synchronně blokovat hlavní vlákno, ale přesná příčina uživatelem hlášeného záseku při první/poslední pojistce není bez herního profilu definitivně potvrzena. Starý diagnostický soubor může zůstat na disku, tato verze ho automaticky nepřepisuje.

DinFuseView nastavuje viditelnost a materiály pouze při změně Conducting, Tripped nebo výkonu. Ve stabilním stavu se opakovaně nevolá SetActive/GetComponent a nevytvářejí se nové property blocks každým snímkem. Vzhled0.12.47 i vyjmutí do odpovídajícího stacku0.12.48 zůstává. Elektrická topologie, inventář, síťové zprávy a ukládání beze změny.

Kontroly: Release build0 chyb/varování;49 kontrol katalogu, vkládání/vyjmutí, trip a persistence; produkční geometrie a přepínání všech stavů pojistky;240 stabilních aktualizací bez dalšího SetActive a bez diagnostického Capture. Unity objekty jsou v testech nahrazené, skutečné časování hry je nutné ověřit.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards ve složce mods. Server i klienti stejná verze. Po instalaci opakovaně zkus vložit první pojistku a vyjmout poslední. Pokud zásek zůstane, je potřeba Player.log z dané chvíle a informace, zda hra po záseku pokračuje nebo přestane reagovat trvale.
