# Modular Switchboards 0.12.18 — podstavec a tunel jako jedno tělo

Původní nosné tělo středního podstavce je nahrazeno jedním souvislým meshem zahrnujícím podstavec, plynulý kořen tunelu, svislý tunel a horní rozšíření. Tunel už není samostatná geometrie protínající hotové horní víko podstavce. Přechod širokého podstavce do užšího tunelu má 30mm plynulou zaoblenou oblast přes původní výšku horního okraje podstavce. Mesh je propojený po celé výšce, bez vnitřního víka v kořeni.

Samostatný původní šroubovaný kryt, symbol blesku a čtyři šrouby zůstávají převzaté z APC: 215 původních trojúhelníků s původními UV a materiály. Původní nosné boční plochy pod tímto krytem se již nekreslí duplicitně. Nové souvislé nosné tělo má stejné základní montážní rozměry podstavce 240 × 240 × 91.412 mm a používá šedý povrch APC.

Profil z předchozí verze je zachovaný v hlavní části tunelu: rovná vnitřní stěna u skříně a zaoblené rozšíření ven v posledních 60 mm. Kořen dole plynule přejde do těla podstavce. Horní panel, původní konektor a jejich polohy se nemění. Kabinetní Cabinet.meshbin je shodný s předchozí verzí. Každá instance má vlastní mesh a kolizi nosného těla.

Pořád pouze model: žádná Connection, funkční elektrická přípojka ani vnitřní drátování. Statické referenční Art soubory APC obsahují původní podstavec; souvislé tělo se podle skutečné polohy panelu vytváří za běhu.

Instalace: při vypnuté hře nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Zachovej závislosti. Původní potvrzená záloha 0.12.7 zůstává na GitHubu.

Ověřeno: kompilace bez chyb a varování, produkční výpočet meshe pro pět wall-fit offsetů. Graf vrcholů tvoří jeden propojený celek; platné nedegenerované trojúhelníky, vnější orientace, otevřená pouze horní hranice pod konektorem, zachovaný svislý tunel a horní vnější rozšíření. 645 vrcholů a 1260 trojúhelníků. Zachování zdroje panelu a původního meshe skříně a integrita ZIPů ověřeny. Vizuální návaznost je třeba potvrdit ve hře.
