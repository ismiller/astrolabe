using System;
using Astrolabe.Core.Helpers;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing;

/// <summary>
/// Предоставляет функционал контекста навигации.
/// </summary>
internal sealed class RouteExecutionContext : IRouteExecutionContext
{
    #region Private Fields

    private readonly INavigationFrame _frame;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="RouteExecutionContext"/>.
    /// </summary>
    /// <param name="frame">Экземпляр <see cref="INavigationFrame"/> в рамках которого производится навигация.</param>
    public RouteExecutionContext(INavigationFrame frame)
    {
        _frame = Security.NotNull(frame, nameof(frame));
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public bool TryExecute(Type viewType, IViewModelContainer container, IFrameOptions options)
    {
        _ = Security.NotNull(options, nameof(options));
        return _frame.NavigateToType(viewType, container, options);
    }

    #endregion Public Methods
}