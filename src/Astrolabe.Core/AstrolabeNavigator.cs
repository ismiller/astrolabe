using System;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Navigating;
using Astrolabe.Core.Navigating.Abstraction;
using Astrolabe.Core.Routing.Routes;
using Astrolabe.Core.Routing.Routes.Abstractions;
using Astrolabe.Core.Utilities.Security;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core;

/// <summary>
/// Предоставляет функционал управления навигацией.
/// </summary>
internal sealed class AstrolabeNavigator : IAstrolabe
{
    #region Private Fields

    private readonly INavigationStack<INavigationExecutor> _navigationStack;
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
    /// <param name="router">Маршрутизатор.</param>
    public AstrolabeNavigator(IRouter router)
    {
        _router = Security.ProtectFrom.Null(router, nameof(router));
        _navigationStack = new NavigationStack<INavigationExecutor>();
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public void NavigateBack(INavigationArgs navigationArgs, INavigationOptions options)
    {
        if (_navigationStack.Any())
        {
            _ = _navigationStack.TryGetSuspend(out INavigationExecutor lastRouteMover);

            if (_navigationStack.TryPop(out INavigationExecutor mover))
            {
                IRoutingResult result = mover.Execute();

                if (result.IsSuccess)
                {
                    result.ApplyNavigateArgs(navigationArgs);

                    ApplyNavigateOptions(mover, options);

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
            if (_navigationStack.TryPop(out INavigationExecutor mover))
            {
                IRoutingResult result = mover.Execute();

                if (result.IsSuccess)
                {
                    result.ApplyNavigateArgs(navigationArgs);
                    Navigated?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    /// <inheritdoc />
    public void NavigateTo(Type viewModelType, INavigationArgs navigationArgs, INavigationOptions options)
    {
        var request = new RouteBuildRequest(viewModelType, navigationArgs);
        IBuildRouteResult buildRoute = _router.GetRequiredRoute(request);

        if (buildRoute.IsSuccess)
        {
            IRoutingResult routingResult = buildRoute.Mover.Execute();
            if (routingResult.IsSuccess)
            {
                routingResult.ApplyNavigateArgs(navigationArgs);
                ApplyNavigateOptions(buildRoute.Mover, options);
                Navigated?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    /// <inheritdoc />
    public void NavigateTo(Type viewModelType, INavigationArgs navigationArgs)
    {
        var request = new RouteBuildRequest(viewModelType, navigationArgs);

        IBuildRouteResult buildRoute = _router.GetRequiredRoute(request);
        if (buildRoute.IsSuccess)
        {
            IRoutingResult routingResult = buildRoute.Mover.Execute();
            if (routingResult.IsSuccess)
            {
                _navigationStack.Push(buildRoute.Mover);
                routingResult.ApplyNavigateArgs(navigationArgs);
                Navigated?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void ApplyNavigateOptions(INavigationExecutor currentNavigationExecutor, INavigationOptions options)
    {
        if (options is not null)
        {
            if (!options.IsIgnoreStack)
            {
                _navigationStack.Push(currentNavigationExecutor);
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