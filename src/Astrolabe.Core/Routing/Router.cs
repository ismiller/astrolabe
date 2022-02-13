using System;
using System.Runtime.CompilerServices;
using Astrolabe.Core.Helpers;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.Core.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core.Routing;

/// <summary>
/// Предоставляет функционал управления маршрута.
/// </summary>
internal sealed class Router : IRouter
{
    #region Private Fields

    private IServiceProvider _provider;
    private readonly IServiceCollection _serviceCollection;
    private readonly IRouteSchemeDictionary _routeSchemeDictionary;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="Route"/>.
    /// </summary>
    /// <param name="routeSchemeDictionary">Словарь маршрутов.</param>
    /// <param name="collection">Коллекция сервисов.</param>
    public Router(IRouteSchemeDictionary routeSchemeDictionary, IServiceCollection collection)
    {
        _routeSchemeDictionary = Security.NotNull(routeSchemeDictionary, nameof(routeSchemeDictionary));
        _serviceCollection = Security.NotNull(collection, nameof(collection));
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public IBuildRouteResult GetRequiredRoute<T>() where T : INavigatable
    {
        if (_routeSchemeDictionary.TryGetScheme<T>(out IRouteScheme scheme))
        {
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