using System;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Navigating;
using Astrolabe.Core.Navigating.Abstraction;
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

    private readonly INavigationStack<IRouteMover> _navigationStack;
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
        _navigationStack = new NavigationStack<IRouteMover>();
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public void NavigateBack(INavigationArgs navigationArgs, INavigationOptions options)
    {
        if (_navigationStack.Any())
        {
            _ = _navigationStack.TryGetSuspend(out IRouteMover lastRouteMover);

            if (_navigationStack.TryPop(out IRouteMover mover))
            {
                IRoutingResult result = mover.Move();

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
            if (_navigationStack.TryPop(out IRouteMover mover))
            {
                IRoutingResult result = mover.Move();

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
        IBuildRouteResult buildRoute = _router.GetRequiredRoute(viewModelType);
        if (buildRoute.IsSuccess)
        {
            IRoutingResult routingResult = buildRoute.Mover.Move();
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
        IBuildRouteResult buildRoute = _router.GetRequiredRoute(viewModelType);
        if (buildRoute.IsSuccess)
        {
            IRoutingResult routingResult = buildRoute.Mover.Move();
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

    private void ApplyNavigateOptions(IRouteMover currentRouteMover, INavigationOptions options)
    {
        if (options is not null)
        {
            if (!options.IsIgnoreStack)
            {
                _navigationStack.Push(currentRouteMover);
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