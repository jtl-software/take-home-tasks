using JtlDemo.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace JtlDemo.Modules.Windows;

/// Lives in the Windows-targeted assembly and is composed alongside the genuinely
/// Windows modules, but its code calls no Windows API at all. Deciding what to do
/// with a module like this is the point: a reference count is not coupling.
public sealed class StatsModule : IApiModule
{
    public string Name => "Stats";

    public static int Value => 42;

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/stats", () => Results.Ok(new { value = Value }));
    }
}
