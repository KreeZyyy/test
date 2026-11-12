## 1.0.137 — Wall spawn cache test

The wall-fit cache now includes the wall mesh identity, vertex count/bounds and renderer-to-wall transform. A late native wall mesh replacement or renderer-space change triggers a fresh fit even when cabinet/wall roots and the build-state index are unchanged. Stable geometry keeps the existing short circuit. This fixes an offline-reproduced cache defect; it does not establish the cause of the intermittent opaque white panel in the player screenshots.

Adds bounded, read-only `Cabinet spawn view` log records after spawn and when the open/build state changes. Records include cabinet position/rotation, model offset/rotation and own renderer mesh names, visibility and centres. They distinguish a real cover from hidden interior geometry without altering cover/save state. No blind axis flip.

Validation: native-reference build with zero warnings/errors; 107 production-source wall-fit/cache checks, including late mesh replacement, renderer movement, bounds changes and native draw-data fallback. The 1.0.136 wall-fit source fails the late replacement regression in the same fixture. Live Unity appearance remains unverified; test the same location repeatedly and retain Player.log if the white panel returns. Includes the existing control-power and printer-name changes; no Large prototype or manual routing.

## 1.0.136 — Symmetric wall mounting envelope

Back-face mounting now uses the same outer mounting envelope as the opposite face, instead of pulling the cabinet inward to the native wall's thin/asymmetric rear skin. The envelope is centred on the native wall mounting grid. It applies to both the template/ghost offset and the actual supporting-wall fit. The known native flat-wall profile (rear+0.012642m,front+0.130001m,grid plane0) retains its front face and uses-0.130001m at the back, with the existing0.5mm clearance. This is a conservative mounting envelope, not a new scan of every surrounding frame.

Cabinet root/grid positions, roll/orientation choices, models, costs, wiring graph and save formats are unchanged. Existing model-relative rails/modules, covers, door boards and wire visuals move with their existing parent transforms. Existing cable-port alignment and bounds refresh remain in place. Previously placed back-side cabinets refit through the existing wall-fit update after loading. No forced save migration or electrical reconnection.

Validation: native-reference build0warnings/errors;34,014 wall-envelope fixture checks cover the reported asymmetric profile, opposite faces, shifted mounting grid planes, cardinal rotations, model-relative child translation, symmetric/invalid profiles. Existing upright/manual mount-orientation fixture also passes. Native LibConstruct AddStructure parents mounted structures to each board Origin; those origins are children of CompletedShell. Offline fixtures do not reproduce the player's exact scene or prove all surrounding structural geometry is clear. Actual game appearance and a populated cabinet on the back wall still need testing.

Includes135internal control power,134stable printer names and orange indicator; manual cable routing remains removed. The separate vanilla multiplayer printer issue remains unconfirmed. Install the same version on server and clients. No Steam Workshop publication.

## 1.0.135 — Internal control power from the wired supply branch

Core and Smart Output control electronics now use the cabinet's real path-based source allocator, alongside transformer control electronics. Supply can come from external inputs, transformers or battery OUT according to the actual connected circuit. A Core no longer requires an external output cable or native external network to run. Outputs take their control supply through their attached Core's side bus and each enabled, correctly addressed Output retains its existing5W cost. Core and transformer costs retain their existing native UsedPower values. Smart Net data-only behaviour is unchanged.

Internal consumers reserve and pay energy once per native electricity cycle. Native consumer billing is disabled for Core and Smart Outputs to avoid double charging; external data-network registration remains independent. Batteries pay actual delivered consumption; native source shortfalls can be topped up from available battery energy at cycle end. Transformer transfer limits, upstream breakers/fuses and physical wire limits remain on the real supply path. Unfinished/OFF/detached or insufficiently supplied consumers do not run. Core supply loss releases control Outputs. No new save format or prefab identities; existing objects keep their wiring.

Validation: final native-reference build0warnings/errors;18,046 service-power checks including3,000 changing-source/enable cycles, isolated battery, mixed/duplicate/multiple inputs, bus loads, actual brownout top-up, exact battery use, output competition, transfer caps, protection, removal and disabled/zero-power states.33 actual mapping/runtime-method checks;33 data-network checks;96 Smart bus/PLC checks. Existing power/protection/battery/transformer regression suite passed. Several old test stubs were brought up to current source interfaces; fixture unused-field warnings are not native build warnings. These are offline checks, not a live Unity or multiplayer validation.

Test on matching1.0.135 server/clients: feed battery IN from a transformer and wire battery OUT to Core POWER IN; install a charged cell. Core should run without an external Output cable. Fit Smart Outputs, verify their commands, disconnect mains, then test battery depletion and an open upstream breaker. Consumption must follow the battery/source. Manual routing remains removed; orange LED and134 stable printer-name correction remain. The separate all-vanilla multiplayer Print issue is not claimed resolved by this power change. No Steam publication.

## 1.0.134 — Stable fallback names for printer kit ordering

