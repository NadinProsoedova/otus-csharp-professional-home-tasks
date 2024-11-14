using System;

namespace PredictValue.Validation.Values.IntValue;

internal class IntValueValidator : IValueValidator<int>
{
    private const sbyte LESS_THEN_TARGET_VALUE = -1;
    private const byte EQUAL_TO_TARGET_VALUE = 0;
    private const byte GREATER_THAN_TARGET = 1;

    public void Init()
    {
        throw new NotImplementedException();
    }

    public ValidateValueResult Validate(int input, int destination)
    {
        var numberValidationResultType = CompareNumbers(input, destination);

        return new ValidateValueResult(numberValidationResultType);
    }

    private ValidateValueResultType CompareNumbers(int input, int destination)
    {
        var compareResult = destination.CompareTo(input);
        return compareResult switch
        {
            EQUAL_TO_TARGET_VALUE => ValidateValueResultType.Success,
            LESS_THEN_TARGET_VALUE => ValidateValueResultType.InputLessThanTarget,
            GREATER_THAN_TARGET => ValidateValueResultType.InputGreaterThanTarget,
            _ => ValidateValueResultType.None
        };
    }
}
