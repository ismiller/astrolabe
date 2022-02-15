using System;
using System.Linq;
using Windows.UI.Xaml;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.UWP.Controls;
using Astrolabe.UWP.Extensions;

namespace Astrolabe.UWP;

public class RouteExecutionContextProvider : IRouteExecutionContextProvider
{
    private IRouteExecutionContextCreator _creator;

    public RouteExecutionContextProvider(IRouteExecutionContextCreator creator)
    {
        _creator = creator;
    }

    public IRouteExecutionContext GetCurrentContext(IContextInfo info)
    {
        AstrolabeFrame rootFrame = Window.Current.Content as AstrolabeFrame;
        if (rootFrame is null)
        {
            rootFrame = new AstrolabeFrame();
            Window.Current.Content = rootFrame;
        }

        INavigationFrame frame = rootFrame.FindChildren<AstrolabeFrame>()
            .FirstOrDefault(c => c.NavigationKey == info.RequiredContextKey);

        if (frame is null)
        {
            if (info.IsExecuteOnlySpecifiedContext)
            {
                //TODO: заменить на кастомную ошибку
                throw new ArgumentNullException(nameof(frame));
            }

            return _creator.CreateRouteExecutionContext(rootFrame, info.FrameOptions);
        }

        return _creator.CreateRouteExecutionContext(frame, info.FrameOptions);
    }
}