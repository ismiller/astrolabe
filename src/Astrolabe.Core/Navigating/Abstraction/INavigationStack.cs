namespace Astrolabe.Core.Navigating.Abstraction;

/// <summary>
/// Определяет функционал стека навигации.
/// </summary>
public interface INavigationStack<TElement>
{
    /// <summary>
    /// Проверяет, содержится ли в стеке хоть один элемент.
    /// </summary>
    /// <returns><see langword="true"/> - если в стеке есть хотя бы один элемент,
    /// иначе - <see langword="false"/>.</returns>
    bool Any();

    /// <summary>
    /// Выполняет полную очистку стека.
    /// </summary>
    void Clear();

    /// <summary>
    /// Пробует извлечь подвешенный элемент, который ещё не был добавлен в стек.
    /// </summary>
    /// <param name="element">Извлеченный элемент.</param>
    /// <returns><see langword="true"/> - если операция выполнена успешно.</returns>
    bool TryGetSuspend(out TElement element);

    /// <summary>
    /// Добавляет элемент в стек.
    /// </summary>
    /// <param name="element">Добавляемый элемент типа <typeparamref name="TElement"/>.</param>
    void Push(TElement element);

    /// <summary>
    /// Удаляет из стека все элементы кроме последнего.
    /// </summary>
    void Reset();

    /// <summary>
    /// Пробует извлечь верхний элемент из стека.
    /// </summary>
    /// <returns>Возвращаемый элемент типа <typeparamref name="TElement"/></returns>
    bool TryPop(out TElement element);
}