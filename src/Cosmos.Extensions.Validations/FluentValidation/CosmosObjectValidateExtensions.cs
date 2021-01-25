using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Cosmos.Exceptions;
using Cosmos.Reflection;
using SystemValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
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
            var context = new SystemValidationContext(target, null, null);

            var failures = new List<ValidationFailure>();

            if (Validator.TryValidateObject(target, context, validationResults, true))
            {
                foreach (var r in validationResults)
                {
                    var propertyName = r.MemberNames.First();
                    
                    //TODO 此处，我们将使用 Cosmos.Extensions.ObjectVisitor 来达成目的
                    // 注意，Cosmos.Extensions.ObjectVisitor 将与 LeoVisitor 共用一套代码
                    // 注意，我们将在 Cosmos.Extensions.ObjectVisitor 中使用 Cosmos.Validation（而不是 LeoVisitor 中的验证器）
                    // 注意，此处的代码不可用，我们目前使用的是 Fake 版本的 TryGetPropertyValue 扩展方法
                    
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
            var context = new SystemValidationContext(target, null, null);

            var failures = new List<ValidationFailure>();

            if (Validator.TryValidateObject(target, context, validationResults, true))
            {
                foreach (var r in validationResults)
                {
                    var propertyName = r.MemberNames.First();
                    
                    //TODO 此处，我们将使用 Cosmos.Extensions.ObjectVisitor 来达成目的
                    // 注意，Cosmos.Extensions.ObjectVisitor 将与 LeoVisitor 共用一套代码
                    // 注意，我们将在 Cosmos.Extensions.ObjectVisitor 中使用 Cosmos.Validation（而不是 LeoVisitor 中的验证器）
                    // 注意，此处的代码不可用，我们目前使用的是 Fake 版本的 GetPropertyValueQuickly 扩展方法

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