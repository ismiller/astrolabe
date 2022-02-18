using Astrolabe.Core.Routing.Routes.Abstractions;

namespace Astrolabe.Core.Routing.History.Abstractions;

internal interface IRouteHistoryInfo
{
    string ContextKey { get; }

    string TargetViewModelName { get; }

    public INavigationExecutor LastExecutor { get; }
}