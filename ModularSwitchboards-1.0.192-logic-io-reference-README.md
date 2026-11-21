## 1.0.192 — Fix native kit export serialization

Fixes the live-game `Nine control templates required` failure reported from 1.0.191. Unity JsonUtility omitted collection fields from the mod DTOs. Template loading now uses the game-provided Newtonsoft.Json library; all kit export reports use the existing public-field DiagnosticJson writer, including nested collections and raw vertex layouts. No extra JSON DLL is bundled.

Run the normal mod and send `%USERPROFILE%/AppData/LocalLow/Rocketwerkz/rocketstation/ModularSwitchboards/Exports/NativeLogicIO-kit-reference-1.0.192.zip`. The exact path is logged. Export remains client-only and once per version; battery reference extraction remains removed. Disable any old standalone audit copy. The reported startup failure is confirmed in the supplied Player.log; full GPU extraction still needs a live-game check.

## 1.0.191 — Native Logic I/O kit reference in AppData

The normal Modular Switchboards mod now exports the original Logic I/O kit automatically on a graphical client. No separate NativeLogicIOAudit mod is required; disable any old standalone audit copy. All actual kit variants retain their construction-option indices. The reference includes models, hierarchy, material properties, selected texture-array slices, connectors and screw controls, plus proposed top/bottom DIN layouts. This is a reference export, not playable DIN logic modules.

On Windows, open `%USERPROFILE%/AppData/LocalLow/Rocketwerkz/Stationeers/ModularSwitchboards/Exports` and send `NativeLogicIO-kit-reference-1.0.191.zip`. The exact path is also printed in the game log. Export runs once per version; an existing ZIP is reused. Delete that version's ZIP to request another capture. A short graphics readback pause is expected. Dedicated servers skip the export. Failed items are marked PARTIAL in the report/log. No original prefabs, live wiring or save data are changed. The old native battery reference exporter has been removed; existing reference files are left in place.

Validation: native build and offline planner/kit-selection checks. Actual in-game extraction still needs testing.

## 1.0.190 — Direct Door Dial input through Net

Adds Door Dial DATA -> dedicated Door Bridge -> Net DATA as a local input to the Smart Core on that Net's continuous bus. No external cabinet cable or Output address is required. Core batch and reference-ID lookups include only the completed Dials connected to its own Net modules; cutting the route, removing a module, breaking the bus or using an incomplete component removes access. Net reports a usable direct Dial connection with its existing green indicator.

The existing Dial -> Bridge -> external cabinet Output route remains available for native logic and external data networks. Each Dial bridge has one destination, and Net has one physical DATA connection. Mixed or ambiguous paths fail closed. Dial/Bridge data edges remain outside the power solver and never join external networks. Smart Door Display remains exclusive to Smart Output through its own dedicated Bridge; it cannot connect to Net. d0-d5 remain Smart Output addresses.

F1 and tooltips explain both routes. Examples/DinSmartDoorDial.ic10 reads native Setting and Ratio using lb. Native compilation, 77 production Dial routing/registration checks, 118 Smart PLC bus/visibility/isolation checks, 8436 display routing/proxy checks and 22 native Dial API contracts pass. Managed fixtures include route restoration, live deletion, burnt/partial/mixed wiring, local inputs without an external cable and access isolation between two Cores. Live in-game wiring, save/load and multiplayer still need testing.

## 1.0.189 — Short selector position mark

Shortens the round selector's white position stripe from 11.2 to 5.2 mm and moves it toward the end of the grip. The grey grip, aligned control depth, Dial label range arc and control behavior are retained.

Production selector geometry/rotation checks and native compilation are validated; the selector icon is regenerated from the updated production mesh. Final appearance needs an in-game check.

## 1.0.188 — Dial label scale and matching selector depth

Removes the Dial's separate grey door plate and transfers its original range arc into the lower part of the optional Door Label. Dial labels now place the editable name in the upper row, like the round selector's name above 0/I. The arc appears only on a label attached to a completed Dial; other labels keep their existing markings. Removing a label removes the arc with it.

Matches the selector grip to the original Dial knob's grey texture and finish, retaining the white position stripe. Reduces Dial protrusion by 3 mm and brings the selector grip forward by 3 mm so their faces align at approximately 23.7 mm from the mounting plane. Both have a matching dark circular seat and the existing shared grey bezel. Front interaction bounds follow the new depths.

Mounting positions, label names, rear adjustment, native dial logic, wiring and saved state are retained. Native build, label placement/geometry and control checks are validated. Final appearance and label target switching need an in-game check.

## 1.0.187 — Matching door control finishes and selector

Unifies the Dial, round selector and five coloured pushbuttons with the same darker matte grey bezel finish and dark body. Dial retains its original transformer knob surface, grey door plate and dark range arc. Button face colours remain distinct.

Replaces the selector's broad white oval with a faceted, elongated dark handle and a narrow white position stripe. The grip remains inside the existing bezel throughout its quarter turn; mounting positions, labels, contacts, control timing and saved states are retained. Includes the rear Dial screw and Screwdriver-only adjustment changes from 1.0.186.

Native compilation, production selector geometry/rotation checks and button behavior checks are validated, and the seven control icons are regenerated. Final appearance requires an in-game check.

## 1.0.186 — Door Dial finishes and rear adjustment

Restores the transformer knob's original dark finish and native white pointer. The flush door plate now uses the same grey as the rounded silver bezel, with a dark range arc and black seat beneath the raised knob. Retains the larger knob and swapped front Increase/Decrease hitboxes.

Enlarges the rear Output-style screw heads to 11.52 mm and moves their white minus/plus marks above them. The two screws remain side by side near the bottom of the body, minus on the installed left and plus on the right. Physical maximum adjustment requires a Screwdriver; the native Labeller maximum-entry shortcut is rejected at these rear controls. Native logic properties and saved state remain compatible.

Native compilation and updated artwork preview are checked. Final appearance and rear control interaction require an in-game check.

## 1.0.185 — Door Dial sizing and adjustment controls

Places the two maximum adjustment screws side by side at the bottom of the Dial rear body, with minus on the installed left and plus on the right. Output-style screw heads are enlarged from 7.2 to 9.6 mm, and their white signs are enlarged and moved below them along the bottom edge. Removes the redundant DATA lettering above the unchanged top cable terminal.

