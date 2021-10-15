using CosmosStack.Date;
using CosmosStack.IdUtils.CombImplements.Providers;
using CosmosStack.IdUtils.CombImplements.Strategies;

namespace CosmosStack.IdUtils.CombImplements
{
    internal static class InternalCombImplementProxy
    {
        public static ICombProvider Legacy = new MsSqlCombProvider(new SqlDateTimeStrategy());

        public static ICombProvider LegacyWithNoRepeat = new MsSqlCombProvider(new SqlDateTimeStrategy(), new NoRepeatTimeStampFactory().GetUtcTimeStamp);

        public static ICombProvider MsSql = new MsSqlCombProvider(new UnixDateTimeStrategy());

        public static ICombProvider MsSqlWithNoRepeat = new MsSqlCombProvider(new UnixDateTimeStrategy(), new NoRepeatTimeStampFactory().GetUtcTimeStamp);

        public static ICombProvider PostgreSql = new PostgreSqlCombProvider(new UnixDateTimeStrategy());

        public static ICombProvider PostgreSqlWithNoRepeat = new PostgreSqlCombProvider(new UnixDateTimeStrategy(), new NoRepeatTimeStampFactory().GetUtcTimeStamp);
    }
}