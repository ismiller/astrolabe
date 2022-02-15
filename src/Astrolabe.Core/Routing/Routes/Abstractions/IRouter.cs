using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Routes.Abstractions;

/// <summary>
/// Определяет функционал управления маршрутами.
/// </summary>
public interface IRouter
{
    /// <summary>
    /// Предоставляет маршрут навигации для требуемой модели представления.
    /// </summary>
    /// <typeparam name="TNavigatable">Тип модели представления.</typeparam>
    /// <returns>Объект маршрута - <see cref="IRoute"/>.</returns>
    IBuildRouteResult GetRequiredRoute<TNavigatable>() where TNavigatable : INavigatable;

    /// <summary>
    /// Выполняет активацию.
    /// </summary>
    public void Activate();
}