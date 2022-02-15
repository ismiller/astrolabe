using System;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Astrolabe.Core.Utilities.Security;

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
        ViewModelType = Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
        ViewType = Security.ProtectFrom.Null(viewType, nameof(viewType));
        ContextInfo = Security.ProtectFrom.Null(info, nameof(info));
    }

    #endregion Public Properties
}