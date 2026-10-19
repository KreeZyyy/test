# ModularSwitchboards 0.12.93 — oddělení barvy skříně a vodičů

Oprava chyby 0.12.92: přebarvení skříně zapisovalo materiálový property blok i do vnitřních vodičů. Tento blok měl přednost před rendererovým blokem jejich vlastních barev, takže samotné obnovení barvy vodiče v Tick nebylo vidět.

Vnitřní vodiče, kontaktní značky a náhled trasy jsou nyní vynechané jak z barvení skříně, tak z jejího seznamu nativních ThingRenderer. Jejich vlastní barva se zapisuje přímo do materiálového slotu 0; tím se opraví i případný starý překrývající blok. Zvýraznění sprejem/štípačkami i uložené vlastní barvy zůstávají zachované.

Barvení skříně předtím měnilo jen vykreslení vodičů, nikoli uložený ColorIndex. Při načtení této verze se proto znovu použijí jejich uložené barvy, případně výchozí červená. Není nutné je všechny znovu přebarvovat.

Základ je stále 0.12.89 přes verze 0.12.91/92: barevné vodiče, jejich výběr sprejem, barvení těl modulů a demontáž s refundací kabelů. Práce na vnitřním krytu zůstává pozastavená; kryt nebyl přidán.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards; závislosti ponech. Ověřeno sestavení a cílený regresní test: reprodukce maskování barvy, oprava starého překrývajícího bloku, oddělené barvení skříně/vodiče, návrat barvy po zvýraznění a ochrana značek/náhledu. Skutečné vykreslení je potřeba ověřit ve hře.
