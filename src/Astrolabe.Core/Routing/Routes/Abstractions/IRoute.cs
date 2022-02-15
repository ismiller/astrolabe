using Astrolabe.Core.Routing.Context.Abstraction;

namespace Astrolabe.Core.Routing.Routes.Abstractions;

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
    IRoutingResult TryExecute(IRouteContext context);
}