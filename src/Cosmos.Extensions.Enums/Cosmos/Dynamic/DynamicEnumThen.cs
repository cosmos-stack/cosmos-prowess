using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Dynamic
{
    public readonly struct DynamicEnumThen<TEnum, TValue>
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly DynamicEnum<TEnum, TValue> _instance;
        private readonly bool _stopEval;

        internal DynamicEnumThen(bool stopEval, DynamicEnum<TEnum, TValue> instance)
        {
            _stopEval = stopEval;
            _instance = instance;
        }

        public void Default(Action action)
        {
            if (!_stopEval)
                action?.Invoke();
        }

        public DynamicEnumWhen<TEnum, TValue> When(DynamicEnum<TEnum, TValue> instanceWhen)
        {
            return new DynamicEnumWhen<TEnum, TValue>(_instance.Equals(instanceWhen), _stopEval, _instance);
        }

        public DynamicEnumWhen<TEnum, TValue> When(params DynamicEnum<TEnum, TValue>[] instances)
        {
            return new DynamicEnumWhen<TEnum, TValue>(instances.Contains(_instance), _stopEval, _instance);
        }

        public DynamicEnumWhen<TEnum, TValue> When(IEnumerable<DynamicEnum<TEnum, TValue>> instances)
        {
            return new DynamicEnumWhen<TEnum, TValue>(instances.Contains(_instance), _stopEval, _instance);
        }
    }
}