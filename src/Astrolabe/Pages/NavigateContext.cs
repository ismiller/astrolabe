using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Astrolabe.Exceptions.Verifications;
using Astrolabe.Pages.Abstractions;
using Astrolabe.ViewModels;
using Astrolabe.ViewModels.Abstractions;

namespace Astrolabe.Pages
{
    /// <summary>
    /// Предоставляет функционал контекста навигации.
    /// </summary>
    internal sealed class NavigateContext : INavigateContext
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
            _frame = Security.NotNull(frame, nameof(frame));
            _navigationOptions = Security.NotNull(navigationOptions, nameof(navigationOptions));
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