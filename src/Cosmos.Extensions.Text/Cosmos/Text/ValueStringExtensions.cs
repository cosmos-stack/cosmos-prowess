using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Exceptions;

namespace Cosmos.Text
{
    public static class ValueStringHelper
    {
        public static bool TryGetValue<TKey, TValue>(
            this IReadOnlyDictionary<TKey, ValueString> source,
            TKey key,
            out TValue value)
        {
            return TryGetValue(source, key, CultureInfo.InvariantCulture, out value);
        }

        public static bool TryGetValue<TKey, TValue>(
            this IReadOnlyDictionary<TKey, ValueString> source,
            TKey key,
            IFormatProvider provider,
            out TValue value)
        {
            try
            {
                if (source.TryGetValue(key, out ValueString v) && v.Is(provider, out value))
                    return true;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException(nameof(source));
            }

            value = default;
            return false;
        }
    }
}