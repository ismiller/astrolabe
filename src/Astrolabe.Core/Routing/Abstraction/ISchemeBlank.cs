﻿using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Abstraction;

/// <summary>
/// Определяет методы настройки схемы маршрута.
/// </summary>
public interface ISchemeBlank
{
    /// <summary>
    /// Устанавливает для маршрута контекст выполнения с указанным ключом.
    /// </summary>
    /// <param name="contextKey">Ключ контекста.</param>
    /// <returns><see cref="ISchemeBlank"/>.</returns>
    ISchemeBlank AttachContext(string contextKey);

    /// <summary>
    /// Устанавливает опции визуального отображения перехода в компоненте навигации.
    /// </summary>
    /// <param name="options">Экземпляр опций.</param>
    /// <returns><see cref="ISchemeBlank"/>.</returns>
    ISchemeBlank AttachFrameOptions(IFrameOptions options);

    /// <summary>
    /// Устанавливает обязательность выполнения в заданном контексте.
    /// </summary>
    /// <returns><see cref="ISchemeBlank"/>.</returns>
    ISchemeBlank ExecuteOnlySpecifiedContext();

    ISchemeBlank AttachNavigationStackRule();

    ISchemeBlank SetView<T>() where T : INavigationPage;

    ISchemeBlank SetViewModel<T>() where T : INavigatable;
}