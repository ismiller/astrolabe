using System.Windows.Input;
using Astrolabe.Core.Abstractions;
using Astrolabe.Core.ViewModels.Abstractions;
using Microsoft.Toolkit.Mvvm.Input;

namespace Test
{
    public class TestPageViewModel : INavigatable
    {
        public ICommand NextCommand { get; }
        private readonly IAstrolabe _navigator;
        public TestPageViewModel(IAstrolabe navigator)
        {
            _navigator = navigator;
            NextCommand = new RelayCommand(() => _navigator.NavigateTo(typeof(InnerPageViewModel), default));
        }

        public void Prepare(INavigationArgs args)
        {
            
        }

        public void SetObserver(IViewObserver observer)
        {

        }
    }
}
