# Custom Speaker Sounds 0.1.1 — TEST
Autor: KreeZy. Řešení přidání herních zvukových událostí vychází z MIT projektu Sovana122/Sationeers-CustomSound, větve speaker (6d5ad7892cb947eaed2fe7377048fe1dd211982f).

## Oprava 0.1.1
Verze 0.1.0 kontrolovala AudioManager.Instance už před vytvořením herního správce. Getter v dodané herní DLL volá Create() a může vytvořit nevybavený singleton. Verze 0.1.1 getter vůbec nevolá: vyhledává pouze existující AudioManager a čeká na AudioSourcePrefab, LoadedChannelData a MixerGroups. Je to oprava konkrétního mechanismu, který může způsobit chyby při načítání světa; výsledek ve hře zatím není ověřen.
Diagnostika se nově zapisuje přímo do BepInEx/LogOutput.log pod CustomSpeakerSounds.

## Instalace a první test
1. Ukonči hru. Při aktualizaci nahraď starou CustomSpeakerSounds.dll a About/About.xml; vlastní sounds ponech. Nenechávej zapnutou druhou kopii modu. Rozbal složku CustomSpeakerSounds do Dokumenty\My Games\Stationeers\mods (případně do své složky Dokumenty na OneDrive).
2. V LaunchPadu zapni Custom Speaker Sounds. Vyžaduje StationeersLaunchPad; nepotřebuje Lua ani ScriptedScreens. Pro první test vypni Custom Sounds od Sovany, aby případné změny stejného Speakeru neovlivnily výsledek.
3. Načti singleplayer. Speaker musí mít elektřinu a být v atmosféře. Připoj jej jako d0 k IC housing.
4. Nejdřív ověř, že stejný svět naběhne bez opakovaných chyb AudioManager. Pak nahraj test.ic10. Po vteřině mají zaznít tři tóny a potom ticho; skript po čtyřech vteřinách nastaví SoundAlert 0 a už zvuk znovu nespouští.
5. Ověř také původní zvuky Speakeru. Pokud nic neslyšíš nebo se zvuk opakuje, pošli BepInEx\LogOutput.log a popis výsledku. Hledej [CustomSpeakerSounds] Ready: ID 100.

## Vlastní hlášky
Nahraď sounds/100_test.wav vlastním WAV a restartuj hru. Jde o soubor uvnitř složky tohoto modu. Doporučený první test: krátký mono PCM WAV (16 bitů).
Další soubory: 101_varovani.wav, 102_kyslik.ogg… Platí ID 100 až 199, jedno ID na soubor. ID určuje číslo před prvním podtržítkem, nikoli pořadí souborů. Mod soubory nepřejmenovává. WAV/OGG/MP3 podporuje načítač Unity; jejich dekódování je nutné ověřit ve hře.
Použij s d0 SoundAlert 101 nebo s d0 Mode 101. Pro opětovné přehrání nejprve nastav SoundAlert 0, počkej aspoň jeden tick a teprve potom vyber ID. Neposílej stejné ID každým tickem. Hlasitost řídí Volume a přehrávání probíhá přes nativní zvuk Speakeru. Původní zvuky se nenahrazují.

## Rozsah ověření
Sestaveno proti dodané Assembly-CSharp.dll. Prošlo 10 kontrolami sestaveného IL: getter singletonu není volán ani z korutiny, mod nevytváří správce, kontroluje jeho připravenost a zachovává nativní registraci zvuků. Zkontrolovány podpisy Speaker.SetLogicValue, InteractMode, zvukové události a načítání AudioManageru. Unity a hra zde neběží: prostorový zvuk, ukončení přehrávání a kompatibilita s jinými mody čekají na herní test.
Build hlásí konflikt referencí System.Net.Http 4.1.2/4.2.0 pocházející z herní DLL; mod nepoužívá HttpClient. Distribuce obsahuje pouze vlastní modovou DLL, nikoli herní sestavení.
Verze 0.1.1 neobsahuje přenos souborů ze serveru. Multiplayer není ověřen; všechny strany by zatím potřebovaly shodné soubory a ID. Testuj na kopii světa: při odebrání modu zůstane ve světě uložený vlastní Mode, který je vhodné před odebráním resetovat na 0.
Ovládání tlačítkem Speakeru může procházet i rezervované mezery mezi vanilla zvuky a ID 100; pro tento test používej IC10.

## Zdroj
https://github.com/Sovana122/Sationeers-CustomSound/tree/speaker
Zdroj našeho malého rozšíření a návod k sestavení je v source/ tohoto ZIPu. Jde o samostatný testovací addon inspirovaný autorovou implementací, nikoli o sestavení celé jeho rozpracované větve.
