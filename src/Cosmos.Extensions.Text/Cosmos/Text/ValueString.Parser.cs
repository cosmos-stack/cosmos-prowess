using System;
using System.Linq.Expressions;
using System.Reflection;

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
            private static readonly Type providerType = typeof(IFormatProvider);

            private static readonly Type[] formattableParserSig;

            private static readonly ParameterExpression[] formattableParserParams;

            private static readonly Type formattableType = typeof(IFormattable);

            static Parser()
            {
                formattableParserSig = new[] {TypeClass.StringClass, providerType};

                var stringParam = Expression.Parameter(TypeClass.StringClass, "s");
                var providerParam = Expression.Parameter(providerType, "provider");
                formattableParserParams = new[] {stringParam, providerParam};
            }

            public static class Formatter<T>
            {
                public static readonly Func<T, IFormatProvider, string> Format = InitFormat();

                private static Func<T, IFormatProvider, string> InitFormat()
                {
                    var sourceType = typeof(T);

                    var isFormattable = formattableType.IsAssignableFrom(sourceType);
                    var isValueType = sourceType.IsValueType;


                    if (isFormattable)
                    {
                        var instance = Expression.Parameter(sourceType, "this");
                        var method = GetMethod(sourceType, "ToString", formattableParserSig);
                        var call = Expression.Call(instance, method, formattableParserParams);
                        var lambda = Expression.Lambda<Func<T, string, IFormatProvider, string>>(
                            call, instance, formattableParserParams[0], formattableParserParams[1]);

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