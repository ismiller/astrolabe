using System;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Components.Abstractions;

/// <summary>
/// Определяет визуальный компонент смены контента при навигации.
/// </summary>
public interface INavigationFrame
{
    /// <summary>
    /// Предоставляет или устанавливает идентификационный ключ компонента.
    /// </summary>
    string ContextKey { get; set; }

    /// <summary>
    /// Выполняет навигацию на указанный тип представления
    /// </summary>
    /// <param name="viewType">Тип представления к которому выполняется навигация.</param>
    /// <param name="container">Контейнер управляющего содержимого представления.</param>
    /// <param name="options">Опции навигации.</param>
    /// <returns><see langword="true"/> - если навигация выполнена успешно.</returns>
    bool ExecuteNavigation(Type viewType, IViewModelContainer container, IFrameOptions options);
}