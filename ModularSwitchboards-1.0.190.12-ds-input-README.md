## 1.0.190.12 — Disable normal diagnostic output

Omits ordinary mod log calls and their message formatting, disables cable timing/printer diagnostic hooks and informational mesh audit, and stops attaching cabinet spawn diagnostics. Functional code, real warnings and errors remain active. Native game output including Ready, client joins and saves is unchanged. Includes1.0.190.11 rail origin preparation and all preceding fixes.

Native build zero warnings/errors. Compiled DLL verified to omit diagnostic calls/hooks and retain warning/error reporting and functional guards. See QUIET_RELEASE.md for details. Actual first-join rail placement still requires live verification; Ready cannot be guaranteed as the final line if the game or a real warning logs later.

