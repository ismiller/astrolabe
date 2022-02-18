using System;
using System.Collections;
using System.Collections.Generic;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Endpoints;

/// <summary>
/// Предоставляет функционал словаря маршрутов.
/// </summary>
internal sealed class EndpointsDictionary : IEndpointsDictionary
{
    #region Private Fields

    private readonly Dictionary<string, IEndpoint> _endpoints;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Создает экземпляр <see cref="EndpointsDictionary"/>.
    /// </summary>
    public EndpointsDictionary()
    {
        _endpoints = new Dictionary<string, IEndpoint>();
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public IEnumerator<IEndpoint> GetEnumerator()
    {
        return _endpoints.Values.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _endpoints.Values.GetEnumerator();
    }

    public void RegisterEndpoint(IEndpoint endpoint)
    {
        string key = endpoint.ViewModelType.FullName;
        _endpoints.Add(key, endpoint);
    }

    /// <inheritdoc />
    public bool TryGetEndpoint(Type viewModelType, out IEndpoint endpoint)
    {
        endpoint = default;
        Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
        string key = viewModelType.FullName;
        if (_endpoints.TryGetValue(key, out IEndpoint concreteScheme))
        {
            endpoint = concreteScheme;
            return true;
        }

        return false;
    }

    #endregion Public Methods
}