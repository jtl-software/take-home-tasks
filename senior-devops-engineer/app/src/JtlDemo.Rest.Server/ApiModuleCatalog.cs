using JtlDemo.Abstractions;
using JtlDemo.Modules.Windows;

namespace JtlDemo.Rest.Server;

/// The composition root. This one file is why the whole library is Windows-only:
/// it constructs the Windows module assembly's types directly. Two of these modules
/// genuinely need Windows; the other three do not.
public static class ApiModuleCatalog
{
    public static IReadOnlyList<IApiModule> BuildApiModules() =>
    [
        new ItemsModule(),
        new CustomersModule(),
        new StatsModule(),
        new DocumentExportModule(),
        new PrinterModule(),
    ];
}
