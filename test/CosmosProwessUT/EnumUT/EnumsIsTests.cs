using Cosmos;
using CosmosProwessUT.EnumUT.Models;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.EnumUT
{
    [Trait("EnumUT", "EnumsIsTests")]
    public class EnumsIsTests
    {
        [Fact]
        public void GenericIsTest()
        {
            Enums.IsEnum<NiceEnum>().ShouldBeTrue();
        }

        [Fact]
        public void NormalTest()
        {
            Enums.IsEnum(typeof(NiceEnum)).ShouldBeTrue();
        }

        [Fact]
        public void ValueTest()
        {
            var m = NiceEnum.One;

            Enums.IsEnum(m).ShouldBeTrue();
            Enums.IsEnum(m, EnumCheckingOptions.Value).ShouldBeTrue();
            Enums.IsEnum(m, typeof(NiceEnum)).ShouldBeTrue();
            Enums.IsEnum(m, typeof(NiceEnum), EnumCheckingOptions.Value).ShouldBeTrue();
        }
    }
}