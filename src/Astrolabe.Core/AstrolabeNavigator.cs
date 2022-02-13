using System;
using Astrolabe.Core.Helpers;
using Astrolabe.Core.Navigating;
using Astrolabe.Core.Navigating.Abstraction;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.Routing.Abstraction;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core;

/// <summary>
/// Предоставляет функционал управления навигацией.
/// </summary>
internal sealed class AstrolabeNavigator : IAstrolabe
{
    #region Private Fields

    private readonly IRouteExecutionContext _context;
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
    public AstrolabeNavigator(IRouteExecutionContext context, IRouter router)
    {
        _context = Security.NotNull(context, nameof(context));
        _router = Security.NotNull(router, nameof(router));
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