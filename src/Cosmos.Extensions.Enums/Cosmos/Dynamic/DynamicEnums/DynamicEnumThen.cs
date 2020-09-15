using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Dynamic.DynamicEnums
{
    public readonly struct DynamicEnumThen<TEnum, TValue>
        where TEnum : IDynamicEnum
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly IDynamicEnum _instance;
        private readonly bool _stopEval;

        internal DynamicEnumThen(bool stopEval, IDynamicEnum instance)
        {
            _stopEval = stopEval;
            _instance = instance;
        }

        public void Default(Action action)
        {
            if (!_stopEval)
                action?.Invoke();
        }

        public DynamicEnumWhen<TEnum, TValue> When(IDynamicEnum instanceWhen)
        {
            return new DynamicEnumWhen<TEnum, TValue>(_instance.Equals(instanceWhen), _stopEval, _instance);
        }

        public DynamicEnumWhen<TEnum, TValue> When(params IDynamicEnum[] instances)
        {
            return new DynamicEnumWhen<TEnum, TValue>(instances.Contains(_instance), _stopEval, _instance);
        }

        public DynamicEnumWhen<TEnum, TValue> When(IEnumerable<IDynamicEnum> instances)
        {
            return new DynamicEnumWhen<TEnum, TValue>(instances.Contains(_instance), _stopEval, _instance);
        }
    }
}