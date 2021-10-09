using System;
using Astrolabe.ViewModels;

namespace Astrolabe.Routing.Abstraction
{
    public interface IRouteDictionary
    {
        bool TryGetValue<TNavigatable>(out Type route) where TNavigatable : INavigatable;

        void RegisterRoute<TNavigatable, TView>()
            where TNavigatable : INavigatable
            where TView : class, new();
    }
}