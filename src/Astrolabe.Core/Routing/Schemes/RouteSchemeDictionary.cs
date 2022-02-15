using System;
using System.Collections.Generic;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Schemes;

/// <summary>
/// Предоставляет функционал словаря маршрутов.
/// </summary>
internal sealed class RouteSchemeDictionary : IRouteSchemeDictionary
{
    #region Private Fields

    private readonly Dictionary<string, IRouteScheme> _schemes;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Создает экземпляр <see cref="RouteSchemeDictionary"/>.
    /// </summary>
    public RouteSchemeDictionary()
    {
        _schemes = new Dictionary<string, IRouteScheme>();
    }

    /// <inheritdoc />
    public void RegisterScheme<TNavigatable, TView>(IContextInfo info)
        where TNavigatable : INavigatable
        where TView : INavigationFrame, new()
    {
        Type viewModelType = typeof(TNavigatable);
        string key = viewModelType.FullName;
        Type viewType = typeof(TView);

        IRouteScheme scheme = new RouteScheme(viewModelType, viewType, info);

        _schemes.Add(key, scheme);
    }

    public void RegisterScheme(IRouteScheme scheme)
    {
        string key = scheme.ViewModelType.FullName;
        _schemes.Add(key, scheme);
    }

    /// <inheritdoc />
    public bool TryGetScheme<TNavigatable>(out IRouteScheme scheme) where TNavigatable : INavigatable
    {
        scheme = default;
        Type viewModelType = typeof(TNavigatable);
        string key = viewModelType.FullName;
        if (_schemes.TryGetValue(key, out IRouteScheme concreteScheme))
        {
            scheme = concreteScheme;
            return true;
        }

        return false;
    }

    #endregion Public Methods
}