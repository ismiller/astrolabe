using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.Routing.Abstraction;

namespace Astrolabe.Core.Routing.Schemes;

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