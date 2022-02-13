using System;

namespace Astrolabe.Core.Routing.Abstraction;

/// <summary>
/// Представляет схему маршрута.
/// </summary>
internal interface IRouteScheme
{
    /// <summary>
    /// Предоставляет тип модели представления.
    /// </summary>
    Type ViewModelType { get; }

    /// <summary>
    /// Предоставляет тип представления.
    /// </summary>
    Type ViewType { get; }

    /// <summary>
    /// Предоставляет опции контекста выполнения маршрута.
    /// </summary>
    IContextInfo ContextInfo { get; }
}