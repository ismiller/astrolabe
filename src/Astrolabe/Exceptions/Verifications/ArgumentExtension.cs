using System;
using System.Globalization;

namespace Astrolabe.Exceptions.Verifications
{
    public static class ArgumentExtension
    {
        public static void NotNull<T>(this T value, string name) where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNullOrWhiteSpace(this string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "String cannot be empty", name));
            }
        }
    }
}