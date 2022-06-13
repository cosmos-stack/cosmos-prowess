using System.Linq.Expressions;
using Cosmos.Exceptions;
using Cosmos.Optionals;
using Cosmos.Reflection.Core;
using A = Cosmos.Reflection.PropertyValueAccessor;

namespace Cosmos.Reflection;

/// <summary>
/// Property Value Accessor <br />
/// 属性值访问器
/// </summary>
public static class PropertyValueAccessor
{
    #region GetPropertyValue

    /// <summary>
    /// Get the value of the specified property name from the that.<br />
    /// 从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that">Any <see cref="object"/></param>
    /// <param name="propertyName">Property name in this that</param>
    /// <returns>Value of the specific property in this that</returns>
    public static object GetPropertyValue(object that, string propertyName)
        => DefaultPropertyValueGetter.Instance.Invoke(that.GetType(), that, propertyName);

    /// <summary>
    /// Get the value of the specified property name from the that.<br />
    /// 从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <returns></returns>
    public static object GetPropertyValue(object that, string propertyName, BindingFlags bindingAttr)
        => DefaultPropertyValueGetter.Instance.Invoke(that.GetType(), that, propertyName, bindingAttr);

    /// <summary>
    /// Get the value of the specified property name from the that.<br />
    /// 从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that">Any <see cref="object"/></param>
    /// <param name="propertyName">Property name in this that</param>
    /// <returns>Value of the specific property in this that</returns>
    public static TVal GetPropertyValue<TVal>(object that, string propertyName)
        => DefaultPropertyValueGetter.Instance.Invoke(that.GetType(), that, propertyName).As<TVal>();

    /// <summary>
    /// Get the value of the specified property name from the that.<br />
    /// 从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <returns></returns>
    public static TVal GetPropertyValue<TVal>(object that, string propertyName, BindingFlags bindingAttr)
        => DefaultPropertyValueGetter.Instance.Invoke(that.GetType(), that, propertyName, bindingAttr).As<TVal>();

    /// <summary>
    /// Try to get the value of the specified property name from the that.<br />
    /// 尝试从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that">Any <see cref="object"/></param>
    /// <param name="propertyName">Property name in this that</param>
    /// <param name="value"></param>
    /// <returns>Value of the specific property in this that</returns>
    public static bool TryGetPropertyValue(object that, string propertyName, out object value)
    {
        return Try.Create(() => DefaultPropertyValueGetter.Instance.Invoke(that.GetType(), that, propertyName))
                  .GetSafeValueOut(out value, defaultVal: null)
                  .IsSuccess;
    }

    /// <summary>
    /// Try to get the value of the specified property name from the that.<br />
    /// 尝试从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryGetPropertyValue(object that, string propertyName, BindingFlags bindingAttr, out object value)
    {
        return Try.Create(() => DefaultPropertyValueGetter.Instance.Invoke(that.GetType(), that, propertyName, bindingAttr))
                  .GetSafeValueOut(out value, defaultVal: null)
                  .IsSuccess;
    }

    /// <summary>
    /// Try to get the value of the specified property name from the that.<br />
    /// 尝试从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that">Any <see cref="object"/></param>
    /// <param name="propertyName">Property name in this that</param>
    /// <param name="value"></param>
    /// <returns>Value of the specific property in this that</returns>
    public static bool TryGetPropertyValue<TVal>(object that, string propertyName, out TVal value)
    {
        return Try.Create(() => DefaultPropertyValueGetter.Instance.Invoke(that.GetType(), that, propertyName).As<TVal>())
                  .GetSafeValueOut(out value, defaultVal: default)
                  .IsSuccess;
    }

    /// <summary>
    /// Try to get the value of the specified property name from the that.<br />
    /// 尝试从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryGetPropertyValue<TVal>(object that, string propertyName, BindingFlags bindingAttr, out TVal value)
    {
        return Try.Create(() => DefaultPropertyValueGetter.Instance.Invoke(that.GetType(), that, propertyName, bindingAttr).As<TVal>())
                  .GetSafeValueOut(out value, defaultVal: default)
                  .IsSuccess;
    }

    #endregion

    #region GetPropertyValue with given impl

