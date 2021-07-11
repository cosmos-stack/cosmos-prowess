using System.Linq;
using System.Reflection;

namespace Cosmos.Reflection
{
    public static class PropertyMetaExtensions
    {
        /// <summary>
        /// Get public field with the specified name
        /// </summary>
        /// <param name="t"></param>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FieldInfo GetField<T>(this T t, string propertyName)
        {
            return TypeReflections.TypeCacheManager.GetTypeFields(typeof(T)).FirstOrDefault(_ => _.Name == propertyName);
        }

        /// <summary>
        /// Get specified field, using the specified binding constraints.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FieldInfo GetField<T>(this T t, string propertyName, BindingFlags bindingAttr)
        {
            return typeof(T).GetField(propertyName, bindingAttr);
        }

        /// <summary>
        /// Get all public fields from the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static FieldInfo[] GetFields(this object obj)
        {
            ObjectGuard.NotNull(obj, nameof(obj));
            return TypeReflections.TypeCacheManager.GetTypeFields(obj.GetType());
        }

        /// <summary>
        /// Get all specified fields from the given object, using the specified binding constraints.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bindingAttr"></param>
        /// <returns></returns>
        public static FieldInfo[] GetFields(this object obj, BindingFlags bindingAttr)
        {
            ObjectGuard.NotNull(obj, nameof(obj));
            return obj.GetType().GetFields(bindingAttr);
        }

        /// <summary>
        /// Get public method with ths specified name.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="methodName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MethodInfo GetMethod<T>(this T t, string methodName)
        {
            return TypeReflections.TypeCacheManager.TypeMethodCache.GetOrAdd(typeof(T), t => t.GetMethods()).First(_ => _.Name == methodName);
        }

        /// <summary>
        /// Get specified method, using the specified binding constraints.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="methodName"></param>
        /// <param name="bindingAttr"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MethodInfo GetMethod<T>(this T t, string methodName, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(methodName, bindingAttr);
        }

        /// <summary>
        /// Get all public methods from the given object.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static MethodInfo[] GetMethods<T>(this T t)
        {
            return TypeReflections.TypeCacheManager.TypeMethodCache.GetOrAdd(typeof(T), _ => _.GetMethods());
        }

        /// <summary>
        /// Get all specified methods from the given object, using the specified binding constraints.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="bindingAttr"></param>
        /// <returns></returns>
        public static MethodInfo[] GetMethods<T>(this T t, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethods(bindingAttr);
        }
        
        /// <summary>
        /// Get public property with ths specified name.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PropertyInfo GetProperty<T>(this T t, string propertyName)
        {
            return TypeReflections.TypeCacheManager.GetTypeProperties(typeof(T)).FirstOrDefault(_ => _.Name == propertyName);
        }

        /// <summary>
        /// Get specified property, using the specified binding constraints.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PropertyInfo GetProperty<T>(this T t, string propertyName, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(propertyName, bindingAttr);
        }

        /// <summary>
        /// Get all public properties from the given object.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties<T>(this T t)
        {
            return TypeReflections.TypeCacheManager.GetTypeProperties(typeof(T));
        }

        /// <summary>
        /// Get all specified properties from the given object, using the specified binding constraints.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="bindingAttr"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties<T>(this T t, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperties(bindingAttr);
        }

        /// <summary>
        /// Get public property or field from ths given object with the specified name.
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
    }
}