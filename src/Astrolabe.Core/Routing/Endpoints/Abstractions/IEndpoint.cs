using System;
using Astrolabe.Core.Routing.Context.Abstraction;

namespace Astrolabe.Core.Routing.Endpoints.Abstractions;

/// <summary>
/// Представляет схему маршрута.
/// </summary>
public interface IEndpoint
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

    /// <summary>
    /// Предоставляет флаг, указывающий, что схема является корнем выполнения навигации.
    /// </summary>
    bool IsRoot { get; }
}