Adds a fixed light plate flush on the door sheet with the original transformer range arc, automatically built with the Dial. The existing optional label is retained for later adjustment. Moves the transformer-shaped knob fully in front of the silver bezel, enlarges it by 10%, gives it a blue-grey finish with a white pointer and a dark circular seat underneath. Front interaction and selection bounds follow the raised knob. Swaps the front knob Increase/Decrease hitbox sides as requested. The shared door-control bezel, native dial behavior, data route and saved state are retained. Native compilation and existing Dial routing/registration and API checks pass. Final rear orientation and appearance require an in-game check.

## 1.0.184 — Door Dial controls and rear adjustment

Door Dial now reuses the transformer's exported knob and pointer inside the same silver bezel as the other door controls. Its rear body matches the door button family. Maximum adjustment uses the exact Output selector screw mesh and surface on the rear: plus on the right, minus at the bottom, with white marks above each screw. DATA remains at the top and gains a white label. The front has no adjustment screws.

Native dial behavior, wiring, data-only network registration, kit cost and saved state are retained. F1 and tooltip now identify the rear adjustment screws. Native compilation and existing Dial routing/registration and API checks pass; final appearance and interaction require an in-game check.

## 1.0.183 — Door Dial for native logic and Smart Core

Adds a door-mounted rotary dial using the shared silver control bezel, a black knob with white pointer, two front screws for the native maximum and one rear DATA terminal. It uses one Door Kit and accepts the ordinary door label.

Wire DATA to the door side of a dedicated Door Bridge, then its inside side to an external cabinet Output. With an external data cable connected, native logic can read Setting and Ratio and Smart Core can access the same dial through its Net. No power or Smart Core is required. Dedicated data bridges reject mixed power wiring and cannot join two external networks. Dial wires are excluded from the power solver.

Native LogicDial owns interaction, maximum adjustment, logic properties and saved/networked state. Routing, data-only registration and cleanup, placement, labels, F1, existing displays and Core scheduler checks pass. Native compilation passes; live Unity appearance, interaction and multiplayer still need an in-game check.

## 1.0.182 — Orange Output indicator without a Core chip

A completed Output attached to a powered, enabled Core now keeps its address visible and shows an orange indicator when the Core has no IC10 chip or its output session is not ready. OFF or unpowered Core remains dark. A ready, connected output keeps red for OFF and green for energized OUT.

The indicator uses available Core power independently of the permission to drive OUT. Missing-chip/reset protection and program-command reset behavior are retained. Tooltip and F1 explain the orange state. Native compilation and indicator, Output proxy/reset and scheduler checks pass; appearance still needs an in-game check.

## 1.0.181 — Reset Outputs before Core restart

Core OFF/ON, power loss/restoration and loading start a fresh Output session. Old Output commands and connected door display values are cleared before the bus becomes available and before the first instruction executes: On 0, display Mode 0, Setting 0 and green. The chip restarts from its first instruction, so the program can initialize the outputs again. Stable powered ticks do not clear fresh program writes. Output addresses and wires remain unchanged.

Keeps the final display behavior from 1.0.180: IDLE without a chip/program, WORK for a healthy loaded program, explicit db content retained even after a short script finishes, ERR overriding custom content, and a blank display when OFF/unpowered. Native display modes and save/network payloads remain compatible.

Native compilation and scheduler/reset-order, display/save/join, Output proxy, routing and status checks pass. Load behavior is covered by the managed native-scheduler fixture; live Unity/multiplayer testing remains to be done.

## 1.0.180 — Core WORK status, db display persistence and Output reset

A powered, enabled Core with a healthy non-empty program now displays WORK even after a short script reaches its end. IDLE is reserved for a missing chip or empty program. Faults display ERR with the line number; OFF or loss of power blanks the screen. Status no longer depends on the native instruction pointer or reflection over the private parsed-line collection.

Explicit db Setting writes retain the game's Mode, Setting and Color formatting after execution ends. Untouched display values keep automatic status; Automatic WORK restores it. Errors always override custom values. Native display mode numbers and the existing same-value store-intent hook are preserved.

Removing, replacing or reprogramming the chip clears attached Smart Output ON commands and connected door display values (OFF, Mode 0, Setting 0, green). A Core without a chip cannot energize its Outputs, including legacy loaded state. Periodic cleanup covers saved/disconnected modules and late wiring resolution. Output addresses and wires are retained. An ordinary power interruption with the same installed chip preserves the existing command-resume behavior.

Native compilation and status, scheduler, display/save/join and Output proxy/reset checks pass. No live Unity or multiplayer execution is claimed.

## 1.0.179 — Rounded industrial selector grip

Replaces the pointed round-switch paddle with a broader, rounded black grip and a large rounded white face inspired by the reference selector. Both meshes fit the existing shared silver bezel and keep the 3 mm forward mounting offset. The hollow collar, rear terminals, door labels and switching behavior stay in place.

The body and white face are closed, smooth-normal capsule meshes. Geometry checks cover their winding, normals, envelope and full quarter-turn clearance; the updated icon is rendered from the same production meshes. Button colours, names, pulse timing and save/network formats are unchanged. Final appearance requires an in-game check.

## 1.0.178 — Selector grip clearance and door button names

Shrinks the round switch grip and its white marker so the complete quarter-turn stays inside the silver bezel opening. The grip retains its 3 mm forward position. Geometry checks verify at least 0.4 mm radial clearance throughout rotation; the rear terminals, bezel, mounting and switching behavior remain unchanged.

Button names are now Door Green Button, Door Blue Button, Door Red Button, Door Black Button and Door Yellow Button. Blue and yellow keep their light face colours. Existing prefab identities, saved wiring, kit costs and pulse behavior are preserved.

Native compilation and geometry, control, label and catalog checks pass. Final appearance needs an in-game check.

## 1.0.177 — Five button colours and raised selector grip

Raises the round switch grip and white marker by 3 mm, with matching interaction bounds. The shared rounded bezel, rear terminals and label fit stay in place.

The existing button becomes Green Button with a lighter green face and retains its saved prefab identity. Adds Light Blue Button, Red Button, Black Button and Light Yellow Button to the Door Kit. Each costs one kit, uses one door position and supports the existing editable label. All five share the same non-illuminated face, 550 ms pulse and wiring behavior. Colour-specific icons, F1 titles and English/Czech search terms are included.

Native compilation and control, label, catalog and model checks pass. Artwork previews use the production palette; final appearance requires an in-game check.

## 1.0.176 — Matching rounded collars for door controls

