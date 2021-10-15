#if !NETFRAMEWORK

using CosmosProwessUT.EnumUT.Models;
using CosmosStack.EnumUtils;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.EnumUT
{
    [Trait("EnumUT", "FlagEnumTests")]
    public class FlagEnumTests
    {
        [Fact]
        public void AppendFlagEnumTest()
        {
            var week = WeekEnum.Monday;
            FlagEnums.Add(ref week, WeekEnum.Tuesday);

            (0 != (week & WeekEnum.Monday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Tuesday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Wednesday)).ShouldBeFalse();
        }

        [Fact]
        public void AppendFlagEnumCollTest()
        {
            var week = WeekEnum.Monday;
            FlagEnums.Add(ref week, WeekEnum.Tuesday, WeekEnum.Wednesday);

            (0 != (week & WeekEnum.Monday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Tuesday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Wednesday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Thursday)).ShouldBeFalse();
        }

        [Fact]
        public void RemoveFlagEnumTest()
        {
            var week = WeekEnum.Monday;
            FlagEnums.Add(ref week, WeekEnum.Tuesday);

            (0 != (week & WeekEnum.Monday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Tuesday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Wednesday)).ShouldBeFalse();

            FlagEnums.Remove(ref week, WeekEnum.Tuesday);

            (0 != (week & WeekEnum.Monday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Tuesday)).ShouldBeFalse();
            (0 != (week & WeekEnum.Wednesday)).ShouldBeFalse();
        }

        [Fact]
        public void RemoveFlagEnumCollTest()
        {
            var week = WeekEnum.Monday;
            FlagEnums.Add(ref week, WeekEnum.Tuesday, WeekEnum.Wednesday);

            (0 != (week & WeekEnum.Monday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Tuesday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Wednesday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Thursday)).ShouldBeFalse();

            FlagEnums.Remove(ref week, WeekEnum.Tuesday, WeekEnum.Wednesday);

            (0 != (week & WeekEnum.Monday)).ShouldBeTrue();
            (0 != (week & WeekEnum.Tuesday)).ShouldBeFalse();
            (0 != (week & WeekEnum.Wednesday)).ShouldBeFalse();
            (0 != (week & WeekEnum.Thursday)).ShouldBeFalse();
        }

        [Fact]
        public void ContainsFlagEnumTest()
        {
            var week = WeekEnum.Monday;
            
            FlagEnums.Contains(week, WeekEnum.Monday).ShouldBeTrue();
            FlagEnums.Contains(week, WeekEnum.Tuesday).ShouldBeFalse();
            
            FlagEnums.Add(ref week, WeekEnum.Tuesday, WeekEnum.Wednesday);
            
            FlagEnums.Contains(week, WeekEnum.Monday).ShouldBeTrue();
            FlagEnums.Contains(week, WeekEnum.Tuesday).ShouldBeTrue();
        }
    }
}

#endif