using Microsoft.Extensions.DependencyInjection;
using Parcel.Handling.Application.common;
using Parcel.Handling.Application.Common;
using Parcel.Handling.Application.Services;


namespace Parcel.Handling.Application.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IParcelService, ParcelService>();
            return services;

        }
    }
}
