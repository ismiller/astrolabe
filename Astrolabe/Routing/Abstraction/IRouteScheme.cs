using System;

namespace Astrolabe.Routing.Abstraction
{
    public interface IRouteScheme
    {
        Type ViewModelType { get; }

        Type ViewType { get; }
    }
}