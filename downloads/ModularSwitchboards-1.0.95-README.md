# Modular Switchboards 1.0.95 — hatched cover preview, stronger edges and labels

Saved-cover placement combines subtle diagonal hatch with stronger real outer/hole boundaries and highlighted saved label text/frames. Hatch is clipped away from cutouts and labels; internal panel-grid seams are omitted. Other kits retain their wire outlines. Native visual verification is pending.

Fitted-cover inventory icons now show the saved cover proportions, transparent retained apertures and label positions in the saved hue. Icons are owned/cached per item and refresh on shape/colour changes; tiny label text is not reproduced. In-game outline/icon confirmation is pending.

Precision-placement ghosts now draw boundary/crease lines with the native Wireframe line shader and native preview alpha; they draw no filled translucent triangles. Fitted-cover icons are returned through both actual game thumbnail APIs, and a recovered cover broadcasts its saved payload to clients immediately. Native visual/MP confirmation is pending.

Fitted-cover placement uses the native transparent green precision-placement preview without saved paint overwriting it. Actual held/world covers keep their saved finish; the inventory/hand-slot icon now reflects their saved hue using a cached tinted thumbnail. In-game preview/UI verification is pending.

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

Saved paths upgrade atomically to **route revision 9**. The larger reservation can reduce capacity in densely packed arrangements; if rerouting fails, the original connections and quantities remain intact and manual rewiring is requested. Network packets now include the rupture flag and still read earlier wire formats. **Use a world copy and install 1.0.95 on the host and every client.** Older builds cannot read the new packet format. Local build and automated results are recorded in Verification; the game appearance, sound, effect placement and closed-door clearance still need an in-game check.

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
- **This first stage adds coil selection, appearance and persistence only. Internal wires do not yet burn or impose cable-type power limits.** Existing module protection and power simulation are unchanged.

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
