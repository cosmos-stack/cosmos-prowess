using System.Linq;
using System.Reflection;
using Cosmos.Exceptions;
using Cosmos.Reflection;
using Cosmos.Validations;

namespace System.ComponentModel.DataAnnotations
{
    public class DataAnnotationValidationFailure
    {
        /// <summary>Creates a new validation failure.</summary>
        public DataAnnotationValidationFailure(string propertyName, string errorMessage)
            : this(propertyName, errorMessage, null)
        {
        }

        /// <summary>Creates a new ValidationFailure.</summary>
        public DataAnnotationValidationFailure(string propertyName, string errorMessage, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            AttemptedValue = attemptedValue;
        }

        /// <summary>
        /// The name of the property.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The property value that caused the failure.
        /// </summary>
        public object AttemptedValue { get; set; }

        /// <summary>
        /// Is valid
        /// </summary>
        public bool IsValid { get; internal set; }

        public override string ToString() => ErrorMessage;

        public static DataAnnotationValidationFailure Create(ValidationResult result)
        {
            var propertyName = result.MemberNames.First();

            var failure = new DataAnnotationValidationFailure(propertyName, result.ErrorMessage)
            {
                IsValid = result == ValidationResult.Success
            };

            return failure;
        }

        public static DataAnnotationValidationFailure Create(ValidationResult result, object target)
        {
            var propertyName = result.MemberNames.First();
            
            var failure = target.TryGetPropertyValue(propertyName, out var val)
                ? new DataAnnotationValidationFailure(propertyName, result.ErrorMessage, val)
                : new DataAnnotationValidationFailure(propertyName, result.ErrorMessage);

            failure.IsValid = result == ValidationResult.Success;

            return failure;
        }

        public static DataAnnotationValidationFailure Create<T>(ValidationResult result, T target)
        {
            var propertyName = result.MemberNames.First();
            
            var @try = Try.Create(() => target.GetPropertyValueQuickly<T>(propertyName));

            var failure = @try.IsSuccess
                ? new DataAnnotationValidationFailure(propertyName, result.ErrorMessage, @try.Value)
                : new DataAnnotationValidationFailure(propertyName, result.ErrorMessage);

            failure.IsValid = result == ValidationResult.Success;

            return failure;
        }
        
        public CosmosValidationFailure ToUnionResult() => new CosmosValidationFailure(this);
    }
}