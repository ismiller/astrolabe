using System;
using Astrolabe.Core.Navigating.Abstraction;
using Astrolabe.Core.ViewModels.Abstractions;

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
    /// Выполняет навигацию на предыдущую страницу.
    /// </summary>
    /// <remarks>
    /// Обработка опций навигации будут произведена после завершения навигации.
    /// </remarks>
    /// <param name="navigationArgs">Аргументы навигации.</param>
    /// <param name="options">Опции навигации.</param>
    void NavigateBack(INavigationArgs navigationArgs, INavigationOptions options);

    /// <summary>
    /// Выполняет навигацию на предыдущую страницу.
    /// </summary>
    /// <param name="navigationArgs">Аргументы навигации.</param>
    void NavigateBack(INavigationArgs navigationArgs);

    /// <summary>
    /// Выполняет навигацию на указанную страницу.
    /// </summary>
    /// <remarks>
    /// Обработка опций навигации будут произведена после завершения навигации.
    /// </remarks>
    /// <param name="viewModelType"></param>
    /// <param name="navigationArgs">Аргументы навигации.</param>
    /// <param name="options">Опции навигации.</param>
    void NavigateTo(Type viewModelType, INavigationArgs navigationArgs, INavigationOptions options);

    /// <summary>
    /// Выполняет навигацию на указанную страницу.
    /// </summary>
    /// <param name="viewModelType"></param>
    /// <param name="navigationArgs">Аргументы навигации.</param>
    void NavigateTo(Type viewModelType, INavigationArgs navigationArgs);
}