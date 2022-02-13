﻿using System;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Abstraction;

/// <summary>
/// Определяет функционал контекста навигации.
/// </summary>
public interface IRouteExecutionContext
{
    /// <summary>
    /// Пробует выполнить установку типа представления в контекст навигации.
    /// </summary>
    /// <param name="viewType">Тип представления.</param>
    /// <param name="container">Модель представления.</param>
    /// <returns><see langword="true"/> - если установка выполнена успешно.</returns>
    bool TryExecute(Type viewType, IViewModelContainer container, IFrameOptions options);
}