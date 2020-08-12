using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Cosmos.Validations.Internals;
using FluentValidation;
using FluentResult = FluentValidation.FluentValidationResult;

namespace Cosmos.Validations
{
    /// <summary>
    /// A mixed validation result collection for both <see cref="DataAnnotationValidationResultCollection"/> and <see cref="FluentValidationResultCollection"/>.
    /// </summary>
    public partial class ValidationResultCollection
    {
        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(FluentResult result) : this()
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));
            var unionResult = result.ToUnionResult();
            _results.Add(unionResult);
            UpdateResultFlaggedByStrategy(Constants.Noname, unionResult);
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strategyName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(FluentResult result, string strategyName) : this()
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));
            var unionResult = result.ToUnionResult();
            _results.Add(unionResult);
            UpdateResultFlaggedByStrategy(strategyName, unionResult);
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="results"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(IEnumerable<FluentResult> results) : this()
        {
            if (results is null)
                throw new ArgumentNullException(nameof(results));
            var unionResults = results.Select(result => result.ToUnionResult()).ToList();
            _results.AddRange(unionResults);
            UpdateResultFlaggedByStrategy(Constants.Noname, unionResults);
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="results"></param>
        /// <param name="strategyName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(IEnumerable<FluentResult> results, string strategyName) : this()
        {
            if (results is null)
                throw new ArgumentNullException(nameof(results));
            var unionResults = results.Select(result => result.ToUnionResult()).ToList();
            _results.AddRange(unionResults);
            UpdateResultFlaggedByStrategy(strategyName, unionResults);
        }

        /// <summary>
        /// Create a new instance of <see cref="ValidationResultCollection"/>.
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationResultCollection(FluentValidationResultCollection collection) : this()
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            ErrorCode = collection.ErrorCode;
            Flag = collection.Flag;
            _results = collection.Select(result => result.ToUnionResult()).ToList();
            UpdateResultFlaggedByStrategy(collection);
        }

        private void UpdateResultFlaggedByStrategy(FluentValidationResultCollection coll)
        {
            foreach (var set in coll.InternalStrategy)
            {
                UpdateResultFlaggedByStrategy(set.Key, set.Value);
            }
        }

        private void UpdateResultFlaggedByStrategy(string name, List<FluentResult> results)
        {
            if (_resultsFlaggedByStrategy.ContainsKey(name))
            {
                _resultsFlaggedByStrategy[name].AddRange(results.Select(result => result.ToUnionResult()));
            }
            else
            {
                _resultsFlaggedByStrategy.Add(name, results.Select(result => result.ToUnionResult()).ToList());
            }
        }
    }
}