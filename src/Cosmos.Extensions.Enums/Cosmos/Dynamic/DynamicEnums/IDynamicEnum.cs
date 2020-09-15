using System;

namespace Cosmos.Dynamic.DynamicEnums
{
    public interface IDynamicEnum
    {
        /// <summary>
        /// Get value's type.
        /// </summary>
        /// <returns></returns>
        Type GetValueType();

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }
    }
}