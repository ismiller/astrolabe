using Astrolabe.Pages;
using Astrolabe.ViewModels.Abstractions;

namespace Astrolabe.Routing.Abstraction
{
    public interface ISchemeBuilder
    {
        ISchemeBlank AddScheme<TNavigatable, TView>()
            where TNavigatable : INavigatable
            where TView : AstrolabePage, new();
    }
}