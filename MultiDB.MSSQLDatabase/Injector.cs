using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDB.MSSQLDatabase
{
    public static class Injector
    {
        public static IServiceCollection MSSQLDatabaseInjector(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<MSSQLApplicationDBContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IMSSQLApplicationDBContext, MSSQLApplicationDBContext>();
            return services;
        }
    }
}
