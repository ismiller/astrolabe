using System.Collections.Generic;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Routing.Endpoints.Abstractions;
using Astrolabe.Core.Routing.Schemes;
using Astrolabe.Core.Utilities.Security;

namespace Astrolabe.Core.Routing.Endpoints;

internal class EndpointBuilder : IEndpointBuilder, IBuild<IEndpointsDictionary<IEndpoint>>
{
    private readonly IEndpointsDictionary<IEndpoint> _schemeDictionary;
    private readonly List<IEndpointBlank> _blanks;

    public EndpointBuilder()
    {
        _schemeDictionary = new EndpointsDictionary();
        _blanks = new List<IEndpointBlank>();
    }

    public IEndpointBlank AttachSchemeToContext(string contextKey)
    {
        Security.ProtectFrom.NullOrWhiteSpace(contextKey, nameof(contextKey));
        IEndpointBlank blank = new EndpointBlank(contextKey);
        _blanks.Add(blank);

        return blank;
    }

    public IEndpointBlank AttachSchemeToRoot()
    {
        IEndpointBlank blank = new EndpointBlank(true);
        _blanks.Add(blank);

        return blank;
    }

    public IEndpointsDictionary<IEndpoint> Build()
    {
        foreach (IEndpointBlank blank in _blanks)
        {
            IBuild<IEndpoint> blankBuild = blank as IBuild<IEndpoint>;
            if (blankBuild == null)
            {
                continue;
            }

            IEndpoint scheme = blankBuild.Build();
            _schemeDictionary.RegisterScheme(scheme);
        }

        return _schemeDictionary;
    }
}