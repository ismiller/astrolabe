using System;
using System.Collections.Generic;

namespace Astrolabe.Core.Routing.Schemes.Abstractions;

/// <summary>
/// Определяет функционал словаря маршрутов.
/// </summary>
public interface IRouteSchemeDictionary<T> : IEnumerable<T>
{
    /// <summary>
    /// Пытается извлечь из словаря схему маршрута.
    /// </summary>
    /// <param name="viewModelType"></param>
    /// <param name="scheme">Извлеченный маршрут. <see langword="null" /> если маршрут не найден.</param>
    /// <returns><see langword="true"/> - если маршрут найден, иначе <see langword="false"/>.</returns>
    bool TryGetScheme(Type viewModelType, out T scheme);

    /// <summary>
    /// Регистрирует маршрут в словаре.
    /// </summary>
    /// <param name="scheme">Схема маршрута.</param>
    void RegisterScheme(T scheme);
}