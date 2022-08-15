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

        Array.Copy(dbytes, 0, gbytes, 0, _dateTimeStrategy.NumDateBytes);

        SwapByteOrderForStringOrder(gbytes);

        return new Guid(gbytes);
    }

    public override DateTime GetTimeStamp(Guid value)
    {
        var gbytes = value.ToByteArray();
        var dbytes = new byte[_dateTimeStrategy.NumDateBytes];

        SwapByteOrderForStringOrder(gbytes);

        Array.Copy(gbytes, 0, dbytes, 0, _dateTimeStrategy.NumDateBytes);

        return _dateTimeStrategy.BytesToDateTime(dbytes);
    }

    private void SwapByteOrderForStringOrder(byte[] input)
    {
        Array.Reverse(input, 0, 4);
        if (input.Length == 4)
            return;
        Array.Reverse(input, 4, 2);
    }
}