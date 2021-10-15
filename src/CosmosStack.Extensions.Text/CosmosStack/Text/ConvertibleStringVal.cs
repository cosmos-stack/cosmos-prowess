using System;
using System.Collections.Concurrent;
using System.Globalization;
using CosmosStack.Conversions;

namespace CosmosStack.Text
{
    /// <summary>
    /// The structure used for string parsing can more easily convert the string
    /// to the type specified by the user through the Cosmos.Conversions and XConv toolset. <br />
    /// 用于字符串解析的结构体可以通过 Cosmos.Conversions 和 XConv 工具集更轻松地将字符串转换为用户指定的类型。
    /// </summary>
    public readonly partial struct ConvertibleStringVal : IEquatable<ConvertibleStringVal>, IEquatable<string>
    {
        private readonly string _value;

        public ConvertibleStringVal(string value) => _value = value;

        #region Of

        /// <summary>
        /// Create a new <see cref="ConvertibleStringVal"/> with a specified object. <br />
        /// 使用指定的对象创建一个新的 <see cref="ConvertibleStringVal"/>。
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ConvertibleStringVal Of<T>(T value) => new(Parser.Formatter<T>.Format(value, CultureInfo.InvariantCulture));

        /// <summary>
        /// Create a new <see cref="ConvertibleStringVal"/> with a specified string. <br />
        /// 使用指定的字符串创建一个新的 <see cref="ConvertibleStringVal"/>。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConvertibleStringVal Of(string value) => new(value);

        #endregion

        #region As

        /// <summary>
        /// Convert <see cref="ConvertibleStringVal"/> to the given type <br />
        /// 将 ConvertibleStringVal 转换为给定的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T As<T>() => _value.CastTo<T>();

        /// <summary>
        /// Convert <see cref="ConvertibleStringVal"/> to the given type <br />
        /// 将 ConvertibleStringVal 转换为给定的类型
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T As<T>(T defaultVal) => _value.CastTo(defaultVal);

        /// <summary>
        /// Convert <see cref="ConvertibleStringVal"/> to the given type <br />
        /// 将 ConvertibleStringVal 转换为给定的类型
        /// </summary>
        /// <param name="context"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T As<T>(CastingContext context, T defaultVal = default) where T : class
        {
            return _value.CastTo(context, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="ConvertibleStringVal"/> to the given type <br />
        /// 将 ConvertibleStringVal 转换为给定的类型
        /// </summary>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T As<T>(IFormatProvider formatProvider) where T : struct
        {
            return _value.CastTo<T>(ctx =>
            {
                ctx.IgnoreCase = IgnoreCase.FALSE;
                ctx.FormatProvider = formatProvider;
            });
        }

        /// <summary>
        /// Convert <see cref="ConvertibleStringVal"/> to the given type <br />
        /// 将 ConvertibleStringVal 转换为给定的类型
        /// </summary>
        /// <param name="numberStyles"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T As<T>(NumberStyles numberStyles, T defaultVal = default) where T : struct
        {
            return _value.CastTo<T>(ctx =>
            {
                ctx.IgnoreCase = IgnoreCase.FALSE;
                ctx.NumberStyles = numberStyles;
            }, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="ConvertibleStringVal"/> to the given type <br />
        /// 将 ConvertibleStringVal 转换为给定的类型
        /// </summary>
        /// <param name="dateTimeStyles"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T As<T>(DateTimeStyles dateTimeStyles, T defaultVal = default) where T : struct
        {
            return _value.CastTo<T>(ctx =>
            {
                ctx.IgnoreCase = IgnoreCase.FALSE;
                ctx.DateTimeStyles = dateTimeStyles;
            }, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="ConvertibleStringVal"/> to the given type <br />
        /// 将 ConvertibleStringVal 转换为给定的类型
        /// </summary>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <param name="format"></param>
        /// <param name="numberStyles"></param>
        /// <param name="dateTimeStyles"></param>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// Determine whether <see cref="ConvertibleStringVal"/> can be converted to a given type <br />
        /// 判断 ConvertibleStringVal 是否可转换为给定的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool Is<T>() where T : struct => _value.Is<T>();

        /// <summary>
        /// Determine whether <see cref="ConvertibleStringVal"/> can be converted to a given type <br />
        /// 判断 ConvertibleStringVal 是否可转换为给定的类型
        /// </summary>
        /// <param name="provider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool Is<T>(IFormatProvider provider) where T : struct
        {
            return _value.Is<T>(ctx => { ctx.FormatProvider = provider; });
        }

        /// <summary>
        /// Determine whether <see cref="ConvertibleStringVal"/> can be converted to a given type <br />
        /// 判断 ConvertibleStringVal 是否可转换为给定的类型
        /// </summary>
        /// <param name="numberStyles"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool Is<T>(NumberStyles numberStyles) where T : struct
        {
            return _value.Is<T>(ctx => { ctx.NumberStyles = numberStyles; });
        }

        /// <summary>
        /// Determine whether <see cref="ConvertibleStringVal"/> can be converted to a given type <br />
        /// 判断 ConvertibleStringVal 是否可转换为给定的类型
        /// </summary>
        /// <param name="dateTimeStyles"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool Is<T>(DateTimeStyles dateTimeStyles) where T : struct
        {
            return _value.Is<T>(ctx => { ctx.DateTimeStyles = dateTimeStyles; });
        }

        /// <summary>
        /// Determine whether <see cref="ConvertibleStringVal"/> can be converted to a given type <br />
        /// 判断 ConvertibleStringVal 是否可转换为给定的类型
        /// </summary>
        /// <param name="ignoreCase"></param>
        /// <param name="action"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// Determine whether <see cref="ConvertibleStringVal"/> can be converted to a given type <br />
        /// 判断 ConvertibleStringVal 是否可转换为给定的类型
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool Is<T>(out T result) where T : struct
        {
            var ret = Is<T>();

            result = ret ? As<T>() : default;

            return ret;
        }

        /// <summary>
        /// Determine whether <see cref="ConvertibleStringVal"/> can be converted to a given type <br />
        /// 判断 ConvertibleStringVal 是否可转换为给定的类型
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool Is<T>(IFormatProvider provider, out T result) where T : struct
        {
            var ret = Is<T>(provider);

            result = ret ? As<T>() : default;

            return ret;
        }

        #endregion

        #region Equals, operators and other overrided methods.

        public static implicit operator ConvertibleStringVal(string value) => Of(value);

        public static bool operator ==(ConvertibleStringVal left, ConvertibleStringVal right) => left.Equals(right);

        public static bool operator !=(ConvertibleStringVal left, ConvertibleStringVal right) => !(left == right);

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public bool Equals(ConvertibleStringVal other, StringComparison comparison) => Equals(other._value, comparison);

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ConvertibleStringVal other) => Equals(other._value);

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public bool Equals(string other, StringComparison comparison) => ReferenceEquals(_value, other) || (_value?.Equals(other, comparison) ?? false);

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(string other) => _value == other;

        /// <inheritdoc />
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

        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
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