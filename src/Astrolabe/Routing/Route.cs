using System;
using Astrolabe.Pages.Abstractions;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels;

namespace Astrolabe.Routing
{
    public class Route : IRoute
    {
        #region Private Fields

        private readonly IViewModelContainer _viewModelContainer;
        private readonly Type _viewType;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр <see cref="Route"/>.
        /// </summary>
        /// <param name="viewModel">Навигируемый объект.</param>
        /// <param name="viewType">Тип представления.</param>
        public Route(INavigatable viewModel, Type viewType)
        {
            _viewType = viewType;
            _viewModelContainer = new ViewModelContainer(viewModel);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc />
        public IRoutingResult TryExecute(INavigateContext context)
        {
            bool result = context.TryAccept(_viewType, _viewModelContainer);
            if (result)
            {
                return RoutingResult.Succeeded(_viewModelContainer.ViewModel);
            }
            else
            {
                return RoutingResult.Failed();
            }
        }

        #endregion Public Methods
    }
}