using Microsoft.AspNetCore.Routing;

namespace JtlDemo.Abstractions;

/// A unit of API surface. Each module maps its own routes onto the host.
public interface IApiModule
{
    string Name { get; }

    void MapEndpoints(IEndpointRouteBuilder endpoints);
}
