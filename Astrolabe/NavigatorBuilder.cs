using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Astrolabe.Pages;
using Astrolabe.Pages.Abstractions;
using Astrolabe.Routing;
using Astrolabe.Routing.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe
{
    /// <summary>
    /// Предоставляет функционал для сборки сервиса навигации.
    /// </summary>
    public class NavigatorBuilder : INavigatorBuilder
    {
        #region Private Fields

        private readonly IRouteSchemeDictionary _schemeDictionary;
        private INavigateContext _navigateContext;
        private IServiceCollection _serviceCollection;

        #endregion Private Fields

        #region Private Constructors

        private NavigatorBuilder()
        {
            _schemeDictionary = new RouteSchemeDictionary();
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Предоставляет экземпляр билдера сервиса навигации.
        /// </summary>
        public static INavigatorBuilder GetBuilder() => new NavigatorBuilder();

        /// <inheritdoc />
        public IAstrolabe Build()
        {
            if (_navigateContext is null)
            {
                throw new ArgumentNullException(nameof(_navigateContext));
            }

            IRouter router = new Router(_schemeDictionary, _serviceCollection);
            AstrolabeNavigator astrolabe = new AstrolabeNavigator(_navigateContext, router);
            _serviceCollection.AddSingleton<IAstrolabe>(s => astrolabe);
            router.Activate();
            return astrolabe;
        }

        /// <inheritdoc />
        public INavigatorBuilder RegisterRoutes(Action<IRouteSchemeDictionary> setAction)
        {
            setAction?.Invoke(_schemeDictionary);
            return this;
        }

        /// <inheritdoc />
        public INavigatorBuilder SetNavigateContext(Frame frame)
        {
            if (frame is null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            var transitionInfo = new SuppressNavigationTransitionInfo();
            var options = new FrameNavigationOptions()
            {
                IsNavigationStackEnabled = true,
                TransitionInfoOverride = transitionInfo
            };

            return SetNavigateContext(frame, options);
        }

        /// <inheritdoc />
        public INavigatorBuilder SetNavigateContext(Frame frame, FrameNavigationOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _navigateContext = new NavigateContext(frame, options);

            return this;
        }

        /// <inheritdoc />
        public INavigatorBuilder SetServiceCollection(IServiceCollection collection)
        {
            _serviceCollection = collection ?? throw new ArgumentNullException(nameof(collection));
            return this;
        }

        #endregion Public Methods
    }
}