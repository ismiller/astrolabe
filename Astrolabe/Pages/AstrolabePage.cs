using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Astrolabe.ViewModels;

namespace Astrolabe.Pages
{
    /// <inheritdoc cref="Page"/>
    public abstract class AstrolabePage : Page, IDisposable
    {
        #region Private Fields

        private INavigatable _viewModel;

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
        public AstrolabePage()
        {
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
            ViewModel?.Left();
            base.OnNavigatedFrom(e);
        }

        /// <inheritdoc />
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is IViewModelContainer container)
            {
                ViewModel = container.ViewModel;
            }
            ViewModel?.ViewCreated();
        }

        /// <inheritdoc />
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            ViewModel?.Leave();
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
            _viewModel?.ViewLoaded();
        }

        private void AstrolabePage_OnLoading(FrameworkElement sender, object args)
        {
            _viewModel?.ViewLoading();
        }

        private void AstrolabePage_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _viewModel?.ViewUnloaded();
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