namespace Astrolabe.Core.Routing.Routes.Abstractions;

/// <summary>
/// Определяет функционал управления маршрутами.
/// </summary>
internal interface IRouter
{
    /// <summary>
    /// Предоставляет маршрут навигации для требуемой модели представления.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Объект маршрута - <see cref="IRoute"/>.</returns>
    IBuildRouteResult GetRequiredRoute(RouteBuildRequest request);

    /// <summary>
    /// Выполняет активацию.
    /// </summary>
    public void Activate();
}