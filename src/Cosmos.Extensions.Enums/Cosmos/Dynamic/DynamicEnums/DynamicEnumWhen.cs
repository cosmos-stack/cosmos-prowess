using System;

namespace Cosmos.Dynamic.DynamicEnums
{
    public readonly struct DynamicEnumWhen<TEnum, TValue>
        where TEnum : IDynamicEnum
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly bool _isMatch;
        private readonly IDynamicEnum _instance;
        private readonly bool _stopEval;

        public DynamicEnumWhen(bool isMatch, bool stopEval, IDynamicEnum instance)
        {
            _isMatch = isMatch;
            _stopEval = stopEval;
            _instance = instance;
        }

        public DynamicEnumThen<TEnum, TValue> Then(Action action)
        {
            if (!_stopEval && _isMatch)
                action?.Invoke();
            return new DynamicEnumThen<TEnum, TValue>(_stopEval || _isMatch, _instance);
        }
    }
}