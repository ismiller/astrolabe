namespace Astrolabe.Core.Routing.Routes.Abstractions;

/// <summary>
/// Определяет результат составления маршрута.
/// </summary>
internal interface IBuildRouteResult
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
    IRouteMover Mover { get; }
}