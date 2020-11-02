using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDB.MySQLDatabase
{
    public static class Injector
    {
        public static IServiceCollection MySQLDatabaseInjector(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MySQLApplicationDBContext>(opt => opt.UseMySql(connectionString));
            services.AddScoped<IMySQLApplicationDBContext, MySQLApplicationDBContext>();
            return services;
        }
    }
}
