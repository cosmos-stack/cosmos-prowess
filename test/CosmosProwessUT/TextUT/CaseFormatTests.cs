using Cosmos.Text;

namespace CosmosProwessUT.TextUT;

[Trait("TextUT", "CaseFormatTests")]
public class CaseFormatTests
{
    [Fact]
    public void LowerCamelTest()
    {
        var caseFormat = CaseFormat.Instance;
        caseFormat.To(CaseFormat.Style.LOWER_CAMEL, "Nice To See You").ShouldBe("niceToSeeYou");
    }
    [Fact]
    public void LowerCamelWithWhiteSpaceTest()
    {
        var caseFormat = CaseFormat.Instance;
        caseFormat.To(CaseFormat.Style.LOWER_CAMEL_WITH_WHITESPACE, "Nice To See You").ShouldBe("nice To See You");
    }

    [Fact]
    public void LowerHyphenTest()
    {
        var caseFormat = CaseFormat.Instance;
        caseFormat.To(CaseFormat.Style.LOWER_HYPHEN, "Nice To See You").ShouldBe("nice-to-see-you");
    }

    [Fact]
    public void LowerUnderscoreTest()
    {
        var caseFormat = CaseFormat.Instance;
        caseFormat.To(CaseFormat.Style.LOWER_UNDERSCORE, "Nice To See You").ShouldBe("nice_to_see_you");
    }

    [Fact]
    public void UpperCamelTest()
    {
        var caseFormat = CaseFormat.Instance;
        caseFormat.To(CaseFormat.Style.UPPER_CAMEL, "Nice To See You").ShouldBe("NiceToSeeYou");
    }

    [Fact]
    public void UpperCamelWithWhiteSpacTest()
    {
        var caseFormat = CaseFormat.Instance;
        caseFormat.To(CaseFormat.Style.UPPER_CAMEL_WITH_WHITESPACE, "Nice To See You").ShouldBe("Nice To See You");
    }

    [Fact]
    public void UpperUnderscoreTest()
    {
        var caseFormat = CaseFormat.Instance;
        caseFormat.To(CaseFormat.Style.UPPER_UNDERSCORE, "Nice To See You").ShouldBe("NICE_TO_SEE_YOU");
    }
}