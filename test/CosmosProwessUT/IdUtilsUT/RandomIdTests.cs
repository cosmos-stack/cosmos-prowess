using Cosmos.IdUtils;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.IdUtilsUT
{
    [Trait("IdUtilsUT", "RandomIdTests")]
    public class RandomIdTests
    {
        [Fact]
        public void RandomIdTest()
        {
            var id1 = RandomIdGenerator.Create(16);
            var id2 = RandomIdGenerator.Create(16);

            id1.ShouldNotBeNullOrEmpty();
            id2.ShouldNotBeNullOrEmpty();

            id1.Length.ShouldBe(16);
            id2.Length.ShouldBe(16);

            id1.ShouldNotBe(id2);
        }

        [Fact]
        public void RandomNonceStrTest()
        {
            var nonceStr1 = RandomNonceStrGenerator.Create();
            var nonceStr2 = RandomNonceStrGenerator.Create();
            var nonceStr3 = RandomNonceStrGenerator.Create(true);
            var nonceStr4 = RandomNonceStrGenerator.Create(true);

            nonceStr1.ShouldNotBeNullOrEmpty();
            nonceStr2.ShouldNotBeNullOrEmpty();
            nonceStr3.ShouldNotBeNullOrEmpty();
            nonceStr4.ShouldNotBeNullOrEmpty();

            nonceStr1.Length.ShouldBe(16);
            nonceStr2.Length.ShouldBe(16);
            nonceStr3.Length.ShouldBe(16);
            nonceStr4.Length.ShouldBe(16);

#if NETFRAMEWORK
            nonceStr1.ShouldBe(nonceStr2);
#else
            nonceStr1.ShouldNotBe(nonceStr2);
#endif
            nonceStr3.ShouldNotBe(nonceStr4);
        }

        [Fact]
        public void RandomNonceStrWithLengthTest()
        {
            var nonceStr1 = RandomNonceStrGenerator.Create(16);
            var nonceStr2 = RandomNonceStrGenerator.Create(16);
            var nonceStr3 = RandomNonceStrGenerator.Create(true);
            var nonceStr4 = RandomNonceStrGenerator.Create(true);

            nonceStr1.ShouldNotBeNullOrEmpty();
            nonceStr2.ShouldNotBeNullOrEmpty();
            nonceStr3.ShouldNotBeNullOrEmpty();
            nonceStr4.ShouldNotBeNullOrEmpty();

            nonceStr1.Length.ShouldBe(16);
            nonceStr2.Length.ShouldBe(16);
            nonceStr3.Length.ShouldBe(16);
            nonceStr4.Length.ShouldBe(16);

#if NETFRAMEWORK
            nonceStr1.ShouldBe(nonceStr2);
#else
            nonceStr1.ShouldNotBe(nonceStr2);
#endif
            nonceStr3.ShouldNotBe(nonceStr4);
        }

        [Fact]
        public void SnowflakeGeneratorTest()
        {
            var worker1 = SnowflakeGenerator.Create(1, 2, 17);
            var worker2 = SnowflakeGenerator.Create(2, 2, 17);

            var id11 = worker1.NextId();
            var id12 = worker1.NextId();

            var id21 = worker2.NextId();
            var id22 = worker2.NextId();

            id11.ShouldNotBe(id12);
            id11.ShouldNotBe(id22);
            id21.ShouldNotBe(id12);
            id21.ShouldNotBe(id22);
        }
    }
}