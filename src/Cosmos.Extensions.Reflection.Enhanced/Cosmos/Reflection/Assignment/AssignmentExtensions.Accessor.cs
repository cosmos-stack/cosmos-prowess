using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Cosmos.Reflection.Assignment
{
    public static partial class AssignmentExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, object> GetValueGetter<T>(this T t, string memberName)
        {
            return _ => t.GetValueAccessor().GetValue(memberName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, object> GetValueGetter<T>(this T t, string memberName, BindingFlags bindingAttr)
        {
            return _ => t.GetValueAccessor().GetValue(memberName, bindingAttr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<T, object> GetValueGetter<T>(this PropertyInfo property)
        {
            return StrongTypedCache<T>.PropertyValueGetters.GetOrAdd(property, prop =>
            {
                if (!prop.CanRead)
                    return null;

                var instance = Expression.Parameter(typeof(T), "i");
                var member = Expression.Property(instance, prop);
                var convert = Expression.TypeAs(member, typeof(object));
                return (Func<T, object>)Expression.Lambda(convert, instance).Compile();
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Action<T, object> GetValueSetter<T>(this T t, string memberName)
        {
            return (_, o) => t.GetValueAccessor().SetValue(memberName, o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Action<T, object> GetValueSetter<T>(this T t, string memberName, BindingFlags bindingAttr)
        {
            return (_, o) => t.GetValueAccessor().SetValue(memberName, bindingAttr, o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Action<T, object> GetValueSetter<T>(this PropertyInfo property)
        {
            return StrongTypedCache<T>.PropertyValueSetters.GetOrAdd(property, prop =>
            {
                if (!prop.CanWrite)
                    return null;

                return (i, o) => prop.SetValue(i, o);

                // var instance = Expression.Parameter(typeof(T), "i");
                // var member = Expression.Property(instance, prop);
                // var propertyVal = Expression.Parameter(prop.PropertyType);
                // var assign = Expression.Assign(member, propertyVal);
                // return Expression.Lambda<Action<T, object>>(assign, instance, propertyVal).Compile();
            });
        }
    }
}