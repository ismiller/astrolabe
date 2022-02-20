using System;

namespace Astrolabe.Core.Routing.Endpoints.Abstractions;

internal interface IEndpointRequest
{
    Type RequiredViewModelType { get; }
}