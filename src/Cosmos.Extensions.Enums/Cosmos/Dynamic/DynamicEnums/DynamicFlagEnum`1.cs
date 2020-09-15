namespace Cosmos.Dynamic.DynamicEnums
{
    public abstract class DynamicFlagEnum<TEnum> : DynamicFlagEnum<TEnum, int>, IDynamicEnum
        where TEnum : DynamicFlagEnum<TEnum, int>, IDynamicEnum
    {
        protected DynamicFlagEnum(string name, int value) : base(name, value) { }
    }
}