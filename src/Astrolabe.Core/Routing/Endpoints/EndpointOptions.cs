using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Endpoints.Abstractions;

namespace Astrolabe.Core.Routing.Endpoints;

public class EndpointOptions : IEndpointOptions
{
    public bool IsRootEndpoint { get; set; }
    public string RequiredContextKey { get; set; }
    public IFrameOptions FrameOptions { get; set; }
    public bool IsRequiredSpecifiedContext { get; set; }
    public bool IsRequiredRootFrame { get; set; }
}