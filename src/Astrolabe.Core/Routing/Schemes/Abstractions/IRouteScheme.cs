using System;
using Astrolabe.Core.Routing.Context.Abstraction;

namespace Astrolabe.Core.Routing.Schemes.Abstractions;

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