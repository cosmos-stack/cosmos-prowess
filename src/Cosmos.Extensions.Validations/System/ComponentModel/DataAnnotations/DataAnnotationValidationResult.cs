using System.Collections.Generic;
using System.Linq;
using Cosmos.Text;
using Cosmos.Validations;

namespace System.ComponentModel.DataAnnotations
{
    public class DataAnnotationValidationResult : IValidationResult<DataAnnotationValidationFailure>
    {
        private readonly List<DataAnnotationValidationFailure> _errors;

        public DataAnnotationValidationResult()
        {
            _errors = new List<DataAnnotationValidationFailure>();
        }

        internal DataAnnotationValidationResult(DataAnnotationValidationFailure failure)
        {
            _errors = new List<DataAnnotationValidationFailure>();
            _errors.Add(failure);
        }

        public DataAnnotationValidationResult(IEnumerable<DataAnnotationValidationFailure> failures)
        {
            _errors = failures.ToList();
        }

        internal DataAnnotationValidationResult(IEnumerable<ValidationResult> validationResults)
        {
            _errors = validationResults.Select(result => DataAnnotationValidationFailure.Create(result)).ToList();
        }

        internal DataAnnotationValidationResult(ValidationResult validationResult)
        {
            _errors = new List<DataAnnotationValidationFailure>();
            var failure = DataAnnotationValidationFailure.Create(validationResult);
            _errors.Add(failure);
        }

        /// <inheritdoc />
        public bool IsValid => !_errors.Any() || _errors.TrueForAll(failure => failure.IsValid);

        /// <inheritdoc />
        public IEnumerable<string> MemberNames => _errors.Select(failure => failure.PropertyName);

        /// <summary>A collection of errors</summary>
        public IList<DataAnnotationValidationFailure> Errors => _errors;

        /// <inheritdoc />
        public string ErrorMessage => ToString();

        public override string ToString() => ToString(Strings.NEWLINE);

        public string ToString(string separator) => string.Join(separator, _errors.Select(failure => failure.ErrorMessage));

        public UnionValidationResult ToUnionResult() => new UnionValidationResult(this);
    }
}