# Modular Switchboards 0.12.63

Odstraněné dělící čáry na bateriovém těle: otvor se už neskládá ze4 zvlášť zaoblených dílů. Vyřízne se přímo z původního souvislého zaobleného povrchu jističe s interpolací původních normál. Na čele tedy nevznikají další vnitřní bevely ani spáry. Zůstává jednoduché dvoupozicové tělo jističe bez páčky, s baterií uprostřed.

Bílé plochy vnitřku zásuvky nyní používají přímo stejný materiál a paletový index jako šedé čelo. Pokud je celý nativní socket tvořen bílým materiálem, dostane pouze jeho soukromá kopie meshe odpovídající UV pro tuto čelní plochu. Původní APC asset ani mesh/UV vložené baterie se nemění. Geometrie kontaktů zůstává; jiné samostatně přiřazené nativní barevné materiály se nepřepisují.

Ověření: Release build bez chyb a varování. Test4 míst původních spár potvrzuje původní rovnou čelní plochu bez dodatečného zaoblení. Původní jistič má stále všechny vrcholy a trojúhelníky shodné s původním generátorem. Prošly kontroly otvoru, vyplněného čela, rozměrů2slotů, APC usazení a přední interakční plochy i geometrie pojistek. Vzhled a materiál zásuvky je ještě třeba potvrdit ve hře. Bateriové napájení a ovládání se nemění.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