Fixes an offline-reproduced language-dependent ordering defect for the seven Switchboards kit recipes. The native printer sorts by Localization.GetFallbackName, while the old mod supplied only GetThingName. The new narrow fallback hook supplies stable English names for these seven kit prefab IDs and shares the same mapping with display-name lookup. It leaves vanilla, other mods and non-recipe prefabs on the original localization path. Recipe costs, outputs, networking, electrical behaviour and existing prefab identities are unchanged. Automatic routing from133 is retained; manual routing remains removed. Orange indicator, DS support and printer diagnostics remain.

Use the same1.0.134 on server and clients, restart both, and reselect the desired recipe before testing Print. This correction addresses the reproduced own-kit ordering bug; it is NOT proof that the separate report of all vanilla printing stopping is resolved. The supplied multiplayer logs were client1.0.130 and did not include the authoritative server state.

Validation: native-reference build0warnings/errors;22,849 checks of the actual new name helper against native sorting/fallback method fixtures, including600 catalogue comparisons across6languages, random insertion orders, exact per-index identity, custom-name independence and vanilla/foreign/null fallthrough. Negative control reproduces the old mismatch. No live multiplayer reproduction or validation yet.

## 1.0.133 — Remove experimental manual routing

Restores the automatic cable routing, normal terminal selection and original wire network packet format from 1.0.131. Removes manual routing points, their markers and automatic raised crossings introduced in 1.0.132. Existing completed wires keep their stored paths and electrical endpoints; no save wipe or forced rerouting. Orange Door LED, DS startup support, Core IC10 access repair and printer diagnostics are retained. The Electronics Printer issue remains unresolved. Use matching versions on server and clients, and restart both when switching from 1.0.132.

## 1.0.131 — Electronics Printer diagnostic candidate

Based on DS/orange 1.0.130. Adds observation of the Electronics Printer catalogue and ordered prefab fingerprint on startup, recipe selection on the client, recipe-index receipt on the server, and Print interactions (power, activation, error, tier, ingredients and current recipe). Logs include version and headless/simulation mode. Native exceptions are logged and returned unchanged; diagnostic read failures do not block the game action. No recipe, power, button or network-message behaviour is intentionally changed.

This is NOT a confirmed fix. Install this exact candidate on both the Linux server and testing client, restart, select a vanilla recipe with enough materials and press Print once. Send both logs from startup through that attempt; search for `Printer diagnostic`. One startup catalogue line lists prefab identities only. No player data is logged by these added diagnostics. Actual DS/Unity testing is still required. Native-reference build: zero warnings/errors. Includes orange Door LED; no Large prototypes.

## 1.0.130 — Orange door indicator

Adds Door LED Orange to the existing Door kit for 1 kit. Includes orange off/on lens, emission, native light, icon, F1 catalogue and orange/amber search aliases. Existing prefab names remain unchanged. Based on DS candidate 1.0.127; no Large cabinet changes. The reported Electronics Printer server failure is still under investigation; this addition does not fix it.

Validation: native-reference build passed with 0 warnings/errors; 134 production LED controller checks passed. Actual in-game and multiplayer validation pending.

# Modular Switchboards 1.0.127 — dedicated-server startup candidate

Based on stable 1.0.126 (the Workshop-linked 1.0.122 line plus IC10 access fix). No Large cabinet prototype changes.

The reported first error, Native game paint material unavailable, comes from graphics validation during prefab preparation. Failed recipe checks follow the aborted prefab transaction. A non-rendering server must not require Shader.isSupported to be true.

- Centralized headless detection (batch mode or Null graphics device) and shader validation. Normal rendered clients still reject unsupported shaders. Missing server-wide paint templates/custom shaders can use an existing native APC material/shader; no null shader is accepted.
- Native CPU-readable meshes are copied with all native channels for the battery holder and analyzer, retaining selected triangles without GPU-buffer readback. Client GPU-copy/verification path is retained.
- Headless startup skips cosmetic warning texture readback, lever recolour blits and thumbnails. Shapes/ports/slots/recipes remain registered normally.
- Non-readable mesh data on a headless server fails with the exact mesh name before attempting GPU access. No fake geometry or placeholder colliders are supplied. Fully stripped native meshes require further matching CPU geometry support.
- Startup log reports headless status and graphics backend; paint failures report whether template/shader is missing.

Validation: native-reference build0warnings/errors;72headless shader/material policy checks;16CPU mesh selection/channel-preservation checks;97IC10 access checks passed. This is NOT a real dedicated-server or multiplayer test. The reporter must verify server startup and joining/constructing with matching clients. Use this same version on the DS and every client. If startup still fails, capture the FIRST complete prefab setup exception and stack trace, not only the later recipe failures. Steam Workshop has not been updated.

# Modular Switchboards 1.0.126 — Smart Core IC10 access repair

Based on Workshop-linked 1.0.122, without any Large cabinet prototype changes.

Completed Core slot access now explicitly rebinds the native slot/action/collider dictionaries after registration and construction-state visualization, and checks them during runtime. This covers the native renderer-dependent state-update path that can leave a visible finished socket with stale interaction caches. The custom slot is authored as interactable rather than inheriting the source Air Conditioner's UI flag. Incomplete Core stages remain unavailable; closed/detached cabinet access stays disabled. Existing slot, occupant and chip seating transform are retained.

