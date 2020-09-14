namespace Cosmos.Dynamic
{
    /// <summary>
    /// Dynamic Enum
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public abstract class DynamicEnum<TEnum> : DynamicEnum<TEnum, int>
        where TEnum : DynamicEnum<TEnum, int>
    {
        protected DynamicEnum(string name, int value) : base(name, value) { }
    }
}