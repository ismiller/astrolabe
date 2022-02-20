using System;

namespace Astrolabe.Core.Navigating.Abstraction;

public interface INavigationMessage
{
    /// <summary>
    /// Предоставляет делегат, для выполнения принимающей стороной.
    /// </summary>
    Action NavigationDone { get; }

    /// <summary>
    /// Предоставляет объект передаваемых данных.
    /// </summary>
    object NavigationData { get; }
}