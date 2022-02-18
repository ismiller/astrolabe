using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Routing.History;
using Astrolabe.Core.Routing.History.Abstractions;
using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.Utilities.Security;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Routes;

internal class NavigationExecutor : INavigationExecutor
{
    private readonly IRoute _route;
    private readonly IRouteContext _context;
    private readonly IEndpointOptions _options;

    public NavigationExecutor(IRoute route, IRouteContext context, IEndpointOptions options)
    {
        _route = Security.ProtectFrom.Null(route, nameof(route));
        _context = Security.ProtectFrom.Null(context, nameof(context));
        _options = Security.ProtectFrom.Null(options, nameof(options));
    }

    public IRoutingResult Execute()
    {
        bool result = _context.ExecuteRoute(_route, _options.FrameOptions);
        if (result)
        {
            INavigatable vm = _route.ViewModelContainer.ViewModel;
            string viewModelName = nameof(_route.ViewModelContainer.ViewModel);
            IRouteHistoryInfo info = new RouteHistoryInfo(this, _options.RequiredContextKey, viewModelName);
            return RoutingResult.Succeeded(vm, info);
        }

        return RoutingResult.Failed();
    }
}