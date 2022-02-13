using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Astrolabe.Core.Pages.Abstractions;
using Astrolabe.Core.ViewModels;
using Astrolabe.Core.ViewModels.Abstractions;

namespace Astrolabe.UWP.Controls
{
    public class AstrolabePage : Page, INavigationPage
    {
        #region Private Fields

        private INavigatable _viewModel;
        private readonly IViewObserver _observer;
        private readonly IViewObserverCaller _observerCaller;

        #endregion Private Fields

        #region Public Properties

        private INavigatable ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value)
                {
                    return;
                }

                _viewModel = value;
                DataContext = _viewModel;
                OnViewModelSet();
            }
        }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр <see cref="AstrolabePage"/>.
        /// </summary>
        protected AstrolabePage()
        {
            _observer = new ViewObserver();
            _observerCaller = _observer as IViewObserverCaller;

            Loading += AstrolabePage_OnLoading;
            Loaded += AstrolabePage_OnLoaded;
            Unloaded += AstrolabePage_OnUnloaded;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Loading -= AstrolabePage_OnLoading;
                Loaded -= AstrolabePage_OnLoaded;
                Unloaded -= AstrolabePage_OnUnloaded;
            }
        }

        /// <inheritdoc />
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _observerCaller?.ViewLeft();

            base.OnNavigatedFrom(e);
        }

        /// <inheritdoc />
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is IViewModelContainer container)
            {
                ViewModel = container.ViewModel;
                ViewModel.SetObserver(_observer);
            }

            _observerCaller?.ViewCreated();
        }

        /// <inheritdoc />
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            _observerCaller?.ViewLeave();

            base.OnNavigatingFrom(e);
        }

        /// <summary>
        /// Обрабатывает событие установки модели представления.
        /// </summary>
        protected virtual void OnViewModelSet()
        {
        }

        #endregion Protected Methods

        #region Private Methods

        private void AstrolabePage_OnLoaded(object sender, RoutedEventArgs e)
        {
            _observerCaller?.ViewLoaded();
        }

        private void AstrolabePage_OnLoading(FrameworkElement sender, object args)
        {
            _observerCaller?.ViewLoading();
        }

        private void AstrolabePage_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _observerCaller?.ViewUnloaded();
        }

        #endregion Private Methods

        #region Private Destructors

        /// <summary>
        /// Деструктор.
        /// </summary>
        ~AstrolabePage()
        {
            Dispose(false);
        }

        #endregion Private Destructors
    }
}