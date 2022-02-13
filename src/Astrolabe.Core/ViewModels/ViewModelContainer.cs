using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.ViewModels;

/// <inheritdoc />
internal sealed class ViewModelContainer : IViewModelContainer
{
    /// <inheritdoc />
    public INavigatable ViewModel { get; }

    /// <summary>
    /// Создает экземпляр <see cref="ViewModelContainer"/>.
    /// </summary>
    /// <param name="navigatable">Экземпляр модели представления.</param>
    public ViewModelContainer(INavigatable navigatable)
    {
        ViewModel = navigatable;
    }
}