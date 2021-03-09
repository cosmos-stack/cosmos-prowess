using Cosmos.CharMatchers;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.CharMatcherUT
{
    [Trait("CharMatcherUT", "CharIsTests")]
    public class CharIsTests
    {
        [Fact]
        public void ApplyTest()
        {
            CharMatcher.Is('m').Apply('m').ShouldBeTrue();
            CharMatcher.Is('m').Negate().Apply('m').ShouldBeFalse();
        }

        [Fact]
        public void CollapseFromTest()
        {
            CharMatcher.Is('m').CollapseFrom("Nice to meet you", 'y').ShouldBe("Nice to yeet you");
            CharMatcher.Is('m').Negate().CollapseFrom("Nice to meet you", 'y').ShouldBe("yyyyyyyymyyyyyyy");
        }

        [Fact]
        public void CountInTest()
        {
            CharMatcher.Is('m').CountIn("Nice to meet you").ShouldBe(1);
            CharMatcher.Is('m').Negate().CountIn("Nice to meet you").ShouldBe(1);
        }

        [Fact]
        public void ForPredicateTest()
        {
            CharMatcher.Is('m').ForPredicate(c => c == 'm').ShouldBe("m");
            CharMatcher.Is('m').ForPredicate(c => c == 'n').ShouldBeEmpty();
            CharMatcher.Is('m').Negate().ForPredicate(c => c == 'm').ShouldBeEmpty();
            CharMatcher.Is('m').Negate().ForPredicate(c => c == 'n').ShouldBe("m");
        }

        [Fact]
        public void IndexInTest()
        {
            CharMatcher.Is('m').IndexIn("Nice to meet you").ShouldBe(8);
            CharMatcher.Is('m').IndexIn("Nice to meet you", 5).ShouldBe(8);
            CharMatcher.Is('m').IndexIn("Nice to meet you", 9).ShouldBe(-1);
        }

        [Fact]
        public void InRangeTest()
        {
            CharMatcher.Is('m').InRange('l', 'n').ShouldBe("m");
            CharMatcher.Is('m').InRange('o', 'q').ShouldBeEmpty();
        }

        [Fact]
        public void RemoveFromTest()
        {
            CharMatcher.Is('m').RemoveFrom("Nice to meet you").ShouldBe("Nice to eet you");

            CharMatcher.Is('m').Negate().RemoveFrom("Nice to meet you").ShouldBe("m");
        }

        [Fact]
        public void ReplaceFromTest()
        {
            CharMatcher.Is('m').ReplaceFrom("Nice to meet you", 'n').ShouldBe("Nice to neet you");
            CharMatcher.Is('m').ReplaceFrom("Nice to meet you", "__").ShouldBe("Nice to __eet you");

            CharMatcher.Is('m').Negate().ReplaceFrom("Nice to meet you", 'n').ShouldBe("nnnnnnnnmnnnnnnn");
            CharMatcher.Is('m').Negate().ReplaceFrom("Nice to meet you", "__").ShouldBe("________________m______________");
        }

        [Fact]
        public void RetainFromTest()
        {
            CharMatcher.Is('m').RetainFrom("Nice to meet you").ShouldBe("m");
            CharMatcher.Is('m').Negate().RetainFrom("Nice to meet you").ShouldBe("Nice to eet you");
        }

        [Fact]
        public void TrimFromTest()
        {
            CharMatcher.Is('m').TrimFrom("Nice to meet you").ShouldBe("Nice to meet you");
            CharMatcher.Is('N').TrimFrom("Nice to meet you").ShouldBe("ice to meet you");
            CharMatcher.Is('u').TrimFrom("Nice to meet you").ShouldBe("Nice to meet yo");
        }

        [Fact]
        public void LastIndexInTest()
        {
            CharMatcher.Is('m').LastIndexIn("Nice to meet you").ShouldBe(8);
            CharMatcher.Is('m').Negate().LastIndexIn("Nice to meet you").ShouldBe(8);
        }

        [Fact]
        public void MatchesAllOfTest()
        {
            CharMatcher.Is('m').MatchesAllOf("Nice to meet you").ShouldBeFalse();
            CharMatcher.Is('m').MatchesAllOf("mmmmmmmmmmmmmmmmm").ShouldBeTrue();
            CharMatcher.Is('m').Negate().MatchesAllOf("Nice to meet you").ShouldBeTrue();
            CharMatcher.Is('m').Negate().MatchesAllOf("mmmmmmmmmmmmmmmmm").ShouldBeFalse();
        }

        [Fact]
        public void MatchesAnyOfTest()
        {
            CharMatcher.Is('m').MatchesAnyOf("Nice to meet you").ShouldBeTrue();
            CharMatcher.Is('m').Negate().MatchesAnyOf("Nice to meet you").ShouldBeFalse();
        }

        [Fact]
        public void TrimLeadingFormTest()
        {
            CharMatcher.Is('m').TrimLeadingForm("Nice to meet you").ShouldBe("Nice to meet you");
            CharMatcher.Is('N').TrimLeadingForm("Nice to meet you").ShouldBe("ice to meet you");
            CharMatcher.Is('u').TrimLeadingForm("Nice to meet you").ShouldBe("Nice to meet you");
        }

        [Fact]
        public void TrimTrailingFromTest()
        {
            CharMatcher.Is('m').TrimTrailingFrom("Nice to meet you").ShouldBe("Nice to meet you");
            CharMatcher.Is('N').TrimTrailingFrom("Nice to meet you").ShouldBe("Nice to meet you");
            CharMatcher.Is('u').TrimTrailingFrom("Nice to meet you").ShouldBe("Nice to meet yo");
        }

        [Fact]
        public void TrimAndCollapseFromTest()
        {
            CharMatcher.Is('m').TrimAndCollapseFrom("Nice to meet you", 'y').ShouldBe("Nice to yeet you");
            CharMatcher.Is('N').TrimAndCollapseFrom("Nice to meet you", 'y').ShouldBe("ice to meet you");
            CharMatcher.Is('u').TrimAndCollapseFrom("Nice to meet you", 'y').ShouldBe("Nice to meet yo");
        }
    }
}