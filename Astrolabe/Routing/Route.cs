using System;
using Astrolabe.Pages.Abstractions;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels;

namespace Astrolabe.Routing
{
    public class Route : IRoute
    {
        #region Private Fields

        private readonly INavigatable _navigatableViewModel;

        private readonly Type _viewType;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр <see cref="Route"/>.
        /// </summary>
        /// <param name="navigatableViewModel">Навигируемый объект.</param>
        /// <param name="viewType">Тип представления.</param>
        public Route(INavigatable navigatableViewModel, Type viewType)
        {
            _viewType = viewType;
            _navigatableViewModel = navigatableViewModel;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc />
        public void Reset()
        {
            _navigatableViewModel?.Leave();
        }

        /// <inheritdoc />
        public IRoutingResult TryExecute(INavigateContext context)
        {
            bool result = context.TryAccept(_viewType, _navigatableViewModel);
            if (result)
            {
                return RoutingResult.Succeeded(_navigatableViewModel);
            }
            else
            {
                return RoutingResult.Failed();
            }
        }

        #endregion Public Methods
    }
}