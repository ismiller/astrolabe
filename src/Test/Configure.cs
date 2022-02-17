using Astrolabe.AppSDK.Navigating;
using Astrolabe.Core;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Media.Animation;

namespace Test
{
    public class Configure : IConfigurable
    {
        public void ConfigureSchemes(IEndpointBuilder endpointBuilder)
        {
            endpointBuilder.AttachSchemeToRoot()
                .SetView(typeof(TestPage))
                .SetViewModel(typeof(TestPageViewModel))
                .IsRoot()
                .SetFrameOptions(
                    new FrameOptions(
                        new CommonNavigationTransitionInfo()));

            endpointBuilder.AttachSchemeToContext("inner_frame")
                .SetView(typeof(InnerPage))
                .SetViewModel(typeof(InnerPageViewModel))
                .ExecuteOnlySpecifiedContext()
                .SetFrameOptions(
                    new FrameOptions(
                        new CommonNavigationTransitionInfo()));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TestPageViewModel>();
            services.AddTransient<InnerPageViewModel>();
        }
    }
}