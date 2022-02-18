using Astrolabe.Core.Routing.History.Abstractions;
using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.History;

internal class RouteHistoryInfo : IRouteHistoryInfo
{
    public string ContextKey { get; }
    public string TargetViewModelName { get; }
    public INavigationExecutor LastExecutor { get; }

    public RouteHistoryInfo(INavigationExecutor executor, string context, string viewModelName)
    {
        LastExecutor = Security.ProtectFrom.Null(executor, nameof(executor));
        ContextKey = Security.ProtectFrom.NullOrWhiteSpace(context, nameof(context));
        TargetViewModelName = Security.ProtectFrom.NullOrWhiteSpace(viewModelName, nameof(viewModelName));
    }
}