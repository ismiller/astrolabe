namespace Astrolabe.Core.ViewModels.Abstractions;

/// <summary>
/// Предоставляет контейнер для экземпляря модели представления.
/// </summary>
public interface IViewModelContainer
{
    /// <summary>
    /// Предоставляет модель представления.
    /// </summary>
    public INavigatable ViewModel { get; }
}