using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PredictNumber.Values;

namespace PredictValue.Values.IntValue;

public static class ServiceCollectionExtensions
{
    public static string ValueRangeOptionsSectionName = "";
    public static IServiceCollection RegisterIntValues(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ValueRangeOptions<int>>(configuration.GetSection(ValueRangeOptionsSectionName));
        services.AddTransient(typeof(IValueProvider<int>), typeof(IntValueRandomProvider));
        return services;
    }
}
