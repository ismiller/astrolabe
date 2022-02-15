using System;
using System.Runtime.CompilerServices;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Astrolabe.Core.Utilities.Security;
using Astrolabe.Core.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core.Routing.Routes;

/// <summary>
/// Предоставляет функционал управления маршрута.
/// </summary>
internal sealed class Router : IRouter
{
    #region Private Fields

    private IServiceProvider _provider;
    private readonly IServiceCollection _serviceCollection;
    private readonly IRouteSchemeDictionary _routeSchemeDictionary;
    private readonly IRouteContextProvider _contextProvider;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="Route"/>.
    /// </summary>
    /// <param name="routeSchemeDictionary">Словарь маршрутов.</param>
    /// <param name="collection">Коллекция сервисов.</param>
    public Router(IRouteSchemeDictionary routeSchemeDictionary, IServiceCollection collection, IRouteContextProvider contextProvider)
    {
        _contextProvider = Security.ProtectFrom.Null(contextProvider, nameof(contextProvider));
        _routeSchemeDictionary = Security.ProtectFrom.Null(routeSchemeDictionary, nameof(routeSchemeDictionary));
        _serviceCollection = Security.ProtectFrom.Null(collection, nameof(collection));
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public IBuildRouteResult GetRequiredRoute<T>() where T : INavigatable
    {
        if (_routeSchemeDictionary.TryGetScheme<T>(out IRouteScheme scheme))
        {
            IRouteContext context = _contextProvider.GetContext(scheme.ContextInfo);

            if (context is null && scheme.ContextInfo.IsExecuteOnlySpecifiedContext)
            {
            }

            object viewModel = _provider.GetRequiredService(scheme.ViewModelType);

            if (viewModel is T concreteViewModel)
            {
                IRoute route = new Route(concreteViewModel, scheme.ViewType);
                return BuildRouteResult.Succeeded(route);
            }
        }

        return BuildRouteResult.Failed("Route not found");
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Activate()
    {
        _provider = _serviceCollection.BuildServiceProvider();
    }

    #endregion Public Methods
}