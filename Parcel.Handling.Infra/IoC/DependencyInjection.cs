using Microsoft.Extensions.DependencyInjection;
using Parcel.Handling.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parcel.Handling.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IContext, DepartmentRespository>();
            services.AddScoped<IParcelContext, ParcelRepository>();
            return services;

        }
    }
}
