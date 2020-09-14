﻿using System;
using System.Collections.Concurrent;
using System.Globalization;
using Cosmos.Conversions;

namespace Cosmos.Text
{
    /// <summary>
    /// The structure used for string parsing can more easily convert the string
    /// to the type specified by the user through the Cosmos.Conversions and XConv toolset.
    /// </summary>
    public partial struct ValueString : IEquatable<ValueString>, IEquatable<string>
    {
        private readonly string _value;

        public ValueString(string value) => _value = value;

        #region Of

        /// <summary>
        /// Create a new <see cref="ValueString"/> with a specified object.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ValueString Of<T>(T value) => Of(Parser.Formatter<T>.Format(value, CultureInfo.InvariantCulture));

        /// <summary>
        /// Create a new <see cref="ValueString"/> with a specified string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueString Of(string value)
        {
            return new ValueString(value);
        }

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
            return _value.CastTo<T>(IgnoreCase.FALSE, formatProvider: formatProvider);
        }

        public T As<T>(NumberStyles numberStyles, T defaultVal = default) where T : struct
        {
            return _value.CastTo(IgnoreCase.FALSE, numberStyles: numberStyles, defaultVal: defaultVal);
        }

        public T As<T>(DateTimeStyles dateTimeStyles, T defaultVal = default) where T : struct
        {
            return _value.CastTo(IgnoreCase.FALSE, dateTimeStyles: dateTimeStyles, defaultVal: defaultVal);
        }

        public T As<T>(IgnoreCase ignoreCase, T defaultVal = default, string format = null,
            NumberStyles? numberStyles = null, DateTimeStyles? dateTimeStyles = null, IFormatProvider formatProvider = null)
            where T : struct
        {
            return _value.CastTo(ignoreCase, defaultVal, format, numberStyles, dateTimeStyles, formatProvider);
        }

        #endregion

        #region Is

        public bool Is<T>() where T : struct => _value.Is<T>();

        public bool Is<T>(IFormatProvider provider) where T : struct => _value.Is<T>(formatProvider: provider);

        public bool Is<T>(NumberStyles numberStyles) where T : struct
        {
            return _value.Is<T>(numberStyle: numberStyles);
        }

        public bool Is<T>(DateTimeStyles dateTimeStyles) where T : struct
        {
            return _value.Is<T>(dateTimeStyle: dateTimeStyles);
        }

        public bool Is<T>(IgnoreCase ignoreCase, Action<T> action = null, string format = null,
            NumberStyles? numberStyle = null, DateTimeStyles? dateTimeStyle = null, IFormatProvider formatProvider = null)
            where T : struct
        {
            return _value.Is(ignoreCase, action, format, numberStyle, dateTimeStyle, formatProvider);
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

        public static implicit operator ValueString(string value) => Of(value);

        public static bool operator ==(ValueString left, ValueString right) => left.Equals(right);

        public static bool operator !=(ValueString left, ValueString right) => !(left == right);

        public bool Equals(ValueString other, StringComparison comparison) => Equals(other._value, comparison);

        public bool Equals(ValueString other) => Equals(other._value);

        public bool Equals(string other, StringComparison comparison) => ReferenceEquals(_value, other) || (_value?.Equals(other, comparison) ?? false);

        public bool Equals(string other) => _value == other;

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case null:
                    return _value == null;
                case ValueString v:
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
            private readonly ConcurrentDictionary<Type, T> _dictionary = new ConcurrentDictionary<Type, T>();

            public T GetOrAdd(Type key, Func<Type, T> valueFactory)
            {
                return _dictionary.GetOrAdd(key, valueFactory);
            }
        }

        #endregion
    }
}