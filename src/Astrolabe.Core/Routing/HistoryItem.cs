using System;
using Astrolabe.Core.Navigating.Abstraction;
using Astrolabe.Core.Routing.Endpoints.Abstractions;

namespace Astrolabe.Core.Routing;

public class HistoryItem
{
    public IEndpoint Endpoint { get; set; }

    public Action<INavigationMessage, INavigationOptions> NavigationCallback { get; set; }
}