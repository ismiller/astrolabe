using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Astrolabe.Core.Utilities.Security;

/// <summary>
/// Предоставляет набор методов расширения для валидации аргументов.
/// </summary>
internal static class SecurityProtectFromNullExtension
{
    /// <summary>
    /// Бросает исключение <see cref="ArgumentNullException" /> если <paramref name="input" /> представляет <see langword="null"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
#if NET6_0
    public static T Null<T>(
        [NotNull] this ISecurityDirective securityDirective,
        [NotNull] T input,
        [NotNull] [CallerArgumentExpression("input")] string paramName = "",
        [NotNull] string message = null)
#else
    public static T Null<T>(
        this ISecurityDirective securityDirective, 
        T input, 
        string paramName, 
        string message = null)
#endif
    {
        if (input is null)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(paramName);
            }

            throw new ArgumentNullException(paramName, message);
        }

        return input;
    }


    /// <summary>
    /// Бросает исключение <see cref="ArgumentNullException" /> если <paramref name="input" /> представляет <see langword="null"/>.
    /// Бросает исключение <see cref="ArgumentException" /> если <paramref name="input" /> является пустой коллекцией.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
#if NET6_0
    public static IEnumerable<T> FromNullOrEmpty<T>(
        [NotNull] this ISecurityDirective securityDirective, 
        [NotNull] IEnumerable<T> input,
        [NotNull] [CallerArgumentExpression("input")] string paramName = "",
        [NotNull] string message = null)
#else
    public static IEnumerable<T> FromNullOrEmpty<T>(
        this ISecurityDirective securityDirective, 
        IEnumerable<T> input, 
        string paramName, 
        string message = null)
#endif
    {
        Security.ProtectFrom.Null(input, paramName, message);

        if (input.Any() == false) 
        {
            throw new ArgumentException(message ?? $"Required input {paramName} was empty.", paramName);
        }

        return input;
    }


    /// <summary>
    /// Бросает исключение <see cref="ArgumentNullException" /> если <paramref name="input" /> представляет <see langword="null"/>.
    /// Бросает исключение <see cref="ArgumentException" /> если <paramref name="input" /> является пустой или состоящей из пробелов строкой.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
#if NET6_0
    public static string NullOrWhiteSpace(
        [NotNull] this ISecurityDirective securityDirective,
        [NotNull] string input,
        [NotNull] [CallerArgumentExpression("input")] string paramName = "",
        [NotNull] string message = null)
#else
    public static string NullOrWhiteSpace(
        this ISecurityDirective securityDirective, 
        string input, 
        string paramName, 
        string message = null)
#endif
    {
        Security.ProtectFrom.Null(input, paramName, message);

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(message ?? $"Required input {paramName} was empty.", paramName);
        }

        return input;
    }

    /// <summary>
    /// Бросает исключение <see cref="ArgumentNullException" /> если <paramref name="input" /> представляет <see langword="null"/>.   
    /// Бросает исключение <see cref="ArgumentException" /> если <paramref name="input" /> не удовлетворяет требованиям
    /// предоставленным функцией <paramref name="predicate"/>.   
    /// </summary>
#if NET6_0
    public static T NullOrInvalidInput<T>(
        [NotNull] this ISecurityDirective securityDirective,
        [NotNull] T input,
        [NotNull] Func<T, bool> predicate,
        [NotNull] [CallerArgumentExpression("input")] string paramName = "",
        string message = null)
#else
    public static T NullOrInvalidInput<T>(
        this ISecurityDirective securityDirective,
        T input,
        Func<T, bool> predicate,
        string paramName,
        string message = null)
#endif
    {
        Security.ProtectFrom.Null(input, paramName, message);

        if (predicate(input) == false)
        {
            return Security.ProtectFrom.InvalidInput(input, predicate, paramName, message);
        }

        return input;
    }


    /// <summary>
    /// Бросает исключение <see cref="ArgumentException" /> если <paramref name="input" /> не удовлетворяет требованиям
    /// предоставленным функцией <paramref name="predicate"/>.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
#if NET6_0
    public static T InvalidInput<T>(
        [NotNull] this ISecurityDirective securityDirective,
        [NotNull] T input,
        [NotNull] Func<T, bool> predicate,
        [NotNull] [CallerArgumentExpression("input")] string paramName = "",
        string message = null)
#else
    public static T InvalidInput<T>(
        this ISecurityDirective securityDirective,
        T input,
        Func<T, bool> predicate,
        string paramName,
        string message = null)
#endif
    {
        if (predicate(input) == false)
        {
            throw new ArgumentException(message ?? $"Input {paramName} did not satisfy the options", paramName);
        }

        return input;
    }
}