The Door Button and Door Round Switch now share a rounded, hollow silver-grey bezel above the black mounting ring. The green push face sits slightly below the rim; the selector retains its rotary grip and white marker. The original outside diameter, mounting positions, rear terminals and label fit are preserved. The hollow opening keeps the button visible throughout its 2 mm press travel.

Regenerates both icons from the actual production bezel mesh. Pulse duration, switching, wiring, kit costs and save/network formats are unchanged. Native compilation and geometry/control regressions pass; final appearance needs an in-game check.

## 1.0.175 — Momentary door pushbutton

Adds Door Button to the Door Kit for one kit and one door position. Reuses the round switch mounting collar, silver-grey bezel, rear block and two screw terminals with a green, non-illuminated push face. A click connects IN to OUT for 550 ms, matching the installed game's LogicButton delay, then releases automatically. No hold is required; repeated clicks during a pulse do not extend it. Requires an external supply to pass a signal and provides no overload protection.

The existing Door Label fits the button and can be edited with a Labeller. Includes F1 help, catalog/search and a dedicated icon. Server state owns the timed release, clients use the native interaction/update path, and loaded saves release any transient press. Existing switch, TOTAL STOP, display and holder behavior remain intact. Native compilation and offline control/geometry regressions pass; live game appearance and multiplayer still need testing.

## 1.0.174 — Battery holder limit follows wiring through OFF devices

The one-holder-per-output-branch limit now follows installed wiring through OFF breakers, switches, contactors and transformers. Switching a device off or removing a cell no longer permits a second holder in series or on a merged output. New conflicting internal wires are rejected. Existing banks keep their cells and energy; only the holder with the lowest stable reference stays eligible until the wiring is physically separated. Separate output branches may share a charging feed. Contactor coil terminals remain isolated from the power contacts.

Includes the improved door display F1 help from 1.0.173. F1 now explains that OFF devices do not separate a holder branch. Holders remain usable for ordinary circuits as well as Smart Core backup.

## 1.0.173 — Clearer door display F1 help

Rewrites the Smart Door Display and its label descriptions to match the other modules: purpose, wiring and programming, then placement and kit requirements. Adds linked Door Bridge, Smart Output and label entries, explains the screwdriver-selected d0–d5 address and shows On, Mode, Setting and Color IC10 commands. Display geometry and behavior are unchanged.

## 1.0.172 — Rounded display label bottom

Rounds both lower corners of the door display label with smooth 22 mm arcs, matching the door LED label style. The filled upper shoulders, white caption, flat door mounting and native bezel opening remain intact. Native compilation and offline geometry checks verify the change; final appearance needs an in-game check.

## 1.0.171 — Filled door-label shoulders and wider white caption

The caption grows upward and sideways while its lower edge stays fixed. The white field is 179 x 15 mm inside a 184 x 21 mm plate, using the same 2.5 mm side borders as the door LED labels. The dark grey upper shoulders now fill to the full caption width, removing the cut-out corners. The display bezel remains free and the label stays flat on the cabinet door. Placement checks reserve the enlarged outline and retain clearance from the standard upper control row.

Rear connections, display logic, power and save/network formats are unchanged. Native compilation and geometry/clearance checks run offline; final appearance requires an in-game check.

## 1.0.170 — Display label sits flat on the cabinet door

Corrects the display label mounting plane: like the existing button label, its ring lies from -0.8 to +1.2 mm relative to the door board. It no longer follows the raised LED bezel height or covers the screen. Its opening fits around the native display bezel, leaving that bezel and the complete LED face exposed.

Retains the slightly wider white nameplate and larger text from 169, its compact row height, placement clearance checks, grey rear panel and upper screw/top cable entry. Display logic, energy and save/network formats remain unchanged. Existing labels adopt the corrected geometry without moving their board anchors.

Native compilation and geometry tests verify that every label mesh vertex stays within the original thin door-label depth and the opening clears the entire native bezel. Appearance still needs an in-game check.

## 1.0.169 — Thin display label and larger caption

Removes the deep label walls that made the LED surround look like a black enclosure. The surround is now a 1.2 mm skin seated above the native bezel, with only a 1.5 mm outward extension. The LED opening and native visible characters remain clear.

Widens the white caption face from 150 to 160 mm (outer frame 170 mm) and slightly enlarges its text. Nameplate height and vertical position stay unchanged, preserving clearance to the controls above. The grey rear, upper screw, top cable entry, logic, power and save/network formats stay unchanged.

Native compilation and geometry tests verify thin surround walls, clear LED opening and placement clearance. Final appearance still needs an in-game check.

## 1.0.168 — Compact display nameplate, LED surround and top cable entry

The optional display label now fills inward to the actual visible LED opening, above the original raised bezel. Its opening is the intersection of the native LED mesh and the native bezel's inner front boundary: letters remain in the same visible area and white bezel corners are covered. The upper white nameplate is narrower (150 mm face) and lower (12 mm face), positioned immediately above the display instead of protruding into the control row above.

Placement checks reserve room for the display and its nameplate on the correct door leaf. New displays/labels cannot overlap existing control or label bounds; controls and labels cannot be placed into an existing display's reserved footprint by reversing build order. Ordinary neighboring stop/main-switch controls fit above the new compact nameplate. Existing objects are not deleted or moved; their nameplate adopts the revised geometry.

The single rear screw moves to the upper position used by buttons. Cable entry now matches their top entry (Y 23 mm, Z -30 mm); the screw is at Y 16 mm, Z -38.5 mm. Existing endpoint-drift checks reroute saved display leads using the established atomic migration. The filled grey rear panel, two-position door mounting, Output addresses, display logic, energy accounting and save/network format stay unchanged.

Offline validation covers native compilation, native captured bezel opening extraction, visible LED clipping, exact-corner polygon cleanup, front/rear normals, compact-header screenshot reproduction, both construction orders, overlapping labels, rotated door frames and separate leaves, plus existing display/preview/mount/wiring tests. In-game appearance and multiplayer still require a live check.

## 1.0.167 — Filled grey display back and fuller label

Fills the complete rear display silhouette with the same grey material as its perimeter. The black button-style housing, single DATA IN screw and cable endpoint remain in front of the grey panel.

Widens the display label rim to a 5 mm outward offset and reduces the clearance around the native bezel to 0.25 mm. The original upper nameplate and native screen opening remain clear. Display logic, power, placement, wiring and save/network formats are unchanged.

Native compilation and production geometry checks verify face orientation, clear bezel opening and full rear-face area without holes or overlapping fill. In-game appearance still needs confirmation.

