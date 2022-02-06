namespace Astrolabe.ViewModels.Abstractions
{
    internal interface IViewObserverCaller
    {
        void ViewCreated();

        void ViewLeave();

        void ViewLeft();

        void ViewLoaded();

        void ViewLoading();

        void ViewUnloaded();
    }
}