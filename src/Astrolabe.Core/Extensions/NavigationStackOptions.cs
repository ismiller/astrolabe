using Astrolabe.Core.Navigating.Abstraction;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Extensions;

public static class NavigationStackOptions
{
    public static void ApplyNavigationStackOptions<T>(this INavigationStack<T> stack, INavigationOptions options)
    {
        Security.ProtectFrom.Null(stack, nameof(stack));
        Security.ProtectFrom.Null(options, nameof(options));

        if (options.IsClearStack)
        {
            stack.Clear();
        }

        if (options.IsResetStack)
        {
            stack.Reset();
        }
    }
}