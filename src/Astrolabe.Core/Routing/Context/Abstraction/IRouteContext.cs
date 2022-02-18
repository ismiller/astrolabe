using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Routes.Abstractions;

namespace Astrolabe.Core.Routing.Context.Abstraction;
    
/// <summary>
/// Определяет функционал контекста навигации.
/// </summary>
public interface IRouteContext
{
    /// <summary>
    /// Пробует выполнить установку типа представления в контекст навигации.
    /// </summary>
    /// <param name="route">Тип представления.</param>
    /// <param name="options"></param>
    /// <returns><see langword="true"/> - если установка выполнена успешно.</returns>
    bool ExecuteRoute(IRoute route, IFrameOptions options);
}