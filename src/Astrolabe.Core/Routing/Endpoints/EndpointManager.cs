using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Endpoints;

internal class EndpointManager : IEndpointManager
{
    private readonly IEndpointsDictionary _endpointsDictionary;

    public EndpointManager(IEndpointsDictionary endpoints)
    {
        _endpointsDictionary = Security.ProtectFrom.Null(endpoints, nameof(endpoints));
    }

    public IEndpoint GetEndpoint(IEndpointRequest request)
    {
        bool isSuccess = _endpointsDictionary.TryGetEndpoint(request.RequiredViewModelType, out IEndpoint endpoint);
        if (isSuccess)
        {
            return endpoint;
        }

        return default;
    }
}