Validation: native-reference build0warnings/errors;97production slot/cache/state/access/rollback/chip-preservation checks;61Core stage checks;15Core save/migration checks;22wire-readiness checks passed. These are fixture/stub checks, not Unity reproduction. Actual cause of the user's selection failure and in-game insertion still need confirmation. A one-time log on cache rebind reports stage and binding availability.

Test a fully completed Core: aim at the right-hand socket with an IC10 in hand, insert/remove it, close/reopen the cabinet, then save/reload. If it still fails, collect the Core IC10 access rebound log and check whether the slot action appears while aiming at the socket. Large prototypes remain separate and Steam Workshop has not been updated.

# Modular Switchboards 1.0.122 — restore cabinet door pose during load

Saved door positions now apply immediately during save/join restoration and registration, with first-physics-step initialization as a fallback. Small and both Medium door hinges retain their existing animation and physical colliders. This addresses a door initialization gap; whether it resolves reported player displacement near cabinets requires in-game verification.

Validation: 23 door load/physics/animation checks passed; native-reference build without warnings/errors.

# Modular Switchboards 1.0.121 — empty cover kit refunds

Removing a cover without live labels uses normal deconstruction and returns its cover kits (Small 1, Medium 2). Covers with labels remain portable Fitted Covers, preserving labels, openings and colour. Empty painted covers also return kits.

Validation: 94 cover-transfer checks passed; native-reference build without warnings/errors. Actual in-game refund verification remains pending.

# Modular Switchboards 1.0.120 — remaining kit economy and cover size costs

Smart Output now uses4 Smart kits (Net remains1). Door kit recipe:5 Iron +20 Copper; LEDs, round switches and individual bridges use1 kit, while TOTAL STOP and Main Switch use3. Label kit recipe:5 Silicon, with1 kit per label regardless of width. Cover kit recipe:20 Silicon; Small cover uses1 kit, Medium2.

Medium cover has a separate hidden native-cost prefab so LibConstruct consumes2 kits through its normal construction path. Mounting and server authority select the cabinet-size-matched prefab. All cabinet orientations/input-output variants use the corresponding Small/Medium cost. Existing fitted covers retain labels/color/openings and can be refitted without new kits. The standalone covers remain hidden from F1/creative listings; the kit entry describes both costs.

Validation: native-reference build without warnings/errors;74 direct cover/name/preview/client/cancellation/size/cost checks and70 actual cover-transfer checks passed. Other staged module behavior and accepted geometry remain unchanged. Actual Unity printer/consumption/refund/new-prefab/save-load/multiplayer verification remains pending.

# Modular Switchboards 1.0.119 — native rounded display outline and pocket surfaces

The unfinished Core display opening follows the actual original white bezel outline, including its curved segments, instead of simple chamfered corners. Its floor remains 4 mm deep. Display and IC10 pocket floors/walls now use source material roles, sampled native UVs and original material property blocks instead of the bright cabinet gray. Chip lining is visible only before the native socket is installed; the completed native socket remains unchanged. F1 stage images match the revised models.

Construction, kit recipes, save migration and completed-only chip/control/network/power/wiring gates remain unchanged.

Validation: native-reference build without warnings/errors; 7,395 geometry/ray/rounded-outline/depth/UV-role/nondegenerate checks and 61 stage/model/control/rollback/lining checks passed. F1 icons visually inspected. Actual Unity appearance/color/construction/save-load/multiplayer verification remains pending.

# Modular Switchboards 1.0.118 — visible IC10 and display pockets in unfinished Core

Core now shows the original-depth IC10 opening with an opaque gray floor before the socket is fitted. The display opening matches the native bezel footprint and is 4 mm deep, also with gray walls and a closed floor. These pockets remain beneath the fitted components. Stage0 shows both openings, stage1 adds the display, stage2 adds the original native IC10 socket. F1 images match the revised stage models.

Construction remains 5 Smart kits, then 2 Electronic Parts, then 5 Heavy Cable Coils; IC10 separate. Recipes, saved-stage migration, completed-only chip/control/network/power/wiring gates remain unchanged.

Validation: native-reference build without warnings/errors; 7,005 native geometry/ray/depth/material/nondegenerate checks and 49 stage/model/control/rollback checks passed. Actual Unity appearance/construction/save-load/multiplayer verification remains pending.

# Modular Switchboards 1.0.117 — Smart kit economy and three-stage Core

One Smart kit now costs 10 Copper + 8 Steel + 4 Solder in the Electronics Printer. Core construction: 5 Smart kits build the solid body without display or IC10 socket; 2 Electronic Parts add the display; 5 Heavy Cable Coils add the original socket and its pocket. Insert a separate removable IC10 only after completion. Other Smart module construction kit counts remain unchanged.

Each Core stage has its own F1 image. Incomplete Cores cannot accept IC10, use controls, run programs, bind power/data networks or receive new wiring. Heavy coil assembly uses native construction instead of internal wiring at the display-only stage. New saves preserve partial stages; older completed Core saves migrate to the final stage. The completed native display/socket appearance is preserved.

