namespace PredictValue.Validation.Values.Attempts;

/// <summary>
/// Результат валидации попытки
/// </summary>
public enum ValidateAttemtpsCountResultType
{
    /// <summary>
    /// Пустое значение
    /// </summary>
    None = 0,

    /// <summary>
    /// Успех - попытка в пределах максимально допустимого кол-ва попыток
    /// </summary>
    Success = 1,

    /// <summary>
    /// Кол-во попыток исчерпано
    /// </summary>
    AttemptsCountExceed = -1
}
