using System;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Endpoints;

/// <inheritdoc />
internal sealed class Endpoint : IEndpoint
{
    #region Public Properties

    /// <inheritdoc />
    public Type ViewModelType { get; }

    /// <inheritdoc />
    public Type ViewType { get; }

    public IEndpointOptions Options { get; }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Endpoint"/>.
    /// </summary>
    /// <param name="viewModelType">Тип модели представления.</param>
    /// <param name="viewType">Тип визуального представления.</param>
    /// <param name="options"></param>
    public Endpoint(Type viewModelType, Type viewType, IEndpointOptions options)
    {
        ViewModelType = Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
        ViewType = Security.ProtectFrom.Null(viewType, nameof(viewType));
        Options = Security.ProtectFrom.Null(options, nameof(options));
    }

    #endregion Public Properties
}