    /// <summary>
    /// Get the value of the specified property name from the that.<br />
    /// 从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that">Any <see cref="object"/></param>
    /// <param name="propertyName">Property name in this that</param>
    /// <param name="propertyValueGetter"></param>
    /// <returns>Value of the specific property in this that</returns>
    public static object GetPropertyValue(object that, string propertyName, IPropertyValueGetter propertyValueGetter)
        => propertyValueGetter.SafeRefValue(DefaultPropertyValueGetter.Instance).Invoke(that.GetType(), that, propertyName);

    /// <summary>
    /// Get the value of the specified property name from the that.<br />
    /// 从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="propertyValueGetter"></param>
    /// <returns></returns>
    public static object GetPropertyValue(object that, string propertyName, BindingFlags bindingAttr, IPropertyValueGetter propertyValueGetter)
        => propertyValueGetter.SafeRefValue(DefaultPropertyValueGetter.Instance).Invoke(that.GetType(), that, propertyName, bindingAttr);

    /// <summary>
    /// Get the value of the specified property name from the that.<br />
    /// 从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that">Any <see cref="object"/></param>
    /// <param name="propertyName">Property name in this that</param>
    /// <param name="propertyValueGetter"></param>
    /// <returns>Value of the specific property in this that</returns>
    public static TVal GetPropertyValue<TVal>(object that, string propertyName, IPropertyValueGetter propertyValueGetter)
        => propertyValueGetter.SafeRefValue(DefaultPropertyValueGetter.Instance).Invoke(that.GetType(), that, propertyName).As<TVal>();

    /// <summary>
    /// Get the value of the specified property name from the that.<br />
    /// 从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="propertyValueGetter"></param>
    /// <returns></returns>
    public static TVal GetPropertyValue<TVal>(object that, string propertyName, BindingFlags bindingAttr, IPropertyValueGetter propertyValueGetter)
        => propertyValueGetter.SafeRefValue(DefaultPropertyValueGetter.Instance).Invoke(that.GetType(), that, propertyName, bindingAttr).As<TVal>();

    /// <summary>
    /// Try to get the value of the specified property name from the that.<br />
    /// 尝试从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that">Any <see cref="object"/></param>
    /// <param name="propertyName">Property name in this that</param>
    /// <param name="value"></param>
    /// <param name="propertyValueGetter"></param>
    /// <returns>Value of the specific property in this that</returns>
    public static bool TryGetPropertyValue(object that, string propertyName, out object value, IPropertyValueGetter propertyValueGetter)
    {
        return Try.Create(() => propertyValueGetter
                                .SafeRefValue(DefaultPropertyValueGetter.Instance)
                                .Invoke(that.GetType(), that, propertyName))
                  .GetSafeValueOut(out value, defaultVal: null)
                  .IsSuccess;
    }

    /// <summary>
    /// Try to get the value of the specified property name from the that.<br />
    /// 尝试从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueGetter"></param>
    /// <returns></returns>
    public static bool TryGetPropertyValue(object that, string propertyName, BindingFlags bindingAttr, out object value, IPropertyValueGetter propertyValueGetter)
    {
        return Try.Create(() => propertyValueGetter
                                .SafeRefValue(DefaultPropertyValueGetter.Instance)
                                .Invoke(that.GetType(), that, propertyName, bindingAttr))
                  .GetSafeValueOut(out value, defaultVal: null)
                  .IsSuccess;
    }

    /// <summary>
    /// Try to get the value of the specified property name from the that.<br />
    /// 尝试从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that">Any <see cref="object"/></param>
    /// <param name="propertyName">Property name in this that</param>
    /// <param name="propertyValueGetter"></param>
    /// <param name="value"></param>
    /// <returns>Value of the specific property in this that</returns>
    public static bool TryGetPropertyValue<TVal>(object that, string propertyName, IPropertyValueGetter propertyValueGetter, out TVal value)
    {
        return Try.Create(() => propertyValueGetter
                                .SafeRefValue(DefaultPropertyValueGetter.Instance)
                                .Invoke(that.GetType(), that, propertyName)
                                .As<TVal>())
                  .GetSafeValueOut(out value, defaultVal: default)
                  .IsSuccess;
    }

