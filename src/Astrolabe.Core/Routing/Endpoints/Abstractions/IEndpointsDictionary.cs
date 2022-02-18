using System;
using System.Collections.Generic;

namespace Astrolabe.Core.Routing.Endpoints.Abstractions;

/// <summary>
/// Определяет функционал словаря маршрутов.
/// </summary>
public interface IEndpointsDictionary : IEnumerable<IEndpoint>
{
    /// <summary>
    /// Пытается извлечь из словаря схему маршрута.
    /// </summary>
    /// <param name="viewModelType"></param>
    /// <param name="endpoint">Извлеченный маршрут. <see langword="null" /> если маршрут не найден.</param>
    /// <returns><see langword="true"/> - если маршрут найден, иначе <see langword="false"/>.</returns>
    bool TryGetEndpoint(Type viewModelType, out IEndpoint endpoint);

    /// <summary>
    /// Регистрирует маршрут в словаре.
    /// </summary>
    /// <param name="endpoint">Схема маршрута.</param>
    void RegisterEndpoint(IEndpoint endpoint);
}