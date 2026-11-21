## 1.0.190.1 — Dedicated-server IN panel repair

Based on 1.0.190. Replaces the small cabinet IN panel's runtime Automated Oven mesh extraction with authored CPU geometry: rounded plate, open socket, recessed contacts, lightning mark, physical mesh collider and socket hitbox. Retains native cable-grid metadata, existing power behavior, save identifiers and the 1.0.190 feature set. The medium cabinet input keeps its existing path.

Fixes the demonstrated headless startup blocker caused by unreadable StructureAutomatedOven geometry. Input setup now fails explicitly if its own construction fails, rather than continuing without metadata. A metadata-only headless preflight reports unreadable meshes in remaining legacy Console LED/Air Conditioner paths; those paths are not replaced in this patch.

Validation: native build succeeds with zero warnings/errors; production geometry checks cover finite vertices/indices, envelope, recess and plate aperture; production input checks cover normal/reverse small/medium cabinets, build-state activation, port owner/role, collision mask, zero idle load, wall-fit independence, duplicate prevention and metadata validation. No Unity or dedicated-server runtime was available here. Full server startup and final visual appearance remain to be tested with a fresh log. This patch does not claim that every legacy model dependency has been removed.

