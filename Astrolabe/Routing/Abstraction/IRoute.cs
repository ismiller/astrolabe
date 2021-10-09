namespace Astrolabe.Routing.Abstraction
{
    /// <summary>
    /// Преддоставляет функционал управления маршрутом.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// Пытается выполнить маршрут.
        /// </summary>
        /// <returns>Возвращает объект <see cref="IRoutingResult"/> предоставляющий результат выполнения маршрута.</returns>
        IRoutingResult TryExecute();
    }
}