## 1.0.166 — Door display rear terminals and fitted label

Replaces the plain rear connector block with the same black rear housing, grey terminal and screw-slot style used by door buttons. The display has one central DATA IN screw; cable entry and the aiming point now meet that screw. Adds a thin grey display outline visible inside the cabinet door. The exterior remains the original native display/bezel without an extra casing or pedestal.

The display label now follows the actual native bezel silhouette with a small, uniform clearance instead of an approximate oval. Its original button-style upper nameplate is retained. Both the label opening and inside grey outline use the contour extracted from the installed game's native LED bezel, transformed to the final door pose. Front and rear face winding is verified so both sides remain visible.

Existing display wire paths are checked against the moved terminal and use the existing atomic route repair: connections, cable type/colour and coil quantities are preserved. If obstacles prevent repair, the original path remains and manual rewiring is reported. Output addresses, Mode/Setting/Color logic, power demand, label restrictions and save/network formats are unchanged.

Native compilation and geometry/placement/logic/route regressions run offline. Exact seating, selection and rear appearance still require an in-game check.

## 1.0.165 — Smart door display and matching label

Adds a Smart Door Display occupying two adjacent horizontal positions on one cabinet door. Only the original screen/bezel sits flush on the door; there is no added front casing or pedestal. Built with 4 Smart kits, it is door-only and uses the original five-character LED display renderer, modes and numeric/text formatting. Its rear DATA IN terminal connects through a dedicated Door Bridge to the existing Smart Output module. Net modules remain external network taps. One Output controls either a classic contactor A1 or one display; output addresses remain d0–d5, selected with the existing screwdriver control.

Programming uses ordinary display properties through the Output address. For Output d1:

```ic10
s d1 On 1
s d1 Mode 1
s d1 Setting 3
s d1 Color 2
```

Use `Setting` (singular), as with the native display. On controls the addressed Output and display together. Mode, Setting and Color are exposed when a completed display is connected. The display retains its settings across disconnection and power loss and resumes when control power returns. Its native power requirement is added to the Output's real service demand from the Core supply, including backup; the signal bridge is not a separate load feeder.

Wiring: Output OUT → bridge plate contact → bridge door contact → Display DATA IN. Each display signal requires a dedicated bridge, isolated from load wiring and A1. Direct wiring across the hinge, a second display/output on that signal, or mixed power/coil connections is rejected. Ambiguous, burnt or incomplete signal paths do not drive a display. Other outputs may still control ordinary contactors. Both leaves of a Medium cabinet have independent mounting and routing surfaces. Display placement reserves both positions; existing door controls cannot overlap either one.

Adds a two-position Smart Display Label derived from the existing button label, with its rounded ring widened around the display and the same upper nameplate. The matching label is available in the Label kit (1 kit). It fits only a completed Smart Door Display on the same door, supports the existing Labeller rename workflow, and must be removed before dismantling the display. The display cable must also be removed before dismantling. F1 descriptions/search and dedicated icons cover the new display and label. Native display state, custom color, mounting data and label text use save/join/update synchronization.

Validation includes native game-reference compilation, production routing/footprint and extracted Output-proxy tests, native API contracts, physical-hit board selection on both door leaves, existing native LED/store behavior, Stationpedia, model preview, wiring/combiner, holder-limit and breaker protection regressions. These are offline checks, not Unity gameplay or multiplayer/save-load execution. Test the first model and rendering in-game before public deployment. The previous holder limit and protection fix are retained.

## 1.0.164 — One Battery Holder per connected output branch

One Battery Holder per electrically connected output branch. Additional holders require separate branches.

The holder with the lowest persistent ReferenceId remains active. Additional completed holders on the same branch neither charge nor supply power; their cells and stored energy are preserved. Empty holders still reserve their branch. Existing cables are not deleted and no artificial short circuit is introduced. Separating branches or removing the active holder restores the next eligible holder automatically. New internal wires that create an additional conflicting holder are refused with an explanatory message. Existing conflicts do not prevent unrelated wiring edits.

Branch detection includes linked cabinet outputs, shared external cable networks across cabinets, downstream input links and series holders. Directional paths through breakers and transformers detect downstream merges without treating a common charging supply as a single backed-up output. Cell presence and state of charge never affect ownership. Power reservations are invalidated when the limit changes, including offers already cached in another cabinet. Native electricity ticks refresh external network membership before service and output calculations.

F1 includes the English rule. Inactive holder tooltips show: “Battery backup limit exceeded — connect to a separate output branch.” The stationary DIN battery experiments remain removed; the breaker-trip priority fix is retained. Cell capacity, native cell identities, construction costs and slot handling are unchanged.

Verification: native API compilation, production holder-limit regression (26 holders, energy preservation, branch split/merge, cross-cabinet links, cached offers, downstream protection, deterministic priority and wire adapter), existing combiner, wiring, protection and Stationpedia regressions. These are offline tests; Unity gameplay, save/reload and multiplayer behavior require an in-game check before public deployment.

## 1.0.163 — Breaker/fuse trips precede stale cable damage

Fixes a reproduced5kW-breaker/5kW-wire overload: the solver queued both failures from the same load snapshot. Applying the breaker trip first did not remove the queued wire failure, so the old handler still burned a wire immediately afterward.

The handler now applies protective trips and detects an actual conducting-to-open transition. If one occurred, it discards cable failures from that old snapshot and lets the existing immediate topology refresh/new load cycle reconsider them. An unrelated or battery-fed overload may be delayed until that fresh evaluation; it is not permanently exempt. Unknown, already-open or non-protective IDs do not suppress damage. Wires with oversized protection still fail normally, one per application.

The regression fixture runs the actual extracted production handler together with the real combiner solver and wire-node graph. The old handler reproduces the simultaneous burn; tests cover protected matching ratings, oversized protection, an unrelated branch, ignored/no-op trips and remaining battery backfeed. Experimental stationary DIN batteries remain removed; the holder and energy/accounting algorithms are unchanged.

Native compilation and relevant regressions are run. This is an offline reproduction/fix; the dedicated-server game case still needs testing.

## 1.0.162 — Remove experimental DIN stationary batteries

Removes both experimental DIN Station Battery variants (Small and Large) from the module catalog, prefab creation/registration, construction kit variants, F1 lists and registration verification. Retains only parsing of their old local test save records; the battery prefabs are not recreated. No save migration or conversion is added. Existing original game Station Battery prefabs remain untouched.