Validation: native-reference build without warnings/errors; 14 Smart-kit placement/recipe checks, 15 Core save/XML/chip/legacy checks, 49 stage/model/control/rollback checks, 2,085 native LED/socket geometry checks and 21,938 other geometry checks passed. Stage icons visually inspected. Actual Unity construction/slot/wiring/save-load/multiplayer verification remains pending.

# Modular Switchboards 1.0.116 — original battery floor depth and material

The unfinished battery holder now uses the original deepest native APC floor geometry and material instead of the shallow gray plate. Preserve its original floor depth, vertex channels, UVs, material roles and property blocks. Expand only in X/Y to close the unfinished aperture. The completed native holder stays unchanged. The F1 unfinished image matches the deeper original floor.

Battery construction remains 5 DIN kits plus 1 Electronic Parts; cell separate. Transformer construction remains Small 5 kits plus 2 Heavy Cable Coils, Medium 8 kits plus 6 Heavy Cable Coils. Completed-only new wiring and existing save/power/slot gates remain.

Validation: native-reference build without warnings/errors; 12 production floor-selection/material-role/depth/backface checks passed. Actual Unity appearance/construction/slot/wiring/save-load/multiplayer verification remains pending.

# Modular Switchboards 1.0.115 — battery completion parts and heavy transformer windings

Battery holder: 5 DIN module kits build the body; 1 Electronic Parts completes the original native holder. No Gold or Plastic Sheet is required for this completion. The removable cell remains separate. An opaque gray backing now closes the unfinished aperture, with a matching F1 stage image; the completed original holder is unchanged.

Transformer winding completion now requires Heavy Cable Coils: Small uses 5 DIN module kits plus 2 Heavy Cable Coils; Medium uses 8 DIN module kits plus 6 Heavy Cable Coils. The heavy coil prefab is resolved from the native cable catalog instead of guessing its name. Body construction, completed-only new wiring, slot/power gates, saved-stage migration and other recipes remain as before.

Validation: native-reference build without warnings/errors; 12 updated production winding/contact-priority checks and 21,938 geometry checks passed. Actual Unity appearance/construction/slot/wiring/save-load/multiplayer verification remains pending.

# Modular Switchboards 1.0.114 — restore original battery holder model

Restore the original battery holder appearance without added gray frame bars or extra gold contact pads. Five DIN module kits build the body with an empty opening; 1 g Gold completes the original native holder. The battery cell remains separately removable. Retain construction stages, old-save completion migration, power/slot gates, separate F1 stage images, and the rule allowing new wiring only on completed modules. Battery stage images now show only the original body and native holder.

Validation: native-reference build passes without warnings/errors. Recipe, migration and wiring sources remain identical to 1.0.113. Published source snapshots are preserved. Actual Unity appearance/interaction/save-load/multiplayer validation remains pending.

# Modular Switchboards 1.0.113 — battery construction, stage icons and completed-module wiring

Battery holder construction now uses 5 DIN module kits for the base, then 1 g Gold to finish. There is no Plastic Sheet requirement. The unfinished gray mounts differ visibly from the completed native holder with gold contact pads. Insert the removable battery cell only after completing the holder. Incomplete holders cannot conduct, charge or discharge. Existing completed holders migrate to the completed stage when loading older saves; new saves retain their construction stage.

New internal cables require completed modules at both endpoints. Incomplete contacts do not show wiring markers; attempting to connect displays a completion message. Existing wires are retained and can still be removed with wire cutters. A previously selected endpoint is rechecked before connecting.

F1 Build States now has separate unfinished/finished images for both transformers and the battery holder. All six new icons use the production geometry exports; transformer images retain the original winding supports and materials.

Validation: native-reference build without warnings/errors, 14 battery save/migration/conduction checks, 22 module wiring readiness checks, and 21,934 production geometry checks passed. The six stage icons were visually inspected. Actual Unity construction/slot/wiring/save-load/multiplayer verification remains pending.

# Modular Switchboards 1.0.112 — original winding supports in unfinished transformers

Based on the accepted 1.0.110 appearance, replacing the rejected 1.0.111 visual change. Unfinished Small and Medium transformers hide only the copper winding while retaining original holders, covers and leads. Small keeps its original WindingBands; Medium retains the exact gray/dark support triangles embedded in the original winding mesh. The original gray fascia is flat and coplanar behind the missing winding, without new holder primitives or a white plate. Completing construction restores the original recessed face and full winding. Kit prices, construction quantities, power gates, save migration and the state -1 startup fix remain unchanged.

Validation: native-reference build without warnings/errors; 17,422 geometry checks and 8 initialization checks pass, with exact support triangle/UV provenance verified. Actual Unity appearance, interaction and multiplayer verification remains pending.

# Modular Switchboards 1.0.110 — transformer prefab initialization fix

Fix the 1.0.109 startup failure: do not invoke native stage visualization on an unplaced transformer prefab at state -1, and do not rebuild its fitted hitbox while the native state has all children inactive. Explicitly restore shared body, terminals and controls in both placed construction stages. Completed-stage winding visibility and the 1.0.109 recipes/counts remain.

