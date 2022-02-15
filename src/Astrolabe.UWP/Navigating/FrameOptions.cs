using System;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Astrolabe.Core.Components.Abstractions;

namespace Astrolabe.UWP.Navigating
{
    public class FrameOptions : IFrameOptions
    {
        public FrameNavigationOptions Options { get; }

        public FrameOptions(NavigationTransitionInfo transitionInfo)
        {
            if (transitionInfo is null)
            {
                throw new ArgumentNullException(nameof(transitionInfo));
            }

            Options = new FrameNavigationOptions()
            {
                TransitionInfoOverride = transitionInfo,
                IsNavigationStackEnabled = false
            };
        }

        public FrameOptions() : this(new SuppressNavigationTransitionInfo())
        {
        }

        public static FrameOptions CreateDefault()
        {
            SuppressNavigationTransitionInfo transitionInfo = new();
            return new FrameOptions(transitionInfo);
        }
    }
}