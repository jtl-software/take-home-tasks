using System.Drawing.Printing;
using JtlDemo.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace JtlDemo.Modules.Windows;

/// Genuinely Windows: enumerates printers installed on the host machine. This is
/// meaningless inside a container, so it belongs in the Windows supplement and on
/// the named exclusion list for the Linux image.
public sealed class PrinterModule : IApiModule
{
    public string Name => "Printers";

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/printers", () =>
        {
            var printers = PrinterSettings.InstalledPrinters.Cast<string>().ToArray();
            return Results.Ok(printers);
        });
    }
}
