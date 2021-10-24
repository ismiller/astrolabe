using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Astrolabe.Pages;
using Astrolabe.Pages.Abstractions;
using Astrolabe.Routing;
using Astrolabe.Routing.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe
{
    public class AstrolabeNavigateBuilder
    {
        public static AstrolabeNavigateBuilder GetBuilder()
        {
            return new AstrolabeNavigateBuilder();
        }

        private AstrolabeNavigateBuilder()
        {
            _schemeDictionary = new RouteSchemeDictionary();
        }

        private IServiceCollection _serviceCollection;
        private readonly IRouteSchemeDictionary _schemeDictionary;
        private INavigateContext _navigateContext;

        public AstrolabeNavigateBuilder SetServiceCollection(IServiceCollection collection)
        {
            _serviceCollection = collection ?? throw new ArgumentNullException(nameof(collection));
            return this;
        }

        public AstrolabeNavigateBuilder RegisterRoutes(Action<IRouteSchemeDictionary> setAction)
        {
            setAction?.Invoke(_schemeDictionary);
            return this;
        }

        public AstrolabeNavigateBuilder SetNavigateContext(Frame frame)
        {
            _navigateContext = new NavigateContext(frame, new FrameNavigationOptions());
            return this;
        }

        public IAstrolabe Build()
        {
            if (_navigateContext is null)
            {
                throw new ArgumentNullException(nameof(_navigateContext));
            }

            AstrolabeNavigator astrolabe = new AstrolabeNavigator(_navigateContext);
            _serviceCollection.AddSingleton<IAstrolabe>(s => astrolabe);
            IServiceProvider provider = _serviceCollection.BuildServiceProvider();
            IRouter router = new Router(_schemeDictionary, provider);
            astrolabe.SetRouter(router);
            return astrolabe;
        }
    }
}