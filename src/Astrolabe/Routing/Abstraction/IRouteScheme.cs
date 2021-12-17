using System;

namespace Astrolabe.Routing.Abstraction
{
    /// <summary>
    /// Предоставляет схему маршрута.
    /// </summary>
    public interface IRouteScheme
    {
        /// <summary>
        /// Предоставляет тип модели представления.
        /// </summary>
        Type ViewModelType { get; }

        /// <summary>
        /// Предоставляет тип представления.
        /// </summary>
        Type ViewType { get; }
    }
}