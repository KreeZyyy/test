# ModularSwitchboards 0.12.92 — výběr vodiče sprejem jako u štípaček

Navazuje na 0.12.91, stále se základem 0.12.89 (barvení těl a demontáž; bez proužků z 0.12.90).

V otevřeném rozvaděči se při míření sprejem na vodič používá stejný výběr nejbližšího segmentu jako u štípaček (12 mm). Vybraný vodič se dočasně zvýrazní žlutě; pokud je uložená barva žlutá, použije se bílé zvýraznění. Při odklonu se vrátí jeho skutečná barva. Zvýraznění nikdy nemění uložená data.

Při vybraném vodiči se potlačí velký výběr celé skříně a zobrazí se akce Paint wire / Internal wire. Podržením primární akce proběhne nativní průběhový ukazatel se stejnou dobou stříkání, zvukem a zrušením při uvolnění. Dokončení ověřuje původní vodič, sprej, skříň a otevřený stav; při přemíření na jiný vodič se barva nespotřebuje a nepřebarví nesprávný cíl. Mimo dosah vodiče zůstává běžné barvení skříně/modulu.

Stejný výpočet výběru používá tooltip, zvýraznění a autoritativní serverová akce. Ukládání a síťové barvy jsou stejné jako v 0.12.91. Pro multiplayer použijte stejnou verzi u hosta i hráčů.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards, závislosti ponech. Ověřeno sestavení a produkční logika zásahu a spotřeby spreje, včetně širšího výběru jako u štípaček, netrefené plochy, stejné barvy, serverové pozice, neúspěšné spotřeby a náhledu bez změn. Skutečné UI, coroutine, zvýraznění a multiplayer vyžadují kontrolu v Unity ve hře.
