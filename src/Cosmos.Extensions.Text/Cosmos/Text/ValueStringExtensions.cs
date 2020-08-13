using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos ValueString extensions
    /// </summary>
    public static class ValueStringExtensions
    {
        /// <summary>
        /// Try get value from dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static bool TryGetValue<TKey, TValue>(
            this IReadOnlyDictionary<TKey, ValueString> source, TKey key, out TValue value)
            where TValue : struct
        {
            return TryGetValue(source, key, CultureInfo.InvariantCulture, out value);
        }

        /// <summary>
        /// Try get value from dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool TryGetValue<TKey, TValue>(
            this IReadOnlyDictionary<TKey, ValueString> source, TKey key, IFormatProvider provider, out TValue value)
            where TValue : struct
        {
            try
            {
                if (source.TryGetValue(key, out var v) && v.Is(provider, out value))
                    return true;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException(nameof(source));
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="target"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Add<TKey, TValue>(
            this IDictionary<TKey, ValueString> target, TKey key, TValue value)
        {
            try
            {
                target.Add(key, ValueString.Of(value));
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException(nameof(target));
            }
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="target"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Set<TKey, TValue>(
            this IDictionary<TKey, ValueString> target, TKey key, TValue value)
        {
            try
            {
                target[key] = ValueString.Of(value);
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException(nameof(target));
            }
        }
    }
}