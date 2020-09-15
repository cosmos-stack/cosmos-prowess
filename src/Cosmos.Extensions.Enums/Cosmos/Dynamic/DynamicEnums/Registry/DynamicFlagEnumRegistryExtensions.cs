using System;

namespace Cosmos.Dynamic.DynamicEnums.Registry
{
    public static class DynamicFlagEnumRegistryExtensions
    {
        public static void Init<TEnum, TValue>(this TEnum instance, DynamicEnumRegisterOptions options = DynamicEnumRegisterOptions.ScanGivenType)
            where TEnum : DynamicFlagEnum<TEnum, TValue>, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            DynamicFlagEnumRegistry.Register<TEnum, TValue>(options);
        }

        public static void RegisterSelf<TEnum, TValue>(this TEnum instance)
            where TEnum : DynamicFlagEnum<TEnum, TValue>, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            var members = DynamicEnumManager.GetFlagMembers<TEnum, TValue>();

            if (members is null)
            {
                instance.Init<TEnum, TValue>();
                return;
            }

            members.AddMember(instance);
        }

        public static void RegisterClazz<TEnum, TSubEnum, TValue>(this TSubEnum instance)
            where TEnum : DynamicFlagEnum<TEnum, TValue>, IDynamicEnum
            where TSubEnum : TEnum, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            var members = DynamicEnumManager.GetFlagMembers<TEnum, TValue>();

            if (members is null)
            {
                instance.Init<TEnum, TValue>();
                return;
            }

            var values = DynamicEnumMemberScanner.GetBuildInFieldsFromType<TEnum>(typeof(TSubEnum));
            members.AddMemberRange(values);
        }
    }
}