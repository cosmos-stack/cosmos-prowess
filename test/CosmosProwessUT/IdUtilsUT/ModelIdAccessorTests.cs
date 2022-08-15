using Cosmos.IdUtils;

namespace CosmosProwessUT.IdUtilsUT;

[Trait("IdUtilsUT", "ModelIdAccessorTests")]
public class ModelIdAccessorTests
{
    [Fact]
    public void ModelIdAccessorTest()
    {
        var accessor = new ModelIdAccessor();

        accessor.GetNextIndex().ShouldBe(0);
        accessor.GetNextIndex().ShouldBe(1);
        accessor.GetNextIndex().ShouldBe(2);
        accessor.GetNextIndex().ShouldBe(3);
        accessor.GetNextIndex().ShouldBe(4);
        accessor.GetNextIndex().ShouldBe(5);
    }
}