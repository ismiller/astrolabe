namespace Astrolabe.Core.Navigating.Abstraction;

/// <summary>
/// Определяет набор параметров для навигации.
/// </summary>
public interface INavigationOptions
{
    /// <summary>
    /// Предоставляет или устанавливает флаг, указывающий на необходимость очистки стека после навигации.
    /// </summary>
    bool IsClearStack { get; set; }

    /// <summary>
    /// Предоставляет или устанавливает флаг, указывающий на необходимость сброса стека после навигации.
    /// </summary>
    bool IsResetStack { get; set; }
}