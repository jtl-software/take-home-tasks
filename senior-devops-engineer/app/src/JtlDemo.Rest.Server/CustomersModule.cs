using JtlDemo.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace JtlDemo.Rest.Server;

public sealed class CustomersModule : IApiModule
{
    public string Name => "Customers";

    public static IReadOnlyList<Customer> Customers { get; } =
    [
        new Customer(1, "Contoso"),
        new Customer(2, "Fabrikam"),
    ];

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/customers", () => Results.Ok(Customers));
    }
}

public record Customer(int Id, string Name);
