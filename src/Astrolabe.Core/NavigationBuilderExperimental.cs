using System;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Helpers;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.Core.Routing.Schemes;

namespace Astrolabe.Core;

public class NavigationBuilderExperimental
{
    public static NavigationBuilderExperimental Builder => new();

    private NavigationBuilderExperimental()
    { }

    public NavigationBuilderExperimental RegisterRoutes(Action<ISchemeBuilder> action)
    {
        ISchemeBuilder schemeBuilder = new SchemeBuilder();
        Security.NotNull(action, nameof(action)).Invoke(schemeBuilder);
        var buildInstance = schemeBuilder as IBuild<ISchemeBuilder>;
        _ = buildInstance.Build();

        return this;
    }
}