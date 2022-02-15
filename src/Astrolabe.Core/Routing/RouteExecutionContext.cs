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
    private readonly IFrameOptions _options;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="RouteExecutionContext"/>.
    /// </summary>
    /// <param name="frame">Экземпляр <see cref="INavigationFrame"/> в рамках которого производится навигация.</param>
    /// <param name="options"></param>
    public RouteExecutionContext(INavigationFrame frame, IFrameOptions options)
    {
        _options = Security.NotNull(options, nameof(options));
        _frame = Security.NotNull(frame, nameof(frame));
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public bool TryExecute(Type viewType, IViewModelContainer container)
    {
        return _frame.NavigateToType(viewType, container, _options);
    }

    #endregion Public Methods
}