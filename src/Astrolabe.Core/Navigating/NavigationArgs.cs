using System;
using Astrolabe.Core.Navigating.Abstraction;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Navigating;

internal class NavigationArgs : INavigationArgs
{
    public INavigationMessage Message { get; }

    public bool IsReverseNavigationAvailable { get; }

    private readonly Action<INavigationMessage, INavigationOptions> _moveBack;

    public NavigationArgs(INavigationMessage message, Action<INavigationMessage, INavigationOptions> moveBack)
    {
        Message = Security.ProtectFrom.Null(message, nameof(message));
        _moveBack = Security.ProtectFrom.Null(moveBack, nameof(moveBack));
        IsReverseNavigationAvailable = true;
    }

    public NavigationArgs(INavigationMessage message)
    {
        Message = Security.ProtectFrom.Null(message, nameof(message));
        IsReverseNavigationAvailable = false;
    }

    public void NavigateToBack()
    {
        _moveBack?.Invoke(default, default);
    }

    public void NavigateToBack(INavigationMessage message)
    {
        _moveBack?.Invoke(message, default);
    }

    public void NavigateToBack(INavigationMessage message, INavigationOptions options)
    {
        _moveBack?.Invoke(message, options);
    }
}