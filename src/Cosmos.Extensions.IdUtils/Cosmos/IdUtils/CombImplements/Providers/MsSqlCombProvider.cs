using Cosmos.Collections;
using Cosmos.IdUtils.CombImplements.Strategies;

namespace Cosmos.IdUtils.CombImplements.Providers;

internal class MsSqlCombProvider : BaseProvider
{
    private const int EMBED_AT_INDEX = 10;

    public MsSqlCombProvider(IDateStrategy strategy,
        InternalTimeStampProvider customTimeStampProvider = null,
        InternalGuidProvider customGuidProvider = null)
        : base(strategy, customTimeStampProvider, customGuidProvider) { }

    public override Guid Create(Guid value, DateTime timestamp)
    {
        var gbytes = value.ToByteArray();
        var dbytes = _dateTimeStrategy.DateTimeToBytes(timestamp);

        dbytes.Copy(0, gbytes, EMBED_AT_INDEX, _dateTimeStrategy.NumDateBytes);

        return new Guid(gbytes);
    }

    public override DateTime GetTimeStamp(Guid value)
    {
        var gbytes = value.ToByteArray();
        var dbytes = new byte[_dateTimeStrategy.NumDateBytes];

        gbytes.Copy(EMBED_AT_INDEX, dbytes, 0, _dateTimeStrategy.NumDateBytes);

        return _dateTimeStrategy.BytesToDateTime(dbytes);
    }
}