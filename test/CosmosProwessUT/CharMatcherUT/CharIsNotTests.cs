using Cosmos.CharMatchers;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.CharMatcherUT
{
    [Trait("CharMatcherUT", "CharIsNotTests")]
    public class CharIsNotTests
    {
        [Fact]
        public void ApplyTest()
        {
            CharMatcher.IsNot('m').Apply('m').ShouldBeFalse();
            CharMatcher.IsNot('m').Negate().Apply('m').ShouldBeTrue();
        }

        [Fact]
        public void CollapseFromTest()
        {
            CharMatcher.IsNot('m').CollapseFrom("Nice to meet you", 'y').ShouldBe("yyyyyyyymyyyyyyy");
            CharMatcher.IsNot('m').Negate().CollapseFrom("Nice to meet you", 'y').ShouldBe("Nice to yeet you");
        }

        [Fact]
        public void CountInTest()
        {
            CharMatcher.IsNot('m').CountIn("Nice to meet you").ShouldBe(1);
            CharMatcher.IsNot('m').Negate().CountIn("Nice to meet you").ShouldBe(1);
        }

        [Fact]
        public void ForPredicateTest()
        {
            CharMatcher.IsNot('m').ForPredicate(c => c == 'm').ShouldBeEmpty();
            CharMatcher.IsNot('m').ForPredicate(c => c == 'n').ShouldBe("m");
            CharMatcher.IsNot('m').Negate().ForPredicate(c => c == 'm').ShouldBe("m");
            CharMatcher.IsNot('m').Negate().ForPredicate(c => c == 'n').ShouldBeEmpty();
        }

        [Fact]
        public void IndexInTest()
        {
            CharMatcher.IsNot('m').IndexIn("Nice to meet you").ShouldBe(8);
            CharMatcher.IsNot('m').IndexIn("Nice to meet you", 5).ShouldBe(8);
            CharMatcher.IsNot('m').IndexIn("Nice to meet you", 9).ShouldBe(-1);
        }

        [Fact]
        public void InRangeTest()
        {
            CharMatcher.IsNot('m').InRange('l', 'n').ShouldBeEmpty();
            CharMatcher.IsNot('m').InRange('o', 'q').ShouldBe("m");
        }

        [Fact]
        public void RemoveFromTest()
        {
            CharMatcher.IsNot('m').RemoveFrom("Nice to meet you").ShouldBe("m");

            CharMatcher.IsNot('m').Negate().RemoveFrom("Nice to meet you").ShouldBe("Nice to eet you");
        }

        [Fact]
        public void ReplaceFromTest()
        {
            CharMatcher.IsNot('m').ReplaceFrom("Nice to meet you", 'n').ShouldBe("nnnnnnnnmnnnnnnn");
            CharMatcher.IsNot('m').ReplaceFrom("Nice to meet you", "__").ShouldBe("________________m______________");

            CharMatcher.IsNot('m').Negate().ReplaceFrom("Nice to meet you", 'n').ShouldBe("Nice to neet you");
            CharMatcher.IsNot('m').Negate().ReplaceFrom("Nice to meet you", "__").ShouldBe("Nice to __eet you");
        }

        [Fact]
        public void RetainFromTest()
        {
            CharMatcher.IsNot('m').RetainFrom("Nice to meet you").ShouldBe("Nice to eet you");
            CharMatcher.IsNot('m').Negate().RetainFrom("Nice to meet you").ShouldBe("m");
        }

        [Fact]
        public void TrimFromTest()
        {
            CharMatcher.IsNot('m').TrimFrom("Nice to meet you").ShouldBeEmpty();
            CharMatcher.IsNot('N').TrimFrom("Nice to meet you").ShouldBe("NN");
            CharMatcher.IsNot('u').TrimFrom("Nice to meet you").ShouldBe("uu");
        }

        [Fact]
        public void LastIndexInTest()
        {
            CharMatcher.IsNot('m').LastIndexIn("Nice to meet you").ShouldBe(8);
            CharMatcher.IsNot('m').Negate().LastIndexIn("Nice to meet you").ShouldBe(8);
        }

        [Fact]
        public void MatchesAllOfTest()
        {
            CharMatcher.IsNot('m').MatchesAllOf("Nice to meet you").ShouldBeTrue();
            CharMatcher.IsNot('m').MatchesAllOf("mmmmmmmmmmmmmmmmm").ShouldBeFalse();
            CharMatcher.IsNot('m').Negate().MatchesAllOf("Nice to meet you").ShouldBeFalse();
            CharMatcher.IsNot('m').Negate().MatchesAllOf("mmmmmmmmmmmmmmmmm").ShouldBeTrue();
        }

        [Fact]
        public void MatchesAnyOfTest()
        {
            CharMatcher.IsNot('m').MatchesAnyOf("Nice to meet you").ShouldBeFalse();
            CharMatcher.IsNot('m').Negate().MatchesAnyOf("Nice to meet you").ShouldBeTrue();
        }

        [Fact]
        public void TrimLeadingFormTest()
        {
            CharMatcher.IsNot('m').TrimLeadingForm("Nice to meet you").ShouldBeEmpty();
            CharMatcher.IsNot('N').TrimLeadingForm("Nice to meet you").ShouldBe("N");
            CharMatcher.IsNot('u').TrimLeadingForm("Nice to meet you").ShouldBeEmpty();
        }

        [Fact]
        public void TrimTrailingFromTest()
        {
            CharMatcher.IsNot('m').TrimTrailingFrom("Nice to meet you").ShouldBeEmpty();
            CharMatcher.IsNot('N').TrimTrailingFrom("Nice to meet you").ShouldBeEmpty();
            CharMatcher.IsNot('u').TrimTrailingFrom("Nice to meet you").ShouldBe("u");
        }

        [Fact]
        public void TrimAndCollapseFromTest()
        {
            CharMatcher.IsNot('m').TrimAndCollapseFrom("Nice to meet you", 'y').ShouldBeEmpty();
            CharMatcher.IsNot('N').TrimAndCollapseFrom("Nice to meet you", 'y').ShouldBe("NN");
            CharMatcher.IsNot('u').TrimAndCollapseFrom("Nice to meet you", 'y').ShouldBe("uu");
        }
    }
}