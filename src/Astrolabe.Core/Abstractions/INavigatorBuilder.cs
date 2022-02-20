using Astrolabe.Core.Routing.Context.Abstraction;

namespace Astrolabe.Core.Abstractions;

/// <summary>
/// Определяет функционал для сборки сервиса навигации.
/// </summary>
public interface INavigatorBuilder
{
    public IStartUp Build();

    public INavigatorBuilder TargetContextProvider<T>() where T : class, IContextProvider;

    public INavigatorBuilder UseConfigure<T>() where T : class, IConfigurable;

    public INavigatorBuilder UseStartUp<T>() where T : class, IStartUp;
}