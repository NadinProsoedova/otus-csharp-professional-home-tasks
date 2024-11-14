using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PredictValue.Validation.Values.Attempts;

namespace PredictValue.Validation.Attempts
{
    public static class ServiceCollectionExtensions
    {
        public static string AttemptsValidationOptionsSectionName = "";
        public static IServiceCollection RegisterAttemptsValidation(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AttemptsCountOptions>(configuration.GetSection(AttemptsValidationOptionsSectionName));
            return services;
        }
    }
}
