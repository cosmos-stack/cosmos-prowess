using System.ComponentModel.DataAnnotations;
using Cosmos.Validations.Internals;
using FluentValidation.Results;
using FluentFailure = FluentValidation.Results.ValidationFailure;
using SystemFailure = System.ComponentModel.DataAnnotations.DataAnnotationValidationFailure;

namespace Cosmos.Validations
{
    /// <summary>
    /// A union validation failure for both <see cref="DataAnnotationValidationFailure"/> and <see cref="ValidationFailure"/>.
    /// </summary>
    public class CosmosValidationFailure : IUnionValidationModel<FluentFailure, SystemFailure>
    {
        public UnionValidationTarget Target { get; }
        private readonly FluentFailure _failure0;
        private readonly SystemFailure _failure1;
        public FluentFailure LeftModel => _failure0;
        public SystemFailure RightModel => _failure1;

        internal CosmosValidationFailure(FluentFailure failure)
        {
            Target = UnionValidationTarget.FluentValidation;
            _failure0 = failure;
            _failure1 = null;
        }

        internal CosmosValidationFailure(SystemFailure failure)
        {
            Target = UnionValidationTarget.SystemDataAnnotations;
            _failure0 = null;
            _failure1 = failure;
        }

        /// <summary>
        /// The name of the property.
        /// </summary>
        public string PropertyName
        {
            get
            {
                return Target switch
                {
                    UnionValidationTarget.FluentValidation => _failure0.PropertyName,
                    UnionValidationTarget.SystemDataAnnotations => _failure1.PropertyName,
                    UnionValidationTarget.Mixed => string.Empty,
                    _ => string.Empty
                };
            }
            set
            {
                switch (Target)
                {
                    case UnionValidationTarget.FluentValidation:
                        _failure0.PropertyName = value;
                        break;
                    case UnionValidationTarget.SystemDataAnnotations:
                        _failure1.PropertyName = value;
                        break;
                    case UnionValidationTarget.Mixed:
                        break;
                }
            }
        }

        /// <summary>
        /// The error message
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return Target switch
                {
                    UnionValidationTarget.FluentValidation => _failure0.ErrorMessage,
                    UnionValidationTarget.SystemDataAnnotations => _failure1.ErrorMessage,
                    UnionValidationTarget.Mixed => string.Empty,
                    _ => string.Empty
                };
            }
            set
            {
                switch (Target)
                {
                    case UnionValidationTarget.FluentValidation:
                        _failure0.ErrorMessage = value;
                        break;
                    case UnionValidationTarget.SystemDataAnnotations:
                        _failure1.ErrorMessage = value;
                        break;
                    case UnionValidationTarget.Mixed:
                        break;
                }
            }
        }

        /// <summary>
        /// The property value that caused the failure.
        /// </summary>
        public object AttemptedValue
        {
            get
            {
                return Target switch
                {
                    UnionValidationTarget.FluentValidation => _failure0.AttemptedValue,
                    UnionValidationTarget.SystemDataAnnotations => _failure1.AttemptedValue,
                    UnionValidationTarget.Mixed => null,
                    _ => null
                };
            }
            set
            {
                switch (Target)
                {
                    case UnionValidationTarget.FluentValidation:
                        _failure0.AttemptedValue = value;
                        break;
                    case UnionValidationTarget.SystemDataAnnotations:
                        _failure1.AttemptedValue = value;
                        break;
                    case UnionValidationTarget.Mixed:
                        break;
                }
            }
        }

        /// <summary>
        /// Is valid
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Target switch
                {
                    UnionValidationTarget.FluentValidation => false,
                    UnionValidationTarget.SystemDataAnnotations => _failure1.IsValid,
                    UnionValidationTarget.Mixed => false,
                    _ => false
                };
            }
        }

        public override string ToString()
        {
            return Target switch
            {
                UnionValidationTarget.FluentValidation => _failure0.ToString(),
                UnionValidationTarget.SystemDataAnnotations => _failure1.ToString(),
                UnionValidationTarget.Mixed => string.Empty,
                _ => string.Empty
            };
        }

        public static CosmosValidationFailure Create(FluentFailure left, SystemFailure right)
        {
            if (left != null)
                return new CosmosValidationFailure(left);
            if (right != null)
                return new CosmosValidationFailure(right);
            return null;
        }

        public static CosmosValidationFailure Create(FluentFailure left) => Create(left, null);

        public static CosmosValidationFailure Create(SystemFailure right) => Create(null, right);
    }
}