The existing DIN Battery Backup cell holder and its behavior are unchanged. No one-holder-per-output restriction or short-circuit rule is added. Experimental model/export source and captured reference fixtures remain available for future work but are no longer registered as playable modules. Native compilation and catalog/F1/holder/routing checks are run.

## 1.0.161 — Raised battery face assemblies and light-grey switch trim

On Small and Large, raises the complete original meter assembly so its surround lip is7mm above the DIN fascia; the actual LED faces sit about3.5mm above it. Raises the Large grille to the same7mm outer lip. These remain below the existing native switch paddle's approximately7.4mm maximum projection. Width/height/centres, native charge state, louvers and cable targets are unchanged. Existing surrounding depth still seats the assemblies against/inside the body.

The original outer switch trim on both sizes now has its own non-emissive light-grey material, without the old dark atlas texture. Original black bezel, red/green paddle materials and OFF/ON driver are untouched. The generated F1 thumbnails include these changes.

Native compilation and actual supplied-geometry projection/clearance checks are run; final appearance and door clearance still need the in-game check.

## 1.0.160 — Taller Large battery grille

Extends the original Large grille equally upward/downward to40mm high (approximately twice its159height). Width68mm, horizontal/vertical centre and recessed depth are retained. The matching case pocket grows in height with the grille. Switch, charge meter, Small battery, cable/socket targets and electrical behavior are unchanged. The actual-model F1 thumbnail includes the taller grille.

Native build and supplied-geometry size/centering/clearance checks are run; final appearance needs the in-game check.

## 1.0.159 — Original Large battery vent in the spare DIN face area

Adds the original Large battery's front louvres and surrounding frame in the two-position blank area to the cabinet-view right of its existing meter. The supplied153reference identifies exactly102triangles from the native completed Large body; mirrored rear vent, pedestal and other cabinet parts are excluded. Original UVs, full vertex streams and native materials are retained.

The complete grille is uniformly fitted to a68mm-wide area, centred vertically, and recessed into a matching DIN case pocket with a0.5mm surround lip. The existing switch, charge meter and their positions are unchanged. The mesh is also included in the actual-model F1 thumbnail. Small battery, cable socket/aim separation, electrical behavior and saved state are unchanged.

Native compilation and supplied-geometry selection/layout/seating checks are run. Final rendered appearance still requires the in-game check.

## 1.0.158 — Cable sockets separate from front screw targets

Corrects157: on both DIN batteries, the physical cable ends again enter the black top/bottom sockets, as on the other DIN modules. The front screw heads remain the aiming/click points used by the wiring tool. Cabinet contacts now explicitly receive distinct entry and aim coordinates instead of using the same point for both.

Removes the157front-screw-only route clearance fields and restores the standard end-face wire lead geometry. Existing connection IDs are retained; the existing contact-change migration reroutes saved157cables to the socket positions. Keeps157Large six-position face and F1 previews; no battery model/capacity/energy/save changes.

Native build and routing/contact regressions are run. Actual cable appearance and saved-world rerouting still need the in-game check.

## 1.0.157 — Six-position battery front, F1 preview and screw cable contacts

Large now uses the tested Small battery front geometry on a six-position DIN casing. The unchanged-size face moves two slot pitches toward the cabinet-view left edge, leaving two additional positions of casing to the right. Large retains its native9MJ battery owner/costs and six-position footprint; Small remains3.6MJ/four positions.

Adds a Stationpedia F1 thumbnail rendered from the actual completed DIN meshes/materials, including the five segments, grey switch trim and recessed casing. The temporary render copies only transforms/meshes/material blocks and never instantiates native battery/network scripts. Headless servers skip thumbnail rendering.

Both battery cable entry/endpoints now coincide with the visible front screw targets instead of the former top/bottom end-face positions. Existing saved connections retain their IDs and use refreshed contact positions. Original native charge/switch state, accounting and save data are unchanged. Native compilation and slot/layout/contact/capture checks are run; the Large visual, F1 render and loaded-world cable routing require the in-game check.

## 1.0.156 — Smaller centred meter and solid lower fascia

Reduces the155meter by10% uniformly (131.3mm to118.17mm wide), centres the switch/meter pair with a4mm gap and roughly7mm outer margins, and retains the smaller switch and original grey trim.

The meter case pocket now follows only the actual five LED apertures, rather than almost the entire surrounding frame. This leaves the DIN fascia solid behind the lower and side surround lips, closing the bottom gap shown in the user screenshot. Native geometry/materials, switch poses, battery power and save state are unchanged. Native build and capture-based checks are run; final appearance needs the in-game check.

## 1.0.155 — Original grey switch trim, smaller switch and larger meter

Restores the26original completed-case triangles forming the light-grey switch trim around the separate black bezel, using the supplied153reference. Scales the switch height/depth envelope to80% and keeps the full original bezel/trim/paddle proportions. The click target follows the smaller repositioned switch. Retains native OFF/ON poses and recessed mounting.

The freed space allows the whole five-segment meter and original surround to grow30% in uniform scale: target width101mm to131.3mm. Both parts are laid out within the4position DIN casing with roughly2mm outer margins and gap. The native front-only segment selection and matching recessed case pockets are retained. Large and electrical/save behavior are unchanged.

Native-reference build and supplied-geometry layout/selection/seating checks are run. Rendered appearance still requires an in-game check.

## 1.0.154 — Native battery capture fixes front-only meter and recessed switch

Uses the supplied153native export. Each charge-segment mesh contains both front and mirrored rear quads almost0.9m apart. Copying both caused the severe fit/orientation errors. The Small meter now selects only the two triangles on the native front plane from each segment, preserves the true tilted native face, and extracts only the measured120surround triangles from the exact final body renderer. Rear, broken and earlier construction parts are excluded. Original vertex streams/materials and native five-state bindings remain.

Recesses the original switch bezel using its actual rotated bounds and a matching DIN case pocket; only the bezel lip and native tilted paddle protrude. Meter surround is also sunk to the front lip instead of balancing its back on the case. Switch size/orientation/OFFONposes and electrical state are retained. Large is unchanged. The153reference exporter no longer automatically runs.

The user capture has complete geometry; texture GPU readback failed, so this build reuses original in-game materials. Native compilation and tests against the supplied actual geometry verify single-front selection, frame selection and bounded placement. Final Unity rendering remains to be checked in game.

## 1.0.153 — Native battery reference export

