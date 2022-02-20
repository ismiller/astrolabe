using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Endpoints.Abstractions;

public interface IEndpointExecuteRequest
{
    IEndpoint DestinationEndpoint { get; }

    IViewModelContainer ViewModelContainer { get; }

    IFrameOptions Options { get; }
}