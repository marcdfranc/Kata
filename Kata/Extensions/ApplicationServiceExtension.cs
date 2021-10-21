using Applicattion.Baskets;
using Applicattion.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace Kata.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt => {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddMediatR(typeof(Create).Assembly);
            return services;
        }

    }
}
