using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.UWP.Controls
{
    public class AstrolabeFrame : Frame, INavigationFrame
    {
        public static DependencyProperty NavigationKeyProperty
            = DependencyProperty.Register(
                name: nameof(NavigationKey),
                propertyType: typeof(string),
                ownerType: typeof(AstrolabeFrame),
                typeMetadata: new PropertyMetadata(string.Empty));

        public bool NavigateToType(Type viewType, IViewModelContainer container, object options)
        {
            return NavigateToType(viewType, container, options);
        }

        public string NavigationKey
        {
            get => (string)GetValue(NavigationKeyProperty);
            set => SetValue(NavigationKeyProperty, value);
        }
    }
}