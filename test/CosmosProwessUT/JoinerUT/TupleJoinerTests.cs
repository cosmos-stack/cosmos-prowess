﻿using System.Collections.Generic;
using CosmosStack.Text.Joiners;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.JoinerUT
{
    [Trait("JoinerUT", "TupleJoiner")]
    public class TupleJoinerTests
    {
        private static class OriginalMaterials
        {
            public static List<(string, string)> NormalTupleList { get; } = new() {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("e", "5")};
            public static List<(string, string)> IncludeWhiteSpaceKvTupleList { get; } = new() {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("e", "")};
            public static List<(string, string)> IncludeNullKvTupleList { get; } = new() {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("e", string.Empty)};
            public static List<(string, string)> IncludeEmptyKvTupleList { get; } = new() {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("e", null)};
            public static List<(string, string)> IncludeWhiteSpaceValueTupleList { get; } = new() {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("", "")};

            public static List<(string, string)> IncludeNullValueTupleList { get; } = new() {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), (string.Empty, string.Empty)};

            public static List<(string, string)> IncludeEmptyValueTupleList { get; } = new() {("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), (null, null)};
        }


        [Fact]
        public void TupleToStringTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().Join(OriginalMaterials.NormalTupleList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }


        [Fact]
        public void TupleToStringWithWhiteSpaceKvAndReplacerTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((_, _) => "NullKey", (_, _) => "NullValue")
                            .Join(OriginalMaterials.IncludeWhiteSpaceKvTupleList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=NullValue");
        }

        [Fact]
        public void TupleToStringWithNullKvAndReplacerTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((_, _) => "NullKey", (_, _) => "NullValue")
                            .Join(OriginalMaterials.IncludeNullKvTupleList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=NullValue");
        }

        [Fact]
        public void TupleToStringWithEmptyKvAndReplacerTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((_, _) => "NullKey", (_, _) => "NullValue")
                            .Join(OriginalMaterials.IncludeEmptyKvTupleList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=NullValue");
        }

        [Fact]
        public void TupleToStringWithWhiteSpaceValueAndReplacerTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((_, _) => "NullKey", (_, _) => "NullValue")
                            .Join(OriginalMaterials.IncludeWhiteSpaceValueTupleList);
            str.ShouldBe("a=1&b=2&c=3&d=4&NullKey=NullValue");
        }

        [Fact]
        public void TupleToStringWithNullValueAndReplacerTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((_, _) => "NullKey", (_, _) => "NullValue")
                            .Join(OriginalMaterials.IncludeNullValueTupleList);
            str.ShouldBe("a=1&b=2&c=3&d=4&NullKey=NullValue");
        }

        [Fact]
        public void TupleToStringWithEmptyValueAndReplacerTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((_, _) => "NullKey", (_, _) => "NullValue")
                            .Join(OriginalMaterials.IncludeEmptyValueTupleList);
            str.ShouldBe("a=1&b=2&c=3&d=4&NullKey=NullValue");
        }
    }
}