using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos;
using Cosmos.Collections;
using Cosmos.Validations.Internals;

namespace System.ComponentModel.DataAnnotations
{
    public class DataAnnotationValidationResultCollection : AbstractResultCollection<DataAnnotationValidationResult, DataAnnotationValidationFailure>
    {
        private readonly IDictionary<string, List<DataAnnotationValidationResult>> _resultsFlaggedByStrategy;

        internal IReadOnlyDictionary<string, List<DataAnnotationValidationResult>> InternalStrategy => _resultsFlaggedByStrategy.ToReadOnlyDictionary();

        /// <summary>
        /// Create a new instance of <see cref="DataAnnotationValidationResultCollection"/>.
        /// </summary>
        public DataAnnotationValidationResultCollection()
        {
            _results = new List<DataAnnotationValidationResult>();
            _resultsFlaggedByStrategy = new Dictionary<string, List<DataAnnotationValidationResult>>();
            UpdateResultFlaggedByStrategy(Constants.Noname, new List<DataAnnotationValidationResult>());
        }

        /// <summary>
        /// Create a new instance of <see cref="DataAnnotationValidationResultCollection"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DataAnnotationValidationResultCollection(DataAnnotationValidationResult result) : this()
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
            UpdateResultFlaggedByStrategy(Constants.Noname, result);
        }

        /// <summary>
        /// Create a new instance of <see cref="DataAnnotationValidationResultCollection"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strategyName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DataAnnotationValidationResultCollection(DataAnnotationValidationResult result, string strategyName) : this()
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
            UpdateResultFlaggedByStrategy(strategyName, result);
        }

        /// <summary>
        /// Create a new instance of <see cref="DataAnnotationValidationResultCollection"/>.
        /// </summary>
        /// <param name="results"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DataAnnotationValidationResultCollection(IEnumerable<DataAnnotationValidationResult> results) : this()
        {
            if (results is null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
            UpdateResultFlaggedByStrategy(Constants.Noname, results.ToList());
        }

        /// <summary>
        /// Create a new instance of <see cref="DataAnnotationValidationResultCollection"/>.
        /// </summary>
        /// <param name="results"></param>
        /// <param name="strategyName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DataAnnotationValidationResultCollection(IEnumerable<DataAnnotationValidationResult> results, string strategyName) : this()
        {
            if (results is null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
            UpdateResultFlaggedByStrategy(strategyName, results.ToList());
        }

        /// <summary>
        /// Create a new instance of <see cref="DataAnnotationValidationResultCollection"/>.
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DataAnnotationValidationResultCollection(DataAnnotationValidationResultCollection collection) : this()
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

        private void UpdateResultFlaggedByStrategy(DataAnnotationValidationResultCollection coll)
        {
            foreach (var set in coll._resultsFlaggedByStrategy)
            {
                UpdateResultFlaggedByStrategy(set.Key, set.Value);
            }
        }

        private void UpdateResultFlaggedByStrategy(string name, List<DataAnnotationValidationResult> results)
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

        private void UpdateResultFlaggedByStrategy(string name, DataAnnotationValidationResult result)
        {
            if (_resultsFlaggedByStrategy.ContainsKey(name))
            {
                _resultsFlaggedByStrategy[name].Add(result);
            }
            else
            {
                _resultsFlaggedByStrategy.Add(name, new List<DataAnnotationValidationResult> {result});
            }
        }

        internal DataAnnotationValidationResultCollection Filter(Action<IEnumerable<DataAnnotationValidationResult>> filter)
        {
            var ret = _results;
            filter?.Invoke(ret);

            return ret.Count == 0 ? null : new DataAnnotationValidationResultCollection(ret);
        }

        internal DataAnnotationValidationResultCollection Filter(string strategyName)
        {
            if (string.IsNullOrWhiteSpace(strategyName))
                strategyName = Constants.Noname;

            return _resultsFlaggedByStrategy.TryGetValue(strategyName, out var ret)
                ? new DataAnnotationValidationResultCollection(ret)
                : null;
        }
    }
}