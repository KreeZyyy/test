# Modular Switchboards 0.12.6 — původní zadní krabička APC, bez přípojek

Na střed zadního pláště přidává skutečnou centrální krabičku z hlavního meshe herního APC, včetně původního symbolu blesku, krytu a čtyř šroubů. Původní velikost: přibližně 240 × 240 mm a 102.59 mm do hloubky od montážní plochy. Její montážní rovina dosedá na zadní plochu rozvaděče; geometrie se nezvětšuje podle rozvaděče.

Výběr je založený na dodaném exportu: 191 trojúhelníků a 287 původních vrcholů uvnitř centrální oblasti. Za běhu se převezmou z původního APC včetně UV a materiálů/property blocks. Kabelové přípojky jsou mimo tuto oblast a zůstávají vypnuté. Nepřidává se žádná elektrická funkce ani síťové uzly. Kopie původní APC nemění.

Krabička má vlastní kolizi a je zahrnutá do rozměrů skříně. Existující bílý a šedý plášť včetně zkosení se nemění. Runtime kopie zůstává součástí dokončeného modelu a sleduje jeho usazení na stěnu, bez samostatného posouvání na kabelovou mřížku.

Blender a GLB obsahují referenční geometrii krabičky s původními UV. Referenční objekt se nevkládá znovu do Housing meshbin, aby ve hře nebyl zdvojený. Herní F1 ikona používá offline render bez nativních textur, takže v ní symbol blesku není vidět; ve hře se použije původní textura APC.

Instalace: vypni hru, zálohuj původní mod a nahraď složku ModularSwitchboards v Documents/My Games/Stationeers/mods/ složkou z test ZIPu. Závislosti ponech. Klient i server potřebují stejnou verzi.

Ověřeno: kompilace proti dodaným herním DLL, 0 chyb a 0 varování; výběr nativní geometrie a zachování UV, konektory mimo výběr, existující Cabinet.meshbin byte-for-byte nezměněný, integrita ZIPů. Ve hře zde netestováno. V logu hledej `Native rear APC box installed`; případné selhání je `Native rear APC box unavailable`.
