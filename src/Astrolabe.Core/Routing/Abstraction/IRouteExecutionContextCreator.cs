using Astrolabe.Core.Pages.Abstractions;

namespace Astrolabe.Core.Routing.Abstraction
{
    public interface IRouteExecutionContextCreator
    {
        IRouteExecutionContext CreateRouteExecutionContext(INavigationFrame frame, IFrameOptions options);
    }
}