On the first graphical game startup, exports both original Station Battery prefabs (Small and Large), without modifying them. The ZIP is written under Application.persistentDataPath as ModularSwitchboards-Batteries-reference-1.0.153.zip. On Windows the usual directory is %USERPROFILE%/AppData/LocalLow/Rocketwerkz/Stationeers; the console prints the exact location.

Contains prefab-local OBJ parts, full JSON geometry/submeshes/UVs, raw native vertex streams with layouts, material/shader/property-block metadata and referenced texture PNG readbacks, complete transform hierarchy/local TRS/matrices, native construction renderer paths, indicator order/material names, and original switch pivot/OFF/ON angles. Per-mesh/texture errors are recorded; a partial export is not presented as complete. Existing same-version export is reused. Dedicated servers skip the capture. The current DIN visual model is deliberately unchanged while awaiting these reference files.

Start the game once with this full package, then send the generated reference ZIP. Offline native compilation checks API compatibility; actual game export requires your graphical game instance.

## 1.0.152 — Meter mounting plane and bounded depth

Corrects the small battery meter's mounting plane using the horizontal principal row of the actual used vertices from all five native segments, rather than renderer-origin spacing/cardinal guesses. The full frame is seated by its back on the DIN front, retaining its original geometry and proportions. Uniform fitting is again bounded in all three dimensions:101x40x20mm beside the switch, preventing native recess depth from extending through the cabinet door as in151. Switch and original OFF/ON poses are unchanged.

Checks cover rotated/shared-origin segment clouds and the full width/height/depth envelope. Native compilation passes; final rendering and closed-door clearance still need in-game verification.

## 1.0.151 — Meter fills the free DIN front area

The small battery meter now scales uniformly to the available front width/height beside the switch. Previously its fit also imposed a26mm depth limit on the stock recessed geometry, allowing that depth to shrink the whole five-segment face to a tiny icon. Only the meter fitting calculation changes; original meshes/materials, proportions, switch orientation and bezel seating remain. The full native depth is allowed to follow the uniform face scale.

Native compilation and meter fill/aspect/clearance checks pass. The final visible size still needs an in-game check; no Unity renderer is available here.

## 1.0.150 — Small battery final face, switch180-degree correction

Turns the149switch another180degrees, preserving size, native pivot poses and bezel seating. The original five-segment meter is aligned from the segment row and cabinet front plane rather than one segment's thinnest imported mesh axis. Its native surround is extracted only from the completed native body, excluding earlier construction-model descendants and deep internal geometry. The full selected face is uniformly fitted beside the switch and seated at the DIN surface, retaining native meshes, vertex streams, materials and charge renderer bindings.

Only the completed visual is being refined; native build tools/costs/stage behavior are left intact, with no new construction models. Large is unchanged. Meter frame selection and charge-state appearance still require a Unity game test; offline compilation/layout checks cannot verify their rendered appearance.

## 1.0.149 — Larger small-battery switch, quarter-turn right

After the in-game148 mounting check, enlarges the complete native small-battery switch and bezel and turns its mounting parent90 degrees clockwise in cabinet front view. The fitting envelope grows from25x36x25mm to38x42x35mm, retaining uniform proportions and back-of-bezel seating on the DIN surface. Original native OFF/ON pivot angles and click binding remain unchanged. Meter and Large are unchanged. Native compilation and existing mount/layout checks are run; final size/direction require the in-game visual check.

## 1.0.148 — Small battery switch mounted on DIN front

Reorients the complete native rocker and bezel from the stock battery's vertical side mounting plane onto the DIN front. The mounting normal comes from the cabinet side rather than the tilted rocker's thinnest mesh axis. The back of the original surround is seated at the DIN front surface; the former frontmost-point alignment buried the part in the case. Uniform fitting uses the selected vertices, retaining the original red paddle, bezel, materials and exact native OFF/ON rotations. The147 click/audio reference fix is retained.

Small switch only. The meter is deliberately unchanged pending its own repair. Large, power accounting and saved state are unchanged. Native-reference compilation is checked; no Unity rendering is available, so the final visual fit needs an in-game check.

## 1.0.147 — Small battery original OFF/ON pose

Keeps the original small battery rocker upright on the DIN front, with the exact original OFF/ON pivot poses, matching the user reference. No arbitrary 90-degree rotation in the front plane. Fixes the reported native SwitchOnOff.RefreshPositionState null exception: dynamically added DevicePart drivers must initialize their serialized Transform field before native click audio reads its position. Native DevicePart.Awake/SetParentThing do not initialize that field.

The meter appearance reported after146 is still unresolved; this iteration only adjusts the switch and its missing binding. Large visuals and electrical behavior are unchanged. Native-reference build passes; game appearance and clicking still require in-game verification.

## 1.0.146 — Original small battery meter and red switch

Small (4 DIN positions) now copies the native five charge segments and their original surrounding frame, plus the native red ON/OFF switch. Removes the custom blue panel, fabricated segment sockets and capacity caption from Small. The original vertex streams, UVs, normals, colors and materials are retained; triangle cropping preserves material slots and winding. A recessed DIN case aperture leaves room for the original recessed meter. Native switch state/animation is rebound to the copied parts.

Large (6 positions), energy accounting, existing Holder, wiring, recipes and saved battery data are unchanged. Native-reference build passes with zero warnings/errors. Offline layout/triangle selection and relevant regression checks pass; no Unity render was available. Test the full meter frame, five charge states and switch pose in game. Dedicated-server printing remains deferred.

## 1.0.145 — DIN battery casing assembled like the transformers (first visual test)

Replaces the miniature whole stationary-battery cabinet with the same DIN casing and terminal geometry used by the transformers. Small remains4positions and Large6. There is no rotated/scaled stock enclosure, back, base, feet, external connectors or ventilation grille left in the DIN model. Large is a wider DIN assembly; the earlier request to lay the whole original Large model sideways is superseded by the user's explicit transformer-style construction.

The front is assembled from the stock battery's individual charge segment meshes/UVs/materials and its original ON/OFF rocker. The native Battery still owns the five charge/color/blink states. Native mode0segment geometry forms the dark inactive sockets. The native SwitchOnOff driver, when available, retains its actual on/off rotations, materials/error animation and sounds; a legacy mesh variant uses the serialized ON/OFF state for its rocker pose. Both widgets are independently fitted onto the front, keeping each part's proportions. A small capacity label identifies the native stored-energy maximum. Source battery meshes/materials/controls are read but not moved or mutated.

