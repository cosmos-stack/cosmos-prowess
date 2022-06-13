namespace Cosmos.IdUtils.CombImplements.Providers;

internal interface ICombProvider
{
    Guid Create();

    Guid Create(Guid value);

    Guid Create(DateTime timestamp);

    Guid Create(Guid value, DateTime timestamp);

    DateTime GetTimeStamp(Guid value);
}