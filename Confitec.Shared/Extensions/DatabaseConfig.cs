using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Confitec.Infra;
using System;

namespace Confitec.Shared.Extensions
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
