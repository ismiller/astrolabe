using Astrolabe.Core.Routing.Abstraction;

namespace Astrolabe.Core.Routing;

/// <summary>
/// Предоставляет результат составления маршрута.
/// </summary>
internal sealed class BuildRouteResult : IBuildRouteResult
{
    #region Public Properties

    /// <inheritdoc />
    public bool IsSuccess { get; }

    /// <inheritdoc />
    public string Message { get; }

    /// <inheritdoc />
    public IRoute Route { get; }

    #endregion Public Properties

    #region Private Constructors

    private BuildRouteResult(bool isSuccess, string message, IRoute route = default)
    {
        IsSuccess = isSuccess;
        Message = message;
        Route = route;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Прдоставляет экземпляр <see cref="IRoutingResult"/> неудачного выполнения маршурта.
    /// </summary>
    /// <param name="message">Сообщение ошибки получения маршрута.</param>
    /// <returns>Результат получения маршрута.</returns>
    public static IBuildRouteResult Failed(string message = default)
    {
        return new BuildRouteResult(false, message);
    }

    /// <summary>
    /// Прдоставляет экземпляр <see cref="IRoutingResult"/> успешного получения маршрута.
    /// </summary>
    /// <param name="route">Полученный маршрут.</param>
    /// <param name="message">Сообщение получения маршрута.</param>
    /// <returns>Результат получения маршрута.</returns>
    public static IBuildRouteResult Succeeded(IRoute route, string message = default)
    {
        return new BuildRouteResult(true, message, route);
    }

    #endregion Public Methods
}