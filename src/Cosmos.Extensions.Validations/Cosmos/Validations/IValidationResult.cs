using System.Collections.Generic;

namespace Cosmos.Validations
{
    /// <summary>
    /// Interface for validation result
    /// </summary>
    public interface IValidationResult
    {
        /// <summary>
        /// Whether validation succeeded.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Property/Member names
        /// </summary>
        IEnumerable<string> MemberNames { get; }

        /// <summary>
        /// Error message
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// To String
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        string ToString(string separator);

        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        string ToString();

        /// <summary>
        /// To union result
        /// </summary>
        /// <returns></returns>
        UnionValidationResult ToUnionResult();
    }

    public interface IValidationResult<TFailure> : IValidationResult
    {
        public IList<TFailure> Errors { get; }
    }
}