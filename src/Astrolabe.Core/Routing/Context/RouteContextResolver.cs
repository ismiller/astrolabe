using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;

namespace Astrolabe.Core.Routing.Context;

/// <summary>
/// Предоставляет методы построения контекста выполнения маршрута.
/// </summary>
public class RouteContextResolver : IRouteContextResolver
{
    /// <inheritdoc />
    public IRouteContext Resolve(INavigationFrame frame, IFrameOptions options)
    {
        return new RouteContext(frame, options);
    }
}