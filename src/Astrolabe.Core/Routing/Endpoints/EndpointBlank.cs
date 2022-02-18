using System;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Endpoints;

internal class EndpointBlank : IEndpointBlank, IBuild<IEndpoint>
{
    private readonly string _requiredContextKey;
    private IFrameOptions _frameOptions;
    private bool _isRequiredSpecifiedContext;
    private Type _viewType;
    private Type _viewModelType;
    private bool _isStartedScheme;
    private readonly bool _isExecuteInRoot;

    public EndpointBlank(string contextKey)
    {
        _requiredContextKey = Security.ProtectFrom.NullOrWhiteSpace(contextKey, nameof(contextKey));
        _isExecuteInRoot = false;
    }

    public EndpointBlank(bool isExecuteInRoot)
    {
        _requiredContextKey = string.Empty;
        _isExecuteInRoot = isExecuteInRoot;
    }

    public IEndpointBlank SetFrameOptions(IFrameOptions options)
    {
        _frameOptions = Security.ProtectFrom.Null(options, nameof(options));
        return this;
    }

    public IEndpointBlank ExecuteOnlySpecifiedContext()
    {
        _isRequiredSpecifiedContext = true;
        return this;
    }

    public IEndpointBlank AttachNavigationStackRule()
    {
        return this;
    }

    public IEndpointBlank SetView(Type viewType)
    {
        //TODO: добавить проверку на тип
        _viewType = Security.ProtectFrom.Null(viewType, nameof(viewType));
        return this;
    }

    public IEndpointBlank SetViewModel(Type viewModelType)
    {
        //TODO: добавить проверку на тип
        _viewModelType = Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
        return this;
    }

    public IEndpointBlank IsRoot()
    {
        _isStartedScheme = true;
        return this;
    }

    public IEndpoint Build()
    {
        IEndpointOptions options = new EndpointOptions()
        {
            IsRequiredSpecifiedContext = _isRequiredSpecifiedContext,
            FrameOptions = _frameOptions,
            RequiredContextKey = _requiredContextKey,
            IsRequiredRootFrame = _isExecuteInRoot,
            IsRootEndpoint = _isStartedScheme
        };

        return new Endpoint(_viewModelType, _viewType, options);
    }
}