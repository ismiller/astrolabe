using System;

namespace Astrolabe.ViewModels
{
    /// <summary>
    /// Представляет аргумент навигации.
    /// </summary>
    public interface INavigationArgs
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
}