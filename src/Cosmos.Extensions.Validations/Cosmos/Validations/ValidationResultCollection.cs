using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Cosmos.Text;
using Cosmos.Validations.Internals;
using FluentValidation;

namespace Cosmos.Validations
{
    /// <summary>
    /// A mixed validation result collection for both <see cref="DataAnnotationValidationResultCollection"/> and <see cref="FluentValidationResultCollection"/>.
    /// </summary>
    public partial class ValidationResultCollection : AbstractResultCollection<UnionValidationResult, CosmosValidationFailure>
    {
        private readonly IDictionary<string, List<UnionValidationResult>> _resultsFlaggedByStrategy;

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        public ValidationResultCollection()
        {
            _results = new List<UnionValidationResult>();
            _resultsFlaggedByStrategy = new Dictionary<string, List<UnionValidationResult>>();
            UpdateResultFlaggedByStrategy(Constants.Noname, new List<UnionValidationResult>());
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(UnionValidationResult result) : this()
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
            UpdateResultFlaggedByStrategy(Constants.Noname, result);
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strategyName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(UnionValidationResult result, string strategyName) : this()
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
            UpdateResultFlaggedByStrategy(strategyName, result);
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="results"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(IEnumerable<UnionValidationResult> results) : this()
        {
            if (results is null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
            UpdateResultFlaggedByStrategy(Constants.Noname, results.ToList());
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="results"></param>
        /// <param name="strategyName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(IEnumerable<UnionValidationResult> results, string strategyName) : this()
        {
            if (results is null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
            UpdateResultFlaggedByStrategy(strategyName, results.ToList());
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(ValidationResultCollection collection) : this()
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            ErrorCode = collection.ErrorCode;
            Flag = collection.Flag;
            _results = collection._results;
            UpdateResultFlaggedByStrategy(collection);
        }

        /// <inheritdoc />
        public override IEnumerable<string> ToValidationMessages()
        {
            return IsValid ? Enumerable.Empty<string>() : __getErrorStringList();

            // ReSharper disable once InconsistentNaming
            IEnumerable<string> __getErrorStringList()
            {
                foreach (var error in _results.SelectMany(result => result.Errors))
                {
                    yield return $"{error.PropertyName}, {error.ErrorMessage}";
                }
            }
        }

        private StringBuilder GetErrorString(int spaceCount = 0)
        {
            var space = ' '.Repeat(spaceCount);

            var sb = new StringBuilder();

            foreach (var error in _results.SelectMany(result => result.Errors))
            {
                sb.AppendLine($"{space}{error.PropertyName}, {error.ErrorMessage}");
            }

            return sb;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(ToMessage());
            builder.AppendLine("Detail(s):");

            builder.Append(GetErrorString(6));
            builder.AppendLine();

            return builder.ToString();
        }

        private void UpdateResultFlaggedByStrategy(ValidationResultCollection coll)
        {
            foreach (var set in coll._resultsFlaggedByStrategy)
            {
                UpdateResultFlaggedByStrategy(set.Key, set.Value);
            }
        }

        private void UpdateResultFlaggedByStrategy(string name, List<UnionValidationResult> results)
        {
            if (_resultsFlaggedByStrategy.ContainsKey(name))
            {
                _resultsFlaggedByStrategy[name].AddRange(results);
            }
            else
            {
                _resultsFlaggedByStrategy.Add(name, results);
            }
        }

        private void UpdateResultFlaggedByStrategy(string name, UnionValidationResult result)
        {
            if (_resultsFlaggedByStrategy.ContainsKey(name))
            {
                _resultsFlaggedByStrategy[name].Add(result);
            }
            else
            {
                _resultsFlaggedByStrategy.Add(name, new List<UnionValidationResult> {result});
            }
        }

        public ValidationResultCollection Filter(Action<IEnumerable<UnionValidationResult>> filter)
        {
            var ret = _results;
            filter?.Invoke(ret);

            return ret.Count == 0 ? null : new ValidationResultCollection(ret);
        }

        public ValidationResultCollection Filter(string strategyName)
        {
            if (string.IsNullOrWhiteSpace(strategyName))
                strategyName = Constants.Noname;

            return _resultsFlaggedByStrategy.TryGetValue(strategyName, out var ret)
                ? new ValidationResultCollection(ret)
                : null;
        }
    }
}