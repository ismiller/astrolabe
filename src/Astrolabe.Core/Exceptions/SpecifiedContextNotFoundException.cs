using System;

namespace Astrolabe.Core.Exceptions;

public class SpecifiedContextNotFoundException : Exception
{
    public string RequiredContextKey { get; }

    public SpecifiedContextNotFoundException(string requiredContextKey, string message) : base(message)
    {
        RequiredContextKey = requiredContextKey;
    }

    public SpecifiedContextNotFoundException(string requiredContextKey) : this(requiredContextKey, string.Empty)
    {
        RequiredContextKey = requiredContextKey;
    }
}