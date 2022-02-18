using Astrolabe.Core.Routing.History.Abstractions;
using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Routes;

/// <inheritdoc />
internal sealed class RoutingResult : IRoutingResult
{
    #region Private Fields

    private readonly INavigatable _navigatable;

    #endregion Private Fields

    #region Public Properties

    /// <inheritdoc />
    public bool IsSuccess { get; }

    /// <inheritdoc />
    public string Message { get; }

    public IRouteHistoryInfo HistoryInfo { get; }

    #endregion Public Properties

    #region Private Constructors

    private RoutingResult(INavigatable navigatable, IRouteHistoryInfo info, bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
        _navigatable = navigatable;
        HistoryInfo = info;
    }

    private RoutingResult(bool isSuccess, string message)
        : this(default, default, isSuccess, message)
    {
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Предоставляет экземпляр <see cref="IRoutingResult"/> неудачного выполнения маршрута.
    /// </summary>
    /// <param name="message">Сообщение навигации.</param>
    /// <returns>Результат навигации.</returns>
    public static IRoutingResult Failed(string message = default)
    {
        return new RoutingResult(false, message);
    }

    /// <summary>
    /// Предоставляет экземпляр <see cref="IRoutingResult"/> успешного выполнения маршрута.
    /// </summary>
    /// <param name="navigatable">Навигируемый объект.</param>
    /// <param name="message">Сообщение навигации.</param>
    /// <returns>Результат навигации.</returns>
    public static IRoutingResult Succeeded(INavigatable navigatable, IRouteHistoryInfo info, string message = default)
    {
        return new RoutingResult(navigatable, info, true, message);
    }

    /// <inheritdoc />
    public void ApplyNavigateArgs(INavigationArgs args)
    {
        _navigatable?.Prepare(args);
    }

    #endregion Public Methods
}