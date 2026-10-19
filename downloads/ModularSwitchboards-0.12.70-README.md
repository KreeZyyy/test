# Modular Switchboards 0.12.70

Nová vlastní zásuvka bateriového modulu: tmavě šedá uzavřená prohlubeň, šedý okraj a šest samostatných zlatých kontaktů ve dvou vodorovných řadách. Každá z těchto tří částí má vlastní materiál s obyčejnou bílou texturou, bez paletového atlasu a bez přebarvování APC textur. Viditelný výřez APC se již nepoužívá. Zadní kryt uzavírá i rohy kolem otvoru. Staré pomocné třídy pro přebarvování bílé textury byly odstraněné.

Z APC se přebírá pouze funkční slot, jeho původní orientace, filtr kompatibilních baterií, nativní vložení/vyjmutí/výměna, tooltip a vlastní skutečný předmět baterie s barvami a nábojem. Napájení, nabíjení a záloha zůstávají zachované. Jednoduché tělo jističe na2 pozice zůstává.

Baterie je zvětšená z přibližně41% na56% původního měřítka APC. Měřítko se nyní řídí dostupnou výškou čela, nikoli hloubkou těla. Zásuvka a otvor odpovídají nové velikosti; tělo zůstává v původní DIN hloubce. Velká baterie může vystupovat před čelo přibližně o26mm, místo aby se celá násilně zmenšovala dovnitř. Interakční plocha je před vloženou baterií a její zadní obálka zůstává6mm před základnou.

Kontakty pojistek jsou zjemněné: souvislý profil U má zkosené vnější rohy, kratší čelisti a je zapuštěný pod nejpřednější část bílých zakončení pojistky. Nové maximum z=.0525 namísto.0545 a krajní y=+/-.0186 namísto.019 v modelových souřadnicích. Držák i pojistky zůstávají funkčně stejné; šedé vnitřní stěny proti průhledu jsou zachované.

Ověření: Release build0 chyb/varování. Geometrické kontroly potvrzují3 materiálové části nové zásuvky, šest poloh kontaktů, uzavřenou zadní plochu, původní natočení funkčního slotu, větší otvor, zachovanou hloubku těla a průchod pro baterii. Prošly kontroly menších kontaktů pojistek, stěn a původní geometrie jističe.60 modulových kontrol,1010 barevných případů,2023 bateriových a10044 obvodových/trasovacích kontrol prošlo. Testy nenahrazují skutečnou Unity scénu: nové materiály, zasunutí všech typů baterie a výsledný vzhled je třeba ověřit ve hře.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
