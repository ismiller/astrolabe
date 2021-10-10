﻿using System;
using Astrolabe.ViewModels;

namespace Astrolabe.Navigating.Abstraction
{
    /// <summary>
    /// Описывает функционал управления навигацией.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Событие, инициируемое после завершения навигации.
        /// </summary>
        event EventHandler Navigated;

        /// <summary>
        /// Выполняет навигацию на предыдущую страницу.
        /// </summary>
        /// <remarks>
        /// Обработка опций навигации будут произведена после завершения навигации.
        /// </remarks>
        /// <param name="navigationArgs">Аргументы навигации.</param>
        /// <param name="options">Опции навигации.</param>
        void NavigateBack(INavigationArgs navigationArgs, INavigationOptions options);

        /// <summary>
        /// Выполняет навигацию на предыдущую страницу.
        /// </summary>
        /// <param name="navigationArgs">Аргументы навигации.</param>
        void NavigateBack(INavigationArgs navigationArgs);

        /// <summary>
        /// Выполняет навигацию на указанную страницу.
        /// </summary>
        /// <remarks>
        /// Обработка опций навигации будут произведена после завершения навигации.
        /// </remarks>
        /// <typeparam name="TViewModel">Тип модели представления на страницу которой производится навигация.</typeparam>
        /// <param name="navigationArgs">Аргументы навигации.</param>
        /// <param name="options">Опции навигации.</param>
        void NavigateTo<TViewModel>(INavigationArgs navigationArgs, INavigationOptions options);

        /// <summary>
        /// Выполняет навигацию на указанную страницу.
        /// </summary>
        /// <typeparam name="TViewModel">Тип модели представления на страницу которой производится навигация.</typeparam>
        /// <param name="navigationArgs">Аргументы навигации.</param>
        void NavigateTo<TViewModel>(INavigationArgs navigationArgs);
    }
}