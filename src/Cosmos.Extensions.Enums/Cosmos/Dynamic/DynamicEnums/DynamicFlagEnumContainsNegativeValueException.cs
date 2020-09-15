using System;

namespace Cosmos.Dynamic.DynamicEnums
{
    /// <summary>
    /// The exception that is thrown when a flag dynamic enum item is negative.
    /// </summary>
    [Serializable]
    public class DynamicFlagEnumContainsNegativeValueException : CosmosException
    {
        // ReSharper disable once InconsistentNaming
        private const string FLAG = "DY_NEGATIVE_VAL_INFLAG_FLG";

        // ReSharper disable once InconsistentNaming
        private const string DEFAULT_MESSAGE = "Dynamic flag enum contains negative value.";

        // ReSharper disable once InconsistentNaming
        private const long DEFAULT_CODE = 1093;

        /// <summary>
        /// Create a new <see cref="DynamicFlagEnumContainsNegativeValueException"/> instance.
        /// </summary>
        public DynamicFlagEnumContainsNegativeValueException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="DynamicFlagEnumContainsNegativeValueException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        public DynamicFlagEnumContainsNegativeValueException(string message) : base(DEFAULT_CODE, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="DynamicFlagEnumContainsNegativeValueException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        public DynamicFlagEnumContainsNegativeValueException(long code) : base(code, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="DynamicFlagEnumContainsNegativeValueException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public DynamicFlagEnumContainsNegativeValueException(long code, string message) : base(code, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="DynamicFlagEnumContainsNegativeValueException"/> instance.
        /// </summary>
        /// <param name="innerException"></param>
        public DynamicFlagEnumContainsNegativeValueException(Exception innerException) : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG, innerException) { }

        /// <summary>
        /// Create a new <see cref="DynamicFlagEnumContainsNegativeValueException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public DynamicFlagEnumContainsNegativeValueException(string message, Exception innerException) : base(DEFAULT_CODE, message, FLAG, innerException) { }

        /// <summary>
        /// Create a new <see cref="DynamicFlagEnumContainsNegativeValueException"/> instance.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DynamicFlagEnumContainsNegativeValueException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}