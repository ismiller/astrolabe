using System;
using Astrolabe.Routing.Abstraction;

namespace Astrolabe.Routing
{
    /// <inheritdoc />
    public class RouteScheme : IRouteScheme
    {
        #region Public Properties

        /// <inheritdoc />
        public Type ViewModelType { get; }

        /// <inheritdoc />
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