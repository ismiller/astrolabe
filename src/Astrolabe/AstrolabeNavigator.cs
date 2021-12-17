using System;
using Astrolabe.Navigating;
using Astrolabe.Navigating.Abstraction;
using Astrolabe.Pages.Abstractions;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels;

namespace Astrolabe
{
    /// <summary>
    /// Предоставляет функционал управления навигацией.
    /// </summary>
    internal class AstrolabeNavigator : IAstrolabe
    {
        #region Private Fields

        private readonly INavigateContext _context;
        private readonly INavigationStack<IRoute> _navigationStack;
        private readonly IRouter _router;

        #endregion Private Fields

        #region Public Events

        /// <inheritdoc />
        public event EventHandler Navigated;

        #endregion Public Events

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр <see cref="AstrolabeNavigator"/>.
        /// </summary>
        /// <param name="context">Контекст навигации.</param>
        /// <param name="router">Маршрутизатор.</param>
        public AstrolabeNavigator(INavigateContext context, IRouter router)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _router = router ?? throw new ArgumentNullException(nameof(router));
            _navigationStack = new NavigationStack<IRoute>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc />
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
                        result.ApplyNavigateArgs(navigationArgs);

                        ApplyNavigateOptions(route, options);

                        Navigated?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <inheritdoc />
        public void NavigateBack(INavigationArgs navigationArgs)
        {
            if (_navigationStack.Any())
            {
                if (_navigationStack.TryPop(out IRoute route))
                {
                    IRoutingResult result = route.TryExecute(_context);

                    if (result.IsSuccess)
                    {
                        result.ApplyNavigateArgs(navigationArgs);
                        Navigated?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <inheritdoc />
        public void NavigateTo<TViewModel>(INavigationArgs navigationArgs, INavigationOptions options) where TViewModel : INavigatable
        {
            IBuildRouteResult buildRoute = _router.GetRequiredRoute<TViewModel>();
            if (buildRoute.IsSuccess)
            {
                IRoutingResult routingResult = buildRoute.Route.TryExecute(_context);
                if (routingResult.IsSuccess)
                {
                    routingResult.ApplyNavigateArgs(navigationArgs);
                    ApplyNavigateOptions(buildRoute.Route, options);
                    Navigated?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <inheritdoc />
        public void NavigateTo<TViewModel>(INavigationArgs navigationArgs) where TViewModel : INavigatable
        {
            IBuildRouteResult buildRoute = _router.GetRequiredRoute<TViewModel>();
            if (buildRoute.IsSuccess)
            {
                IRoutingResult routingResult = buildRoute.Route.TryExecute(_context);
                if (routingResult.IsSuccess)
                {
                    _navigationStack.Push(buildRoute.Route);
                    routingResult.ApplyNavigateArgs(navigationArgs);
                    Navigated?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

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

        #endregion Private Methods
    }
}