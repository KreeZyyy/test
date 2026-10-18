# Modular Switchboards 0.12.48

Zdravou pojistku lze z otevřeného držáku vyjmout přímo do stejného kitu Cable Fuses v ruce. Stack se zvětší právě o jeden kus a držák se vyprázdní. Používá se nativní Stackable.Merge, včetně nativních změn počtu kusů a odstranění spotřebovaného jednokusového stacku. Plný stack, jiný kit a zavřený rozvaděč vyjmutí odmítnou. Prázdnou rukou funguje původní vyjmutí. Spálená vložka se odstraní bez použitelného refundu. Následující kliknutí na prázdný držák s odpovídajícím kitem opět vloží jeden kus.

Vzhled0.12.47, elektrika, ochrany a formát ukládání zůstávají. Server i klienti musí mít stejnou verzi.

Ověření: Release build0 chyb/varování. 49 kontrol produkčního katalogu, HandleSwitch/Trip a ukládání/přenosu stavu s náhradami herních objektů. Zahrnuto vyjmutí do stacku8→9 a9→10, opětovné vložení, odmítnutí plného a odlišného stacku, zavřeného rozvaděče, žádná mutace při náhledu či na klientovi, původní vyjmutí prázdnou rukou a spálená bez refundu. Nativní Merge byl prověřen v dekompilované herní implementaci; skutečnou herní interakci a síťové chování je nutné ověřit ve hře.

Instalace při vypnuté hře: nahraď složku ModularSwitchboards ve složce mods.
