using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Astrolabe.Pages.Abstractions;
using Astrolabe.ViewModels;

namespace Astrolabe.Pages
{
    /// <summary>
    /// Предоставляет функционал контекста навигации.
    /// </summary>
    public class NavigateContext : INavigateContext
    {
        #region Private Fields

        private readonly Frame _frame;
        private readonly FrameNavigationOptions _navigationOptions;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр <see cref="NavigateContext"/>.
        /// </summary>
        /// <param name="frame">Экземпляр <see cref="Frame"/> в рамках которого производится навигация.</param>
        /// <param name="navigationOptions">Опции навигации.</param>
        public NavigateContext(Frame frame, FrameNavigationOptions navigationOptions)
        {
            _frame = frame ?? throw new ArgumentNullException(nameof(frame));
            _navigationOptions = navigationOptions ?? throw new ArgumentNullException(nameof(navigationOptions));
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc />
        public bool TryAccept(Type viewType, IViewModelContainer container)
        {
            return _frame.NavigateToType(viewType, container, _navigationOptions);
        }

        #endregion Public Methods
    }
}