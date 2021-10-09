using System;
using System.Collections.Generic;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Routing
{
    public class Router : IRouter
    {
        #region Private Fields

        private readonly IServiceProvider _provider;
        private readonly IRouteDictionary _routeDictionary;

        #endregion Private Fields

        #region Public Constructors

        public Router(IRouteDictionary routeDictionary, IServiceProvider provider)
        {
            _routeDictionary = routeDictionary ?? throw new ArgumentNullException(nameof(routeDictionary));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        #endregion Public Constructors

        #region Public Methods

        public IRoute GetRequiredRoute<TNavigatable>() where TNavigatable : INavigatable
        {
            if (_routeDictionary.TryGetValue<TNavigatable>(out Type viewType))
            {
                //TODO: здесь можно отловить ошибку и обернуть в более спецефичную
                TNavigatable viewModel = _provider.GetRequiredService<TNavigatable>();
                return new Route(viewModel, viewType);
            }

            //TODO: здесь можно отловить ошибку и обернуть в более спецефичную
            throw new KeyNotFoundException("Route not found");
        }

        public void RegisterRoute<TViewModel, TView>(bool isViewCashed = false)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}