    /// <summary>
    /// Try to get the value of the specified property name from the that.<br />
    /// 尝试从对象中获取指定属性名称的值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="propertyValueGetter"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryGetPropertyValue<TVal>(object that, string propertyName, BindingFlags bindingAttr, IPropertyValueGetter propertyValueGetter, out TVal value)
    {
        return Try.Create(() => propertyValueGetter
                                .SafeRefValue(DefaultPropertyValueGetter.Instance)
                                .Invoke(that.GetType(), that, propertyName, bindingAttr)
                                .As<TVal>())
                  .GetSafeValueOut(out value, defaultVal: default)
                  .IsSuccess;
    }

    #endregion

    #region SetPropertyValue

    /// <summary>
    /// Set a value to the specified property name in the that.<br />
    /// 向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    public static void SetPropertyValue(object that, string propertyName, object value)
        => DefaultPropertyValueSetter.Instance.Invoke(that.GetType(), that, propertyName, value);

    /// <summary>
    /// Set a value to the specified property name in the that.<br />
    /// 向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    public static void SetPropertyValue(object that, string propertyName, BindingFlags bindingAttr, object value)
        => DefaultPropertyValueSetter.Instance.Invoke(that.GetType(), that, propertyName, bindingAttr, value);

    /// <summary>
    /// Set a value to the specified property name in the that.<br />
    /// 向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    public static void SetPropertyValue<T, TVal>(T that, string propertyName, TVal value)
        => DefaultPropertyValueSetter.Instance.Invoke(typeof(T), that, propertyName, value);

    /// <summary>
    /// Set a value to the specified property name in the that.<br />
    /// 向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    public static void SetPropertyValue<T, TVal>(T that, string propertyName, BindingFlags bindingAttr, TVal value)
        => DefaultPropertyValueSetter.Instance.Invoke(typeof(T), that, propertyName, bindingAttr, value);

    /// <summary>
    /// Try to set a value to the specified property name in the that.<br />
    /// 尝试向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    public static bool TrySetPropertyValue(object that, string propertyName, object value)
    {
        return Try.Invoke(() => DefaultPropertyValueSetter.Instance.Invoke(that.GetType(), that, propertyName, value))
                  .IsSuccess;
    }

    /// <summary>
    /// Try to set a value to the specified property name in the that.<br />
    /// 尝试向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    public static bool TrySetPropertyValue(object that, string propertyName, BindingFlags bindingAttr, object value)
    {
        return Try.Invoke(() => DefaultPropertyValueSetter.Instance.Invoke(that.GetType(), that, propertyName, bindingAttr, value))
                  .IsSuccess;
    }

    /// <summary>
    /// Try to set a value to the specified property name in the that.<br />
    /// 尝试向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    public static bool TrySetPropertyValue<T, TVal>(T that, string propertyName, TVal value)
    {
        return Try.Invoke(() => DefaultPropertyValueSetter.Instance.Invoke(typeof(T), that, propertyName, value))
                  .IsSuccess;
    }

    /// <summary>
    /// Try to set a value to the specified property name in the that.<br />
    /// 尝试向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    public static bool TrySetPropertyValue<T, TVal>(T that, string propertyName, BindingFlags bindingAttr, TVal value)
    {
        return Try.Invoke(() => DefaultPropertyValueSetter.Instance.Invoke(typeof(T), that, propertyName, bindingAttr, value))
                  .IsSuccess;
    }

    #endregion

    #region SetPropertyValue

    /// <summary>
    /// Set a value to the specified property name in the that.<br />
    /// 向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueSetter"></param>
    public static void SetPropertyValue(object that, string propertyName, object value, IPropertyValueSetter propertyValueSetter)
        => propertyValueSetter.SafeRefValue(DefaultPropertyValueSetter.Instance).Invoke(that.GetType(), that, propertyName, value);

    /// <summary>
    /// Set a value to the specified property name in the that.<br />
    /// 向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueSetter"></param>
    public static void SetPropertyValue(object that, string propertyName, BindingFlags bindingAttr, object value, IPropertyValueSetter propertyValueSetter)
        => propertyValueSetter.SafeRefValue(DefaultPropertyValueSetter.Instance).Invoke(that.GetType(), that, propertyName, bindingAttr, value);

    /// <summary>
    /// Set a value to the specified property name in the that.<br />
    /// 向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueSetter"></param>
    public static void SetPropertyValue<T, TVal>(T that, string propertyName, TVal value, IPropertyValueSetter propertyValueSetter)
        => propertyValueSetter.SafeRefValue(DefaultPropertyValueSetter.Instance).Invoke(typeof(T), that, propertyName, value);

