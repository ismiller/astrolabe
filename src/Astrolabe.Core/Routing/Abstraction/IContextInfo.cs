using Astrolabe.Core.Pages.Abstractions;

namespace Astrolabe.Core.Routing.Abstraction;

/// <summary>
/// Определяет опции выполнения маршрута.
/// </summary>
public interface IContextInfo
{
    /// <summary>
    /// Предоставляет ключ контекста выполнения маршрута.
    /// </summary>
    public string RequiredContextKey { get; }

    /// <summary>
    /// Предоставляет опции отображения навигации в визуальном компоненте.
    /// </summary>
    public IFrameOptions FrameOptions { get; }

    /// <summary>
    /// Предоставляет флаг, указывающий на необходимость выполнения маршрута только в указанном контексте.
    /// </summary>
    public bool IsExecuteOnlySpecifiedContext { get; }
}