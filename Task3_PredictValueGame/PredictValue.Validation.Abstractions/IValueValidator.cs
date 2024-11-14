using System;

namespace PredictValue.Validation;

public interface IValueValidator<TValue> where TValue : IComparable<TValue>
{
    void Init();
    ValidateValueResult Validate(TValue input, TValue destination);
}
