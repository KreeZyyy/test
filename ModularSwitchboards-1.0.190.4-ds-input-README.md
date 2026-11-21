## 1.0.190.4 — Dedicated server graphics audit and guards

Skips the native fabrication-machine SetIcon visual callback on headless servers, whose custom thumbnails intentionally do not exist. Client icons and recipe selection/manufacturing behavior are retained. Small/large native battery surface subsets now use the existing CPU-only mesh-copy helper on DS rather than GPU vertex buffers. Clarifies informational mesh preflight output. Includes the own IN panel and embedded IC10 socket repairs from 1.0.190.3.

Native build passed with zero warnings/errors. 80 headless/client graphics-policy checks and 16 CPU-only mesh selection/channel-preservation checks passed. See DS_AUDIT.md for reviewed areas, user runtime evidence and remaining native model dependencies. Full DS startup for this revision and battery construction still need in-game verification. Install as a normal mod update; no game/server configuration edits.

