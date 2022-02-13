using System;

namespace Astrolabe.Core.ViewModels.Abstractions;

public interface IViewObserver
{
    #region Public Methods

    /// <summary>
    /// Регистрирует обработчик, который будет вызван в момент создания представления.
    /// </summary>
    /// <param name="callback">Делегат обработчика.</param>
    void ListenViewCreated(Action callback);

    /// <summary>
    /// Регистрирует обработчик, который будет вызван в момент
    /// начала выхода из текущего объекта навигации.
    /// </summary>
    /// <remarks>
    /// Метод вызывается на объекте навигации с которого была выполнена навигации,
    /// в случае успешной навигации и перед вызовом метода <see cref="INavigatable.Prepare"/>
    /// объекта на который выполнена навигация.
    /// В случае, если навигация прошла неудачно вызов метода игнорируется.
    /// </remarks>
    /// <param name="callback">Делегат обработчика.</param>
    void ListenViewLeave(Action callback);

    /// <summary>
    /// Регистрирует обработчик, который будет вызван в момент завершения выхода из текущего объекта навигации.
    /// </summary>
    /// <param name="callback">Делегат обработчика.</param>
    void ListenViewLeft(Action callback);

    /// <summary>
    /// Регистрирует обработчик, который будет вызван в момент загрузки представления.
    /// </summary>
    /// <remarks>
    /// Метод вызывается после завершения загрузки представления.
    /// В случае, если навигация прошла неудачно вызов метода игнорируется.
    /// </remarks>
    /// <param name="callback">Делегат обработчика.</param>
    void ListenViewLoaded(Action callback);

    /// <summary>
    /// Регистрирует обработчик, который будет вызван в момент начала загрузки представления.
    /// </summary>
    /// <remarks>
    /// Метод вызывается в начале загрузки представления.
    /// В случае, если навигация прошла неудачно вызов метода игнорируется.
    /// </remarks>
    /// <param name="callback">Делегат обработчика.</param>
    void ListenViewLoading(Action callback);

    /// <summary>
    /// Регистрирует обработчик, который будет вызван в момент выгрузки представления.
    /// </summary>
    /// <remarks>
    /// Метод вызывается после завершения выгрузки представления.
    /// В случае, если навигация прошла неудачно вызов метода игнорируется.
    /// </remarks>
    /// <param name="callback">Делегат обработчика.</param>
    void ListenViewUnloaded(Action callback);

    #endregion Public Methods
}