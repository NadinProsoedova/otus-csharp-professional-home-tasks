using PredictNumber.Values;
using System;

namespace PredictValue.Values.IntValue;

internal class IntValueRandomProvider : IValueProvider<int>
{
    private readonly ValueRangeOptions<int> _options;

    public IntValueRandomProvider(ValueRangeOptions<int> options)
    {
        _options = options;
    }
    public int GetValue()
    {
        var gen = new Random((int)DateTime.Now.Ticks);
        return gen.Next(_options.MinValue, _options.MaxValue);
    }
}
