using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Cosmos.Reflection;

namespace Cosmos.Expressions
{
    public static class ReflectionExpressionExtensions
    {
        #region GetMethod

        public static MethodInfo GetMethod<T>(this Expression<T> expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (expression.Body is not MethodCallExpression methodCallExpression)
                throw new InvalidCastException("Cannot be converted to MethodCallExpression");

            return methodCallExpression.Method;
        }

        public static MethodCallExpression GetMethodExpression<T>(this Expression<Action<T>> method)
        {
            if (method.Body.NodeType != ExpressionType.Call)
                throw new ArgumentException("Method call expected", method.Body.ToString());
            return (MethodCallExpression)method.Body;
        }

        public static MethodCallExpression GetMethodExpression<T>(this Expression<Func<T, object>> exp)
        {
            switch (exp.Body.NodeType)
            {
                case ExpressionType.Call:
                    return (MethodCallExpression)exp.Body;

                case ExpressionType.Convert:
                    if (exp.Body is UnaryExpression { Operand: MethodCallExpression methodCallExpression })
                    {
                        return methodCallExpression;
                    }

                    break;
            }

            throw new InvalidOperationException($"Method expected: {exp.Body}");
        }

        #endregion

        #region GetMember

        /// <summary>
        /// GetMemberName
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <typeparam name="TMember">TMember</typeparam>
        /// <param name="memberExpression">get member expression</param>
        /// <returns></returns>
        public static string GetMemberName<TEntity, TMember>(this Expression<Func<TEntity, TMember>> memberExpression)
        {
            return GetMemberInfo(memberExpression).Name;
        }

        /// <summary>
        /// GetMemberInfo
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <typeparam name="TMember">TMember</typeparam>
        /// <param name="expression">get member expression</param>
        /// <returns></returns>
        public static MemberInfo GetMemberInfo<TEntity, TMember>(this Expression<Func<TEntity, TMember>> expression)
        {
            if (expression.NodeType != ExpressionType.Lambda)
                throw new ArgumentException($"{nameof(expression)} must be Lambda Expression", nameof(expression));

            var lambda = (LambdaExpression)expression;

            var memberExpression = ExtractMemberExpression(lambda.Body);
            if (memberExpression is null)
                throw new ArgumentException($"{nameof(expression)} must be Lambda Expression", nameof(expression));

            return memberExpression.Member;
        }

        private static MemberExpression ExtractMemberExpression(Expression expression)
        {
            if (expression.NodeType == ExpressionType.MemberAccess)
                return (MemberExpression)expression;

            if (expression.NodeType == ExpressionType.Convert)
                return ExtractMemberExpression(((UnaryExpression)expression).Operand);

            throw new InvalidOperationException(nameof(ExtractMemberExpression));
        }

        #endregion

        #region GetProperty

        /// <summary>
        /// GetPropertyInfo
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static PropertyInfo GetProperty<TEntity, TProperty>(this Expression<Func<TEntity, TProperty>> expression)
        {
            var member = GetMemberInfo(expression);

            if (null == member)
                throw new InvalidOperationException("no property found");

            if (member is PropertyInfo property)
                return property;

            return TypeReflections.TypeCacheManager.GetTypeProperties(typeof(TEntity)).First(p => p.Name.Equals(member.Name));
        }

        #endregion
    }
}