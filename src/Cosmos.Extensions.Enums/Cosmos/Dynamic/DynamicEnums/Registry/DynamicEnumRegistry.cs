using System;

namespace Cosmos.Dynamic.DynamicEnums.Registry
{
    public static class DynamicEnumRegistry
    {
        public static void Register<TEnum>(DynamicEnumRegisterOptions options = DynamicEnumRegisterOptions.ScanGivenType)
            where TEnum : DynamicEnum<TEnum, int>, IDynamicEnum
        {
            Register<TEnum, int>(options);
        }

        public static void Register<TEnum, TValue>(DynamicEnumRegisterOptions options = DynamicEnumRegisterOptions.ScanGivenType)
            where TEnum : DynamicEnum<TEnum, TValue>, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            var members = DynamicEnumManager.GetMembers<TEnum, TValue>();
            var created = members is null;

            if (created)
                members = new DynamicEnumMembers<TEnum, TValue>();

            if (options == DynamicEnumRegisterOptions.ScanGivenType)
            {
                var values = DynamicEnumMemberScanner.GetBuildInFieldsFromType<TEnum>(typeof(DynamicEnum<TEnum, TValue>));
                members.AddMemberRange(values);
            }
            else if (options == DynamicEnumRegisterOptions.ScanAssembly)
            {
                var values = DynamicEnumMemberScanner.GetBuildInValuesFromAssembly<TEnum, TValue>();
                members.AddMemberRange(values);
            }

            if (created)
                DynamicEnumManager.SetMembers(members);
        }
    }
}