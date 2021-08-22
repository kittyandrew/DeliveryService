using DeliveryService.BLL.Impl;
using DeliveryService.Impl;
using DeliveryService.Abstr;
using DeliveryService.DAL;
using DeliveryService.BLL;
using System;

namespace DeliveryService
{
    class App
    {
        private readonly ServiceCollection services;
        private readonly IConsoleReader consoleReader;
        private readonly IConsoleWriter consoleWriter;
        private readonly IConsoleUserInterface consoleUserInterface;

        public App()
        {
            services = new ServiceCollection();
            consoleReader = new ConsoleReader();
            consoleWriter = new ConsoleWriter();
            consoleUserInterface = new ConsoleUserInterface(
                services.productService, services.placeService,
                services.deliveryService,
                consoleWriter, consoleReader
            );
        }

        public void Run()
        {
            consoleUserInterface.Show();
        }
    }
}