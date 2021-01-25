using System.Linq;
using System.Reflection;
using Cosmos.Exceptions;
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
                    
            //TODO 此处，我们将使用 Cosmos.Extensions.ObjectVisitor 来达成目的
            // 注意，Cosmos.Extensions.ObjectVisitor 将与 LeoVisitor 共用一套代码
            // 注意，我们将在 Cosmos.Extensions.ObjectVisitor 中使用 Cosmos.Validation（而不是 LeoVisitor 中的验证器）
            // 注意，此处的代码不可用，我们目前使用的是 Fake 版本的 TryGetPropertyValue 扩展方法

            var failure = target.TryGetPropertyValue(propertyName, out var val)
                ? new DataAnnotationValidationFailure(propertyName, result.ErrorMessage, val)
                : new DataAnnotationValidationFailure(propertyName, result.ErrorMessage);

            failure.IsValid = result == ValidationResult.Success;

            return failure;
        }

        public static DataAnnotationValidationFailure Create<T>(ValidationResult result, T target)
        {
            var propertyName = result.MemberNames.First();
                    
            //TODO 此处，我们将使用 Cosmos.Extensions.ObjectVisitor 来达成目的
            // 注意，Cosmos.Extensions.ObjectVisitor 将与 LeoVisitor 共用一套代码
            // 注意，我们将在 Cosmos.Extensions.ObjectVisitor 中使用 Cosmos.Validation（而不是 LeoVisitor 中的验证器）
            // 注意，此处的代码不可用，我们目前使用的是 Fake 版本的 GetPropertyValueQuickly 扩展方法

            var @try = Try.Create(() => target.GetPropertyValueQuickly<T>(propertyName, true));

            var failure = @try.IsSuccess
                ? new DataAnnotationValidationFailure(propertyName, result.ErrorMessage, @try.Value)
                : new DataAnnotationValidationFailure(propertyName, result.ErrorMessage);

            failure.IsValid = result == ValidationResult.Success;

            return failure;
        }
        
        public CosmosValidationFailure ToUnionResult() => new CosmosValidationFailure(this);
    }
}