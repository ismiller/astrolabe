using System;
using System.Collections;
using System.Collections.Generic;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Astrolabe.Core.Utilities.Security;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Schemes;

/// <summary>
/// Предоставляет функционал словаря маршрутов.
/// </summary>
internal sealed class RouteSchemeDictionary : IRouteSchemeDictionary<IRouteScheme>
{

    #region Private Fields

    private readonly Dictionary<string, IRouteScheme> _schemes;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="RouteSchemeDictionary"/>.
    /// </summary>
    public RouteSchemeDictionary()
    {
        _schemes = new Dictionary<string, IRouteScheme>();
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public IEnumerator<IRouteScheme> GetEnumerator()
    {
        return _schemes.Values.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _schemes.Values.GetEnumerator();
    }

    public void RegisterScheme(IRouteScheme scheme)
    {
        string key = scheme.ViewModelType.FullName;
        _schemes.Add(key, scheme);
    }

    /// <inheritdoc />
    public bool TryGetScheme(Type viewModelType, out IRouteScheme scheme)
    {
        scheme = default;
        Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
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