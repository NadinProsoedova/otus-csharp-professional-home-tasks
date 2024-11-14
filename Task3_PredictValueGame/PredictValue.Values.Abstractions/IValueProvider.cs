using System;

namespace PredictNumber.Values;

public interface IValueProvider<TValue> where TValue : IComparable<TValue>
{
    TValue GetValue();
}
