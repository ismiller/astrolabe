using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astrolabe.Navigating.Abstraction;
using Astrolabe.ViewModels;

namespace Astrolabe.Navigating
{
    public class Navigator : INavigationService
    {
        public event EventHandler Navigated;

        public void NavigateBack(INavigationArgs navigationArgs, INavigationOptions options)
        {
            throw new NotImplementedException();
        }

        public void NavigateBack(INavigationArgs navigationArgs)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo<TViewModel>(INavigationArgs navigationArgs, INavigationOptions options)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo<TViewModel>(INavigationArgs navigationArgs)
        {
            throw new NotImplementedException();
        }
    }
}