# Modular Switchboards 0.12.60

Bateriový modul má nové uzavřené tělo na2 DIN pozice. Předchozí třípozicový otevřený rám je nahrazený plným bílým pouzdrem a souvislou šedou čelní deskou kolem zásuvky. Otevřený zůstává pouze otvor pro baterii; deska neprochází jejím modelem. Tělo bylo sestavené znovu s plnými bočními, horními a spodními stěnami a zadním krytem.

Prošel jsem původní export APC (root mesh1971 vrcholů, samostatná dvířka a páčka), původní slot a jeho obsluhu: zásuvka je zapuštěná do souvislé plochy a baterie používá vlastní herní renderer. Zachovaná je původní geometrie zásuvky a kontaktů134 trojúhelníků, její UV/materiály, společné měřítko a relativní poloha baterie. Výška zásuvky60.75mm odpovídá otvoru; okolní plocha je nyní u čela, nikoliv na dně velké dutiny. Modul je široký80.1mm a zabírá přesně2 pozice. Nativní rozměry se jednotně přizpůsobují modulu; nejde o celý nepřizpůsobený model APC.

Funkce zachované: stejný prefab StructureDinBatteryBackup a DIN kit, nativní vložení/vyjmutí baterie, typ baterie, tooltip a nabití, stavové barvy, nabíjení z IN, automatická záloha do OUT, ukládání a přenos stavu. IN a OUT jsou nahoře a dole ve středu nové šířky. Stávající mechanismus při změně polohy svorek přepočítá staré trasy transakčně se zachováním zapojení a ceny kabelů; při neúspěchu původní trasy obnoví a vyžádá ruční přepojení. Diagnostika zůstává omezená a automatická jako dříve.

Ověření: Release build0 chyb/varování. Test produkčního těla potvrzuje vyplnění čela ve všech čtyřech oblastech kolem zásuvky, volný otvor pro baterii, dvoupozicovou šířku, okraje a překryvy. Původní APC fixture potvrzuje vystředění a usazení zásuvky.60 kontrol modulů,1010 barevných případů,2023 bateriových kontrol a10044 kontrol obvodů/tras/ukládání prošlo spolu s ochranami a migrací tras. Náhled samotné geometrie byl vytvořen z produkčních vrcholů; nenahrazuje herní renderer. Vzhled s bateriemi a chování v multiplayeru je třeba potvrdit ve hře.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
