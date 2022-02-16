using Astrolabe.Core.Routing.Schemes.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core
{
    public interface IConfigurable
    {
        void ConfigureScheme(ISchemeBuilder schemeBuilder);

        void ConfigureServices(IServiceCollection services);
    }
}
