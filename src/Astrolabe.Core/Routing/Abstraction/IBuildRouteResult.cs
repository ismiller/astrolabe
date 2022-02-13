namespace Astrolabe.Core.Routing.Abstraction;

/// <summary>
/// Определяет результат составления маршрута.
/// </summary>
public interface IBuildRouteResult
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
    /// Предоставляет полученный маршрут.
    /// </summary>
    IRoute Route { get; }
}