using System;

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
    /// 
    /// </summary>
    IEndpointOptions Options { get; }
}