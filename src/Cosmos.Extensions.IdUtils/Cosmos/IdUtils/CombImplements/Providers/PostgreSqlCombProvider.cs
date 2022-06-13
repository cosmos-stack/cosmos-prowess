using Cosmos.Collections;
using Cosmos.IdUtils.CombImplements.Strategies;

namespace Cosmos.IdUtils.CombImplements.Providers;

internal class PostgreSqlCombProvider : BaseProvider
{
    public PostgreSqlCombProvider(IDateStrategy strategy,
        InternalTimeStampProvider customTimeStampProvider = null,
        InternalGuidProvider customGuidProvider = null)
        : base(strategy, customTimeStampProvider, customGuidProvider) { }

    public override Guid Create(Guid value, DateTime timestamp)
    {
        var gbytes = value.ToByteArray();
        var dbytes = _dateTimeStrategy.DateTimeToBytes(timestamp);

        dbytes.Copy(0, gbytes, 0, _dateTimeStrategy.NumDateBytes);

        SwapByteOrderForStringOrder(gbytes);

        return new Guid(gbytes);
    }

    public override DateTime GetTimeStamp(Guid value)
    {
        var gbytes = value.ToByteArray();
        var dbytes = new byte[_dateTimeStrategy.NumDateBytes];

        SwapByteOrderForStringOrder(gbytes);

        gbytes.Copy(0, dbytes, 0, _dateTimeStrategy.NumDateBytes);

        return _dateTimeStrategy.BytesToDateTime(dbytes);
    }

    private void SwapByteOrderForStringOrder(byte[] input)
    {
        input.Reverse(0, 4);
        if (input.Length == 4)
            return;

        input.Reverse(4, 2);
    }
}