using System.Collections.Generic;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Schemes.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.Core.Routing.Schemes;

internal class SchemeBuilder : ISchemeBuilder, IBuild<IRouteSchemeDictionary>
{
    private readonly IRouteSchemeDictionary _schemeDictionary;
    private readonly List<ISchemeBlank> _blanks;

    public SchemeBuilder()
    {
        _schemeDictionary = new RouteSchemeDictionary();
    }

    public ISchemeBlank AddScheme()
    {
        ISchemeBlank blank = new SchemeBlank();
        _blanks.Add(blank);

        return blank;
    }

    public IRouteSchemeDictionary Build()
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