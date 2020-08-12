using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Cosmos.Exceptions;
using SystemValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;
using ValidationFailure = FluentValidation.Results.ValidationFailure;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace FluentValidation
{
    /// <summary>
    /// Cosmos object validate extensions.
    /// </summary>
    public static class CosmosObjectValidateExtensions
    {
        public static ValidationResult ValidateForDataAnnotations(this object target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var validationResults = new List<SystemValidationResult>();
            var context = new ValidationContext(target, null, null);

            var failures = new List<ValidationFailure>();

            if (Validator.TryValidateObject(target, context, validationResults, true))
            {
                foreach (var r in validationResults)
                {
                    var propertyName = r.MemberNames.First();

                    var failure = target.TryGetPropertyValue(propertyName, out var val)
                        ? new ValidationFailure(propertyName, r.ErrorMessage, val)
                        : new ValidationFailure(propertyName, r.ErrorMessage);

                    failures.Add(failure);
                }
            }

            return new ValidationResult(failures);
        }

        public static ValidationResult ValidateForDataAnnotations<T>(this T target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var validationResults = new List<SystemValidationResult>();
            var context = new ValidationContext(target, null, null);

            var failures = new List<ValidationFailure>();

            if (Validator.TryValidateObject(target, context, validationResults, true))
            {
                foreach (var r in validationResults)
                {
                    var propertyName = r.MemberNames.First();

                    var @try = Try.Create(() => target.GetPropertyValueQuickly<T>(propertyName, true));

                    var failure = @try.IsSuccess
                        ? new ValidationFailure(propertyName, r.ErrorMessage, @try.Value)
                        : new ValidationFailure(propertyName, r.ErrorMessage);

                    failures.Add(failure);
                }
            }

            return new ValidationResult(failures);
        }
    }
}