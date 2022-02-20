using System;
using System.Linq;
using Astrolabe.AppSDK.Controls;
using Astrolabe.AppSDK.Extensions;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Exceptions;
using Astrolabe.Core.Routing.Context.Abstraction;

namespace Astrolabe.AppSDK;

public class AppSdkContextProvider : IContextProvider
{
    private readonly IRouteContextResolver _resolver;

    public AppSdkContextProvider(IRouteContextResolver resolver)
    {
        _resolver = resolver;
    }

    public IRouteContext GetContext(IContextRequest request)
    {
        AstrolabeFrame rootFrame = GetRootFrame();

        INavigationFrame frame = rootFrame.FindChildren<AstrolabeFrame>()
            .FirstOrDefault(c => c.ContextKey == request.ContextKey);

        if (frame is null)
        {
            bool isNotFound = request.IsRequiredRootContext == false && request.IsRequiredSpecifiedContext;

            if (isNotFound)
            {
                string exceptionMessage = "The requested context was not found. " +
                                          "Check if the context key is correct or modify the query.";
                throw new SpecifiedContextNotFoundException(request.ContextKey, exceptionMessage);
            }

            return _resolver.Resolve(rootFrame);
        }

        return _resolver.Resolve(frame);
    }

    private AstrolabeFrame GetRootFrame()
    {
        var rootFrame = AppSdkWindow.Current.Content as AstrolabeFrame;

        if (rootFrame is null)
        {
            rootFrame = new AstrolabeFrame();
            AppSdkWindow.Current.Content = rootFrame;
        }

        return rootFrame;
    }
}