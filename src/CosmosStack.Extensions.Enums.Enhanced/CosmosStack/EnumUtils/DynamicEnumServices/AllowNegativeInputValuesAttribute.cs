using System;

namespace CosmosStack.EnumUtils.DynamicEnumServices
{
    /// <summary>
    /// Allow negative input values attribute <br />
    /// 允许输入负值特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AllowNegativeInputValuesAttribute : Attribute { }
}