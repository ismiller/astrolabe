using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core
{
    public interface IConfigurable
    {
        void ConfigureSchemes(IEndpointBuilder endpointBuilder);

        void ConfigureServices(IServiceCollection services);
    }
}