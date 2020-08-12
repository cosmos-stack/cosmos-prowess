using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Validations.Internals
{
    public abstract class AbstractResultCollection<TResult, TFailure> : IValidationResultCollection<TResult>
        where TResult : class, IValidationResult<TFailure>
    {
        protected List<TResult> _results { get; set; } = new List<TResult>();

        /// <inheritdoc />
        public int Count => _results.Select(x => x.Errors.Count).Sum();

        /// <inheritdoc />
        public bool IsValid => _results.All(result => result.IsValid);

        /// <inheritdoc />
        public long ErrorCode { get; set; } = 1001;

        /// <inheritdoc />
        public string Flag { get; set; } = "__EMPTY_FLG";

        /// <inheritdoc />
        public void Add(TResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
        }

        /// <inheritdoc />
        public void AddRange(IEnumerable<TResult> results)
        {
            if (results == null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
        }

        /// <inheritdoc />
        public virtual string ToMessage()
        {
            var builder = new StringBuilder();

            if (IsValid)
                builder.Append("No errors were found during verification.");
            else if (Count == 1)
                builder.Append("An error was found during verification, please check the details.");
            else
                builder.Append($"{Count} errors were found during verification, please check the details.");

            builder.AppendLine();
            builder.Append($" (code: {ErrorCode}, Flag: {Flag})");

            return builder.ToString();
        }

        /// <inheritdoc />
        public abstract IEnumerable<string> ToValidationMessages();

        /// <inheritdoc />
        public IEnumerator<TResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}