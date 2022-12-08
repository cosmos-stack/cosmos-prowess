using Cosmos.Text;

namespace CosmosProwessUT.TextUT;

[Trait("StringUT", "Strings.Additional")]
public class StringTruncateTests
{
    [Fact(DisplayName = "Truncate test")]
    public void TruncateTest()
    {
        var str = "Nietooo";

        str.Truncate(8).ShouldBe("Nietooo");
        str.Truncate(7).ShouldBe("Nietooo");
        str.Truncate(6).ShouldBe("Nie...");
        str.Truncate(5).ShouldBe("Ni...");
        str.Truncate(4).ShouldBe("N...");
        str.Truncate(3).ShouldBe("Ni.");
    }
}