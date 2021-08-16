using Microsoft.Extensions.DependencyInjection;
using DeliveryService.Abstr;
using DeliveryService.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IConsoleReader, ConsoleReader>();
            services.AddSingleton<IConsoleWriter, ConsoleWriter>();
            services.AddSingleton<IConsoleUserInterface, ConsoleUserInterface>();
            return services;
        }
    }
}
