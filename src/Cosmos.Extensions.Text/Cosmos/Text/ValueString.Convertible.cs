using System;
using System.Globalization;
using System.Reflection;

namespace Cosmos.Text
{
    public partial struct ValueString : IConvertible
    {
        private static readonly CacheMan<MethodInfo> CachedMethods = new CacheMan<MethodInfo>();

        private static MethodInfo GetAsMethod(Type type, bool withFormatProvider)
        {
            var parameters = withFormatProvider ? new[] {typeof(IFormatProvider)} : new Type[0];
            return GetMethod(typeof(ValueString), "As", parameters).MakeGenericMethod(type);
        }

        /// <inheritdoc />
        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;

        /// <inheritdoc />
        bool IConvertible.ToBoolean(IFormatProvider provider) => As<bool>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        byte IConvertible.ToByte(IFormatProvider provider) => As<byte>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        char IConvertible.ToChar(IFormatProvider provider) => As<char>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => As<DateTime>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        decimal IConvertible.ToDecimal(IFormatProvider provider) => As<decimal>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        double IConvertible.ToDouble(IFormatProvider provider) => As<double>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        short IConvertible.ToInt16(IFormatProvider provider) => As<short>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        int IConvertible.ToInt32(IFormatProvider provider) => As<int>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        long IConvertible.ToInt64(IFormatProvider provider) => As<long>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        sbyte IConvertible.ToSByte(IFormatProvider provider) => As<sbyte>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        float IConvertible.ToSingle(IFormatProvider provider) => As<float>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        string IConvertible.ToString(IFormatProvider provider) => ToString();

        /// <inheritdoc />
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            var method = CachedMethods.GetOrAdd(conversionType, t => GetAsMethod(t, true));
            return method.Invoke(this, new object[] {provider ?? CultureInfo.InvariantCulture});
        }

        /// <inheritdoc />
        ushort IConvertible.ToUInt16(IFormatProvider provider) => As<ushort>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        uint IConvertible.ToUInt32(IFormatProvider provider) => As<uint>(provider ?? CultureInfo.InvariantCulture);

        /// <inheritdoc />
        ulong IConvertible.ToUInt64(IFormatProvider provider) => As<ulong>(provider ?? CultureInfo.InvariantCulture);
    }
}