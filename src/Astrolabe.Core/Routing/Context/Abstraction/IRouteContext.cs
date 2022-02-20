using Astrolabe.Core.Components.Abstractions;
using Astrolabe.Core.Routing.Endpoints.Abstractions;

namespace Astrolabe.Core.Routing.Context.Abstraction;

/// <summary>
/// Определяет функционал контекста навигации.
/// </summary>
public interface IRouteContext
{
    /// <summary>
    /// Пробует выполнить установку типа представления в контекст навигации.
    /// </summary>
    /// <returns><see langword="true"/> - если установка выполнена успешно.</returns>
    bool MoveToEndpoint(IEndpointExecuteRequest request);
}