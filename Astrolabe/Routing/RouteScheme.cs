using System;
using Astrolabe.Routing.Abstraction;

namespace Astrolabe.Routing
{
    /// <summary>
    /// Предоставляет схему маршурта.
    /// </summary>
    public class RouteScheme : IRouteScheme
    {
        #region Public Properties

        /// <summary>
        /// Предоставляет тип модели представления.
        /// </summary>
        public Type ViewModelType { get; }

        /// <summary>
        /// Предоставляет тип представления.
        /// </summary>
        public Type ViewType { get; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр <see cref="RouteScheme"/>.
        /// </summary>
        /// <param name="viewModelType">Тип модели представления.</param>
        /// <param name="viewType">Тип представления.</param>
        public RouteScheme(Type viewModelType, Type viewType)
        {
            ViewModelType = viewModelType ?? throw new NullReferenceException(nameof(viewModelType));
            ViewType = viewType ?? throw new ArgumentNullException(nameof(viewType));
        }

        #endregion Public Constructors
    }
}