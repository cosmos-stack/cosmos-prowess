using System;
using System.Collections.Concurrent;
using System.Globalization;
using Cosmos.Conversions;

namespace Cosmos.Text
{
    /// <summary>
    /// The structure used for string parsing can more easily convert the string
    /// to the type specified by the user through the Cosmos.Conversions and XConv toolset.
    /// </summary>
    public readonly partial struct ConvertibleStringVal : IEquatable<ConvertibleStringVal>, IEquatable<string>
    {
        private readonly string _value;

        public ConvertibleStringVal(string value) => _value = value;

        #region Of

        /// <summary>
        /// Create a new <see cref="ConvertibleStringVal"/> with a specified object.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ConvertibleStringVal Of<T>(T value) => Of(Parser.Formatter<T>.Format(value, CultureInfo.InvariantCulture));

        /// <summary>
        /// Create a new <see cref="ConvertibleStringVal"/> with a specified string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConvertibleStringVal Of(string value) => new(value);

        #endregion

        #region As

        public T As<T>() => _value.CastTo<T>();

        public T As<T>(T defaultVal) => _value.CastTo(defaultVal);

        public T As<T>(CastingContext context, T defaultVal = default) where T : class
        {
            return _value.CastTo(context, defaultVal);
        }

        public T As<T>(IFormatProvider formatProvider) where T : struct
        {
            return _value.CastTo<T>(ctx =>
            {
                ctx.IgnoreCase = IgnoreCase.FALSE;
                ctx.FormatProvider = formatProvider;
            });
        }

        public T As<T>(NumberStyles numberStyles, T defaultVal = default) where T : struct
        {
            return _value.CastTo<T>(ctx =>
            {
                ctx.IgnoreCase = IgnoreCase.FALSE;
                ctx.NumberStyles = numberStyles;
            }, defaultVal);
        }

        public T As<T>(DateTimeStyles dateTimeStyles, T defaultVal = default) where T : struct
        {
            return _value.CastTo<T>(ctx =>
            {
                ctx.IgnoreCase = IgnoreCase.FALSE;
                ctx.DateTimeStyles = dateTimeStyles;
            }, defaultVal);
        }

        public T As<T>(IgnoreCase ignoreCase, T defaultVal = default, string format = null,
            NumberStyles? numberStyles = null, DateTimeStyles? dateTimeStyles = null, IFormatProvider formatProvider = null)
            where T : struct
        {
            return _value.CastTo<T>(ctx =>
            {
                ctx.IgnoreCase = ignoreCase;
                ctx.Format = format;
                ctx.NumberStyles = numberStyles;
                ctx.DateTimeStyles = dateTimeStyles;
                ctx.FormatProvider = formatProvider;
            }, defaultVal);
        }

        #endregion

        #region Is

        public bool Is<T>() where T : struct => _value.Is<T>();

        public bool Is<T>(IFormatProvider provider) where T : struct
        {
            return _value.Is<T>(ctx => { ctx.FormatProvider = provider; });
        }

        public bool Is<T>(NumberStyles numberStyles) where T : struct
        {
            return _value.Is<T>(ctx => { ctx.NumberStyles = numberStyles; });
        }

        public bool Is<T>(DateTimeStyles dateTimeStyles) where T : struct
        {
            return _value.Is<T>(ctx => { ctx.DateTimeStyles = dateTimeStyles; });
        }

        public bool Is<T>(IgnoreCase ignoreCase, Action<T> action = null, string format = null,
            NumberStyles? numberStyle = null, DateTimeStyles? dateTimeStyle = null, IFormatProvider formatProvider = null)
            where T : struct
        {
            return _value.Is<T>(ctx =>
            {
                ctx.IgnoreCase = ignoreCase;
                ctx.Format = format;
                ctx.NumberStyles = numberStyle;
                ctx.DateTimeStyles = dateTimeStyle;
                ctx.FormatProvider = formatProvider;
            }, action);
        }

        public bool Is<T>(out T result) where T : struct
        {
            var ret = Is<T>();

            result = ret ? As<T>() : default;

            return ret;
        }

        public bool Is<T>(IFormatProvider provider, out T result) where T : struct
        {
            var ret = Is<T>();

            result = ret ? As<T>() : default;

            return ret;
        }

        #endregion

        #region Equals, operators and other overrided methods.

        public static implicit operator ConvertibleStringVal(string value) => Of(value);

        public static bool operator ==(ConvertibleStringVal left, ConvertibleStringVal right) => left.Equals(right);

        public static bool operator !=(ConvertibleStringVal left, ConvertibleStringVal right) => !(left == right);

        public bool Equals(ConvertibleStringVal other, StringComparison comparison) => Equals(other._value, comparison);

        public bool Equals(ConvertibleStringVal other) => Equals(other._value);

        public bool Equals(string other, StringComparison comparison) => ReferenceEquals(_value, other) || (_value?.Equals(other, comparison) ?? false);

        public bool Equals(string other) => _value == other;

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case null:
                    return _value == null;
                case ConvertibleStringVal v:
                    return Equals(v);
                case string s:
                    return Equals(s);
                default:
                    return false;
            }
        }

        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        public override string ToString() => _value;

        #endregion

        #region Cache man

        private class CacheMan<T>
        {
            private readonly ConcurrentDictionary<Type, T> _dictionary = new();

            public T GetOrAdd(Type key, Func<Type, T> valueFactory)
            {
                return _dictionary.GetOrAdd(key, valueFactory);
            }
        }

        #endregion
    }
}