using System;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Pages.Abstractions;

/// <summary>
/// Определяет визуальный компонент смены контента при навигации.
/// </summary>
public interface INavigationFrame
{
    /// <summary>
    /// Предоставляет или устанавливает индентификационный ключ компонента.
    /// </summary>
    string NavigationKey { get; set; }

    /// <summary>
    /// Выполняет нафигацию на указанный тип представления
    /// </summary>
    /// <param name="viewType">Тип представления к которому выполняется нафигация.</param>
    /// <param name="container">Сонтейнер управляющего содержимого представления.</param>
    /// <param name="options">Опции навигации.</param>
    /// <returns><see langword="true"/> - если нафигация выполнена успешно.</returns>
    bool NavigateToType(Type viewType, IViewModelContainer container, object options);
}