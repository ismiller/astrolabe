using System;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Routes;

public class RouteBuildRequest
{
    public Type RequestViewModelType { get; }

    public INavigationArgs NavigationArgs { get; }

    public RouteBuildRequest(Type viewModelType, INavigationArgs args)
    {
        RequestViewModelType = viewModelType;
        NavigationArgs = args;
    }
}