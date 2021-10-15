namespace CosmosStack.IdUtils
{
    /// <summary>
    /// Snowflake Generator <br />
    /// 雪花编号生成器
    /// </summary>
    public static class SnowflakeGenerator
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="dataCenterId"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static SnowflakeIdWorker Create(long workerId, long dataCenterId, long sequence = 0L)
        {
            return new(workerId, dataCenterId, sequence);
        }

        /// <summary>
        /// Create <br />
        /// 生成
        /// </summary>
        /// <typeparam name="TSnowflakeIdWorker"></typeparam>
        /// <param name="workerId"></param>
        /// <param name="dataCenterId"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static TSnowflakeIdWorker Create<TSnowflakeIdWorker>(long workerId, long dataCenterId, long sequence = 0L)
            where TSnowflakeIdWorker : SnowflakeIdWorker
        {
            return Reflection.TypeVisit.CreateInstance<TSnowflakeIdWorker>(workerId, dataCenterId, sequence);
        }
    }
}