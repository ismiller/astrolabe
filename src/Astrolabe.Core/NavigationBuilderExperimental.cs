using System;
using Astrolabe.Core.Routing.Schemes;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core;

public class NavigationBuilderExperimental
{
    public static NavigationBuilderExperimental DefaultBuilder => new();
    private readonly ISchemeBuilder _schemeBuilder;

    private NavigationBuilderExperimental()
    {
        _schemeBuilder = new SchemeBuilder();
        
    }

    public NavigationBuilderExperimental RegisterRoutes(Action<ISchemeBuilder> action)
    {
        Security.ProtectFrom.Null(action, nameof(action)).Invoke(_schemeBuilder);
        return this;
    }

    public NavigationBuilderExperimental 
}