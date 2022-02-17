using Astrolabe.Core.Abstractions;

namespace Astrolabe.AppSDK.Extensions;

public static class NavigationBuilderExtension
{
    public static INavigatorBuilder UseAppSdkPlatform(this INavigatorBuilder builder)
    {
        return builder.TargetContextProvider<AppSdkContextProvider>()
            .UseAppSdkStrtup();
    }
}