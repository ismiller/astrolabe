using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.UWP.Controls;

namespace Astrolabe.UWP;

public class RouteExecutionContextProvider : IRouteExecutionContextProvider
{
    public IRouteExecutionContext GetCurrentContext(string contextKey)
    {
        AstrolabeFrame rootFrame = Window.Current.Content as AstrolabeFrame;
        if (rootFrame is null)
        {
            rootFrame = new AstrolabeFrame();
            Window.Current.Content = rootFrame;
        }

        return new RouteExe
    }
}