namespace Astrolabe.Core.ViewModels.Abstractions;

public interface IViewObserverCaller
{
    void ViewCreated();

    void ViewLeave();

    void ViewLeft();

    void ViewLoaded();

    void ViewLoading();

    void ViewUnloaded();
}