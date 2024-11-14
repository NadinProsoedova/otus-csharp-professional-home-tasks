namespace PredictNumber.Domain;

internal class RandomNumberProvider
{
    private readonly GenerateNumberOptions _options;
    public RandomNumberProvider(GenerateNumberOptions options)
    {
        _options = options;
    }
    public int GetNumber()
    {
        var gen = new Random((int)DateTime.Now.Ticks);
        return gen.Next(_options.MinValue, _options.MaxValue);
    }
}
