using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictValue.Validation.Values.Attempts;

/// <summary>
/// Результат проверки текущей попытки
/// </summary>
public class ValidateAttemtpsCountResult
{
    /// <summary>
    /// Результат проверки
    /// </summary>
    public ValidateAttemtpsCountResultType Result { get; }

    /// <summary>
    /// Номер попытки
    /// </summary>
    public int AttemptNumber { get; }

    public ValidateAttemtpsCountResult(ValidateAttemtpsCountResultType result, int currentAttempt)
    {
        Result = result;
        AttemptNumber = currentAttempt;
    }
}
