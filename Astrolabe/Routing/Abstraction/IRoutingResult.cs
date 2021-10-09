namespace Astrolabe.Routing.Abstraction
{
    /// <summary>
    /// Предоставляет результат выполнения маршрута.
    /// </summary>
    public interface IRoutingResult
    {
        /// <summary>
        /// Предоставляет флаг, указывающий на успешное выполнение маршрута.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Предоставляет флаг, указывающий на неудачное выполнение маршрута.
        /// </summary>
        bool IsFailure { get; }

        /// <summary>
        /// Предоставляет сообщение результата выполнения маршрута.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Применяет переданные аргументы навигации.
        /// </summary>
        void ApplyNavigateArgs();
    }
}