using System;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Endpoints;

public class EndpointRequest : IEndpointRequest
{
    public Type RequiredViewModelType { get; }

    public EndpointRequest(Type viewModelType)
    {
        RequiredViewModelType = Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
    }
}