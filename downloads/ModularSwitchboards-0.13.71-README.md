# Modular Switchboards 0.13.71

## Oprava ukládání světa

DoorLabelSaveData nyní registrujeme přes nativní Mod.AddSaveDataType stejně jako ostatní vlastní save typy. Chybějící registrace způsobovala chybu XML serializeru a selhání ručního/autosave, pokud svět obsahoval Door Label nebo Emergency Stop Label. Oba druhy používají tento společný save typ; žádná změna jejich identity, připojení ani formátu dat.

Kontrola porovnává všechny deklarované vlastní StructureSaveData typy s registrací v OnLoaded: všech šest je přítomných. XML regresní test s produkční deklarací DoorLabelSaveData a izolovanými náhradami nativních base/mount typů reprodukuje selhání bez registrace; s registrací uloží a načte oba prefaby včetně názvu, hosta a buněk. Není to živý test celého herního serializeru; skutečný save/load je potřeba ověřit ve hře.

Pokud ještě běží hra se starší verzí a ukládání selhává, sundej všechny Door Label a Emergency Stop Label, zkus ruční save a ověř jeho úspěch před ukončením. DIN labels mají jiný již registrovaný typ. Instalace DLL vyžaduje restart hry; nerozpracovaný svět se samotnou výměnou souboru neopraví.

## Vzhled

Emergency Stop Label má žlutou výplň až k červenému tlačítku: vnitřní poloměr 21.3 mm, vnější 39 mm. Výplň leží pod ochranným límcem, konec na Z=1.2 mm je pod jeho začátkem Z=2.5 mm. Střed pro červené tlačítko o poloměru21mm zůstává otevřený. Větší černé obloukové EMERGENCY STOP, vlastní ikona aktualizována.

Čelo main switche a žlutá deska jsou o třetinu větší (deska66mm, černý rámeček72mm). Zadní kontakty a vyčnívání do hloubky se nemění. Klikací plocha72mm a bounds75mm odpovídají většímu modelu; konstrukční náhled používá skutečné transformované díly. Round switch se nemění. Main ikona rovněž aktualizována.

## Kontroly

Produkční build proti herním DLL bez chyb/varování. 8 XML regresních kontrol a audit všech6 save registrací;3839 kontrol umístění/geometrie štítků;46 kontrol ovládání/pozice main switche;36 kontrol TOTAL STOP. Ikony renderované a vizuálně ověřené. Ve hře zbývá ověřit ruční/autosave a načtení se štítky, čitelnost, klikání a reset.

Zálohuj save. Host a klienti stejnou verzi. Mřížka, dráty a souřadnice zadních kontaktů se oproti0.13.70 nemění. Záloha0.13.51 zachována.
