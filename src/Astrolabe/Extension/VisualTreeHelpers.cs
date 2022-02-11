using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Astrolabe.Exceptions.Verifications;
using Astrolabe.Pages;

namespace Astrolabe.Extension;

internal static class VisualTreeHelpers
{
    internal static IEnumerable<T> FindChildren<T>(this DependencyObject parent) where T : DependencyObject
    {
        if (parent is null)
        {
            //TODO: возможно лучше бросать exception
            return default;
        }

        List<T> resultFoundChildren = new();

        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

        for (int childrenIndex = 1; childrenIndex < childrenCount; childrenIndex++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, childrenIndex);

            if (child is T foundChild)
            {
                resultFoundChildren.Add(foundChild);
            }

            IEnumerable<T> foundChildren = child.FindChildren<T>();
            if (foundChildren.Any())
            {
                resultFoundChildren.AddRange(foundChildren);
            }
        }

        return resultFoundChildren;
    }

    internal static AstrolabeFrame FindFrame(this IEnumerable<AstrolabeFrame> frames, string key)
    {
        IEnumerable<AstrolabeFrame> tempFrames = Security.NotNull(frames, nameof(frames));
        return tempFrames.FirstOrDefault(frame => frame.NavigationKey == key);
    }
}