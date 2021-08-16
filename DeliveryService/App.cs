using Microsoft.Extensions.DependencyInjection;
using DeliveryService.BLL.Abstr;
using DeliveryService.Abstr;
using DeliveryService.DAL;
using DeliveryService.BLL;
using System;

namespace DeliveryService
{
    class App
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.RegisterDALDependencies();
            services.RegisterBLLDependencies();
            services.RegisterDependencies();
            serviceProvider = services.BuildServiceProvider();
        }

        public void Run()
        {
            IConsoleUserInterface consoleInterface = serviceProvider.GetRequiredService<IConsoleUserInterface>();
            consoleInterface.Show();
        }
    }
}