# Modular Switchboards 1.0.109 — cabinet economy and transformer construction

Cabinet kit: 60 Iron + 30 Copper, Electronics Printer only. Small uses 1 kit + 2 Plastic Sheets; Medium uses 3 kits + 5 Plastic Sheets, including reverse/collector variants.

DIN rail kit: 5 Iron. One kit per Small or Medium rail. DIN module kit: 5 Iron + 20 Copper. Other kit recipes remain unchanged; all custom kits remain exclusive to the Electronics Printer.

DIN transformers now have two construction stages. Small: 5 module kits for the body, then 3 normal Cable Coil units. Medium: 8 module kits, then 5 normal Cable Coil units. The unfinished body keeps the gray pocket backing without windings. Its terminals can be wired, but it transfers no power until finished. Aim the coil at the body to finish construction; terminal targets retain wiring priority. Native construction handles material consumption and stage dismantling. Existing completed transformers migrate to the completed stage when loading older saves.

Validation: native-reference build succeeds without warnings/errors; 28 save/XML/join-order checks, 12 winding-versus-terminal routing checks, and 4,791 power-engine regression checks pass. Actual Unity stage rendering, construction interaction and multiplayer still need in-game testing.

## Previous release notes

# Modular Switchboards 1.0.108 — own-item preview and hitbox audit

Construction previews now suppress copied opaque model renderers across all own structure families. This fixes coloured transformer windings, front parts, Smart screens/status pieces and door parts appearing at the same time as the green blueprint. The native animated fill, static contours, native port helpers and validity colours remain; the placed objects keep their original materials.

Board-mounted parts use the actual blueprint bounds for an unpadded, scaled selection box. Transformers and Smart Output now receive the same handling as ordinary DIN parts. Controls use their real fitted collider bounds without native extra selection padding. The accepted cabinet frame/placement layout stays intact.

DIN modules, transformers, Smart Core/Net/Output, door modules and DIN rails use a passive triangle hitbox built from their real model. Interaction/slot colliders and mounting surfaces remain separate. Width changes rebuild the passive body from that object's own geometry, excluding mounted children, even if its renderer is temporarily hidden. Runtime-generated meshes are owned and released independently of shared prefab meshes. Native bounds caching is followed by restoration of the fitted model bounds.

All seven custom construction kits keep their own model blueprints and receive a convex physical package envelope matching that geometry; native trigger colliders, quantity, identity and hand poses are retained. Perforated installed covers and labels retain their existing mesh colliders; carried labelled covers retain their existing thin physics envelope and saved preview state. See Verification/PREVIEW-HITBOX-AUDIT-1.0.108.md for the family-by-family audit.

Native-reference Release build: 0 warnings/errors. New source/stub preview/selection/body/kit/audit checks and existing model, door, cover, resize, placement, native-helper and width-upgrade regressions pass. Actual Unity rendering/Harmony execution, MeshCollider cooking/raycast priority, moving-control feel, dropped-kit physics and multiplayer/save-load still require in-game verification. No gameplay power or wiring change is included.

# Modular Switchboards 1.0.107 — prevent intersecting cabinet bodies

Reject overlapping cabinet housings during construction, including **Medium beside Small on different half-metre grid cells**. The same rule applies in the opposite build order and between unfinished frames. Native grid occupancy and terminal adjacency alone could miss a physical overlap between differently sized cabinets.

The placement check reads each cabinet's actual housing mesh bounds and transform and compares oriented body volumes. It reserves the future housing even at the frame stage. It handles both sizes, Basic/Reverse, distributor/collector profiles and rolled wall mounting. Properly separated or merely touching volumes are allowed; existing native placement checks can still reject other conflicts. Missing housing geometry falls back to the cabinet bounds.

This adds no colliders or selection boxes. Frame targeting, geometry, placement grid, power logic and saved identifiers are unchanged. The native green/yellow/red feedback and APC-style terminal adjacency introduced in 1.0.106 remain. Newly blocked body overlap produces the native placement-obstacle message and red preview. Existing constructed objects are not moved or deleted.

Local validation: native-reference Release build with 0 warnings/errors; 2,367 body-volume checks including actual SBMS housing bounds, mixed sizes in both orders, rotations, depths, lifecycle cleanup and random volume cases; 1,414 endpoint/colour/placement checks; 29 model-preview checks. Source/extracted tests use stubs. Actual Unity placement, rendering, registration/load timing and multiplayer verification remain for in-game testing.

# Modular Switchboards 1.0.106 — native cable placement feedback

Cabinet placement now uses the game's own network-join detection for **yellow previews and connected port arrows**. Valid empty placement stays green; invalid placement stays red. The static model outlines follow the native validity colour while preserving their opacity and the existing native animated fill.

Apply the APC-style adjacent-device rule to the future power ports of all eight cabinet variants. Directly facing device terminals cannot consume the space required for a cable. Neighboring unfinished switchboard frames also reserve their future port access. Ordinary placement constraints and the game's compatible networked-pipe exception remain. Cabinets can still be placed beside one another when their terminals do not create this conflict; this is not a blanket minimum-distance rule.

