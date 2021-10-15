#if !NETFRAMEWORK

using System;
using CosmosStack.Reflection;

namespace CosmosStack.EnumUtils
{
    /// <summary>
    /// Enum Utilities <br />
    /// 枚举工具
    /// </summary>
    public static class FlagEnums
    {
        static FlagEnums()
        {
            NatashaInitializer.InitializeAndPreheating();
        }

        private static class FlagEnumHelper<TEnum> where TEnum : struct, Enum
        {
            static FlagEnumHelper()
            {
                AppendEnumValueFunction = NDelegate.RandomDomain().Func<TEnum, TEnum[], TEnum>("foreach(var item in arg2){ arg1 = arg1 | item;} return arg1;");
                RemoveEnumValueFunction = NDelegate.RandomDomain().Func<TEnum, TEnum[], TEnum>("foreach(var item in arg2){ arg1 = arg1 & ~item;} return arg1;");
                ContainsEnumValueFunction = NDelegate.RandomDomain().Func<TEnum, TEnum, bool>("return 0 != (arg1 & arg2);");
            }

            public static readonly Func<TEnum, TEnum[], TEnum> AppendEnumValueFunction;
            public static readonly Func<TEnum, TEnum[], TEnum> RemoveEnumValueFunction;
            public static readonly Func<TEnum, TEnum, bool> ContainsEnumValueFunction;
        }


        /// <summary>
        /// Add additional values to enumerated values marked with Flag <br />
        /// 向标记有 Flag 的枚举值中增加额外的值
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="enumValSet"></param>
        /// <typeparam name="TEnum"></typeparam>
        public static void Add<TEnum>(ref TEnum @enum, params TEnum[] enumValSet) where TEnum : struct, Enum
        {
            if (typeof(TEnum).IsEnum && Types.IsAttributeDefined<FlagsAttribute>(typeof(TEnum)))
            {
                @enum = FlagEnumHelper<TEnum>.AppendEnumValueFunction.Invoke(@enum, enumValSet);
            }
        }

        /// <summary>
        /// Remove the specified value from the enumeration value marked with Flag <br />
        /// 从标记有 Flag 的枚举值中移除指定的值
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="enumValSet"></param>
        /// <typeparam name="TEnum"></typeparam>
        public static void Remove<TEnum>(ref TEnum @enum, params TEnum[] enumValSet) where TEnum : struct, Enum
        {
            if (typeof(TEnum).IsEnum && Types.IsAttributeDefined<FlagsAttribute>(typeof(TEnum)))
            {
                @enum = FlagEnumHelper<TEnum>.RemoveEnumValueFunction.Invoke(@enum, enumValSet);
            }
        }

        /// <summary>
        /// Check whether the specified value is included in the enumeration value marked with Flag <br />
        /// 砸标记有 Flag 的枚举值中检查是否包含指定的值
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="anotherEnum"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static bool Contains<TEnum>(TEnum @enum, TEnum anotherEnum) where TEnum : struct, Enum
        {
            if (typeof(TEnum).IsEnum && Types.IsAttributeDefined<FlagsAttribute>(typeof(TEnum)))
            {
                return FlagEnumHelper<TEnum>.ContainsEnumValueFunction.Invoke(@enum, anotherEnum);
            }

            return false;
        }
    }
}

#endif