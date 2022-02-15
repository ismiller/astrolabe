﻿using Astrolabe.Core.Pages.Abstractions;

namespace Astrolabe.Core.Routing.Abstraction;

/// <summary>
/// Определяет функционал управления маршрутом.
/// </summary>
public interface IRoute
{
    /// <summary>
    /// Пытается выполнить маршрут.
    /// </summary>
    /// <param name="context">Контекст навигации.</param>
    /// <returns>Возвращает объект <see cref="IRoutingResult"/> предоставляющий результат выполнения маршрута.</returns>
    IRoutingResult TryExecute(IRouteExecutionContext context);
}