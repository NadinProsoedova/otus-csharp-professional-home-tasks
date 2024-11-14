namespace PredictValue.Validation;

/// <summary>
/// Результат валидации введенного числа
/// </summary>
public enum ValidateValueResultType
{
    /// <summary>
    /// Пустое значение
    /// </summary>
    None = 0,

    /// <summary>
    /// Введенное число меньше загаданного
    /// </summary>
    InputLessThanTarget = 1,

    /// <summary>
    /// Введенное число больше загаданного
    /// </summary>
    InputGreaterThanTarget = 2,

    /// <summary>
    /// Успех - введенное число равно загаданному
    /// </summary>
    Success = 3
}