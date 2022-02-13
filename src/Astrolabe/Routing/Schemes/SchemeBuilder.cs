using System;
using Astrolabe.Pages;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels.Abstractions;

namespace Astrolabe.Routing.Schemes
{
    public class SchemeBuilder : ISchemeBuilder
    {
        public ISchemeBlank AddScheme<TNavigatable, TView>() where TNavigatable : INavigatable where TView : AstrolabePage, new()
        {
            throw new NotImplementedException();
        }
    }
}