using System;
using System.Linq;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Routing.Context;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Routes;
using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.Routing.Schemes;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core;

public class NavigationBuilder : INavigatorBuilder
{

    #region Private Fields

    private readonly ISchemeBuilder _schemeBuilder;
    private readonly IServiceCollection _serviceCollection;
    private IRouteSchemeDictionary<IRouteScheme> _schemes;

    private Action _useConfigure;
    private Action _useStartUp;

    #endregion Private Fields

    #region Public Properties

    public static INavigatorBuilder DefaultBuilder => new NavigationBuilder();

    #endregion Public Properties

    #region Private Constructors

    private NavigationBuilder()
    {
        _schemeBuilder = new SchemeBuilder();
        _serviceCollection = new ServiceCollection();
    }

    #endregion Private Constructors

    #region Public Methods

    public IStartUp Build()
    {
        var options = new ServiceProviderOptions
        {
            ValidateOnBuild = false,
            ValidateScopes = true
        };

        _useConfigure?.Invoke();

        IServiceProvider provider = _serviceCollection.BuildServiceProvider(options);

        using (IServiceScope scope = provider.CreateScope())
        {
            IConfigurable configurable = scope.ServiceProvider.GetRequiredService<IConfigurable>();

            configurable.ConfigureServices(_serviceCollection);
            configurable.ConfigureScheme(_schemeBuilder);
        }

        provider = _serviceCollection.BuildServiceProvider(options);

        using (IServiceScope scope = provider.CreateScope())
        {
            IRouteContextProvider contextProvider = scope.ServiceProvider.GetRequiredService<IRouteContextProvider>();

            var schemeBuilder = _schemeBuilder as IBuild<IRouteSchemeDictionary<IRouteScheme>>;
            _schemes = schemeBuilder.Build();
            _serviceCollection.AddTransient(s => _schemes);
            IRouter router = new Router(_schemes, _serviceCollection, contextProvider);
            _serviceCollection.AddTransient(s => router);
            _serviceCollection.AddTransient<IAstrolabe, AstrolabeNavigator>();
        }

        provider = _serviceCollection.BuildServiceProvider(options);

        using (IServiceScope scope = provider.CreateScope())
        {
            IRouter router = scope.ServiceProvider.GetRequiredService<IRouter>();
            router.Activate();
        }
        
        _useStartUp?.Invoke();

        provider = _serviceCollection.BuildServiceProvider(options);

        using (IServiceScope scope = provider.CreateScope())
        {
            return scope.ServiceProvider.GetRequiredService<IStartUp>();
        }
    }

    public INavigatorBuilder TargetContextProvider<T>() where T : class, IRouteContextProvider
    {
        _serviceCollection.AddTransient<IRouteContextResolver, RouteContextResolver>();
        _serviceCollection.AddTransient<IRouteContextProvider, T>();
        
        return this;
    }

    public INavigatorBuilder UseConfigure<T>() where T : class, IConfigurable
    {
        _useConfigure = () => _serviceCollection.AddTransient<IConfigurable, T>();

        return this;
    }
    public INavigatorBuilder UseStartUp<T>() where T : class, IStartUp
    {
        _useStartUp = () => _serviceCollection.AddTransient<IStartUp, T>();

        return this;
    }

    #endregion Public Methods

}