Separate stage bodies preserve all original battery build tools/costs after the DIN mounting kit. Front widgets appear at completion. Headless servers build the same CPU DIN body/controls/contacts without reading GPU-only stock meshes. IN/OUT now use the same end-face entries and front screw aiming coordinates as transformers. Existing saved wire ends use the existing reroute mechanism when endpoints move. Body paint/finish follows transformers, with the native charge and rocker materials excluded from case recoloring.

Storage capacity, actual energy accounting, cell Holder, Core, data binding and battery save/join payload remain unchanged; only the old whole-model Animator setup is removed from Awake. Existing prefab identities and widths are retained. Install matching full folders on clients/server.

Validation: native-reference build0warnings/errors;613face layout/fit/clearance checks,49actual paint registration/palette checks including native battery isolation,50finish checks,25registration,26audio,21input,35blueprint+154families,15F1/104catalog and4819combiner checks pass. These are offline fixtures, not an in-game render. Native mesh extraction, rocker selection/pose, source material appearance, completed build visibility and loaded-world wire rerouting need the first Unity visual test. No live game was available. This release does not claim to fix the separate dedicated-server printing issue.

## 1.0.144 — Full140/143 source comparison and battery registration fix

Reviewed all26 changed/added source files from140to143. Original runtime Assets(87files), complete recipe GameData, dependency/package references, existing Holder and Smart Core code are unchanged. Both140 and144 compile against the same native references with zero warnings/errors. The common production energy and routing checks pass against both source versions;144 also passes28stationary-store checks. Full findings and limits: Verification/AUDIT-1.0.140-vs-1.0.143.md.

Fixes battery registration validation: inspect serialized ON/OFF controls instead of the private InteractOnOff runtime cache, which is not serialized onto an unawakened registered clone. Validation still rejects missing prefabs, missing controls/stages, wrong widths/mount kit and invalid capacity, and now logs the exact prefab/field failure. The previous combined error did not disclose which predicate failed. A cloned-data fixture reproduces the empty-cache false failure;25production validator checks pass. Actual Unity startup remains to be retried.

Unfinished battery construction now stays in the native tool flow instead of being intercepted as cabinet wiring when holding cable. The actual143 ModePrefix reproduces this regression in the same fixture that144 passes. Completed battery wiring and original targets/authority dispatch remain covered by21input-hook checks. The headless presentation setup also clears removed animation helpers consistently with the original transformer setup.

Retains143inactive-owner preview fix and142initialization/audio guards. Re-ran4819combiner,12464circuit/persistence/routing,33service binding,12setup,26audio,35blueprint+154family,15F1/104catalog and23name checks. The140baseline passed4791common combiner and12464routing/circuit checks. Fixture unused-field warnings are separate from the native build. No Unity visual, actual new battery save/late-join or dedicated server run was available; the separate StationeersMods.AssemblyMod exception and older multiplayer-printing report are not claimed fixed.

## 1.0.143 — Battery preview under inactive prefab storage

Fixes the reported startup exception: `Cannot build a preview without model geometry` in DinStationBatteryModel.Install. ModelBlueprint's owner filter used GetComponentInParent<Thing>() with Unity's default includeInactive=false. During authoring, the battery lives below inactive prefab storage, so the filter rejected its renderers even though their mesh geometry existed. The filter now uses GetComponentInParent<Thing>(true). It still excludes meshes belonging to a nested foreign Thing, retains the original ownership check and does not activate storage or replace native meshes.

The regression fixture now models inactive-ancestor lookup correctly and tests the same battery/storage hierarchy. Running the old production filter against this fixture reproduces the exact reported exception; the fixed production filter passes. Existing visibility, nested transforms, mirrored winding, native submeshes, source ownership, large meshes, cursor selection and hitbox checks also pass:35 blueprint checks plus154 own-family checks. Final native-reference build:zero warnings/errors. This is an offline reproduction and targeted fix; an actual Unity startup retry is still needed.

Keeps142normalization/audio guards and141batteries, construction costs and energy behavior. No recipe XML or power solver change. The recipe-verification messages in this report followed the aborted prefab transaction; this fix addresses that demonstrated startup failure, not the older separate dedicated-server printing report.

## 1.0.142 — Battery prefab preparation guard fixes

Normalizes native battery controls before replacing their owner: preserves controls declared only in construction stages, removes null/duplicate entries, initializes absent lists and caches the native ON/OFF reference before authoring checks. Audio rebinding/runtime cloning now accepts null native event/condition lists; the added mount stage shifts only existing audio build-state conditions. Component reference remapping now touches serialized fields only, avoiding unrelated runtime caches.

Removes the premature startup requirement for exactly five indicator renderers. The five visible charge segments are native Battery behavior; the number of mesh renderers is native prefab data. An unavailable pre-registration visual reference now produces a focused warning rather than aborting every switchboard prefab. Construction costs, energy accounting, widths and native battery storage remain as in141.

On prefab failure, the original exception is recorded/logged before cleanup. Registration verification repeats that original exception once and skips the cascade of missing-object errors. Module preparation logs name the variant being built. This preserves atomic publication of the complete prefab set; it does not silently discard failed battery variants.

Validation: native-reference build zero warnings/errors;26 actual production audio-owner checks including null lists/conditions and12 actual production battery-normalization checks including stage-only ON/OFF, stable control identity/order and repeated setup. No live Unity runtime is available. The supplied screenshot contained only downstream verification failures, so the exact exception from that run is not confirmed and this startup fix needs an in-game retry. The earlier dedicated-server printing report is separate.

## 1.0.141 — Native Station Batteries on DIN rails (first test build)

Adds DIN Station Battery (4 positions) and DIN Station Battery (Large), occupying 6 positions with the original large model turned sideways. Both use uniformly scaled native geometry, native materials, the original ON/OFF control, five charge indicators, native Battery capacity/charge storage, logic values and charge/save/join serialization. The capacities come directly from the game's StructureBattery/StructureBatteryLarge prefabs. The existing cell-based Battery Holder is retained.

Build from Kit (Switchboard Modules): one kit mounts the DIN plate, then all original native battery construction stages/materials/tools follow. New batteries start empty. Connect IN for charging and OUT to a protected load circuit. OFF disables charging and discharging; the native stationary-battery self-discharge/thermal behavior is retained. The cabinet owns energy transfer, so the native object cannot register a second external power provider. Holder charging remains capped at its existing 1 kJ per cycle; stationary batteries retain their native uncapped throughput, subject to the wired circuit and its protection. Shared bidirectional battery terminals, new parallel wiring rules and short-circuit simulation are deferred.

