using System;
using Astrolabe.Core.Components.Abstractions;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;

namespace Astrolabe.AppSDK.Navigating
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