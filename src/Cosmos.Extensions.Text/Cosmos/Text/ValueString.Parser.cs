using System;
using System.Linq.Expressions;
using System.Reflection;
using Cosmos.Reflection;

namespace Cosmos.Text
{
    public partial struct ValueString
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
                        else
                            return (f, provider) => f != null ? compiled(f, null, provider) : null;
                    }

                    if (isValueType)
                        return (o, provider) => o.ToString();
                    else
                        return (o, provider) => o?.ToString();
                }
            }
        }
    }
}