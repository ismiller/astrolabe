using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;
using Astrolabe.UWP.Navigating;

namespace Astrolabe.UWP.Controls;

/// <inheritdoc cref="Frame"/>.
public class AstrolabeFrame : Frame, INavigationFrame
{
    /// <summary>
    /// Предоставляет свойство зависимости для ключа контекста.
    /// </summary>
    public static DependencyProperty ContextKeyProperty
        = DependencyProperty.Register(
            name: nameof(ContextKey),
            propertyType: typeof(string),
            ownerType: typeof(AstrolabeFrame),
            typeMetadata: new PropertyMetadata(string.Empty));

    /// <summary>
    /// Выполняет навигацию на указанный тип визуального представления.
    /// </summary>
    /// <param name="viewType">Тип представления.</param>
    /// <param name="container">Контейнер модели представления.</param>
    /// <param name="options">Опции представления.</param>
    /// <returns><see langword="true"/> - если навигация выполнена успешно.</returns>
    public bool ExecuteNavigation(Type viewType, IViewModelContainer container, IFrameOptions options)
    {
        if (options is FrameOptions frameOptions)
        {
            return base.NavigateToType(viewType, container, frameOptions.Options);
        }

        FrameOptions defaultOptions = FrameOptions.CreateDefault();
        return base.NavigateToType(viewType, container, defaultOptions.Options);
    }

    /// <inheritdoc />
    public string ContextKey
    {
        get => (string)GetValue(ContextKeyProperty);
        set => SetValue(ContextKeyProperty, value);
    }
}