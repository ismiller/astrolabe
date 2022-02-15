using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Context.Abstraction;

namespace Astrolabe.Core.Routing.Context;

/// <inheritdoc />
internal class ContextInfo : IContextInfo
{
    /// <inheritdoc />
    public string RequiredContextKey { get; set; }

    /// <inheritdoc />
    public IFrameOptions FrameOptions { get; set; }

    /// <inheritdoc />
    public bool IsExecuteOnlySpecifiedContext { get; set; }
}