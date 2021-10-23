using System;
using System.Collections.Generic;
using Astrolabe.Pages;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels;

namespace Astrolabe.Routing
{
    /// <summary>
    /// Предоставляет функционал словаря маршрутов.
    /// </summary>
    public class RouteSchemeDictionary : IRouteSchemeDictionary
    {
        #region Private Fields

        private readonly Dictionary<string, IRouteScheme> _schemes;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Создает экземпляр <see cref="RouteSchemeDictionary"/>.
        /// </summary>
        public RouteSchemeDictionary()
        {
            _schemes = new Dictionary<string, IRouteScheme>();
        }

        /// <inheritdoc />
        public void RegisterScheme<TNavigatable, TView>()
            where TNavigatable : INavigatable
            where TView : AstrolabePage, new()
        {
            Type viewModelType = typeof(TNavigatable);
            string key = viewModelType.FullName;
            Type viewType = typeof(TView);

            IRouteScheme scheme = new RouteScheme(viewModelType, viewType);

            _schemes.Add(key, scheme);
        }

        /// <inheritdoc />
        public bool TryGetScheme<TNavigatable>(out IRouteScheme scheme) where TNavigatable : INavigatable
        {
            scheme = default;
            Type viewModelType = typeof(TNavigatable);
            string key = viewModelType.FullName;
            if (_schemes.TryGetValue(key, out IRouteScheme concreteScheme))
            {
                scheme = concreteScheme;
                return true;
            }

            return false;
        }

        #endregion Public Methods
    }
}