## 1.0.190.9 — Native chip execution and reduced optional Lua adapter

Keeps Lua execution on the native ProgrammableChip.Execute entry intercepted by StationeersLua. Removes unused direct Lua VM tick/active-query adapters and their API dependencies. Removes Lua initialization from ordinary computer device-list/editor tracking callbacks. Keeps custom-host activity, removal snapshot, save guards and optional error/editor integration; error reporting is no longer a prerequisite for execution readiness. Includes absent-Lua discovery caching from1.0.190.8 and earlier DS/network/join fixes.

Verified against author's StationeersLua1.1.0.0 and addon template. Native build0warnings/errors;21 Lua adapter/API checks pass including absent-mod cache, late loading, lifecycle and optional-dependency checks. See LUA_INTEGRATION.md for API scope/limitations. Live DS cable performance and Lua behavior still need verification. Update server and client together.

