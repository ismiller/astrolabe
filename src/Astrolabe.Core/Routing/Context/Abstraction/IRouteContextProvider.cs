﻿namespace Astrolabe.Core.Routing.Context.Abstraction;

/// <summary>
/// Определяет методы предоставления контекста выполнения маршрута.
/// </summary>
public interface IRouteContextProvider
{
    /// <summary>
    /// Предоставляет контекст выполнения маршрута.
    /// </summary>
    /// <param name="info">Информация о запрашиваемом контексте выполнения.</param>
    /// <returns>Запрошенный контекст выполнения.</returns>
    IRouteContext GetContext(IContextInfo info);
}