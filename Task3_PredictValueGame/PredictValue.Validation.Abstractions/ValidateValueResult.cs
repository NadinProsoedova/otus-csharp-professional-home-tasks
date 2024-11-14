namespace PredictValue.Validation;

/// <summary>
/// 
/// </summary>
public class ValidateValueResult
{
    /// <summary>
    /// 
    /// </summary>
    public ValidateValueResultType Result { get; }

    public ValidateValueResult(ValidateValueResultType result)
    {
        Result = result;
    }
}
