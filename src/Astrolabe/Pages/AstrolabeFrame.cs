using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Astrolabe.Pages
{
    public class AstrolabeFrame : Frame
    {
        public static DependencyProperty NavigationKeyProperty
            = DependencyProperty.Register(
                name: nameof(NavigationKey),
                propertyType: typeof(string),
                ownerType: typeof(AstrolabeFrame),
                typeMetadata: new PropertyMetadata(string.Empty));

        public string NavigationKey
        {
            get => (string)GetValue(NavigationKeyProperty);
            set => SetValue(NavigationKeyProperty, value);
        }
    }
}