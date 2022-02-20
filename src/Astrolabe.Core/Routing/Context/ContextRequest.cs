using Astrolabe.Core.Routing.Context.Abstraction;

namespace Astrolabe.Core.Routing.Context;

public class ContextRequest : IContextRequest
{
    public string ContextKey { get; set; }

    public bool IsRequiredSpecifiedContext { get; set; }

    public bool IsRequiredRootContext { get; set; }
}