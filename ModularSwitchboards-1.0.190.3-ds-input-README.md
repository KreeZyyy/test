## 1.0.190.3 — Embedded Smart IC10 socket geometry

Repairs the next demonstrated dedicated-server startup blocker: SmartChipSocket loads a baked CPU mesh instead of reading StructureAirConditioner geometry. The same selected socket geometry is embedded in the DLL: 263 vertices, 166 triangles, original UVs and material group. Native materials and slot metadata remain in use; chip placement, insertion interaction, pocket geometry and slot behavior are unchanged. Includes the own IN panel repair from 1.0.190.2.

Validation: native build passed with zero warnings/errors; baked positions, UVs and indices match the authoring export at float32 precision. Production embedded loader fixture verifies counts, selection, fit and cache without game mesh or GPU access. Complete DS startup and live chip insertion still require testing. This patch does not remove every legacy geometry dependency.

