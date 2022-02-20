using System;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Context;

/// <summary>
/// Предоставляет функционал контекста навигации.
/// </summary>
internal sealed class RouteContext : IRouteContext
{
    #region Private Fields

    private readonly INavigationFrame _frame;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="RouteContext"/>.
    /// </summary>
    /// <param name="frame">Экземпляр <see cref="INavigationFrame"/> в рамках которого производится навигация.</param>

    public RouteContext(INavigationFrame frame)
    {
        _frame = Security.ProtectFrom.Null(frame, nameof(frame));
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public bool MoveToEndpoint(IEndpointExecuteRequest request)
    {
        return _frame.ExecuteNavigation(request.DestinationEndpoint.ViewType, request.ViewModelContainer, request.Options);
    }

    #endregion Public Methods
}