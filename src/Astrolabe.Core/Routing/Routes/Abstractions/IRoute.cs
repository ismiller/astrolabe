using System;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Routes.Abstractions;

/// <summary>
/// Определяет функционал управления маршрутом.
/// </summary>
public interface IRoute
{
    public IViewModelContainer ViewModelContainer { get; }
    public Type ViewType { get; }
}