Headless servers use a procedural footprint with the same battery identity/capacity/controls and construction costs; they do not need native visual meshes or indicator materials. Visual animation is skipped only in batch mode. This path is compiled but still needs a real dedicated-server check.

Mounting, occupied DIN positions, cover openings, wiring endpoints/routing, teardown/refunds, save/join and data-only network registration include both variants. The native model and controls are nested below an unscaled board root; the large variant's visual rotation does not change its saved board orientation. This build must be installed with the complete folder on all participating clients/server.

Offline validation: native-reference build with zero warnings/errors; 4819 collecting-cabinet checks (including 28 new live-store battery checks), 12464 circuit/budget/persistence/routing checks and existing battery/transformer/protection regressions, 33 actual service bindings, 23 name checks, 15 F1 binding and 104 catalog/search checks. Fixture unused-field warnings are separate from the native build. Native Unity model fitting, indicator animation, switch hitboxes and actual save/late-join still require an in-game check. No live Unity or dedicated server was available here. This does not claim to fix the separately reported dedicated-server printing problem.

Source archive note: additional large authoring JSON is supplied losslessly as .xz; decompress beside the original path when needed. Raw authoring inputs and historical snapshots remain unchanged in the workspace.

## 1.0.140 — Direct cabinet Output to Smart Net DATA

A completed Smart Net DATA contact can now connect directly to cabinet Output1,2or3 (where present), in either click order. Each cabinet Output has one separate direct DATA-tap slot alongside its unchanged power-feeder capacity. Collecting outputs retain their existing branch limit. A Net still accepts a single DATA connection. Core POWER IN, ordinary module inputs, Output-to-Output connections and Net-to-Net connections do not gain this exception.

The explicit tap selects that Output's real external cable network even if the upstream breaker is open, the Output is unpowered or its internal feed is reachable from Input. An external cable/network must exist at the Output. Different Net modules retain indexed network access and native data isolation; the Net does not join native networks or supply any device. Direct DATA-tap edges are removed from the energy/overload graph. Existing feeder-side taps still work.

Markers and routing support the shared power/data terminal; paths still reserve space around existing wires and devices. Save/network loading preserves the new narrow Output-to-Net leaf before board identities are available, then existing deferred cleanup checks that its owner really is a Net. Invalid staged leaves cannot transfer power. The existing wire packet format, coil cost/paint/refund, model and module economy are unchanged. F1 now explains direct taps. Install this version on both client/server and keep the full GameData folder.

Validation: native-reference build0warnings/errors;1101 production topology/capacity checks;18 actual CabinetWiring XML/binary/load checks with board identities deliberately absent;actual mirrored routing tests with an occupied Output;existing malformed/legacy/paint/damage serialization checks.99SmartPLC and33Smart-network checks include independent direct Output networks and open protections.4791collecting-cabinet checks,18046service-power checks and the existing power/battery/transformer/protection suite pass. Fixture stubs needed updates for existing service-load fields; fixture unused-field warnings are not native-build warnings. These are offline checks, not a live Unity/multiplayer visual test.

Includes139native Core execution and138XML recipes unchanged. The separately reported dedicated-server printing problem remains unresolved.

## 1.0.139 — Smart Core native chip execution test

Smart Core now uses only the native ElectricityManager -> CircuitHolders -> ICircuitHolder.Execute path used by IC Housing. Removed the separate LateUpdate execution timer. Native Device.Awake normally registers the Core already; placement and finished-load callbacks now explicitly ensure registration using the native duplicate-safe DensePoolReference. Deregistration removes the holder and marks Lua inactive. No second VM tick or blanket device-pool patch.

Core Execute refreshes its paid internal service-power state and retains construction, mounted-board, ON, power, simulation, running-game and pause guards. IC10 uses the native128-instruction budget. Lua goes through ProgrammableChip.Execute too, allowing StationeersLua's own patch to apply runtime/save/compile guards and its GameTickSpeedSeconds cadence. The ordinary IC10 path has no mandatory Lua dependency.

IC10 status stays idle until this chip has passed through Execute; a valid line0 alone no longer labels an unexecuted chip RUNNING. Reprogramming/insertion/removal clears the execution marker. Lua compilation/runtime status comes from the Lua adapter rather than the native IC10 compiler flag. Internal battery/transformer control power, physical slot/model, programme/save formats and138native XML recipes are retained.

Validation: native-reference build0warnings/errors.322 checks use ACTUAL native CircuitHolders/DensePoolReference with extracted production execution/registration/status methods, including100loop ticks and duplicate Awake/placement/load callbacks. The chip/VM in that fixture are explicit stand-ins, not the real IC10 interpreter/Lua VM.23optionalLua adapter/actualDLLAPI checks and32status-display checks pass. Live Unity/singleplayer/DS execution of the reported programme remains to be tested; the specific original freeze is not claimed reproduced. Retest powered Core with the five-line counter loop, then save/reload and OFF/ON; optionally retest Lua. The independent dedicated-server printer issue remains unresolved.

## 1.0.138 — Native XML recipe registration test

All seven kit recipes now live in `ModularSwitchboards/GameData/electronics.xml` and use the native GameData loader, matching the supplied Modular Consoles Reloaded package. Removed the `GenerateRecipieList` Harmony prefix, its C# recipe injection and the unused SmartKitRecipe factory. XML is the sole recipe source. Existing post-load recipe diagnostics, kit identities, costs, durations, energy, Tier One and one-kit outputs remain unchanged. Native XML loading performs recipe range checks and associates recipes with mod metadata.

Install the full folder, including the new GameData directory, on server and clients. Replacing only the DLL will omit every kit recipe. Restart the game/server after installation. This is a candidate for the reported multiplayer printing problem, not a confirmed fix. The native XML load notices should now include this mod when its GameData file loads.

Validation: native-reference build with zero warnings/errors; all seven XML recipes deserialize with the actual native WorldManager.RecipeData type;14 Smart kit/placement checks pass using the production XML. Native LoadGameDataAsync awaits Prefab.LoadAll before LoadDataFiles, so the existing PreparePrefabs hook publishes our kits before recipe XML is processed. Economy/package parity checked against137. Live multiplayer printing still requires a server/client retest of both vanilla items and switchboard kits. Includes137spawn cache/diagnostics and preceding internal control power; no Large prototype or manual routing.

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
