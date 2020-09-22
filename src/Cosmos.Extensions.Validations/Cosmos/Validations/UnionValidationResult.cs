using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;
using Cosmos.Text;
using Cosmos.Validations.Internals;
using FluentValidation;
using FluentResult = FluentValidation.FluentValidationResult;
using SystemResult = System.ComponentModel.DataAnnotations.DataAnnotationValidationResult;
using SystemFailure = System.ComponentModel.DataAnnotations.DataAnnotationValidationFailure;

namespace Cosmos.Validations
{
    /// <summary>
    /// A union validation failure for both <see cref="SystemResult"/> and <see cref="FluentValidationResult"/>.
    /// </summary>
    public class UnionValidationResult :
        IValidationResult<CosmosValidationFailure>,
        IUnionValidationModel<FluentResult, List<SystemFailure>>
    {
        public UnionValidationTarget Target { get; }
        private readonly FluentResult _result0;
        private readonly List<SystemFailure> _result1;
        public FluentResult LeftModel => _result0;
        public List<SystemFailure> RightModel => _result1;

        internal UnionValidationResult(FluentResult result)
        {
            Target = UnionValidationTarget.FluentValidation;
            _result0 = result;
            _result1 = null;
        }

        internal UnionValidationResult(SystemResult result)
        {
            Target = UnionValidationTarget.SystemDataAnnotations;
            _result0 = null;
            _result1 = result.Errors.ToList();
        }

        internal UnionValidationResult(FluentResult result0, SystemResult result1)
        {
            Target = UnionValidationTarget.Mixed;
            _result0 = result0;
            _result1 = result1.Errors.ToList();
        }

        /// <inheritdoc />
        public bool IsValid
        {
            get
            {
                return Target switch
                {
                    UnionValidationTarget.FluentValidation => _result0.IsValid,
                    UnionValidationTarget.SystemDataAnnotations => _result1.TrueForAll(failure => failure.IsValid),
                    UnionValidationTarget.Mixed => _result0.IsValid && _result1.TrueForAll(failure => failure.IsValid),
                    _ => false
                };
            }
        }

        /// <inheritdoc />
        public IEnumerable<string> MemberNames
        {
            get
            {
                return Target switch
                {
                    UnionValidationTarget.FluentValidation => _result0.MemberNames,
                    UnionValidationTarget.SystemDataAnnotations => _result1.Select(failure => failure.PropertyName),
                    UnionValidationTarget.Mixed => _result0.MemberNames.Merge(_result1.Select(failure => failure.PropertyName)).Distinct(),
                    _ => Enumerables.EmptyList<string>()
                };
            }
        }

        /// <summary>A collection of errors</summary>
        public IList<CosmosValidationFailure> Errors
        {
            get
            {
                return Target switch
                {
                    UnionValidationTarget.FluentValidation => _result0.Errors.Select(failure => new CosmosValidationFailure(failure)).ToList(),
                    UnionValidationTarget.SystemDataAnnotations => _result1.Select(failure => new CosmosValidationFailure(failure)).ToList(),
                    UnionValidationTarget.Mixed => _result0.Errors.Select(failure => new CosmosValidationFailure(failure)).Merge(_result1.Select(failure => new CosmosValidationFailure(failure))).ToList(),
                    _ => Enumerables.EmptyList<CosmosValidationFailure>()
                };
            }
        }

        /// <inheritdoc />
        public string ErrorMessage => ToString();

        public override string ToString() => ToString(Strings.NEWLINE);

        public string ToString(string separator)
        {
            return Target switch
            {
                UnionValidationTarget.FluentValidation => _result0.ToString(separator),
                UnionValidationTarget.SystemDataAnnotations => string.Join(separator, _result1.Select(failure => failure.ErrorMessage)),
                UnionValidationTarget.Mixed => string.Join(
                    separator,
                    _result0.ToString(separator),
                    string.Join(separator, _result1.Select(failure => failure.ErrorMessage))),
                _ => string.Empty
            };
        }

        public static UnionValidationResult Create(FluentResult left, SystemResult right)
        {
            if (left != null && right != null)
                return new UnionValidationResult(left, right);
            if (left != null)
                return new UnionValidationResult(left);
            if (right != null)
                return new UnionValidationResult(right);
            return null;
        }

        public static UnionValidationResult Create(FluentResult left) => Create(left, null);

        public static UnionValidationResult Create(SystemResult right) => Create(null, right);

        public UnionValidationResult ToUnionResult() => this;
    }
}