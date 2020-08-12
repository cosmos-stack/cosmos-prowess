using Cosmos.Validations;
using FluentValidation.Results;

namespace FluentValidation
{
    /// <summary>
    /// Cosmos validation failure extensions
    /// </summary>
    public static class CosmosValidationFailureExtensions
    {
        public static CosmosValidationFailure ToUnionResult(this ValidationFailure failure) => new CosmosValidationFailure(failure);
    }
}