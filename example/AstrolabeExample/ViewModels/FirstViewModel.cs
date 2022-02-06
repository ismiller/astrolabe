using System;
using System.Diagnostics;
using System.Windows.Input;
using Astrolabe;
using Astrolabe.Navigating.Options;
using Astrolabe.ViewModels;
using Astrolabe.ViewModels.Abstractions;
using AstrolabeExample.Helpers;
using AstrolabeExample.ViewModels.Base;

namespace AstrolabeExample.ViewModels
{
    public class FirstViewModel : BaseViewModel, INavigatable
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

        public ICommand NavigateToFront { get; }

        public string ReceivedMessage
        {
            get => _receivedMessage;
            set => Set(ref _receivedMessage, value);
        }

        #endregion Public Properties

        #region Public Constructors

        public FirstViewModel(IAstrolabe navigator)
        {
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            NavigateToFront = new TemplateCommand(OnNavigateToForward);
            NavigateToBack = new TemplateCommand(OnNavigateToBack);
        }

        #endregion Public Constructors

        #region Public Methods

        public void Leave()
        {
            Debug.WriteLine("\t -> Leave.");
        }

        public void Left()
        {
            MessageTextForBack = String.Empty;
            MessageTextForForward = String.Empty;
            ReceivedMessage = String.Empty;
            Debug.WriteLine("\t -> Left.");
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

        public void SetObserver(IViewObserver observer)
        {
            observer.ListenViewCreated(ViewCreated);
            observer.ListenViewLeave(Leave);
            observer.ListenViewLeft(Left);
            observer.ListenViewLoaded(ViewLoaded);
            observer.ListenViewLoading(ViewLoading);
            observer.ListenViewUnloaded(ViewUnloaded);

            Debug.WriteLine("\t -> Set observer.");
        }

        public void ViewCreated()
        {
            Debug.WriteLine("\t -> View created.");
        }

        public void ViewLoaded()
        {
            Debug.WriteLine("\t -> View loaded.");
        }

        public void ViewLoading()
        {
            Debug.WriteLine("\t -> View loading.");
        }

        public void ViewUnloaded()
        {
            Debug.WriteLine("\t -> View unloaded.");
        }

        #endregion Public Methods

        #region Private Methods

        private void OnNavigateToBack(object obj)
        {
            NavigationArgs args = new NavigationArgs(MessageTextForBack);
            _navigator.NavigateBack(args, new NavigationOptions
            {
                IsClearStack = false,
                IsResetStack = true,
                IsIgnoreStack = false
            });
        }

        private void OnNavigateToForward(object obj)
        {
            NavigationArgs args = new NavigationArgs(MessageTextForForward);
            _navigator.NavigateTo<SecondViewModel>(args);
        }

        #endregion Private Methods
    }
}