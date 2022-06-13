using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Cosmos.Text;

/// <summary>
/// The structure used for string parsing can more easily convert the string
/// to the type specified by the user through the Cosmos.Conversions and XConv toolset. <br />
/// 用于字符串解析的结构体可以通过 Cosmos.Conversions 和 XConv 工具集更轻松地将字符串转换为用户指定的类型。
/// </summary>
public readonly partial struct ConvertibleStringVal : IDynamicMetaObjectProvider
{
    /// <inheritdoc />
    DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        => new ValueStringMetaObject(parameter, this);

    private sealed class ValueStringMetaObject : DynamicMetaObject
    {
        // ReSharper disable once MemberHidesStaticFromOuterClass
        private static readonly CacheMan<MethodInfo> CachedMethods = new();

        public ValueStringMetaObject(Expression expression, ConvertibleStringVal value)
            : base(expression, BindingRestrictions.Empty, value) { }

        /// <inheritdoc />
        public override DynamicMetaObject BindConvert(ConvertBinder binder)
        {
            var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
            if (binder.Type == LimitType)
                // ReSharper disable once AssignNullToNotNullAttribute
                return binder.FallbackConvert(new DynamicMetaObject(Expression, restrictions, Value));

            var method = CachedMethods.GetOrAdd(binder.Type, t => GetAsMethod(t, false));
            var call = Expression.Call(Expression.Convert(Expression, LimitType), method);
            return new DynamicMetaObject(call, restrictions);
        }
    }
}