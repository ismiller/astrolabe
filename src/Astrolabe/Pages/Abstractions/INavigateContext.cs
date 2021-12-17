using System;
using Windows.UI.Xaml.Controls;
using Astrolabe.ViewModels;

namespace Astrolabe.Pages.Abstractions
{
    /// <summary>
    /// Определяет функционал контекста навигации.
    /// </summary>
    /// <remarks>
    /// Контекст навигации представляет собой обёртку над экземпляром <see cref="Frame"/>,
    /// в рамках которого выполняется постраничная навигация.
    /// </remarks>
    public interface INavigateContext
    {
        /// <summary>
        /// Пробует выполнить установку типа представления в контекст навигации.
        /// </summary>
        /// <param name="viewType">Тип представления.</param>
        /// <param name="container">Модель представления.</param>
        /// <returns><see langword="true"/> - если установка выполнена успешно.</returns>
        bool TryAccept(Type viewType, IViewModelContainer container);
    }
}