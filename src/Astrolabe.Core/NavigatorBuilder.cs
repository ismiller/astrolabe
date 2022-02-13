using System;
using Astrolabe.Core.Helpers;
using Astrolabe.Core.Pages;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.Routing;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.Core.Routing.Schemes;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core;

/// <summary>
/// Предоставляет функционал для сборки сервиса навигации.
/// </summary>
public sealed class NavigatorBuilder
{
    #region Private Fields

    private readonly IRouteSchemeDictionary _schemeDictionary;
    private IRouteExecutionContext _routeExecutionContext;
    private IServiceCollection _serviceCollection;

    #endregion Private Fields

    #region Private Constructors

    private NavigatorBuilder()
    {
        _schemeDictionary = new RouteSchemeDictionary();
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Предоставляет экземпляр билдера сервиса навигации.
    /// </summary>
    public static NavigatorBuilder GetBuilder() => new NavigatorBuilder();

    /// <inheritdoc />
    public IAstrolabe Build()
    {
        Security.NotNull(_routeExecutionContext, nameof(_routeExecutionContext));

        IRouter router = new Router(_schemeDictionary, _serviceCollection);
        var astrolabe = new AstrolabeNavigator(_routeExecutionContext, router);
        _serviceCollection.AddSingleton<IAstrolabe>(s => astrolabe);
        router.Activate();
        return astrolabe;
    }

    /// <inheritdoc />
    public NavigatorBuilder SetNavigateContext(INavigationFrame frame, IFrameOptions options)
    {
        Security.NotNull(options, nameof(frame));

        _routeExecutionContext = new RouteExecutionContext(frame, options);

        return this;
    }

    /// <inheritdoc />
    public NavigatorBuilder SetServiceCollection(IServiceCollection collection)
    {
        _serviceCollection = Security.NotNull(collection, nameof(collection));
        return this;
    }

    #endregion Public Methods
}