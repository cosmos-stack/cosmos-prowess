using System;

namespace Cosmos.Dynamic.DynamicEnums.Registry
{
    public static class DynamicFlagEnumRegistry
    {
        public static void Register<TEnum>(DynamicEnumRegisterOptions options = DynamicEnumRegisterOptions.ScanGivenType)
            where TEnum : DynamicFlagEnum<TEnum, int>, IDynamicEnum
        {
            Register<TEnum, int>(options);
        }

        public static void Register<TEnum, TValue>(DynamicEnumRegisterOptions options = DynamicEnumRegisterOptions.ScanGivenType)
            where TEnum : DynamicFlagEnum<TEnum, TValue>, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            var members = DynamicEnumManager.GetFlagMembers<TEnum, TValue>();
            var created = members is null;

            if (created)
                members = new DynamicFlagEnumMembers<TEnum, TValue>();

            if (options == DynamicEnumRegisterOptions.ScanGivenType)
            {
                var values = DynamicEnumMemberScanner.GetBuildInFieldsFromType<TEnum>(typeof(DynamicFlagEnum<TEnum, TValue>));
                members.AddMemberRange(values);
            }
            else if (options == DynamicEnumRegisterOptions.ScanAssembly)
            {
                var values = DynamicEnumMemberScanner.GetBuildInValuesFromAssembly<TEnum, TValue>();
                members.AddMemberRange(values);
            }

            if (created)
                DynamicEnumManager.SetFlagMembers(members);
        }
    }
}