    /// <summary>
    /// Set a value to the specified property name in the that.<br />
    /// 向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueSetter"></param>
    public static void SetPropertyValue<T, TVal>(T that, string propertyName, BindingFlags bindingAttr, TVal value, IPropertyValueSetter propertyValueSetter)
        => propertyValueSetter.SafeRefValue(DefaultPropertyValueSetter.Instance).Invoke(typeof(T), that, propertyName, bindingAttr, value);

    /// <summary>
    /// Try to set a value to the specified property name in the that.<br />
    /// 尝试向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueSetter"></param>
    public static bool TrySetPropertyValue(object that, string propertyName, object value, IPropertyValueSetter propertyValueSetter)
    {
        return Try.Invoke(() => propertyValueSetter
                                .SafeRefValue(DefaultPropertyValueSetter.Instance)
                                .Invoke(that.GetType(), that, propertyName, value))
                  .IsSuccess;
    }

    /// <summary>
    /// Try to set a value to the specified property name in the that.<br />
    /// 尝试向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueSetter"></param>
    public static bool TrySetPropertyValue(object that, string propertyName, BindingFlags bindingAttr, object value, IPropertyValueSetter propertyValueSetter)
    {
        return Try.Invoke(() => propertyValueSetter
                                .SafeRefValue(DefaultPropertyValueSetter.Instance)
                                .Invoke(that.GetType(), that, propertyName, bindingAttr, value))
                  .IsSuccess;
    }

    /// <summary>
    /// Try to set a value to the specified property name in the that.<br />
    /// 尝试向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueSetter"></param>
    public static bool TrySetPropertyValue<T, TVal>(T that, string propertyName, TVal value, IPropertyValueSetter propertyValueSetter)
    {
        return Try.Invoke(() => propertyValueSetter
                                .SafeRefValue(DefaultPropertyValueSetter.Instance)
                                .Invoke(typeof(T), that, propertyName, value))
                  .IsSuccess;
    }

    /// <summary>
    /// Try to set a value to the specified property name in the that.<br />
    /// 尝试向对象中的指定属性名称设置值。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    /// <param name="propertyValueSetter"></param>
    public static bool TrySetPropertyValue<T, TVal>(T that, string propertyName, BindingFlags bindingAttr, TVal value, IPropertyValueSetter propertyValueSetter)
    {
        return Try.Invoke(() => propertyValueSetter
                                .SafeRefValue(DefaultPropertyValueSetter.Instance)
                                .Invoke(typeof(T), that, propertyName, bindingAttr, value))
                  .IsSuccess;
    }

    #endregion

    #region CreatePropertyValueAccessor

    public static IPropertyValueAccessor GetValueAccessor(object that, Type type)
    {
        return new DefaultPropertyValueAccessor(type, that, getterImpl: null, setterImpl: null);
    }

    public static IPropertyValueAccessor GetValueAccessor(object that, Type type, Func<Type, object, string, BindingFlags, object> getter)
    {
        return new DefaultPropertyValueAccessor(type, that, getter, null);
    }

    public static IPropertyValueAccessor GetValueAccessor(object that, Type type, Action<Type, object, string, BindingFlags, object> setter)
    {
        return new DefaultPropertyValueAccessor(type, that, null, setter);
    }

    public static IPropertyValueAccessor GetValueAccessor(object that, Type type, Func<Type, object, string, BindingFlags, object> getter, Action<Type, object, string, BindingFlags, object> setter)
    {
        return new DefaultPropertyValueAccessor(type, that, getter, setter);
    }

    public static IPropertyValueAccessor GetValueAccessor(object that, Type type, IPropertyValueGetter getter)
    {
        return new DefaultPropertyValueAccessor(type, that, getter, null);
    }

    public static IPropertyValueAccessor GetValueAccessor(object that, Type type, IPropertyValueSetter setter)
    {
        return new DefaultPropertyValueAccessor(type, that, null, setter);
    }

    public static IPropertyValueAccessor GetValueAccessor(object that, Type type, IPropertyValueGetter getter, IPropertyValueSetter setter)
    {
        return new DefaultPropertyValueAccessor(type, that, getter, setter);
    }

    public static IPropertyValueAccessor GetValueAccessor<T>(T that)
    {
        return new DefaultPropertyValueAccessor<T>(that, getterImpl: null, setterImpl: null);
    }

