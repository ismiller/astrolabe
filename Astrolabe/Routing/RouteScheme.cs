using System;
using Astrolabe.Routing.Abstraction;

namespace Astrolabe.Routing
{
    /// <summary>
    /// Предоставляет схему маршурта.
    /// </summary>
    public class RouteScheme : IRouteScheme
    {
        public Type ViewModelType { get; }

        public Type ViewType { get; }

        public RouteScheme(Type viewModelType, Type viewType)
        {
            ViewModelType = viewModelType ?? throw new NullReferenceException(nameof(viewModelType));
            ViewType = viewType ?? throw new ArgumentNullException(nameof(viewType));
        }
    }
}