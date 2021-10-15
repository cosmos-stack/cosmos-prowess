using System;
using System.Reflection;

namespace CosmosStack.Reflection
{
    /// <summary>
    /// Property Value Getter <br />
    /// 属性值获取器接口
    /// </summary>
    public interface IPropertyValueGetter
    {
        /// <summary>
        /// Invoke <br />
        /// 调用
        /// </summary>
        /// <param name="type"></param>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        object Invoke(Type type, object that, string propertyName);

        /// <summary>
        /// Invoke <br />
        /// 调用
        /// </summary>
        /// <param name="type"></param>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <returns></returns>
        object Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr);
    }
}