    public static IPropertyValueAccessor GetValueAccessor<T>(T that, Func<Type, object, string, BindingFlags, object> getter)
    {
        return new DefaultPropertyValueAccessor<T>(that, getter, null);
    }

    public static IPropertyValueAccessor GetValueAccessor<T>(T that, Action<Type, object, string, BindingFlags, object> setter)
    {
        return new DefaultPropertyValueAccessor<T>(that, null, setter);
    }

    public static IPropertyValueAccessor GetValueAccessor<T>(T that, Func<Type, object, string, BindingFlags, object> getter, Action<Type, object, string, BindingFlags, object> setter)
    {
        return new DefaultPropertyValueAccessor<T>(that, getter, setter);
    }

    public static IPropertyValueAccessor GetValueAccessor<T>(T that, IPropertyValueGetter getter)
    {
        return new DefaultPropertyValueAccessor<T>(that, getter, null);
    }

    public static IPropertyValueAccessor GetValueAccessor<T>(T that, IPropertyValueSetter setter)
    {
        return new DefaultPropertyValueAccessor<T>(that, null, setter);
    }

    public static IPropertyValueAccessor GetValueAccessor<T>(T that, IPropertyValueGetter getter, IPropertyValueSetter setter)
    {
        return new DefaultPropertyValueAccessor<T>(that, getter, setter);
    }

    public static IPropertyPathValueAccessor GetValueAccessor<T>(object that, PropertyPath<T> path)
    {
        return new DefaultPropertyPathValueAccessor(path, that);
    }

    public static IPropertyPathValueAccessor GetValueAccessor<T, TVal>(T that, Func<PropertyPath<T>, PropertyPath<TVal>> pathFunc)
    {
        var root = PropertyPath.Of<T>();
        var finalPath = pathFunc?.Invoke(root);
        return new DefaultPropertyPathValueAccessor(finalPath, that);
    }

    #endregion
}

/// <summary>
/// Property Value Accessor Extensions <br />
/// 属性值访问器扩展
/// </summary>
public static class PropertyValueAccessorExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor(this object that, Type type)
        => A.GetValueAccessor(that, type);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor(this object that, Type type, Func<Type, object, string, BindingFlags, object> getter)
        => A.GetValueAccessor(that, type, getter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor(this object that, Type type, Action<Type, object, string, BindingFlags, object> setter)
        => A.GetValueAccessor(that, type, setter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor(this object that, Type type, Func<Type, object, string, BindingFlags, object> getter, Action<Type, object, string, BindingFlags, object> setter)
        => A.GetValueAccessor(that, type, getter, setter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor(this object that, Type type, IPropertyValueGetter getter)
        => A.GetValueAccessor(that, type, getter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor(this object that, Type type, IPropertyValueSetter setter)
        => A.GetValueAccessor(that, type, setter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor(this object that, Type type, IPropertyValueGetter getter, IPropertyValueSetter setter)
        => A.GetValueAccessor(that, type, getter, setter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor<T>(this T that)
        => A.GetValueAccessor(that);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor<T>(this T that, Func<Type, object, string, BindingFlags, object> getter)
        => A.GetValueAccessor(that, getter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor<T>(this T that, Action<Type, object, string, BindingFlags, object> setter)
        => A.GetValueAccessor(that, setter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor<T>(this T that, Func<Type, object, string, BindingFlags, object> getter, Action<Type, object, string, BindingFlags, object> setter)
        => A.GetValueAccessor(that, getter, setter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor<T>(this T that, IPropertyValueGetter getter)
        => A.GetValueAccessor(that, getter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor<T>(this T that, IPropertyValueSetter setter)
        => A.GetValueAccessor(that, setter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyValueAccessor GetValueAccessor<T>(this T that, IPropertyValueGetter getter, IPropertyValueSetter setter)
        => A.GetValueAccessor(that, getter, setter);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyPathValueAccessor GetValueAccessor<T, TVal>(this T that, Func<PropertyPath<T>, PropertyPath<TVal>> pathFunc)
        => A.GetValueAccessor(that, pathFunc);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IPropertyPathValueAccessor GetValueAccessor<T, TProperty>(this object that, Expression<Func<T, TProperty>> expression)
        => A.GetValueAccessor(that, PropertyPath.Of<T>().Then(expression));
}