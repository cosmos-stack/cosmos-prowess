namespace Cosmos.Dynamic.DynamicEnums
{
    /// <summary>
    /// Dynamic Enum
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public abstract class DynamicEnum<TEnum> : DynamicEnum<TEnum, int>
        where TEnum : DynamicEnum<TEnum, int>, IDynamicEnum
    {
        protected DynamicEnum(string name, int value) : base(name, value) { }
    }
}