namespace Astrolabe.Core.ViewModels.Abstractions;

/// <summary>
/// Определяет функционал навигируемого объекта.
/// </summary>
public interface INavigatable
{
    /// <summary>
    /// Устанавливает аргументы навигации.
    /// </summary>
    /// <remarks>
    /// Метод будет вызван после удачного выполнения навигации.
    /// В случае, если навигация прошла неудачно вызов метода игнорируется.
    /// </remarks>
    /// <param name="args">Объект аргументов навигации.</param>
    void Prepare(INavigationArgs args);

    /// <summary>
    /// Устанавливает экземпляр наблюдателя событий представления.
    /// </summary>
    /// <param name="observer">Экземпляр наблюдателя событий представления</param>
    void SetObserver(IViewObserver observer);
}