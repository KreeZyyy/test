# Modular Switchboards 0.12.58

Rozšířená diagnostika opakujícího se vzoru baterie. Porovnává přímo identitu živého mesh s původním prefabem, hash a počet UV souřadnic a jejich rozsah. Pro každý materiál zapisuje identitu textury, textureScale/textureOffset, wrapMode, shader keywords a GPU instancing; pro renderer také režim vrhání a přijímání stínů. Zachovává předchozí porovnání materiálů a transformací.

Kód baterkového modulu UV vložené baterie neupravuje. Dosavadní výpis neobsahoval UV a tiling, proto z něj nelze určit příčinu opakovaného vzoru. Tato verze zatím neopravuje vzhled ani nemění původní textury, UV či stíny. Je určena k odlišení změny UV/tilingu od jiné vykreslovací závady.

Po restartu hry otevři rozvaděč a vlož problematickou baterii. Vzorek vznikne automaticky po třech snímcích, jednou na typ (nejvýše osm vzorků); není export celé geometrie ani textur, bez GPU readback. Pošli nově vytvořený ModularSwitchboards-battery-diagnostics.json z %USERPROFILE%/AppData/LocalLow/Rocketwerkz/Stationeers. Přesná cesta je v logu BATTERY DIAG saved. Výpis ze starší verze nestačí.

Ověření: Release build bez chyb a varování. Instalace při vypnuté hře: nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
