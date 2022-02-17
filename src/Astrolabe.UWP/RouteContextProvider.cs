﻿using System;
using System.Linq;
using Windows.UI.Xaml;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.UWP.Controls;
using Astrolabe.UWP.Extensions;

namespace Astrolabe.UWP;

public class RouteContextProvider : IRouteContextProvider
{
    private readonly IRouteContextResolver _resolver;

    public RouteContextProvider(IRouteContextResolver resolver)
    {
        _resolver = resolver;
    }

    public IRouteContext GetContext(IContextInfo info)
    {
        AstrolabeFrame rootFrame = Window.Current.Content as AstrolabeFrame;
        if (rootFrame is null)
        {
            rootFrame = new AstrolabeFrame();
            Window.Current.Content = rootFrame;
        }

        INavigationFrame frame = rootFrame.FindChildren<AstrolabeFrame>()
            .FirstOrDefault(c => c.ContextKey == info.RequiredContextKey);

        if (frame is null)
        {
            if (info.IsRequiredSpecifiedContext)
            {
                //TODO: заменить на кастомную ошибку
                throw new ArgumentNullException(nameof(frame));
            }

            return _resolver.Resolve(rootFrame, info.FrameOptions);
        }

        return _resolver.Resolve(frame, info.FrameOptions);
    }
}