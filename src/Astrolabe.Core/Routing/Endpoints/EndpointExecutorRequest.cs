using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Endpoints;

internal class EndpointExecutorRequest : IEndpointExecuteRequest
{
    public IEndpoint DestinationEndpoint { get; set; }
    public IViewModelContainer ViewModelContainer { get; set; }
    public IFrameOptions Options { get; set; }
}