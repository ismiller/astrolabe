using System;
using Astrolabe.Exceptions.Verifications;
using Astrolabe.Routing.Abstraction;

namespace Astrolabe.Routing.Schemes
{
    /// <inheritdoc />
    internal sealed class RouteScheme : IRouteScheme
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
            ViewModelType = Security.NotNull(viewModelType, nameof(viewModelType));
            ViewType = Security.NotNull(viewType, nameof(viewType));
        }

        #endregion Public Constructors
    }
}