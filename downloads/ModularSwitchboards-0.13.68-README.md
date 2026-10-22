# Modular Switchboards 0.13.68

## Door Label v existujícím Labels kitu

Nová čtvrtá varianta **Door Label** v **Kit (Switchboard Labels)**. Jeden kus kitu vytvoří černý držák s kulatým otvorem a světlou ploškou nad ovladačem.

Jeden společný prefab se automaticky přizpůsobí cíli: na LED má jeden vlastní řádek; na kulatém switchi má vlastní název nahoře a pevný druhý řádek **0 / I**. Přepisovatelný text mění Labeller původním herním přejmenováním. Pevný druhý řádek se přejmenováním nezmění.

Nasadit lze jen na dokončenou dveřní LED nebo Door Round Switch, maximálně jeden štítek na díl. Main, TOTAL STOP, bridge, prázdná či obsazená pozice jsou odmítnuty. Otvor nechává čočku i páčku přístupnou. Štítek lze nasadit, přejmenovat i sundat při otevřených nebo zavřených dveřích. Používá Hand Drill jako ostatní konstrukční štítky. Před demontáží ovladače je nutné sundat jeho štítek.

Uložení a připojení klienta používají vlastní nativní LibConstruct board na dveřích a native CustomName pro text. Jeden typ štítku; není potřeba samostatná LED/switch varianta. Tři stávající šířky štítků v kitu zůstávají na prvních třech místech.

## Mřížka a kabely

Celá dveřní mřížka 3×3 je o 25 mm níž; rozestupy 100 mm a logické pozice zůstávají stejné. Držák horní řady končí nejvýš na Y=125 mm, pod dolní hranou výstražného trojúhelníku. Main, STOP ani bridge nemají nový štítek; bridge mřížka se neposouvá.

Rezervace pro kabely odpovídají nové výšce. Verze tras je 6: staré trasy se po načtení přepočítají při zachování spojení, barev a spotřeby kabelu. Pokud se některá trasa nevejde, migrace vrátí původní trasy a ohlásí potřebu ručního přepojení, místo aby mazala vodiče. Před aktualizací si ulož kopii svého savu.

## Ověření

Build proti herním DLL bez chyb/varování. 874 kontrol skutečné politiky umístění a geometrie: cíle, duplicity, nehotové/mazané díly, blokace demontáže, rozměry, volný otvor a místo pod symbolem. Kabelové kontroly: 67889 jednotlivých bridge a 12464 obvodových, rozpočtových, ukládacích a trasovacích kontrol; plné dveře a horní řada používají sníženou mřížku. Ikona renderována ze skutečného modelu.

Živý test nasazení, Labelleru, automatického řádku, save/load a host/klient ještě zbývá. Host a klienti musí mít **0.13.68** kvůli novému dveřnímu boardu v síťových datech. Záloha **0.13.51** zůstává zachovaná.