Real unfinished cabinet ports remain NetworkType.None and electrically inactive. Only the unregistered construction cursor exposes Power during native SmallGrid.WillJoinNetwork, with immediate restoration on success or exception. Endpoint references are preserved so the native per-port yellow indicators work. No custom colour guesses, extra wiring networks or new preview animation are introduced.

Native-reference Release build: 0 warnings/errors. Production placement helper and extracted construction/outline methods pass 1,412 checks with stubs, across eight profile combinations, rotations and planes, cable joins, neighboring completed/incomplete cabinets, APC, invalid placement, control isolation and exception cleanup. Native port-helper, model-preview and source/path power regressions also pass. Actual Stationeers graphics, Harmony execution in Unity, physics and multiplayer placement still require in-game verification.

# Modular Switchboards 1.0.105 — three-wire power contacts and F1 families

Power contacts on DIN analyzers, breakers, fuse holders, transformers and battery modules now accept **three wires on IN and three on OUT**. Contactor IN, NO/OUT and NC also accept three. A1, DATA, Smart Output control and Smart Core POWER IN stay at one; door bridge terminals keep their existing three-wire limit. Three incoming wires can converge on a shared analyzer after individual input breakers. A fourth wire is refused. Ratings apply to the actual combined load through the module, not separately to each attached wire.

The actual router permits a shared entry pocket at multi-wire module inputs while retaining clearance around devices, rails, other leads and cable segments. Saved and joined wiring retains all three incoming connections; packet formats and existing endpoint IDs are unchanged. Direct cabinet IN-to-IN and IN-to-OUT bypasses, feedback loops and inappropriate control connections remain prohibited.

One source/path power engine now serves all eight cabinet profiles, including existing distributors. It shares real input-network, battery and transformer budgets across converging paths and multiple outputs, supplies current demand before spare headroom, and records actual load on each physical path. Parallel breakers carry their own share; a common upstream protector carries the sum. Repeated provider queries and completed callbacks cannot duplicate a cycle's budget. Partial input repayments, partial cell charging, transformer standby, source rebinds and pending provider callbacks retain their accounting. Paid charging and standby also consume the shared source budget.

F1 lists **one Switchboard Small and one Switchboard Medium family page**, each explaining both I/O ratios and Basic/Reverse selection. All eight actual cabinet variants remain available from the Switchboard Kit and retain their stable saved IDs. Family searches include Reverse and collecting variants. Small has 1 IN / 2 OUT or 2 IN / 1 OUT; Medium has 1 IN / 3 OUT or 3 IN / 1 OUT. Existing shell costs, frames, covers, rails and modules follow the corresponding size.

Collecting variants put inputs at the original OUT sockets and their single output at the original IN socket; Reverse flips the sides. Placement helpers now show the correct input arrows for every logical input, including the second/third saved native slots. Actual saved native roles, transforms, cable cells and network types are preserved.

Local validation: native-reference Release build with 0 warnings/errors; 4,791 source/path/family/capacity checks; 213 native placement-helper checks; F1 catalog/search checks; full power/wiring regressions; and four real routing fixtures with three branches into a shared analyzer (28 routes). Tests use production source or extracted methods with native/Unity stubs. Actual in-game visuals, native threaded callbacks, multiplayer and world save/load still require player verification.

All own item and construction previews reuse the game ThingImporter blueprint-template material, preserving its shader, textures and animation parameters. Static model/cover contours, real cover openings and saved labels remain. Custom diagonal hatching and custom opacity animation are removed. Native GPU appearance still needs in-game confirmation.

Cabinet panels and independent covers retain the native texture-array paint material on every colour and repaint. Gold and bronze no longer swap to a legacy solid-colour swatch. The native prefab surface-layer index is preserved instead of reading legacy gloss as an array index. In-game gold/bronze comparison remains pending.

Medium outer door corners now match the housing’s circular 40 mm profile instead of the previous 20 × 40 mm ellipse. Centre seam, handles and hinge pivots remain unchanged. Small already uses matching 20 mm corners. Transferred covers explicitly restore non-emissive saved paint, even when white matches the prefab colour. Physical paint clears inherited emission; live indicator materials remain independent. Internal cable shadow casting is disabled to avoid enlarged aliasing streaks, while cables retain received lighting and saved paint.

Hinges are smaller (10 × 24 × 16 mm) and mirrored on both sides of Medium double doors. Painted cabinet panels and independently coloured covers retain the native textured paint atlas and selected colour layer, including metallic paints, instead of forcing a matte surface or swapping to solid-colour swatches. Visual verification in game is pending.

Power queries now share a cached graph, reachable sets and module paths until topology changes. Supply, demand, battery charge, energy use and protection still update normally. Hidden wiring markers skip selection work. Revision-8 routes with unchanged endpoints retain their exact paths and upgrade without A*; moved contacts and older routes still migrate atomically. Player FPS/load-time measurements are pending.

