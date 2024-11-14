using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PredictValue.Validation.IntValue;

public static class ServiceCollectionExtensions
{
    public static string ValidateValueOptionsSectionName = "";
    public static IServiceCollection RegisterIntValueValidation(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ValidateValueOptions>(configuration.GetSection(ValidateValueOptionsSectionName));
        return services;
    }
}
