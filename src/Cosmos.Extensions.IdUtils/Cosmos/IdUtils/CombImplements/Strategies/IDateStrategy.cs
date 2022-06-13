namespace Cosmos.IdUtils.CombImplements.Strategies;

internal interface IDateStrategy
{
    int NumDateBytes { get; }

    DateTime MinDateTimeValue { get; }

    DateTime MaxDateTimeValue { get; }

    byte[] DateTimeToBytes(DateTime timestamp);

    DateTime BytesToDateTime(byte[] value);
}