using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parcel.Handling.Application.Dto;
using Parcel.Handling.Domain;

namespace Parcel.Handling.Infra.IoC
{
    public static class SettingsCollectionExtension
    {
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<PathOption>(configuration.GetSection("PathOption"));
            return services;

        }
    }
}
