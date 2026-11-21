## 1.0.190.10 — Fix native client crash from worker graphics query

Fixes the fatal stack in the user's Player.log: CablePlacementTiming queried SystemInfo.graphicsDeviceType through ServerGraphics.Headless inside the electricity simulation worker. Graphics mode is now captured once during mod initialization before hook registration. All later headless checks read a cached volatile managed bool, avoiding graphics API access from simulation workers. Includes previous1.0.190.9 changes.

Native build zero warnings/errors;88 graphics-policy checks pass including80000worker headless reads with the graphics getter forbidden after initialization. See CLIENT_CRASH_FIX.md for evidence and limits. Singleplayer and DS live tests still required; this fixes the identified crash path, not yet a verified resolution of cable pauses. Update server/client together.

