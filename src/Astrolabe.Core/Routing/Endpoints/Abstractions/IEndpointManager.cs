namespace Astrolabe.Core.Routing.Endpoints.Abstractions
{
    internal interface IEndpointManager
    {
        IEndpoint GetEndpoint(IEndpointRequest request);
    }
}