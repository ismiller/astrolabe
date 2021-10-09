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
        IRoute GetRequiredRoute<TViewModel>();

        /// <summary>
        /// Выполняет регистрацию маршрута.
        /// </summary>
        /// <typeparam name="TViewModel">Тип модели представления.</typeparam>
        /// <typeparam name="TView">Тип представления.</typeparam>
        /// <param name="isViewCashed">Флаг, указывающий на необходимость кеширования модели представления.</param>
        void RegisterRoute<TViewModel, TView>(bool isViewCashed = false);
    }
}