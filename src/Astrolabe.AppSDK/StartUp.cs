using System.Linq;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.AppSDK;

internal class StartUp : IStartUp
{
    private readonly IRouteSchemeDictionary<IRouteScheme> _schemes;
    private readonly IAstrolabe _navigator;

    public StartUp(IRouteSchemeDictionary<IRouteScheme> schemes, IAstrolabe navigator)
    {
        _schemes = schemes;
        _navigator = navigator;
    }

    public void Run()
    {
        IRouteScheme scheme = _schemes.FirstOrDefault(s => s.IsRoot);
        if (scheme is null)
        {
            ///TODO:бросаем исклбючение
        }

        _navigator.NavigateTo(scheme.ViewModelType, default);
    }

    public void Run<T>() where T : INavigatable
    {
        _navigator.NavigateTo(typeof(T), default);
    }
}