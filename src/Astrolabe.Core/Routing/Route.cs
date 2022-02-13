using System;
using Astrolabe.Core.Helpers;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.Core.ViewModels;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing;

/// <summary>
/// Предоставляет функционал управления маршрутом.
/// </summary>
internal sealed class Route : IRoute
{
    #region Private Fields

    private readonly IViewModelContainer _viewModelContainer;
    private readonly Type _viewType;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="Route"/>.
    /// </summary>
    /// <param name="viewModel">Навигируемый объект.</param>
    /// <param name="viewType">Тип представления.</param>
    public Route(INavigatable viewModel, Type viewType)
    {
        _viewType = Security.NotNull(viewType, nameof(viewType));
        _viewModelContainer = new ViewModelContainer(viewModel);
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public IRoutingResult TryExecute(IRouteExecutionContext context)
    {
        bool result = context.TryExecute(_viewType, _viewModelContainer);
        if (result)
        {
            return RoutingResult.Succeeded(_viewModelContainer.ViewModel);
        }
        else
        {
            return RoutingResult.Failed();
        }
    }

    #endregion Public Methods
}