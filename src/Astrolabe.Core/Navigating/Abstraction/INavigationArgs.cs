using System;

namespace Astrolabe.Core.Navigating.Abstraction;

/// <summary>
/// Представляет аргумент навигации.
/// </summary>
public interface INavigationArgs
{
    INavigationMessage Message { get; }

    bool IsReverseNavigationAvailable { get; }

    void NavigateToBack();

    void NavigateToBack(INavigationMessage message);

    void NavigateToBack(INavigationMessage message, INavigationOptions options);
}