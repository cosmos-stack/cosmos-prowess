using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cosmos.Reflection;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Cosmos Data annotation validation extensions
    /// </summary>
    public static class CosmosDataAnnotationValidationExtensions
    {
        public static bool HasDataAnnotationAttribute(this TypeInfo type)
        {
            var attributes = type.GetCustomAttributes();
            return attributes.Any(a => a.GetType().IsDerivedFrom<ValidationAttribute>());
        }

        public static IEnumerable<Attribute> GetDataAnnotationAttributes(this TypeInfo type)
        {
            var attributes = type.GetCustomAttributes();
            return attributes.Where(a => a.GetType().IsDerivedFrom<ValidationAttribute>());
        }

        public static DataAnnotationValidationResult ValidateDataAnnotation(this object target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var results = new List<ValidationResult>();
            var context = new ValidationContext(target, null, null);
            var isValid = Validator.TryValidateObject(target, context, results, true);

            if (!isValid)
            {
                var failures = results.Select(r => DataAnnotationValidationFailure.Create(r));
                return new DataAnnotationValidationResult(failures);
            }

            return new DataAnnotationValidationResult();
        }
    }
}