using System;
using System.Windows.Input;
using Astrolabe;
using Astrolabe.ViewModels;
using AstrolabeExample.Helpers;
using AstrolabeExample.ViewModels.Base;

namespace AstrolabeExample.ViewModels
{
    public class EndViewModel : BaseViewModel, INavigatable
    {
        #region Private Fields

        private readonly IAstrolabe _navigator;

        private string _messageTextForBack;
        private string _messageTextForForward;
        private string _receivedMessage;

        #endregion Private Fields

        #region Public Properties

        public string MessageTextForBack
        {
            get => _messageTextForBack;
            set => Set(ref _messageTextForBack, value);
        }

        public string MessageTextForForward
        {
            get => _messageTextForForward;
            set => Set(ref _messageTextForForward, value);
        }

        public ICommand NavigateToBack { get; }

        public string ReceivedMessage
        {
            get => _receivedMessage;
            set => Set(ref _receivedMessage, value);
        }

        #endregion Public Properties

        #region Public Constructors

        public EndViewModel(IAstrolabe navigator)
        {
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            NavigateToBack = new TemplateCommand(OnNavigateToBack);
        }

        #endregion Public Constructors

        #region Public Methods

        public void Leave()
        {
        }

        public void Left()
        {
            MessageTextForBack = String.Empty;
            MessageTextForForward = String.Empty;
            ReceivedMessage = String.Empty;
        }

        public void Prepare(INavigationArgs args)
        {
            if (args != null)
            {
                if (args.NavigationData is string message)
                {
                    ReceivedMessage = $"Message: \"{message}\"";
                }
            }
        }

        public void ViewCreated()
        {
        }

        public void ViewLoaded()
        {
        }

        public void ViewLoading()
        {
        }

        public void ViewUnloaded()
        {
        }

        #endregion Public Methods

        #region Private Methods

        private void OnNavigateToBack(object obj)
        {
            NavigationArgs args = new NavigationArgs(MessageTextForBack);
            _navigator.NavigateBack(args);
        }

        #endregion Private Methods
    }
}