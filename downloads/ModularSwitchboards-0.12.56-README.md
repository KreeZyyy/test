# Modular Switchboards 0.12.56

Diagnostická verze pro rozpadlé plochy vložené baterie. Tři snímky po otevření modulu nebo výměně baterie se automaticky uloží omezený výpis metadat: hierarchie transformací, měřítka a determinanty, mesh bounds, renderery, materiály, shadery, property blocks a kolidery. Srovnává živý modul a vloženou baterii s původním prefabem stejné baterie a původním slotem APC. Ukládá i oba lokalizační klíče a hashe pro přetrvávající chybu názvu slotu.

Soubor: ModularSwitchboards-battery-diagnostics.json v Application.persistentDataPath (na Windows obvykle %USERPROFILE%/AppData/LocalLow/Rocketwerkz/Stationeers). Přesná cesta se vypíše v herním logu jako BATTERY DIAG saved. Otevři rozvaděč bez baterie a potom postupně vlož malou, velkou a nukleární baterii. Soubor se doplňuje jednou na každý typ v rámci spuštění, nejvýše osm vzorků. Neprovádí GPU readback, neexportuje textury ani plné vertexy a neběží při každém snímku nebo elektrickém ticku. Nic se nikam automaticky neodesílá.

Ověření: Release build bez chyb a varování. Vizuální závada se touto verzí zatím neopravuje; výpis slouží k určení příčiny. Pošli výsledný JSON z herního počítače.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
