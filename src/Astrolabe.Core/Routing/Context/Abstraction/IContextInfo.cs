using Astrolabe.Core.Components.Abstractions;

namespace Astrolabe.Core.Routing.Context.Abstraction;

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
    public bool IsRequiredSpecifiedContext { get; }

    /// <summary>
    /// Предоставляет или устанавливает флаг, указывающий, что маршрут, связанный с этим контекстом,
    /// должен будет выполниться в корневом фрейме окна.
    /// </summary>
    public bool IsRequiredRootFrame { get; set; }
}