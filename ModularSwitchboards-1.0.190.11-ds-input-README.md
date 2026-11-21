## 1.0.190.11 — Prepare DIN rail origins before module join restoration

Resolves pending cabinet/rail relationships before LibConstruct.FinishLoad and sizes each rail to its Small/Medium host before module coordinates are restored. Sizes on normal parent-board assignment too, and avoids resetting non-cursor rails to Small while the host is unresolved. Preserves saved grid coordinates, wiring and network format. Includes previous DS, Lua and worker-graphics crash repairs.

Native build zero warnings/errors.41 pending-board preparation checks pass; see RAIL_JOIN_FIX.md for fixture scope and remaining Unity verification. This addresses the identified initialization hazard; actual cold-client multiplayer join must confirm the intermittent visual offset is fixed. Update server and clients together, launch client fresh, join, then reconnect without manually relocating modules.

