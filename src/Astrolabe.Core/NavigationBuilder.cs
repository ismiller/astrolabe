using System;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Routing.Context;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Endpoints;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core;

public class NavigationBuilder : INavigatorBuilder
{
    #region Private Fields

    private readonly IEndpointBuilder _endpointBuilder;
    private readonly IServiceCollection _serviceCollection;
    private IEndpointsDictionary _schemes;

    private Action _useConfigure;
    private Action _useStartUp;

    #endregion Private Fields

    #region Public Properties

    public static INavigatorBuilder DefaultBuilder => new NavigationBuilder();

    #endregion Public Properties

    #region Private Constructors

    private NavigationBuilder()
    {
        _endpointBuilder = new EndpointBuilder();
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
            configurable.ConfigureSchemes(_endpointBuilder);
        }

        provider = _serviceCollection.BuildServiceProvider(options);

        using (IServiceScope scope = provider.CreateScope())
        {
            IContextProvider contextProvider = scope.ServiceProvider.GetRequiredService<IContextProvider>();

            var schemeBuilder = _endpointBuilder as IBuild<IEndpointsDictionary>;
            _schemes = schemeBuilder.Build();
            _serviceCollection.AddTransient(s => _schemes);
            IRouter router = new RouteManager(_schemes, _serviceCollection, contextProvider);
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

    public INavigatorBuilder TargetContextProvider<T>() where T : class, IContextProvider
    {
        _serviceCollection.AddTransient<IRouteContextResolver, RouteContextResolver>();
        _serviceCollection.AddTransient<IContextProvider, T>();

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