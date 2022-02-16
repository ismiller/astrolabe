using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Routes;

internal class RouteMover : IRouteMover
{
    private readonly IRoute _route;
    private readonly IRouteContext _context;

    public RouteMover(IRoute route, IRouteContext context)
    {
        _route = Security.ProtectFrom.Null(route, nameof(route));
        _context = Security.ProtectFrom.Null(context, nameof(context));
    }

    public IRoutingResult Move()
    {
        return _route.TryExecute(_context);
    }
}