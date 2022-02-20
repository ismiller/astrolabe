using System;
using System.Collections.Generic;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Extensions;
using Astrolabe.Core.Navigating;
using Astrolabe.Core.Navigating.Abstraction;
using Astrolabe.Core.Navigating.Options;
using Astrolabe.Core.Routing;
using Astrolabe.Core.Routing.Context;
using Astrolabe.Core.Routing.Context.Abstraction;
using Astrolabe.Core.Routing.Endpoints;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Utilities.Security;
using Astrolabe.Core.ViewModels;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core;

/// <summary>
/// Предоставляет функционал управления навигацией.
/// </summary>
internal sealed class AstrolabeNavigator : IAstrolabe
{
    #region Private Fields

    private readonly IEndpointManager _endpointManager;
    private readonly IContextProvider _contextProvider;

    private readonly Dictionary<string, INavigationStack<HistoryItem>> _contextHistories;

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
    public AstrolabeNavigator(IEndpointManager endpointManager, IContextProvider contextProvider)
    {
        _endpointManager = Security.ProtectFrom.Null(endpointManager, nameof(endpointManager));
        _contextProvider = Security.ProtectFrom.Null(contextProvider, nameof(contextProvider));
        _contextHistories = new Dictionary<string, INavigationStack<HistoryItem>>(3);
    }

    #endregion Public Constructors

    #region Public Methods

    /// <inheritdoc />
    public void NavigateTo(Type viewModelType, INavigationMessage message)
    {
        INavigationOptions defaultOptions = new NavigationOptions()
        {
            IsClearStack = false,
            IsResetStack = false
        };

        NavigateTo(viewModelType, message, defaultOptions);
    }

    #endregion Public Methods

    #region Private Methods

    /// <inheritdoc />
    public void NavigateTo(Type viewModelType, INavigationMessage message, INavigationOptions options)
    {
        IEndpointRequest endpointRequest = new EndpointRequest(viewModelType);
        IEndpoint requiredEndpoint = _endpointManager.GetEndpoint(endpointRequest);

        IContextRequest contextRequest = BuildContextRequest(requiredEndpoint.Options);
        IRouteContext context = _contextProvider.GetContext(contextRequest);

        object viewModel = ServiceLocator.GetRequiredService(viewModelType);

        if (viewModel is INavigatable navigatable)
        {
            IEndpointExecuteRequest executeRequest = BuildEndpointExecuteRequest(requiredEndpoint, navigatable);
            bool isSuccessMove = context.MoveToEndpoint(executeRequest);

            if (isSuccessMove)
            {
                INavigationStack<HistoryItem> stack = GetHistoryStack(requiredEndpoint);

                Action<INavigationMessage, INavigationOptions> callBack =
                    BuildReverseBackNavigateAction(requiredEndpoint.Options.RequiredContextKey, viewModelType);

                HistoryItem item = new()
                {
                    Endpoint = requiredEndpoint,
                    NavigationCallback = callBack
                };

                stack.Push(item);
                stack.ApplyNavigationStackOptions(options);

                INavigationArgs args;
                if (stack.Any())
                {
                    args = new NavigationArgs(message, callBack);
                }
                else
                {
                    args = new NavigationArgs(message);
                }

                navigatable.Prepare(args);
                Navigated?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private Action<INavigationMessage, INavigationOptions> BuildReverseBackNavigateAction(string contextKey, Type viewModelType)
    {
        return (message, options) =>
        {
            _contextHistories.TryGetValue(contextKey, out INavigationStack<HistoryItem> stack);
            if (stack.Any())
            {
                _ = stack.TryGetSuspend(out HistoryItem _);

                if (stack.TryPop(out HistoryItem item))
                {
                    IContextRequest contextRequest = BuildContextRequest(item.Endpoint.Options);
                    IRouteContext context = _contextProvider.GetContext(contextRequest);

                    object viewModel = ServiceLocator.GetRequiredService(viewModelType);

                    if (viewModel is INavigatable navigatable)
                    {
                        IEndpointExecuteRequest executeRequest = BuildEndpointExecuteRequest(item.Endpoint, navigatable);
                        bool isSuccessMove = context.MoveToEndpoint(executeRequest);

                        if (isSuccessMove)
                        {
                            stack.ApplyNavigationStackOptions(options);

                            INavigationArgs args;
                            if (stack.Any())
                            {
                                args = new NavigationArgs(message, item.NavigationCallback);
                            }
                            else
                            {
                                args = new NavigationArgs(message);
                            }

                            navigatable.Prepare(args);
                            Navigated?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
            }
        };
    }

    private IContextRequest BuildContextRequest(IEndpointOptions options)
    {
        return new ContextRequest
        {
            ContextKey = options.RequiredContextKey,
            IsRequiredSpecifiedContext = options.IsRequiredSpecifiedContext,
            IsRequiredRootContext = options.IsRequiredRootContext
        };
    }

    private IEndpointExecuteRequest BuildEndpointExecuteRequest(IEndpoint endpoint, INavigatable viewModelInstance)
    {
        return new EndpointExecutorRequest
        {
            DestinationEndpoint = endpoint,
            Options = endpoint.Options.FrameOptions,
            ViewModelContainer = new ViewModelContainer(viewModelInstance)
        };
    }

    private INavigationStack<HistoryItem> GetHistoryStack(IEndpoint endpoint)
    {
        _contextHistories.TryGetValue(endpoint.Options.RequiredContextKey, out INavigationStack<HistoryItem> stack);
        if (stack is null)
        {
            stack = AddContextInHistory(endpoint);
        }

        return stack;
    }

    private INavigationStack<HistoryItem> AddContextInHistory(IEndpoint endpoint)
    {
        INavigationStack<HistoryItem> stack = new NavigationStack<HistoryItem>();
        _contextHistories.Add(endpoint.Options.RequiredContextKey, stack);
        return stack;
    }

    #endregion Private Methods
}