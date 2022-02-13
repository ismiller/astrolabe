using Astrolabe.Core.Navigating.Abstraction;

namespace Astrolabe.Core.Navigating.Options;

/// <summary>
/// Предоставляет набор параметров для навигации.
/// </summary>
public struct NavigationOptions : INavigationOptions
{
    /// <inheritdoc />
    public bool IsClearStack { get; set; }

    /// <inheritdoc />
    public bool IsResetStack { get; set; }

    /// <inheritdoc />
    public bool IsIgnoreStack { get; set; }
}