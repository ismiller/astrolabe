using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Schemes.Abstractions;

/// <summary>
/// Определяет функционал словаря маршрутов.
/// </summary>
internal interface IRouteSchemeDictionary
{
    /// <summary>
    /// Пытается извлечь из словаря схему маршрута.
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
    void RegisterScheme<TNavigatable, TView>(IContextInfo info)
        where TNavigatable : INavigatable
        where TView : INavigationFrame, new();

    /// <summary>
    /// Регистрирует маршрут в словаре.
    /// </summary>
    /// <param name="scheme">Схема маршрута.</param>
    void RegisterScheme(IRouteScheme scheme);
}