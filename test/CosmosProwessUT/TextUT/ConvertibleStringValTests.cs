using System;
using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.TextUT
{
    [Trait("TextUT", "ConvertibleStringVal")]
    public class ConvertibleStringValTests
    {
        [Fact]
        public void DateTimeTest()
        {
            var today = DateTime.Today;
            var str = ConvertibleStringVal.Of(today);

            str.Is<DateTime>().ShouldBeTrue();
            str.As<DateTime>().Date.ShouldBe(today);
        }

        [Fact]
        public void NumericStringTest()
        {
            var str = ConvertibleStringVal.Of("1");

            str.Is<int>().ShouldBeTrue();
            str.Is<long>().ShouldBeTrue();
            str.Is<short>().ShouldBeTrue();

            str.As<int>().ShouldBe(1);
            str.As<long>().ShouldBe(1);
            str.As<short>().ShouldBe((short) 1);
        }

        [Fact]
        public void MayBeTest()
        {
            var s = ConvertibleStringVal.Of("1");
            // ReSharper disable once InconsistentNaming
            var m_d = s.AsOptionals<DateTime>();
            // ReSharper disable once InconsistentNaming
            var m_int32 = s.AsOptionals<int>();

            m_d.HasValue.ShouldBeTrue();
            m_d.Value.ShouldBe(new DateTime(0));

            m_int32.HasValue.ShouldBeTrue();
            m_int32.Value.ShouldBe(1);
        }
    }
}