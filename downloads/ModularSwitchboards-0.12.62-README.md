# Modular Switchboards 0.12.62

Bateriový modul je nyní přímo tělo jističe rozšířené na2 DIN pozice. Používá stejný DinBreakerModel.Build jako běžný jistič, stejné zaoblení základního těla, horního stupně, šedého čela, šroubů a kabelových vstupů. Odstraněná je páčka, indikátor a pevné úchyty páčky. Uprostřed zůstává jen otvor se zásuvkou a skutečnou baterií. Předchozí samostatně navržené pouzdro bateriového modulu se již nepoužívá.

Tělo má jen potřebný výřez kolem vložené baterie a zadní kryt; plná plocha kolem otvoru zůstává. Hloubka čela odpovídá jističi. Dvoupozicová šířka, nativní ovládání slotu z APC, kontakty, tooltip, barvy baterie, náboj, nabíjení a záloha jsou zachované. Interakční plocha zůstává před koliderem těla jako v0.12.61. Běžné jističe se nemění.

Ověření: Release build bez chyb a varování. Přímé porovnání původního generátoru z0.12.61 s novým sdíleným generátorem potvrdilo všechny vrcholy a trojúhelníky běžného jističe beze změny. Produkční geometrické kontroly potvrzují2slotovou šířku, vyplněné čelo kolem baterie, volný střed, nativní usazení a interakční plochu před tělem. Prošly i kontroly geometrie pojistek. Herní vzhled vyžaduje ověření v Unity.

Při vypnuté hře nahraď složku ModularSwitchboards v mods; server a klienti stejná verze.
