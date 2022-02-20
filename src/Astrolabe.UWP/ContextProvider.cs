using System;
using System.Linq;
using Windows.UI.Xaml;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.UWP.Controls;
using Astrolabe.UWP.Extensions;

namespace Astrolabe.UWP;

public class ContextProvider : IContextProvider
{
    private readonly IRouteContextResolver _resolver;

    public ContextProvider(IRouteContextResolver resolver)
    {
        _resolver = resolver;
    }

    public IRouteContext GetContext(IContextRequest request)
    {
        AstrolabeFrame rootFrame = Window.Current.Content as AstrolabeFrame;
        if (rootFrame is null)
        {
            rootFrame = new AstrolabeFrame();
            Window.Current.Content = rootFrame;
        }

        INavigationFrame frame = rootFrame.FindChildren<AstrolabeFrame>()
            .FirstOrDefault(c => c.ContextKey == request.ContextKey);

        if (frame is null)
        {
            if (request.IsRequiredSpecifiedContext)
            {
                //TODO: заменить на кастомную ошибку
                throw new ArgumentNullException(nameof(frame));
            }

            return _resolver.Resolve(rootFrame);
        }

        return _resolver.Resolve(frame);
    }

    public IRouteContext GetRootContext()
    {
        throw new NotImplementedException();
    }
}