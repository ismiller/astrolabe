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

    #endregion Public Properties

    #region Private Constructors

    private RoutingResult(bool isSuccess, INavigatable navigatable, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
        _navigatable = navigatable;
    }

    private RoutingResult(bool isSuccess, string message)
        : this(isSuccess, default, message)
    {
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Прдоставляет экземпляр <see cref="IRoutingResult"/> неудачного выполнения маршурта.
    /// </summary>
    /// <param name="message">Сообщение навигации.</param>
    /// <returns>Результат навигации.</returns>
    public static IRoutingResult Failed(string message = default)
    {
        return new RoutingResult(false, message);
    }

    /// <summary>
    /// Прдоставляет экземпляр <see cref="IRoutingResult"/> успешного выполнения маршурта.
    /// </summary>
    /// <param name="navigatable">Навигируемый объект.</param>
    /// <param name="message">Сообщение навигации.</param>
    /// <returns>Результат навигации.</returns>
    public static IRoutingResult Succeeded(INavigatable navigatable, string message = default)
    {
        return new RoutingResult(true, navigatable, message);
    }

    /// <inheritdoc />
    public void ApplyNavigateArgs(INavigationArgs args)
    {
        _navigatable?.Prepare(args);
    }

    #endregion Public Methods
}