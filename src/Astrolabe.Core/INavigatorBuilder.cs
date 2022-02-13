using System;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.Routing.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core;

/// <summary>
/// Определяет функционал для сборки сервиса навигации.
/// </summary>
internal interface INavigatorBuilder
{
    /// <summary>
    /// Выполняет сборку сервиса навигации.
    /// </summary>
    /// <returns>Экземпляр сервиса навигации.</returns>
    IAstrolabe Build();

    /// <summary>
    /// Выполняет регестрацию маршрутов навигации.
    /// </summary>
    /// <param name="setAction">Делегат установки маршрутов.</param>
    /// <returns>Экземпляр билдера сервиса навигации.</returns>
    INavigatorBuilder RegisterRoutes(Action<IRouteSchemeDictionary> setAction);

    /// <summary>
    /// Устанавливает контекст навигации.
    /// </summary>
    /// <param name="frame">Экземпляр <see cref="INavigationFrame"/> в котором будет происходить навигация.</param>
    /// <param name="options">Экземпляр <see cref="IFrameOptions"/>.</param>
    /// <returns>Экземпляр билдера сервиса навигации.</returns>
    INavigatorBuilder SetNavigateContext(INavigationFrame frame, IFrameOptions options);

    /// <summary>
    /// Выполняет установку коллекции сервисов.
    /// </summary>
    /// <param name="collection">Экземпляр <see cref="IServiceCollection"/>.</param>
    /// <returns>Экземпляр билдера сервиса навигации.</returns>
    INavigatorBuilder SetServiceCollection(IServiceCollection collection);
}