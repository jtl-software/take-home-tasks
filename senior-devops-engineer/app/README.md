# JtlDemo REST service

A small ASP.NET Core service, deliberately coupled to Windows. It is a scaled-down
stand-in for a real service we are moving off Windows and onto Linux containers. Your
task is to slice out the Windows coupling and ship a Linux image; the task
description is in [`../instructions.md`](../instructions.md).

## Projects

| Project | Target | Role |
| --- | --- | --- |
| `JtlDemo.Abstractions` | `net8.0` | The `IApiModule` contract. Uses no Windows API. |
| `JtlDemo.Rest.Server` | `net8.0-windows` | Shared library: the `Items` and `Customers` modules and the composition root `ApiModuleCatalog`. |
| `JtlDemo.Modules.Windows` | `net8.0-windows` | Three modules: `Documents`, `Printers`, `Stats`. |
| `JtlDemo.Rest.Host` | `net8.0-windows` | The runnable host: reads config, composes the catalog, maps routes. |
| `JtlDemo.CompositionTests` | `net8.0-windows` | The standing test gate. |

## Where the Windows coupling is

- **The composition root.** `ApiModuleCatalog` constructs every module directly, so
  `JTL.Rest.Server` references the Windows module assembly and is dragged to
  `net8.0-windows`, even though most of it needs nothing from Windows.
- **The host.** `Program.cs` reads its connection profile from the Windows registry
  (`HKLM\SOFTWARE\JTL\Wawi`) and writes startup to the Windows Event Log. Both throw
  on a non-Windows host, so the service cannot start in a Linux container as-is.
- **Two modules that genuinely need Windows.** `DocumentExportModule` renders with
  GDI+ (`System.Drawing`); `PrinterModule` enumerates installed printers.
- **One module that does not.** `StatsModule` ships in the Windows assembly and is
  composed next to the other two, but its code calls no Windows API.

## Endpoints

- `GET /healthz`, `GET /api/_config` (host).
- `GET /api/items`, `GET /api/customers`, `GET /api/stats` (no Windows API).
- `GET /api/documents/{id}/preview`, `GET /api/printers` (Windows-only at runtime).

## Build and test

Requires the .NET 8 SDK. Builds and tests run on any OS.

```sh
dotnet build
dotnet test
```

The solution builds everywhere and the tests pass everywhere, because the Windows
APIs are only reached at runtime. Running `JtlDemo.Rest.Host` off Windows, or calling
the two Windows endpoints, is where it breaks. That gap is the task.
