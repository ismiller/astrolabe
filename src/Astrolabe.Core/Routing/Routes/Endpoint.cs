using System;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Routes;

internal class Endpoint
{
    public string ViewModelFullName { get; }

    public Type ViewModelType { get; }

    public string ViewFullName { get; }

    public Type ViewType { get; }

    public Endpoint(Type viewModelType, Type viewType)
    {
        ViewModelType = Security.ProtectFrom.Null(viewModelType, nameof(viewModelType));
        ViewType = Security.ProtectFrom.Null(viewType, nameof(viewType));
        ViewModelFullName = ViewModelType.FullName;
        ViewFullName = ViewType.FullName;
    }
}