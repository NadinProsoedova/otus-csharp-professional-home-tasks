namespace PredictValue.Validation.Values.Attempts;

public interface IAttemptsCountValidator
{
    ValidateAttemtpsCountResult Validate(int currentAttempt);
}
