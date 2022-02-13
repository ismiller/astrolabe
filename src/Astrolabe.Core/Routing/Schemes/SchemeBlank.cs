using System;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Helpers;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Schemes;

internal class SchemeBlank : ISchemeBlank, IBuild<IRouteScheme>
{
    private string _contextKey;
    private IFrameOptions _frameOptions;
    private bool _isExecuteOnlySpecifiedContext;
    private Type _viewType;
    private Type _viewModelType;

    public ISchemeBlank AttachContext(string contextKey)
    {
        _contextKey = Security.NotNullOrWhiteSpace(contextKey, nameof(contextKey));
        return this;
    }

    public ISchemeBlank AttachFrameOptions(IFrameOptions options)
    {
        _frameOptions = Security.NotNull(options, nameof(options));
        return this;
    }

    public ISchemeBlank ExecuteOnlySpecifiedContext()
    {
        _isExecuteOnlySpecifiedContext = true;
        return this;
    }

    public ISchemeBlank AttachNavigationStackRule()
    {
        return this;
    }

    public ISchemeBlank SetView<T>() where T : INavigationPage
    {
        _viewType = typeof(T);
        return this;
    }

    public ISchemeBlank SetViewModel<T>() where T : INavigatable
    {
        _viewModelType = typeof(T);
        return this;
    }

    public IRouteScheme Build()
    {
        IContextInfo info = new ContextInfo()
        {
            IsExecuteOnlySpecifiedContext = _isExecuteOnlySpecifiedContext,
            FrameOptions = _frameOptions,
            RequiredContextKey = _contextKey
        };

        return new RouteScheme(_viewModelType, _viewType, info);
    }
}