# Modular Switchboards 0.13.69

Door Label má souvislou černou plochu mezi kruhovým otvorem a horním štítkem. Vnější poloměr kroužku je 18 mm místo 20 mm, otvor 16.1 mm místo 16.3 mm: těsně kolem 16mm základny LED/round switche, s volným středem pro ovladač. Nová ikona odpovídá modelu.

Opraven výběr namontovaných dveřních dílů a štítků: native RaycastHit.transform může ukazovat na rigidbody skříně. Po nativním raycastu se pro vlastní dokončené dveřní díly použije nejbližší Thing skutečně zasaženého collideru. Round/main switch a TOTAL STOP tak cílí na vlastní interakce; Door Label i DIN štítky na vlastní Labeller. Cizí objekty a konstrukční kurzory se nepřesměrovávají.

Pomocná plocha pro montáž Door Label už není v běžných BuildState colliderech. Před raycastem se zapíná pouze ve skutečném režimu stavění s Labels kitem a Door Label kurzorem. S prázdnou rukou, Labellerem či jiným nástrojem je vypnutá. Přejmenování skříně je omezené na její vlastní horní štítek, který má vlastní collider; nemá se nabízet po celých dveřích.

Build proti herním DLL: 0 chyb, 0 varování. 1272 kontrol produkční geometrie/umístění včetně volného otvoru a černé spojovací plochy; 12 kontrol skutečné opravy kurzoru. Ikona renderována a vizuálně ověřena. Živé ovládání a Labeller je nutné ověřit ve hře, Unity runtime není dostupný.

Ukládací formát, mřížka a kabelové trasy se oproti 0.13.68 nemění. Použij kopii savu. Host i klienti mají používat stejnou verzi. Záloha 0.13.51 zůstává zachována.
