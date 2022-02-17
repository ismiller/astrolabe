using System;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Schemes;

/// <inheritdoc />
internal sealed class Endpoint : IEndpoint
{
    #region Public Properties

    /// <inheritdoc />
    public Type ViewModelType { get; }

    /// <inheritdoc />
    public Type ViewType { get; }

    /// <inheritdoc />
    public IContextInfo ContextInfo { get; }

    /// <inheritdoc />
    public bool IsRoot { get; }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Endpoint"/>.
    /// </summary>
    /// <param name="viewModelType">Тип модели представления.</param>
    /// <param name="viewType">Тип визуального представления.</param>
    /// <param name="info">Информация о контексте навигации.</param>
    /// <param name="isRoot">Флаг, указывающий, является ли маршрут корневым.</param>
    public Endpoint(Type viewModelType, Type viewType, IContextInfo info, bool isRoot)
    {
        ViewModelType = Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
        ViewType = Security.ProtectFrom.Null(viewType, nameof(viewType));
        ContextInfo = Security.ProtectFrom.Null(info, nameof(info));
        IsRoot = isRoot;
    }

    #endregion Public Properties
}