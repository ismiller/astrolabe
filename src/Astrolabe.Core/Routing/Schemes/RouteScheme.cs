using System;
using Astrolabe.Core.Helpers;
using Astrolabe.Core.Routing.Abstraction;

namespace Astrolabe.Core.Routing.Schemes;

/// <inheritdoc />
internal sealed class RouteScheme : IRouteScheme
{
    #region Public Properties

    /// <inheritdoc />
    public Type ViewModelType { get; }

    /// <inheritdoc />
    public Type ViewType { get; }

    /// <inheritdoc />
    public IContextInfo ContextInfo { get; }

    public RouteScheme(Type viewModelType, Type viewType, IContextInfo info)
    {
        ViewModelType = Security.NotNull(viewModelType, nameof(viewModelType));
        ViewType = Security.NotNull(viewType, nameof(viewType));
        ContextInfo = Security.NotNull(info, nameof(info));
    }

    #endregion Public Properties
}