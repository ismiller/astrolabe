using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Astrolabe.Routing.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe
{
    /// <summary>
    /// Определяет функционал для сборки сервиса навигации.
    /// </summary>
    public interface INavigatorBuilder
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
        /// <param name="frame">Экземпляр <see cref="Frame"/> в котором будет происходить навигация.</param>
        /// <returns>Экземпляр билдера сервиса навигации.</returns>
        INavigatorBuilder SetNavigateContext(Frame frame);

        /// <summary>
        /// Устанавливает контекст навигации.
        /// </summary>
        /// <param name="frame">Экземпляр <see cref="Frame"/> в котором будет происходить навигация.</param>
        /// <param name="options">Экземпляр <see cref="FrameNavigationOptions"/>.</param>
        /// <returns>Экземпляр билдера сервиса навигации.</returns>
        INavigatorBuilder SetNavigateContext(Frame frame, FrameNavigationOptions options);

        /// <summary>
        /// Выполняет установку коллекции сервисов.
        /// </summary>
        /// <param name="collection">Экземпляр <see cref="IServiceCollection"/>.</param>
        /// <returns>Экземпляр билдера сервиса навигации.</returns>
        INavigatorBuilder SetServiceCollection(IServiceCollection collection);
    }
}