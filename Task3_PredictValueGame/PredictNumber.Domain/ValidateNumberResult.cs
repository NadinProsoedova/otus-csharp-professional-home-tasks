namespace PredictNumber.Domain;

/// <summary>
/// 
/// </summary>
public class ValidateNumberResult
{
    /// <summary>
    /// 
    /// </summary>
    public ValidateNumberResultType Result { get; }

    /// <summary>
    /// 
    /// </summary>
    public int AttemptNumber { get; }

    public ValidateNumberResult(ValidateNumberResultType result, int currentAttempt)
    {
        Result = result;
        AttemptNumber = currentAttempt;
    }
}
