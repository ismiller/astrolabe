using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Routes;

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
    public IRouteMover Mover { get; }

    #endregion Public Properties

    #region Private Constructors

    private BuildRouteResult(bool isSuccess, string message, IRouteMover routeMover)
    {
        IsSuccess = isSuccess;
        Message = message;
        Mover = Security.ProtectFrom.Null(routeMover, nameof(routeMover));
    }

    private BuildRouteResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Предоставляет экземпляр <see cref="IRoutingResult"/> неудачного выполнения маршурта.
    /// </summary>
    /// <param name="message">Сообщение ошибки получения маршрута.</param>
    /// <returns>Результат получения маршрута.</returns>
    public static IBuildRouteResult Failed(string message = default)
    {
        return new BuildRouteResult(false, message);
    }

    /// <summary>
    /// Предоставляет экземпляр <see cref="IRoutingResult"/> успешного получения маршрута.
    /// </summary>
    /// <param name="mover">исполнитель маршрута.</param>
    /// <param name="message">Сообщение получения маршрута.</param>
    /// <returns>Результат получения маршрута.</returns>
    public static IBuildRouteResult Succeeded(IRouteMover mover, string message = default)
    {
        return new BuildRouteResult(true, message, mover);
    }

    #endregion Public Methods
}