namespace PredictNumber.Domain;

internal class NumberValidator
{
    private const byte START_ATTEMPT_VALUE = 1;

    private const sbyte LESS_THEN_TARGET_VALUE = -1;
    private const byte EQUAL_TO_TARGET_VALUE = 0;
    private const byte GREATER_THAN_TARGET = 1;

    private readonly ValidateNumberOptions _options;

    private int _currentAttempt;

    public NumberValidator(ValidateNumberOptions options)
    {
        _options = options;
        _currentAttempt = START_ATTEMPT_VALUE;
    }

    public ValidateNumberResult Validate(int input, int destination)
    {
        if (CanAttempt())
        {
            AcceptAttempt();

            var numberValidationResultType = CompareNumbers(input, destination);

            return new ValidateNumberResult(numberValidationResultType, _currentAttempt);
        }
        else
        {
            return new ValidateNumberResult(ValidateNumberResultType.AttemptsCountExceed, _options.MaxAttemptsCount);
        }
    }

    private ValidateNumberResultType CompareNumbers(int input, int destination)
    {
        var compareResult = destination.CompareTo(input);
        return compareResult switch
        {
            EQUAL_TO_TARGET_VALUE => ValidateNumberResultType.Success,
            LESS_THEN_TARGET_VALUE => ValidateNumberResultType.InputLessThanTarget,
            GREATER_THAN_TARGET => ValidateNumberResultType.InputGreaterThanTarget,
            _ => ValidateNumberResultType.None
        };
    }

    private bool CanAttempt() =>_currentAttempt <= _options.MaxAttemptsCount;

    private void AcceptAttempt() => _currentAttempt++;
}
