using System;
using System.Collections;
using System.Collections.Generic;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Endpoints;

/// <summary>
/// Предоставляет функционал словаря маршрутов.
/// </summary>
internal sealed class EndpointsDictionary : IEndpointsDictionary<IEndpoint>
{
    #region Private Fields

    private readonly Dictionary<string, IEndpoint> _schemes;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="EndpointsDictionary"/>.
    /// </summary>
    public EndpointsDictionary()
    {
        _schemes = new Dictionary<string, IEndpoint>();
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public IEnumerator<IEndpoint> GetEnumerator()
    {
        return _schemes.Values.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _schemes.Values.GetEnumerator();
    }

    public void RegisterScheme(IEndpoint scheme)
    {
        string key = scheme.ViewModelType.FullName;
        _schemes.Add(key, scheme);
    }

    /// <inheritdoc />
    public bool TryGetScheme(Type viewModelType, out IEndpoint scheme)
    {
        scheme = default;
        Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
        string key = viewModelType.FullName;
        if (_schemes.TryGetValue(key, out IEndpoint concreteScheme))
        {
            scheme = concreteScheme;
            return true;
        }

        return false;
    }

    #endregion Public Methods
}