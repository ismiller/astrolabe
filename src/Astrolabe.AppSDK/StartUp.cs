using System.Linq;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.AppSDK;

internal class StartUp : IStartUp
{
    private readonly IEndpointsDictionary<IEndpoint> _endpoints;
    private readonly IAstrolabe _navigator;

    public StartUp(IEndpointsDictionary<IEndpoint> endpoints, IAstrolabe navigator)
    {
        _endpoints = endpoints;
        _navigator = navigator;
    }

    public void Run()
    {
        IEndpoint endpoint = _endpoints.FirstOrDefault(s => s.IsRoot);
        if (endpoint is null)
        {
            ///TODO:бросаем исклбючение
        }

        _navigator.NavigateTo(endpoint.ViewModelType, default);
    }

    public void Run<T>() where T : INavigatable
    {
        _navigator.NavigateTo(typeof(T), default);
    }
}