# Modular Switchboards 0.12.78

Kontakty pojistek nyní používají skutečné nativní materiály pouzdra (CabinetGeometry.Materials), původní textury a herní paletu. Všechny jejich plochy leží v materiálové roli4, která má barvu Gray. Nejde o samostatný bílý nebo kovový materiál s podobnou RGB barvou.

Kontakty jsou nově zahrnuté do registrace ThingRenderer a běžného DinBreakerModel.Refresh. Získávají stejný DiffuseIndex a SmoothnessIndex jako ostatní nativní části. Dosavadní UV mapování na původní APC povrch je zachované. Kontakty nadále nepřijímají drobné vlastní stíny.

Tvar kontaktů, vanička, bílé čepičky, jističe, baterie a elektrické chování zůstávají stejné jako v0.12.77. Změna cílí pouze na šedý materiál kontaktů a jeho zapojení do herního vykreslování.

Ověření: Release build bez chyb a varování; kontrola diffu potvrzuje změnu pouze přiřazení materiálů, registrace, aktualizace vzhledu a verze. Produkční generátory geometrie a UV jsou beze změny. Vykreslení z dálky ještě musí potvrdit kontrola ve hře; Unity scéna zde není k dispozici.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards v mods; server i klienti stejná verze.
