using System;
using Astrolabe.Navigating.Abstraction;
using Astrolabe.Pages.Abstractions;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels;

namespace Astrolabe.Navigating
{
    public class Navigator : INavigationService
    {
        public event EventHandler Navigated;

        private readonly INavigationStack<IRoute> _navigationStack;

        private readonly INavigateContext _context;

        private readonly IRouter _router;

        public Navigator(IRouter router, INavigateContext context)
        {
            _router = router ?? throw new ArgumentNullException(nameof(router));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _navigationStack = new NavigationStack<IRoute>();
        }

        public void NavigateBack(INavigationArgs navigationArgs, INavigationOptions options)
        {
            if (_navigationStack.Any())
            {
                _ = _navigationStack.TryGetSuspend(out IRoute lastRoute);

                if (_navigationStack.TryPop(out IRoute route))
                {
                    IRoutingResult result = route.TryExecute(_context);

                    if (result.IsSuccess)
                    {
                        lastRoute?.Reset();
                        result.ApplyNavigateArgs(navigationArgs);

                        ApplyNavigateOptions(route, options);

                        Navigated?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void NavigateBack(INavigationArgs navigationArgs)
        {
            if (_navigationStack.Any())
            {
                _ = _navigationStack.TryGetSuspend(out IRoute lastRoute);

                if (_navigationStack.TryPop(out IRoute route))
                {
                    IRoutingResult result = route.TryExecute(_context);

                    if (result.IsSuccess)
                    {
                        lastRoute?.Reset();
                        result.ApplyNavigateArgs(navigationArgs);
                        Navigated?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void NavigateTo<TViewModel>(INavigationArgs navigationArgs, INavigationOptions options) where TViewModel : INavigatable
        {
            IBuildRouteResult buildRoute = _router.GetRequiredRoute<TViewModel>();
            if (buildRoute.IsSuccess)
            {
                _ = _navigationStack.TryGetSuspend(out IRoute lastRoute);
                IRoutingResult routingResult = buildRoute.Route.TryExecute(_context);
                if (routingResult.IsSuccess)
                {
                    lastRoute.Reset();
                    routingResult.ApplyNavigateArgs(navigationArgs);
                    ApplyNavigateOptions(buildRoute.Route, options);
                    Navigated?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public void NavigateTo<TViewModel>(INavigationArgs navigationArgs) where TViewModel : INavigatable
        {
            IBuildRouteResult buildRoute = _router.GetRequiredRoute<TViewModel>();
            if (buildRoute.IsSuccess)
            {
                _ = _navigationStack.TryGetSuspend(out IRoute lastRoute);
                IRoutingResult routingResult = buildRoute.Route.TryExecute(_context);
                if (routingResult.IsSuccess)
                {
                    _navigationStack.Push(buildRoute.Route);
                    lastRoute.Reset();
                    routingResult.ApplyNavigateArgs(navigationArgs);
                    Navigated?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void ApplyNavigateOptions(IRoute currentRoute, INavigationOptions options)
        {
            if (options is not null)
            {
                if (!options.IsIgnoreStack)
                {
                    _navigationStack.Push(currentRoute);
                }

                if (options.IsResetStack)
                {
                    _navigationStack.Reset();
                }

                if (options.IsClearStack)
                {
                    _navigationStack.Clear();
                }
            }
        }
    }
}