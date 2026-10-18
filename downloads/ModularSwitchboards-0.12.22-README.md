# Modular Switchboards 0.12.22 — horní elektrický vstup IN

Horní konektor je registrovaný jako jediná ConnectionRole.Input s typem Power u dokončeného rozvaděče. Nedokončená stavba má typ None a elektricky se nepřipojuje. Používá připravený nativní bod a osu z NativeCableLayout; kabelová buňka zůstává volná pro kabel. Převzatá kolizní maska APC dovoluje souběh skříně s kabely. Logický bod je přímo pod kořenem rozvaděče, takže se při wall-fit neposouvá. Samostatná malá ovládací kolize je u viditelného otvoru horního panelu.

Vstup se registruje do nativní kabelové sítě. Životní cyklus dokončení, rozebrání, načtení a výměny/odstranění kabelu používá stávající registraci Device a aktualizaci sítí; vlastník Connection se při registraci instance obnovuje. Přidaná kontrola jediné přípojky a diagnostický log Cabinet IN ready. Původní výstupní konektory zůstávají vypnuté.

Skříň má zatím nulový vlastní odběr. Tento krok přidává vstupní přípojku; zatím neobsahuje výstupy, propojení přípojnic, napájení DIN modulů ani naše vnitřní drátování. Samotné označení Input nepředstavuje modelovaný jednosměrný výkonový obvod. Geometrie z 0.12.21 zůstává stejná.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Záloha 0.12.7 i modelová verze 0.12.21 zůstávají na GitHubu.

Ověření: kontrola API v dodané Assembly-CSharp.dll, kompilace bez chyb a varování. Produkční instalační kód ověřen oddělenou zkouškou se zástupnými Unity objekty: jediný Input, stav stavby, vlastník, kolize, nulový odběr, nezávislost bodu na wall-fit, poloha ovládací kolize a odmítnutí duplicitní či nesouhlasné registrace. Zkouška je v Verification/PowerInput; nejde o simulaci hry. Beze změny meshe skříně a zdrojů geometrie tunelu. ZIPy ověřeny.

Ve hře ověř: dokončená skříň, tooltip Input na otvoru, přivedení napájeného kabelu do horního otvoru; potom odstranění a znovupřipojení kabelu a načtení uložené hry. Na samotném kabelovém připojení se zatím neprojeví odběr spotřebičů uvnitř. Při potížích zkontroluj log Power registration verified a Cabinet IN ready.
