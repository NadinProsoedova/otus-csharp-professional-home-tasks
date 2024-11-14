using PredictValue.Validation.Values.Attempts;

namespace PredictValue.Validation.Attempts;

internal class AttemptsCountValidator: IAttemptsCountValidator
{
    private readonly AttemptsCountOptions _options;

    public AttemptsCountValidator(AttemptsCountOptions options)
    {
        _options = options;
    }

    public ValidateAttemtpsCountResult Validate(int currentAttempt)
    {
        if (currentAttempt <= _options.MaxAttemptsCount)
        {
            return new ValidateAttemtpsCountResult(ValidateAttemtpsCountResultType.Success, currentAttempt);
        }
        else
        {
            return new ValidateAttemtpsCountResult(ValidateAttemtpsCountResultType.AttemptsCountExceed, currentAttempt);
        }
    }
}
