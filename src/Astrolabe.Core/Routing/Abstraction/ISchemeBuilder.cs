using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Abstraction;

public interface ISchemeBuilder
{
    ISchemeBlank AddScheme<TNavigatable, TView>()
        where TNavigatable : INavigatable
        where TView : INavigationFrame, new();
}