Failed saved-route migration now waits for an actual wiring change before retrying. Periodic contact refresh no longer restarts synchronous pathfinding on the same failed snapshot. In-game FPS impact still needs verification.

Fixes the 1.0.85 Mono startup error by removing the Harmony patch on a static interface method. Covers handle spray painting through their own interaction methods.

Door bridge contacts now accept **three wires per contact on both sides**. Routing checks shared branches outside the contact fork and retains existing cable spacing. Medium transformer contact markers now align with its actual six-slot body; saved routes migrate to revision 9.

By **KreeZy**. Build and manually wire modular DIN switchboards in Stationeers.

**Required: BepInEx + [StationeersLaunchPad](https://github.com/StationeersLaunchPad/StationeersLaunchPad/).** Subscribing on Workshop alone does not install the loader. Also install [LibConstructReloaded](https://steamcommunity.com/sharedfiles/filedetails/?id=3751750326) and load it first.

The mod-list/Workshop preview now carries an orange StationeersLaunchPad requirement banner and a more detailed switchboard illustration. Loader requirements and installation links are first in both descriptions. The in-game text uses plain bullets; the prepared Workshop text retains Steam BBCode. The preview is promotional illustrated artwork, not a gameplay screenshot.

Route previews now capture geometry on the main thread, then search on a worker with no Unity/world access. Hover polls a completed-result cache rather than waiting for A*. Moving to another contact, changing coil type or wiring revision cancels stale work; a pending result shows a calculating state and consumes no cable. Search work arrays are reused per thread, and edge geometry/visual costs are shared across bend-history states. **Cold authoritative commit validation and legacy migration remain synchronous.**

Burnt insulation now uses its own renderer with exactly the intact wire's native paint/material path. Local scorch and exposed conductors have a separate, compact mesh/renderer with two unpainted Standard materials. Burnt bodies participate in continuous saved-colour restoration, just like intact wires, instead of being skipped after initial construction. Player screenshots after 1.0.80 confirm red insulation with local dark ends and exposed conductors; preview responsiveness still needs player feedback.

All new routes reserve an **8 mm cable envelope and 9 mm centreline separation**, independent of the coil held. Normal remains 2.4 mm, Heavy 4.4 mm with narrow spiral marking, and Super Heavy 8 mm with silver joints on straight sections. Empty contact entries and route anchors are protected through the routing depths, and grid routes leave at least 9 mm between bends. The Small reverse output and shared Input lead anchors were adjusted for wider wiring. Door layers stay within 63 mm of their inner frame; do not increase that depth into the closed cabinet's plate wiring.

**Actual-load cable limits:** Normal 5 kW, Heavy 100 kW, Super Heavy 500 kW. Limits are read from the native construction-kit cable prefabs when available. Demand and advertised supply alone do not burn a wire; actual delivered power does. Common upstream wires carry the sum of their branches. Battery output, charging and transformer service loads use the existing actual-transfer solver. The native strict `actual > limit` comparison is preserved. One overloaded cable ruptures per application, alongside existing module protection.

A ruptured wire retains its saved insulation colour and type markings along its length. Only the broken ends are scorched (about 6mm), slightly tapered and fitted with three bent exposed metal conductors; a visible gap remains between them. It no longer conducts. The rupture uses the game's **CableSpark audio and native 100-spark emitter**. Wire cutters remove it without returning a coil; painting cannot repair it. Save/load and multiplayer updates retain damage, type and original insulation colour. Initial joins and repeated updates do not replay old rupture effects.

Coils preserve held colour during installation and saved colour on intact-wire recovery. Native compatible hand stacks may mix colours and retain the receiving stack's colour. Batch refunds are prepared atomically before intact wires are removed; burnt wires never contribute to a refund.

Saved paths upgrade atomically to **route revision 9**. The larger reservation can reduce capacity in densely packed arrangements; if rerouting fails, the original connections and quantities remain intact and manual rewiring is requested. Network packets now include the rupture flag and still read earlier wire formats. **Use a world copy and install 1.0.105 on the host and every client.** Older builds cannot read the new packet format. Local build and automated results are recorded in Verification; the game appearance, sound, effect placement and closed-door clearance still need an in-game check.

## Requirements

This is a code mod. **A Workshop subscription alone does not install its loader.**

1. Install BepInEx and [StationeersLaunchPad](https://github.com/StationeersLaunchPad/StationeersLaunchPad/) following the loader's installation instructions.
2. Subscribe to [LibConstructReloaded](https://steamcommunity.com/sharedfiles/filedetails/?id=3751750326).
3. Install Modular Switchboards and enable it in LaunchPad. LibConstructReloaded must load first; this dependency is declared in About.xml.
4. Restart the game after changing code-mod files.

For a local ZIP installation, extract the **ModularSwitchboards** folder into `Documents/My Games/Stationeers/mods/`. The result must contain `mods/ModularSwitchboards/About/About.xml` and `mods/ModularSwitchboards/Assemblies/ModularSwitchboards.dll`.

Use the same version and required dependencies on the host/server and every multiplayer client. Enable only one local or Workshop copy of Modular Switchboards.

## What you can build

- Small cabinets with two 7-position DIN rows and two Outputs; Medium cabinets with double doors, three 14-position rows and three Outputs. Both sizes have reversed Input/Output variants.
- Breakers, replaceable fuse holders, battery backup, cable analyzers, ordinary and NC contactors.
- Four-position Small and six-position Medium transformers, adjustable up to 5 kW and 25 kW. Each uses 10 W for control electronics in the current game version, supplied at IN in addition to transferred power.
- Door LEDs, manual selectors/main switches, latching TOTAL STOP, individual hinge bridges, fitted inner covers and labels in 1, 2, 3, 4 or 6-position widths.
- Smart Core, Net and Output modules for programmable control.

## First circuit

Print the cabinet kit in the Electronics Printer. Right-click to choose the cabinet variant, place its frame and finish the shell with the indicated materials and Wrench. Print separate rail and module kits, open the door and fit the parts.

With the inner cover removed, use **Cable Coil, Heavy Cable Coil or Super Heavy Cable Coil** to connect contacts. Route cabinet **Input → protection → cabinet Output**. **Wire Cutters** remove wires. A cabinet does not connect its terminals automatically. Manual switches and contactors do not provide overload protection.

Use F1 for each part's contacts, rating, construction cost and controls. The cable analyzer tooltip and configuration tablet report the selected Input/Output network, not an isolated individual wire's consumption. Fit the inner cover after wiring, then add labels and edit them with a Labeller.

## Smart modules

- **Core:** four positions, runs an IC10 chip and provides its programmable display. The chip addresses Core itself as `db`.
- **Net:** one position, connects Core to a chosen data network through its DATA contact.
- **Output:** two positions, drives only the A1 control input of a classic DIN contactor. The contactor's separately protected IN/OUT carries the load. Select one of six private addresses, `d0` to `d5`, using the Output's screwdriver screw.

Net and Output extensions must form a continuous row directly to the left of Core. Core supplies their control bus. See `Examples/` for IC10 programs.

**Lua is optional.** Ordinary IC10 does not need StationeersLua. Lua programs need a compatible StationeersLua installation and a Lua chip; `Examples/DinSmartModule.lua` is an optional example.

## Typed internal wiring — added in 1.0.70

- Wire contacts using any of the three native coil types: Normal, Heavy or Super Heavy. Each completed connection consumes one unit of the coil held when you finish it.
- Wire maximum diameters are **2.4 / 4.4 / 8.0 mm** respectively; the route preview uses the same diameter. All fit inside the existing routing clearance. Paint colour remains independent of cable type.
- Wire Cutters return the matching native coil. Dismantling a connected module refunds each attached wire in its own coil type.
- XML saves and multiplayer state retain the type, route and paint. Existing wires load as Normal without losing their connections or colour. Host and clients must all update.
- Internal wire types retain their saved appearance and paint. Actual-load limits are Normal 5 kW, Heavy 100 kW and Super Heavy 500 kW; overloaded wires rupture and stop conducting.

Game test: use all three coils in one cabinet, compare the previews and finished thicknesses, paint a Heavy wire, save/reload, then cut it and check the returned coil. Also test mixed-type module-demolition refunds and multiplayer views. Use a copied world.

## Fitted covers — added in 1.0.68

This build adds a new saved item type. **Try it in a copy of your world before publishing or replacing a public installation.** Host and clients need the same version. Production costs are unchanged.

- Remove any inner cover with a Wrench: recover **one non-stackable Fitted Switchboard Cover item** with its visible openings, labels, exact saved texts, positions and colour. Label kits are not refunded separately.
- Hold that item and left-click inside an open, uncovered cabinet of the **same size** for two seconds. Small/Reverse share covers; Medium/Medium Reverse share covers. No extra cover or label kits are consumed.
- Labels retain the aperture spans beneath their full DIN width. Adjacent labels can jointly preserve one wider opening. Current modules also create their required openings, even in previously solid areas.
- Removing a label immediately releases its own retained aperture span. A current module still keeps its necessary opening. A newly placed replacement label does not inherit a removed label's stale holes.
- On removal, openings without a retaining label are discarded. Even without labels, removal returns the fitted cover item and preserves its colour.
- The item can be carried, dropped and precision-placed. Its shape preview is specific to the individual cover. Precision placement starts upright with the front facing the player; native rotation controls remain available. Save/load and network serialization retain the payload.
- A new cover takes the cabinet colour once. Spray a mounted or loose fitted cover independently; its saved colour remains when moved to another cabinet or when the cabinet is repainted.

First game test: label a Medium cover, remove it with a Wrench, drop/pick up the item, save/reload, then fit it on another Medium with different modules. Remove a label above an empty retained opening and check that it closes; finally remove every label and recover the fitted cover with its colour. Also check host/client views and a failed attempt on a Small cabinet.

Gameplay wiring, power simulation and existing prefab identities are retained. The full public Workshop description and universal tablet readouts from 1.0.67 are included. Detailed older development history is in `CHANGELOG.md` in the source package.

Development is ongoing. New fitted-cover items do not exist in older builds, so do not use a test world's new objects with an older public version.
