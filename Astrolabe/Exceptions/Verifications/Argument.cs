using System;
using System.Globalization;

namespace Astrolabe.Exceptions.Verifications
{
    public static class Argument
    {
        public static void NotNull<T>(T value, string name) where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNullOrWhiteSpace(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "String cannot be empty", name));
            }
        }
    }
}