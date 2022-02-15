using System;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Utilities.Security;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Context;

/// <summary>
/// Предоставляет функционал контекста навигации.
/// </summary>
internal sealed class RouteContext : IRouteContext
{
    #region Private Fields

    private readonly INavigationFrame _frame;
    private readonly IFrameOptions _options;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="RouteContext"/>.
    /// </summary>
    /// <param name="frame">Экземпляр <see cref="INavigationFrame"/> в рамках которого производится навигация.</param>
    /// <param name="options"></param>
    public RouteContext(INavigationFrame frame, IFrameOptions options)
    {
        _options = Security.ProtectFrom.Null(options, nameof(options));
        _frame = Security.ProtectFrom.Null(frame, nameof(frame));
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public bool TryExecute(Type viewType, IViewModelContainer container)
    {
        return _frame.ExecuteNavigation(viewType, container, _options);
    }

    #endregion Public Methods
}