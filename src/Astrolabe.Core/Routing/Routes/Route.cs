using System;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.Utilities.Security;
using Astrolabe.Core.ViewModels;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Routes;

/// <summary>
/// Предоставляет функционал управления маршрутом.
/// </summary>
internal sealed class Route : IRoute
{
    #region Private Fields

    public IViewModelContainer ViewModelContainer { get; }

    public Type ViewType { get; }

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="Route"/>.
    /// </summary>
    /// <param name="viewModel">Навигируемый объект.</param>
    /// <param name="viewType">Тип представления.</param>
    private Route(INavigatable viewModel, Type viewType)
    {
        ViewType = Security.ProtectFrom.Null(viewType, nameof(viewType));
        ViewModelContainer = new ViewModelContainer(viewModel);
    }

    #endregion Public Constructors

    #region Public Methods

    public static IRoute BuildRoute(INavigatable viewModel, Type viewType)
    {
        return new Route(viewModel, viewType);
    }

    #endregion Public Methods
}