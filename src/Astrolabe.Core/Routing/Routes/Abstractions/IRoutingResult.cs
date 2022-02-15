using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Routes.Abstractions;

/// <summary>
/// Предоставляет результат выполнения маршрута.
/// </summary>
public interface IRoutingResult
{
    /// <summary>
    /// Предоставляет флаг, указывающий на успешное выполнение маршрута.
    /// </summary>
    bool IsSuccess { get; }

    /// <summary>
    /// Предоставляет сообщение результата выполнения маршрута.
    /// </summary>
    string Message { get; }

    /// <summary>
    /// Применяет переданные аргументы навигации.
    /// </summary>
    /// <param name="args">Устанавливаемые аргументы навигации.</param>
    void ApplyNavigateArgs(INavigationArgs args);
}