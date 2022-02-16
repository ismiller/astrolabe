using System.Collections.Generic;
using System.Linq;
using Astrolabe.AppSDK.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace Astrolabe.AppSDK.Extensions
{
    internal static class VisualTreeExtensions
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

            for (int childrenIndex = 0; childrenIndex < childrenCount; childrenIndex++)
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
            return frames.FirstOrDefault(frame => frame.ContextKey == key);
        }
    }
}