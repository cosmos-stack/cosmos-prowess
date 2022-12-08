﻿namespace Cosmos.Reflection;

/// <summary>
/// Property metadata extensions <br />
/// 属性元信息扩展
/// </summary>
public static class PropertyMetaExtensions
{
    /// <summary>
    /// Get public field with the specified name <br />
    /// 根据给定的名称获取公开的字段信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="propertyName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FieldInfo GetField<T>(this T t, string propertyName)
    {
        return TypeReflections.TypeCacheManager.GetTypeFields(typeof(T)).FirstOrDefault(_ => _.Name == propertyName);
    }

    /// <summary>
    /// Get specified field, using the specified binding constraints. <br />
    /// 根据跟定的名称获取指定可访问性的字段信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FieldInfo GetField<T>(this T t, string propertyName, BindingFlags bindingAttr)
    {
        return typeof(T).GetField(propertyName, bindingAttr);
    }

    /// <summary>
    /// Get all public fields from the given object. <br />
    /// 从给定的对象中获取所有公开字段信息
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FieldInfo[] GetFields(this object obj)
    {
        ObjectGuard.NotNull(obj);
        return TypeReflections.TypeCacheManager.GetTypeFields(obj.GetType());
    }

    /// <summary>
    /// Get all specified fields from the given object, using the specified binding constraints. <br />
    /// 从给定的对象中获取所有指定可访问性的字段信息
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="bindingAttr"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FieldInfo[] GetFields(this object obj, BindingFlags bindingAttr)
    {
        ObjectGuard.NotNull(obj);
        return obj.GetType().GetFields(bindingAttr);
    }

    /// <summary>
    /// Get public method with ths specified name. <br />
    /// 根据名称获取指定的公开方法信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="methodName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MethodInfo GetMethod<T>(this T t, string methodName)
    {
        return TypeReflections.TypeCacheManager.TypeMethodCache.GetOrAdd(typeof(T), v => v.GetMethods()).First(_ => _.Name == methodName);
    }

    /// <summary>
    /// Get specified method, using the specified binding constraints. <br />
    /// 根据名称获取指定的可访问性的方法信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="methodName"></param>
    /// <param name="bindingAttr"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MethodInfo GetMethod<T>(this T t, string methodName, BindingFlags bindingAttr)
    {
        return typeof(T).GetMethod(methodName, bindingAttr);
    }

    /// <summary>
    /// Get all public methods from the given object. <br />
    /// 从对象中获取所有公开方法信息
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MethodInfo[] GetMethods<T>(this T t)
    {
        return TypeReflections.TypeCacheManager.TypeMethodCache.GetOrAdd(typeof(T), _ => _.GetMethods());
    }

    /// <summary>
    /// Get all specified methods from the given object, using the specified binding constraints. <br />
    /// 从对象中获取所有指定可访问性的方法信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="bindingAttr"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MethodInfo[] GetMethods<T>(this T t, BindingFlags bindingAttr)
    {
        return typeof(T).GetMethods(bindingAttr);
    }

    /// <summary>
    /// Get public property with ths specified name. <br />
    /// 根据给定的名称获取公开的属性信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="propertyName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PropertyInfo GetProperty<T>(this T t, string propertyName)
    {
        return TypeReflections.TypeCacheManager.GetTypeProperties(typeof(T)).FirstOrDefault(_ => _.Name == propertyName);
    }

    /// <summary>
    /// Get specified property, using the specified binding constraints. <br />
    /// 根据给定的名称获取指定可访问性的属性信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PropertyInfo GetProperty<T>(this T t, string propertyName, BindingFlags bindingAttr)
    {
        return typeof(T).GetProperty(propertyName, bindingAttr);
    }

    /// <summary>
    /// Get all public properties from the given object. <br />
    /// 从对象中获取所有公开的属性信息
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PropertyInfo[] GetProperties<T>(this T t)
    {
        return TypeReflections.TypeCacheManager.GetTypeProperties(typeof(T));
    }

    /// <summary>
    /// Get all specified properties from the given object, using the specified binding constraints. <br />
    /// 从对象中获取所有指定可访问性的属性信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="bindingAttr"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PropertyInfo[] GetProperties<T>(this T t, BindingFlags bindingAttr)
    {
        return typeof(T).GetProperties(bindingAttr);
    }

    /// <summary>
    /// Get public property or field from ths given object with the specified name. <br />
    /// 根据名称获取公开的属性或字段信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="memberName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static MemberInfo GetPropertyOrField<T>(this T t, string memberName)
    {
        var property = t.GetProperty(memberName);
        if (property is not null)
            return property;
        return t.GetField(memberName);
    }

    /// <summary>
    /// Get specified property or field, using the specified binding constraints. <br />
    /// 根据给定的名称获取指定可访问性的属性或字段信息
    /// </summary>
    /// <param name="t"></param>
    /// <param name="memberName"></param>
    /// <param name="bindingAttr"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static MemberInfo GetPropertyOrField<T>(this T t, string memberName, BindingFlags bindingAttr)
    {
        var property = t.GetProperty(memberName, bindingAttr);
        if (property is not null)
            return property;
        return t.GetField(memberName, bindingAttr);
    }
}