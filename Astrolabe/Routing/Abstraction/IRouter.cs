using Astrolabe.ViewModels;

namespace Astrolabe.Routing.Abstraction
{
    /// <summary>
    /// Определяет функционал управления маршрутами.
    /// </summary>
    public interface IRouter
    {
        /// <summary>
        /// Предоставляет маршрут навигации для требуемой модели представления.
        /// </summary>
        /// <typeparam name="TViewModel">Тип модели представления.</typeparam>
        /// <returns>Объект маршрута - <see cref="IRoute"/>.</returns>
        IRoute GetRequiredRoute<TNavigatable>() where TNavigatable : INavigatable;
    }
}