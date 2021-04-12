#if !NETFRAMEWORK

using System;
using Cosmos.Reflection;
using Natasha.CSharp;

namespace Cosmos
{
    public static class FlagEnums
    {
        static FlagEnums()
        {
            NatashaInitializer.InitializeAndPreheating();
        }

        public static void Add<TEnum>(ref TEnum @enum, params TEnum[] enumValSet) where TEnum : struct, Enum
        {
            if (typeof(TEnum).IsEnum && Types.IsAttributeDefined<FlagsAttribute>(typeof(TEnum)))
            {
                @enum = NDelegate.RandomDomain().Func<TEnum, TEnum[], TEnum>("foreach(var item in arg2){ arg1 = arg1 | item;} return arg1;").Invoke(@enum, enumValSet);
            }
        }

        public static void Remove<TEnum>(ref TEnum @enum, params TEnum[] enumValSet) where TEnum : struct, Enum
        {
            if (typeof(TEnum).IsEnum && Types.IsAttributeDefined<FlagsAttribute>(typeof(TEnum)))
            {
                @enum = NDelegate.RandomDomain().Func<TEnum, TEnum[], TEnum>("foreach(var item in arg2){ arg1 = arg1 & ~item;} return arg1;").Invoke(@enum, enumValSet);
            }
        }

        public static bool Contains<TEnum>(TEnum @enum, TEnum anotherEnum) where TEnum : struct, Enum
        {
            if (typeof(TEnum).IsEnum && Types.IsAttributeDefined<FlagsAttribute>(typeof(TEnum)))
            {
                return NDelegate.RandomDomain().Func<TEnum, TEnum, bool>("return 0 != (arg1 & arg2);").Invoke(@enum, anotherEnum);
            }

            return false;
        }
    }
}

#endif