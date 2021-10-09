using Astrolabe.Pages.Abstractions;

namespace Astrolabe.Routing.Abstraction
{
    /// <summary>
    /// Преддоставляет функционал управления маршрутом.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// Пытается выполнить маршрут.
        /// </summary>
        /// <param name="context">Контекст навигации.</param>
        /// <returns>Возвращает объект <see cref="IRoutingResult"/> предоставляющий результат выполнения маршрута.</returns>
        IRoutingResult TryExecute(INavigateContext context);

        /// <summary>
        /// Выполняяет сбрасывание маршрута.
        /// </summary>
        void Reset();
    }
}