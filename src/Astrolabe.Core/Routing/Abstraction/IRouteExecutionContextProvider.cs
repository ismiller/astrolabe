namespace Astrolabe.Core.Routing.Abstraction;

public interface IRouteExecutionContextProvider
{
    IRouteExecutionContext GetCurrentContext(string contextKey);
}