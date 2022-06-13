using System.Linq.Expressions;
using System.Reflection;
using Cosmos.Reflection;
// ReSharper disable CoVariantArrayConversion

namespace Cosmos.Text;

/// <summary>
/// The structure used for string parsing can more easily convert the string
/// to the type specified by the user through the Cosmos.Conversions and XConv toolset. <br />
/// 用于字符串解析的结构体可以通过 Cosmos.Conversions 和 XConv 工具集更轻松地将字符串转换为用户指定的类型。
/// </summary>
public readonly partial struct ConvertibleStringVal
{
    private static MethodInfo GetMethod(Type type, string methodName, Type[] parameters) => type.GetMethod(methodName, parameters);

    /// <summary>
    /// Internal value string parser
    /// </summary>
    internal class Parser
    {
        private static readonly Type[] FormattableParserSig;
        private static readonly ParameterExpression[] FormattableParserParams;

        static Parser()
        {
            FormattableParserSig = new[] {TypeClass.StringClazz, TypeClass.FormatProviderClazz};

            var stringParam = Expression.Parameter(TypeClass.StringClazz, "s");
            var providerParam = Expression.Parameter(TypeClass.FormatProviderClazz, "provider");
            FormattableParserParams = new[] {stringParam, providerParam};
        }

        public static class Formatter<T>
        {
            public static readonly Func<T, IFormatProvider, string> Format = InitFormat();

            private static Func<T, IFormatProvider, string> InitFormat()
            {
                var sourceType = typeof(T);

                var isValueType = sourceType.IsValueType;

                // is formattable
                if (TypeClass.FormattableClazz.IsAssignableFrom(sourceType))
                {
                    var instance = Expression.Parameter(sourceType, "this");
                    var method = GetMethod(sourceType, "ToString", FormattableParserSig);
                    var call = Expression.Call(instance, method, FormattableParserParams);
                    var lambda = Expression.Lambda<Func<T, string, IFormatProvider, string>>(
                        call, instance, FormattableParserParams[0], FormattableParserParams[1]);

                    var compiled = lambda.Compile();

                    if (isValueType)
                        return (f, provider) => compiled(f, null, provider);
                    return (f, provider) => f != null ? compiled(f, null, provider) : null;
                }

                if (isValueType)
                    return (o, provider) => o.ToString();
                return (o, provider) => o?.ToString();
            }
        }
    }
}