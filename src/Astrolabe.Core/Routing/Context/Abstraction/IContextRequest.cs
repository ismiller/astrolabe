namespace Astrolabe.Core.Routing.Context.Abstraction;

public interface IContextRequest
{
    string ContextKey { get; }

    bool IsRequiredSpecifiedContext { get; }
}