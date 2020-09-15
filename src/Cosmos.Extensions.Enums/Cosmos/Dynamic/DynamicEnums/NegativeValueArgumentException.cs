using System;

namespace Cosmos.Dynamic.DynamicEnums
{
    /// <summary>
    /// The exception that is thrown when a negative value is provided as an argument value.
    /// </summary>
    [Serializable]
    public class NegativeValueArgumentException : CosmosException
    {
        // ReSharper disable once InconsistentNaming
        private const string FLAG = "DY_NEGATIVE_VAL_FLG";

        // ReSharper disable once InconsistentNaming
        private const string DEFAULT_MESSAGE = "Negative value argument.";

        // ReSharper disable once InconsistentNaming
        private const long DEFAULT_CODE = 1092;

        /// <summary>
        /// Create a new <see cref="NegativeValueArgumentException"/> instance.
        /// </summary>
        public NegativeValueArgumentException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="NegativeValueArgumentException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        public NegativeValueArgumentException(string message) : base(DEFAULT_CODE, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="NegativeValueArgumentException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        public NegativeValueArgumentException(long code) : base(code, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="NegativeValueArgumentException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public NegativeValueArgumentException(long code, string message) : base(code, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="NegativeValueArgumentException"/> instance.
        /// </summary>
        /// <param name="innerException"></param>
        public NegativeValueArgumentException(Exception innerException) : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG, innerException) { }

        /// <summary>
        /// Create a new <see cref="NegativeValueArgumentException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public NegativeValueArgumentException(string message, Exception innerException) : base(DEFAULT_CODE, message, FLAG, innerException) { }

        /// <summary>
        /// Create a new <see cref="NegativeValueArgumentException"/> instance.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected NegativeValueArgumentException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}