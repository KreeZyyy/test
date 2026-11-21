## 1.0.190.5 — Stable Smart Core multiplayer interaction indices

Uses one ordered interaction table for all three Smart Core construction stages. Restores the canonical table before native join serialization and deserialization, preventing clients with an initial short construction-stage list from indexing beyond the list when joining a completed Core. IC10 slot accessibility remains gated by completion and cabinet access; existing chips and seating transforms are preserved. No network data is skipped. Update both server and clients to this revision.

Skips the native Stationpedia.AddConstructedBy UI helper on headless servers to avoid missing-thumbnail errors; graphical client Stationpedia, printer icons, recipes and manufacturing remain active. Includes previous DS geometry/graphics repairs. Native build passed with zero warnings/errors; 142 production join/access checks and 80 graphics checks passed. Full multiplayer reconnect still requires live verification.

