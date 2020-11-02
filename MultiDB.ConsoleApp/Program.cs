using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MultiDB.Application;
using MultiDB.Application.Command;
using MultiDB.MSSQLDatabase;
using MultiDB.MySQLDatabase;
using System;
using System.Text.Json;

namespace MultiDB.ConsoleApp
{
    class Program
    {
        private static IServiceCollection ServiceCollection 
        {
            get 
            {
                var services = new ServiceCollection();
                services.MSSQLDatabaseInjector(ConnectionString.mssql);
                services.MySQLDatabaseInjector(ConnectionString.mysql);
                services.ApplicationInjector();
                return services;
            }
        }
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var serviceProvider = ServiceCollection.BuildServiceProvider();
            var _mediator = serviceProvider.GetService<IMediator>();
            var result = await _mediator.Send(new AddProfileCommand { Name = "FromConsole" });
            Console.WriteLine(JsonSerializer.Serialize(result));
        }
    }
}
