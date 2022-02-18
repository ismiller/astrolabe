using Astrolabe.Core.Components.Abstractions;

namespace Astrolabe.Core.Routing.Context.Abstraction;

/// <summary>
/// Определяет функционал разрешения контекста выполнения маршрута.
/// </summary>
public interface IRouteContextResolver
{
    /// <summary>
    /// Регистрирует контекст маршрута.
    /// </summary>
    /// <param name="frame">Компонент визуального отображения навигации.</param>
    /// <returns>Контекст маршрута.</returns>
    IRouteContext Resolve(INavigationFrame frame);
}