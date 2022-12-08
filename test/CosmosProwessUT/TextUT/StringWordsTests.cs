using System.Linq;
using Cosmos.Text;

namespace CosmosProwessUT.TextUT;

[Trait("StringUT", "Strings.Words")]
public class StringWordsTests
{
    [Fact(DisplayName = "String/Words CapitalCase test")]
    public void CapitalCaseTest()
    {
        var text = "nice to meet you, AlexLEWIS";
        StringWords.ToCapitalCase(text).ShouldBe("Nice To Meet You, Alexlewis");
    }

    [Fact(DisplayName = "String/Words CamelCase test")]
    public void CamelCaseTest()
    {
        var text = "AlexLEWIS DuDuDu";
        StringWords.ToCapitalCase(text).ShouldBe("Alexlewis Dududu");
    }

    [Fact(DisplayName = "String/Words CountByWords test")]
    public void CountByWordsTest()
    {
        var text = "Nice to meet you";
        StringWords.CountByWords(text).ShouldBe(4);
    }

    [Fact(DisplayName = "String/Words SplitByWords test")]
    public void SplitByWordsTest()
    {
        var text = "Nice to meet you";
        var vals = StringWords.SplitByWords(text).ToList();

        vals.Count.ShouldBe(4);
    }

    [Fact(DisplayName = "String/Words TruncateByWords test")]
    public void TruncateByWordsTest()
    {
        var text = "Nice to meet you";
        StringWords.TruncateByWords(text, 3).ShouldBe("Nice to meet...");
        StringWords.TruncateByWords(text, 3, extraSpace: true).ShouldBe("Nice to meet ...");
    }
}