using System;
using System.Globalization;

namespace Astrolabe.Exceptions.Verifications
{
    /// <summary>
    /// Предоставляет набор методов расширения для валидации аргументов.
    /// </summary>
    internal static class Security
    {
        /// <summary>
        /// Выполняет проверку на значение <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">Тип проверяемого объекта.</typeparam>
        /// <param name="value">Проверяемый объект.</param>
        /// <param name="name">Имя аргумента.</param>
        /// <exception cref="ArgumentNullException" />
        public static T NotNull<T>(T value, string name) where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }

            return value;
        }

        /// <summary>
        /// Выполняет проверку строки.
        /// </summary>
        /// <param name="value">Проверяемая строка.</param>
        /// <param name="name">Имя аргумента.</param>
        /// <exception cref="ArgumentException" />
        public static string NotNullOrWhiteSpace(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "String cannot be empty", name));
            }

            return value;
        }
    }
}