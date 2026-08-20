using JtlDemo.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace JtlDemo.Rest.Server;

public sealed class ItemsModule : IApiModule
{
    public string Name => "Items";

    public static IReadOnlyList<Item> Items { get; } =
    [
        new Item(1, "Widget"),
        new Item(2, "Gadget"),
        new Item(3, "Sprocket"),
    ];

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/items", () => Results.Ok(Items));
    }
}

public record Item(int Id, string Name);
