using System;
using System.Runtime.CompilerServices;
using Astrolabe.Core.Routing.Context;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Routing.Routes.Abstractions;
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
    private readonly IEndpointsDictionary _endpointsDictionary;
    private readonly IRouteContextProvider _contextProvider;
    private IRouteContext _currentContext;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="Route"/>.
    /// </summary>
    /// <param name="endpointsDictionary">Словарь маршрутов.</param>
    /// <param name="collection">Коллекция сервисов.</param>
    /// <param name="contextProvider">Провайдер контекста выполнения маршрута.</param>
    public Router(IEndpointsDictionary endpointsDictionary, IServiceCollection collection, IRouteContextProvider contextProvider)
    {
        _contextProvider = Security.ProtectFrom.Null(contextProvider, nameof(contextProvider));
        _endpointsDictionary = Security.ProtectFrom.Null(endpointsDictionary, nameof(endpointsDictionary));
        _serviceCollection = Security.ProtectFrom.Null(collection, nameof(collection));
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public IBuildRouteResult GetRequiredRoute(RouteBuildRequest request)
    {
        if (_endpointsDictionary.TryGetEndpoint(request.RequestViewModelType, out IEndpoint endpoint))
        {
            string key = endpoint.Options.RequiredContextKey;
            bool isRequired = endpoint.Options.IsRequiredSpecifiedContext;
            IContextRequest contextRequest = BuildContextRequest(key, isRequired);
            IRouteContext context = GetContext(contextRequest);
            
            object viewModel = _provider.GetRequiredService(endpoint.ViewModelType);

            if (viewModel is INavigatable concreteViewModel)
            {
                IRoute route = Route.BuildRoute(concreteViewModel, endpoint.ViewType);
                INavigationExecutor executor = new NavigationExecutor(route, context, endpoint.Options);
                _currentContext = context;
                return BuildRouteResult.Succeeded(executor);
            }
        }

        return BuildRouteResult.Failed("Route not found");
    }

    private IRouteContext GetContext(IContextRequest request)
    {
        IRouteContext context = _contextProvider.GetContext(request);
        if (context is null)
        {
            if (request.IsRequiredSpecifiedContext)
            {
                //TODO: бросить исключение
            }

            if (_currentContext is null)
            {
                //TODO: бросить исключение или организовать поиск ближайшего контекста по правилам маршрутизации
            }
        }

        return context;
    }

    private ContextRequest BuildContextRequest(string contextKey, bool isRequired)
    {
        return new ContextRequest
        {
            ContextKey = contextKey,
            IsRequiredSpecifiedContext = isRequired
        };
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Activate()
    {
        _provider = _serviceCollection.BuildServiceProvider();
    }

    #endregion Public Methods
}