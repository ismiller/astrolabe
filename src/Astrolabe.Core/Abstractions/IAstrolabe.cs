using System;
using Astrolabe.Core.Navigating.Abstraction;

namespace Astrolabe.Core.Abstractions;

/// <summary>
/// Описывает функционал управления навигацией.
/// </summary>
public interface IAstrolabe
{
    /// <summary>
    /// Событие, инициируемое после завершения навигации.
    /// </summary>
    event EventHandler Navigated;

    /// <summary>
    /// Выполняет навигацию на указанную страницу.
    /// </summary>
    /// <remarks>
    /// Обработка опций навигации будут произведена после завершения навигации.
    /// </remarks>
    /// <param name="viewModelType"></param>
    /// <param name="message">Аргументы навигации.</param>
    /// <param name="options">Опции навигации.</param>
    void NavigateTo(Type viewModelType, INavigationMessage message, INavigationOptions options);

    /// <summary>
    /// Выполняет навигацию на указанную страницу.
    /// </summary>
    /// <param name="viewModelType"></param>
    /// <param name="message">Аргументы навигации.</param>
    void NavigateTo(Type viewModelType, INavigationMessage message);
}