using System;

namespace PredictNumber.Values;

public class ValueRangeOptions<TValue> where TValue : IComparable<TValue>
{
    public required TValue MinValue { get; init; }

    public required TValue MaxValue { get; init; }
}
