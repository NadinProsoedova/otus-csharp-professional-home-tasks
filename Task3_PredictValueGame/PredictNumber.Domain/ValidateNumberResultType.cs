namespace PredictNumber.Domain;

/// <summary>
/// Результат валидации введенного числа
/// </summary>
public enum ValidateNumberResultType
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
    Success = 3,

    /// <summary>
    /// Кол-во попыток исчерпано
    /// </summary>
    AttemptsCountExceed = -1
}