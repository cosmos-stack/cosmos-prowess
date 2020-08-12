using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Cosmos.Validations
{
    /// <summary>
    /// Cosmos validation result extensions
    /// </summary>
    public static class CosmosValidationResultExtensions
    {
        /// <summary>
        /// To wrap in Cosmos validation result
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IValidationResult ToWrap(this ValidationResult result)
        {
            return new DataAnnotationValidationResult(result);
        }

        /// <summary>
        /// To wrap in Cosmos validation result
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static IValidationResult ToWrap(this IEnumerable<ValidationResult> results)
        {
            return new DataAnnotationValidationResult(results);
        }

        /// <summary>
        /// To wrap in Cosmos validation result
        /// </summary>
        /// <param name="failure"></param>
        /// <returns></returns>
        public static IValidationResult ToWrap(this DataAnnotationValidationFailure failure)
        {
            return new DataAnnotationValidationResult(failure);
        }

        /// <summary>
        /// To wrap in Cosmos validation result
        /// </summary>
        /// <param name="failures"></param>
        /// <returns></returns>
        public static IValidationResult ToWrap(this IEnumerable<DataAnnotationValidationFailure> failures)
        {
            return new DataAnnotationValidationResult(failures);
        }

        /// <summary>
        /// To wrap in Cosmos validation result
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IValidationResult ToWrap(this FluentValidation.Results.ValidationResult result)
        {
            return new FluentValidationResult(result);
        }

        /// <summary>
        /// To wrap in Cosmos validation result
        /// </summary>
        /// <param name="failures"></param>
        /// <returns></returns>
        public static IValidationResult ToWrap(this IEnumerable<FluentValidation.Results.ValidationFailure> failures)
        {
            return new FluentValidationResult(failures);
        }

        /// <summary>
        /// To union wrap in Cosmos validation result.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static UnionValidationResult ToUnionWrap(this ValidationResult result) => result.ToWrap().ToUnionResult();

        /// <summary>
        /// To union wrap in Cosmos validation result.
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static UnionValidationResult ToUnionWrap(this IEnumerable<ValidationResult> results) => results.ToWrap().ToUnionResult();

        /// <summary>
        /// To union wrap in Cosmos validation result.
        /// </summary>
        /// <param name="failure"></param>
        /// <returns></returns>
        public static UnionValidationResult ToUnionWrap(this DataAnnotationValidationFailure failure) => failure.ToWrap().ToUnionResult();

        /// <summary>
        /// To union wrap in Cosmos validation result.
        /// </summary>
        /// <param name="failures"></param>
        /// <returns></returns>
        public static UnionValidationResult ToUnionWrap(this IEnumerable<DataAnnotationValidationFailure> failures) => failures.ToWrap().ToUnionResult();

        /// <summary>
        /// To union wrap in Cosmos validation result.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static UnionValidationResult ToUnionWrap(this FluentValidation.Results.ValidationResult result) => result.ToWrap().ToUnionResult();

        /// <summary>
        /// To union wrap in Cosmos validation result.
        /// </summary>
        /// <param name="failures"></param>
        /// <returns></returns>
        public static UnionValidationResult ToUnionWrap(this IEnumerable<FluentValidation.Results.ValidationFailure> failures) => failures.ToWrap().ToUnionResult();
    }
}