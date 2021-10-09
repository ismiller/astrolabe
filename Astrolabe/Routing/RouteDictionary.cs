using System;
using System.Collections.Generic;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels;

namespace Astrolabe.Routing
{
    public class RouteDictionary : IRouteDictionary
    {
        #region Private Fields

        private Dictionary<Type, Type> _routes;

        #endregion Private Fields

        #region Public Methods

        public RouteDictionary()
        {
            _routes = new Dictionary<Type, Type>();
        }

        public void RegisterRoute<TNavigatable, TView>()
            where TNavigatable : INavigatable
            where TView : class, new()
        {
            Type key = typeof(TNavigatable);
            Type value = typeof(TView);
            _routes.Add(key, value);
        }

        public bool TryGetValue<TNavigatable>(out Type route) where TNavigatable : INavigatable
        {
            route = default;
            if (_routes.TryGetValue(typeof(TNavigatable), out Type view))
            {
                route = view;
                return true;
            }

            return false;
        }

        #endregion Public Methods
    }
}