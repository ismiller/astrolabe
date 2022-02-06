using System;
using Astrolabe.ViewModels.Abstractions;

namespace AstrolabeExample.Helpers
{
    public class NavigationArgs : INavigationArgs
    {
        public Action NavigationDone { get; }
        public object NavigationData { get; }

        public NavigationArgs(object data, Action navigationDone)
        {
            NavigationData = data;
            NavigationDone = navigationDone;
        }

        public NavigationArgs(object data) : this(data, null)
        {
            NavigationData = data;
        }
    }
}