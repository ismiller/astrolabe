using System;
using Microsoft.Extensions.DependencyInjection;

namespace Astrolabe.Core
{
    internal class ServiceLocator
    {
        private IServiceProvider _provider;
        private static ServiceLocator _instance;

        public static void Activate(IServiceCollection collection)
        {
            IServiceProvider provider = collection.BuildServiceProvider();
            _instance = new ServiceLocator(provider);
        }

        private ServiceLocator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public static object GetRequiredService(Type serviceType)
        {
            return _instance._provider.GetRequiredService(serviceType);
        }
    }
}