using Astrolabe.AppSDK.Navigating;
using Astrolabe.Core;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Media.Animation;

namespace Test
{
    public class Configure : IConfigurable
    {
        public void ConfigureScheme(ISchemeBuilder schemeBuilder)
        {
            schemeBuilder.AddScheme()
                .SetView<TestPage>()
                .SetViewModel<TestPageViewModel>()
                .AttachContext("root_frame")
                .AsRoot()
                .AttachFrameOptions(
                    new FrameOptions(
                        new CommonNavigationTransitionInfo()));

            schemeBuilder.AddScheme()
                .SetView<InnerPage>()
                .SetViewModel<InnerPageViewModel>()
                .AttachContext("inner_frame")
                .ExecuteOnlySpecifiedContext()
                .AttachFrameOptions(
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
