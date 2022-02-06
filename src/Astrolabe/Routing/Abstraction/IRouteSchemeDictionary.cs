using Astrolabe.Pages;
using Astrolabe.ViewModels.Abstractions;

namespace Astrolabe.Routing.Abstraction
{
    /// <summary>
    /// Определяет функционал словаря маршрутов.
    /// </summary>
    public interface IRouteSchemeDictionary
    {
        /// <summary>
        /// Пытается извлечь из словаря схему маршурта.
        /// </summary>
        /// <typeparam name="TNavigatable">Тип модели представления, для которой извлекается схема.</typeparam>
        /// <param name="scheme">Извлеченный маршрут. <see langword="null" /> если маршрут не найден.</param>
        /// <returns><see langword="true"/> - если маршрут найден, иначе <see langword="false"/>.</returns>
        bool TryGetScheme<TNavigatable>(out IRouteScheme scheme) where TNavigatable : INavigatable;

        /// <summary>
        /// Регистрирует маршрут в словаре.
        /// </summary>
        /// <typeparam name="TNavigatable">Тип модели представления, для которой регистрируется схема.</typeparam>
        /// <typeparam name="TView">Тип представления.</typeparam>
        void RegisterScheme<TNavigatable, TView>()
            where TNavigatable : INavigatable
            where TView : AstrolabePage, new();
    }
}