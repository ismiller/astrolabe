using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astrolabe.Routing.Abstraction;
using Astrolabe.ViewModels;

namespace Astrolabe.Routing
{
    public class BuildRouteResult : IBuildRouteResult
    {
        #region Public Properties

        /// <inheritdoc />
        public bool IsSuccess { get; }

        /// <inheritdoc />
        public string Message { get; }

        /// <inheritdoc />
        public IRoute Route { get; }

        #endregion Public Properties

        #region Private Constructors

        private BuildRouteResult(bool isSuccess, IRoute route, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
            Route = route;
        }

        private BuildRouteResult(bool isSuccess, string message)
            : this(isSuccess, default, message)
        {
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Прдоставляет экземпляр <see cref="IRoutingResult"/> неудачного выполнения маршурта.
        /// </summary>
        /// <param name="message">Сообщение ошибки получения маршрута.</param>
        /// <returns>Результат получения маршрута.</returns>
        public static IBuildRouteResult Failed(string message = default)
        {
            return new BuildRouteResult(false, message);
        }

        /// <summary>
        /// Прдоставляет экземпляр <see cref="IRoutingResult"/> успешного получения маршрута.
        /// </summary>
        /// <param name="route">Полученный маршрут.</param>
        /// <param name="message">Сообщение получения маршрута.</param>
        /// <returns>Результат получения маршрута.</returns>
        public static IBuildRouteResult Succeeded(IRoute route, string message = default)
        {
            return new BuildRouteResult(true, route, message);
        }

        #endregion Public Methods
    }
}