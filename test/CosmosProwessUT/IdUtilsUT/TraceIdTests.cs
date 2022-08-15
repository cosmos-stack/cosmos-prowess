using Cosmos.IdUtils;

namespace CosmosProwessUT.IdUtilsUT;

[Trait("IdUtilsUT", "TraceIdAccessor")]
public class TraceIdTests
{
    [Fact]
    public void TraceIdAccessorTest()
    {
        var accessor1 = new TraceIdAccessor(null);
        var accessor2 = new TraceIdAccessor(null);

        var id1 = accessor1.GetTraceId();
        var id2 = accessor2.GetTraceId();

        id1.ShouldNotBe(id2);
    }
}