using System.Collections.Generic;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Routing.Schemes.Abstractions;

namespace Astrolabe.Core.Routing.Schemes;

internal class SchemeBuilder : ISchemeBuilder, IBuild<IRouteSchemeDictionary<IRouteScheme>>
{
    private readonly IRouteSchemeDictionary<IRouteScheme> _schemeDictionary;
    private readonly List<ISchemeBlank> _blanks;

    public SchemeBuilder()
    {
        _schemeDictionary = new RouteSchemeDictionary();
        _blanks = new List<ISchemeBlank>();
    }

    public ISchemeBlank AddScheme()
    {
        ISchemeBlank blank = new SchemeBlank();
        _blanks.Add(blank);

        return blank;
    }

    public IRouteSchemeDictionary<IRouteScheme> Build()
    {
        foreach (ISchemeBlank blank in _blanks)
        {
            IBuild<IRouteScheme> blankBuild = blank as IBuild<IRouteScheme>;
            if (blankBuild == null)
            {
                continue;
            }

            IRouteScheme scheme = blankBuild.Build();
            _schemeDictionary.RegisterScheme(scheme);
        }

        return _schemeDictionary;
    }
}