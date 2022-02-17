using System;
using Astrolabe.Core.Components.Abstractions;

namespace Astrolabe.Core.Routing.Endpoints.Abstractions;

/// <summary>
/// Определяет методы настройки схемы маршрута.
/// </summary>
public interface IEndpointBlank
{
    /// <summary>
    /// Устанавливает опции визуального отображения перехода в компоненте навигации.
    /// </summary>
    /// <param name="options">Экземпляр опций.</param>
    /// <returns><see cref="IEndpointBlank"/>.</returns>
    IEndpointBlank SetFrameOptions(IFrameOptions options);

    /// <summary>
    /// Устанавливает обязательность выполнения в заданном контексте.
    /// </summary>
    /// <returns><see cref="IEndpointBlank"/>.</returns>
    IEndpointBlank ExecuteOnlySpecifiedContext();

    IEndpointBlank AttachNavigationStackRule();

    IEndpointBlank SetView(Type viewType);

    IEndpointBlank SetViewModel(Type viewModelType);

    IEndpointBlank IsRoot();
}