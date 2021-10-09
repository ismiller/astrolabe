using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrolabe.Navigating.Abstraction
{
    /// <summary>
    /// Определяет набор параметров для навигации.
    /// </summary>
    public interface INavigationOptions
    {
        /// <summary>
        /// Предоставляет или устанавливает флаг, указвающий на необходимость очистки стека после навигации.
        /// </summary>
        bool IsClearStack { get; set; }

        /// <summary>
        /// Предоставляет или устанавливает флаг, указвающий на необходимость сброса стека после навигации.
        /// </summary>
        bool IsResetStack { get; set; }

        /// <summary>
        /// Предоставляет или устанавливает флаг, указвающий на необходимость игнорирования текущей навигации.
        /// </summary>
        bool IsIgnoreCurrentNavigate { get; set; }
    }
}