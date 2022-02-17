using Astrolabe.Core.Abstractions;

namespace Astrolabe.AppSDK.Extensions;

public static class StartupExtension
{
    public static void Run(this IStartUp startup)
    {
        if (startup is StartUp concreteStartup)
        {
            concreteStartup.Run();
        }
    }

    public static void Run<T>(this IStartUp startup)
    {
        if (startup is StartUp concreteStartup)
        {
            concreteStartup.Run<T>();
        }
    }

    public static INavigatorBuilder UseAppSdkStrtup(this INavigatorBuilder builder)
    {
        return builder.UseStartUp<StartUp>();
    }
}