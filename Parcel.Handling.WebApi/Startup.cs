using DepartmentDBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Parcel.Handling.Application.IoC;
using Parcel.Handling.Infra.IoC;
using System;

namespace Parcel.Handling.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration){
            _configuration = configuration;

        }
        

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSettings(_configuration);

            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Department"))
                .AddMemoryCache()
                .AddAplication()
                .AddRepository()
                .AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Parcel Handling",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "A.M Vieira",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/alemoraisvieira/"),
                    },
                });
            });   
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parcel Handling V1");

                c.RoutePrefix = string.Empty;
            });
        }
    }
}
