namespace Astrolabe.Core.Routing.Endpoints.Abstractions;

public interface IEndpointBuilder
{
    IEndpointBlank AttachSchemeToContext(string contextKey);

    IEndpointBlank AttachSchemeToRoot();
}