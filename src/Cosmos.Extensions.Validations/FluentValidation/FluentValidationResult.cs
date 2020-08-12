using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Text;
using Cosmos.Validations;
using FluentValidation.Results;

namespace FluentValidation
{
    public class FluentValidationResult : IValidationResult<ValidationFailure>
    {
        private readonly ValidationResult _validationResult;

        public FluentValidationResult(ValidationResult validationResult)
        {
            _validationResult = validationResult ?? throw new ArgumentNullException(nameof(validationResult));
        }

        internal FluentValidationResult(IEnumerable<ValidationFailure> failures)
        {
            _validationResult = new ValidationResult(failures);
        }

        /// <inheritdoc />
        public bool IsValid => _validationResult.IsValid;

        /// <inheritdoc />
        public IEnumerable<string> MemberNames => _validationResult.Errors.Select(f => f.PropertyName);

        /// <summary>A collection of errors</summary>
        public IList<ValidationFailure> Errors => _validationResult.Errors;

        /// <inheritdoc />
        public string ErrorMessage => _validationResult.ToString(Strings.NEWLINE);

        public override string ToString() => _validationResult.ToString();

        public string ToString(string separator) => _validationResult.ToString(separator);

        public UnionValidationResult ToUnionResult() => new UnionValidationResult(this);
    }
}