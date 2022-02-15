using System;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Astrolabe.Core.Utilities.Security;
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
        _contextKey = Security.ProtectFrom.NullOrWhiteSpace(contextKey, nameof(contextKey));
        return this;
    }

    public ISchemeBlank AttachFrameOptions(IFrameOptions options)
    {
        _frameOptions = Security.ProtectFrom.Null(options, nameof(options));
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

    public ISchemeBlank SetView<T>()
    {
        //TODO: добавить проверку на тип
        _viewType = typeof(T);
        return this;
    }

    public ISchemeBlank SetViewModel<T>()
    {
        //TODO: добавить проверку на тип
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