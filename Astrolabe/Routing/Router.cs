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
        private readonly IRouteSchemeDictionary _routeSchemeDictionary;

        #endregion Private Fields

        #region Public Constructors

        public Router(IRouteSchemeDictionary routeSchemeDictionary, IServiceProvider provider)
        {
            _routeSchemeDictionary = routeSchemeDictionary ?? throw new ArgumentNullException(nameof(routeSchemeDictionary));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        #endregion Public Constructors

        #region Public Methods

        public IBuildRouteResult GetRequiredRoute<TNavigatable>() where TNavigatable : INavigatable
        {
            if (_routeSchemeDictionary.TryGetScheme<TNavigatable>(out IRouteScheme scheme))
            {
                object viewModel = _provider.GetRequiredService(scheme.ViewModelType);

                if (viewModel is TNavigatable concreteViewModel)
                {
                    IRoute route = new Route(concreteViewModel, scheme.ViewType);
                    return BuildRouteResult.Succeeded(route);
                }
            }

            return BuildRouteResult.Failed("Route not found");
        }

        #endregion Public Methods
    }
}