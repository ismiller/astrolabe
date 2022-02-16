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
    private readonly IRouteSchemeDictionary<IRouteScheme> _routeSchemeDictionary;
    private readonly IRouteContextProvider _contextProvider;
    private IRouteContext _currentContext;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="Route"/>.
    /// </summary>
    /// <param name="routeSchemeDictionary">Словарь маршрутов.</param>
    /// <param name="collection">Коллекция сервисов.</param>
    /// <param name="contextProvider">Провайдер контекста выполнения маршрута.</param>
    public Router(IRouteSchemeDictionary<IRouteScheme> routeSchemeDictionary, IServiceCollection collection, IRouteContextProvider contextProvider)
    {
        _contextProvider = Security.ProtectFrom.Null(contextProvider, nameof(contextProvider));
        _routeSchemeDictionary = Security.ProtectFrom.Null(routeSchemeDictionary, nameof(routeSchemeDictionary));
        _serviceCollection = Security.ProtectFrom.Null(collection, nameof(collection));
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public IBuildRouteResult GetRequiredRoute(Type viewModelType)
    {
        if (_routeSchemeDictionary.TryGetScheme(viewModelType, out IRouteScheme scheme))
        {
            IRouteContext context = GetContext(scheme.ContextInfo);
            
            object viewModel = _provider.GetRequiredService(scheme.ViewModelType);

            if (viewModel is not null && viewModel is INavigatable concreteViewModel)
            {
                IRoute route = new Route(concreteViewModel, scheme.ViewType);
                IRouteMover mover = new RouteMover(route, context);
                _currentContext = context;
                return BuildRouteResult.Succeeded(mover);
            }
        }

        return BuildRouteResult.Failed("Route not found");
    }

    private IRouteContext GetContext(IContextInfo info)
    {
        IRouteContext context = _contextProvider.GetContext(info);

        if (context is null)
        {
            if (info.IsExecuteOnlySpecifiedContext)
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

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Activate()
    {
        _provider = _serviceCollection.BuildServiceProvider();
    }

    #endregion Public Methods
}