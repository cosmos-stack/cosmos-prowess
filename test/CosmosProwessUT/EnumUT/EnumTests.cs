using System.Linq;
using CosmosProwessUT.EnumUT.Models;
using Cosmos.EnumUtils;

namespace CosmosProwessUT.EnumUT;

[Trait("EnumUT", "EnumTests")]
public class EnumTests
{
    [Fact]
    public void EnumOfTest()
    {
        Enums.Of<NiceEnum>("One", NiceEnum.Ten).ShouldBe(NiceEnum.One);
        Enums.Of<NiceEnum>("one", true, NiceEnum.Ten).ShouldBe(NiceEnum.One);
        Enums.Of<NiceEnum>("Ooo", NiceEnum.Ten).ShouldBe(NiceEnum.Ten);
    }

    [Fact]
    public void EnumOfObjectTest()
    {
        Enums.Of("One", typeof(NiceEnum), NiceEnum.Ten).ShouldBe(NiceEnum.One);
        Enums.Of("one", typeof(NiceEnum), true, NiceEnum.Ten).ShouldBe(NiceEnum.One);
        Enums.Of("Ooo", typeof(NiceEnum), NiceEnum.Ten).ShouldBe(NiceEnum.Ten);
    }

    [Fact]
    public void GetNameTest()
    {
        Enums.NameOf(NiceEnum.One).ShouldBe("One");
        Enums.NameOf(typeof(NiceEnum), NiceEnum.One).ShouldBe("One");
    }

    [Fact]
    public void CountTest()
    {
        Enums.Count<NiceEnum>().ShouldBe(11);
    }

    [Fact]
    public void GetValuesTest()
    {
        var values = Enums.GetValues<NiceEnum>().ToList();

        values.ShouldNotBeNull();
        values.ShouldContain(NiceEnum.One);
        values.ShouldContain(NiceEnum.Two);
        values.ShouldContain(NiceEnum.Three);
        values.ShouldContain(NiceEnum.Four);
        values.ShouldContain(NiceEnum.Five);
        values.ShouldContain(NiceEnum.Six);
        values.ShouldContain(NiceEnum.Seven);
        values.ShouldContain(NiceEnum.Eight);
        values.ShouldContain(NiceEnum.Nigh);
        values.ShouldContain(NiceEnum.Ten);
        values.ShouldContain(NiceEnum.Eleven);
    }

    [Fact]
    public void GetValuesObjectTest()
    {
        var values = Enums.GetValues(typeof(NiceEnum)).ToList();

        values.ShouldNotBeNull();
        values.ShouldContain(NiceEnum.One);
        values.ShouldContain(NiceEnum.Two);
        values.ShouldContain(NiceEnum.Three);
        values.ShouldContain(NiceEnum.Four);
        values.ShouldContain(NiceEnum.Five);
        values.ShouldContain(NiceEnum.Six);
        values.ShouldContain(NiceEnum.Seven);
        values.ShouldContain(NiceEnum.Eight);
        values.ShouldContain(NiceEnum.Nigh);
        values.ShouldContain(NiceEnum.Ten);
        values.ShouldContain(NiceEnum.Eleven);
    }
}