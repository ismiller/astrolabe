namespace Astrolabe.Core.Abstractions;

/// <summary>
/// Определяет метод сборки для возвращаемого типа.
/// </summary>
/// <typeparam name="T">Тип, возвращаемый методом сборки.</typeparam>
internal interface IBuild<out T> where T : class
{
    /// <summary>
    /// Выполняет сборку.
    /// </summary>
    /// <returns>Результат сборки.</returns>
    T Build();
}