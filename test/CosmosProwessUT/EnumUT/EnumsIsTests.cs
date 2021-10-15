using CosmosProwessUT.EnumUT.Models;
using CosmosStack.EnumUtils;
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
            EnumVisit.IsEnum<NiceEnum>().ShouldBeTrue();
        }

        [Fact]
        public void NormalTest()
        {
            EnumVisit.IsEnum(typeof(NiceEnum)).ShouldBeTrue();
        }

        [Fact]
        public void ValueTest()
        {
            var m = NiceEnum.One;

            EnumVisit.IsEnum(m).ShouldBeTrue();
            EnumVisit.IsEnum(m, EnumVisitOptions.For.Value()).ShouldBeTrue();
            EnumVisit.IsEnum(m, typeof(NiceEnum)).ShouldBeTrue();
            EnumVisit.IsEnum(m, typeof(NiceEnum), EnumVisitOptions.For.Value()).ShouldBeTrue();
        }
    }
}