using System;
using Astrolabe.Exceptions.Verifications;
using Astrolabe.ViewModels.Abstractions;

namespace Astrolabe.ViewModels
{
    internal sealed class ViewObserver : IViewObserver, IViewObserverCaller
    {
        #region Private Fields

        private Action _viewCreatedCallback;
        private Action _viewLeaveCallback;
        private Action _viewLeftCallback;
        private Action _viewLoadedCallback;
        private Action _viewLoadingCallback;
        private Action _viewUnloadedCallback;

        #endregion Private Fields

        #region Public Methods

        public void ListenViewCreated(Action callback)
        {
            _viewCreatedCallback = Security.NotNull(callback, nameof(callback));
        }

        public void ListenViewLeave(Action callback)
        {
            _viewLeaveCallback = Security.NotNull(callback, nameof(callback));
        }

        public void ListenViewLeft(Action callback)
        {
            _viewLeftCallback = Security.NotNull(callback, nameof(callback));
        }

        public void ListenViewLoaded(Action callback)
        {
            _viewLoadedCallback = Security.NotNull(callback, nameof(callback));
        }

        public void ListenViewLoading(Action callback)
        {
            _viewLoadingCallback = Security.NotNull(callback, nameof(callback));
        }

        public void ListenViewUnloaded(Action callback)
        {
            _viewUnloadedCallback = Security.NotNull(callback, nameof(callback));
        }

        #endregion Public Methods

        #region Internal Methods

        void IViewObserverCaller.ViewCreated() => _viewCreatedCallback?.Invoke();

        void IViewObserverCaller.ViewLeave() => _viewLeaveCallback?.Invoke();

        void IViewObserverCaller.ViewLeft() => _viewLeftCallback?.Invoke();

        void IViewObserverCaller.ViewLoaded() => _viewLoadedCallback?.Invoke();

        void IViewObserverCaller.ViewLoading() => _viewLoadingCallback?.Invoke();

        void IViewObserverCaller.ViewUnloaded() => _viewUnloadedCallback?.Invoke();

        #endregion Internal Methods
    }
}