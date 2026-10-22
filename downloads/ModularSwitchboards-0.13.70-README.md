# Modular Switchboards 0.13.70

## Emergency Stop Label

TOTAL STOP nyní zobrazuje stručné akce **Press** a **Hold to reset**; okamžitý stisk a 1.2s reset zůstávají stejné.

Pátá varianta v existujícím **Kit (Switchboard Labels)**, za Door Label. Žlutý kruhový štítek s pevným černým obloukovým nápisem **EMERGENCY** nahoře a **STOP** dole. Labeller jeho text nemění.

Lze nasadit pouze na dokončený dveřní TOTAL STOP, jeden štítek na tlačítko. LED, round switch, main switch, bridge, prázdná pozice a duplicity se odmítnou i serverovou validací. Spotřeba je jeden Labels kit; Hand Drill štítek sundá a vrátí kit. Před demontáží tlačítka je nutné sundat jeho štítek. Nasazení a sundání funguje na otevřených i zavřených dokončených dveřích jako u Door Label.

Vnější průměr 78 mm, otvor 57.6 mm ponechává vůli kolem ochranného límce TOTAL STOP o průměru 57 mm. Štítek je tenký, u desky; střední otvor nemá kolizní plochu, tlačítko zůstává přístupné. Na snížené mřížce 3x3 nepřesahuje do výstražného trojúhelníku. Má vlastní ikonu z produkční geometrie a stejný model pro konstrukční náhled.

Používá stávající DoorLabels board a stejná save/join data jako Door Label. Nová stabilní identita StructureSwitchboardEmergencyStopLabel. Stávající varianty kitu a jejich pořadí se zachovávají. Oprava cílení skutečného namontovaného dílu z 0.13.69 platí i pro nový štítek.

## Ověření

Produkční build proti dodaným herním DLL bez chyb a varování. 3839 kontrol produkční politiky umístění a geometrie (správný STOP, nesprávné cíle, duplicity, blokace sundání tlačítka, rozměry a volný límec, místo pod varováním, platné trojúhelníky). 12 kontrol skutečné opravy cílení kurzoru. Ikona renderována a zkontrolována.

Živý test nasazení, čitelnosti obloukového textu, stisku/resetu STOP, sundání a save/load ještě zbývá. Před testem použij kopii savu. Host a klienti musí mít stejnou verzi. Mřížka ani dráty se oproti 0.13.69 nemění. Záloha 0.13.51 zůstává zachována.
