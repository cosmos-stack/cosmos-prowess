using System.Collections.Generic;

namespace Cosmos.Validations
{
    public interface IValidationResultCollection
    {
        /// <summary>
        /// Count
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Is valid
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Error code
        /// </summary>
        long ErrorCode { get; set; }

        /// <summary>
        /// Flag
        /// </summary>
        string Flag { get; set; }

        /// <summary>
        /// To message
        /// </summary>
        /// <returns></returns>
        string ToMessage();

        /// <summary>
        /// To validation messages
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ToValidationMessages();
    }

    public interface IValidationResultCollection<TValidationResult> : IValidationResultCollection, IEnumerable<TValidationResult>
        where TValidationResult : class, IValidationResult
    {
        /// <summary>
        /// Add validated result
        /// </summary>
        /// <param name="result"></param>
        void Add(TValidationResult result);

        /// <summary>
        /// Add a set of validated results
        /// </summary>
        /// <param name="results"></param>
        void AddRange(IEnumerable<TValidationResult> results);
    }
}