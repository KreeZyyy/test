## 1.0.190.7 — Avoid redundant cable-network registrations and broadcasts

Compares the reference console mod's native registration approach against the game's CableNetwork implementation. Removes our duplicate network-wide refresh after native AddDevice, skips existing cable registrations, and retains the required single refresh for partial removal. Applies to Core, Dial, transformer/battery data bindings and the contactor binding helper. Circuit routing and power accounting are unchanged. Includes previous DS/join repairs and the 1.0.190.6 timing observer.

Native build zero warnings/errors. 1007 registration transition/callback checks and 33 Smart network visibility/isolation checks pass. See NETWORK_REGISTRATION.md for comparison, behavior and validation. Live DS testing is still required to determine whether the redundant callbacks explain the whole cable-placement pause. Update server and clients to the same revision.

