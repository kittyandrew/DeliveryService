using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using DeliveryService.GUI.ViewModel;
using DeliveryService.BLL.Abstr;
using DeliveryService.DAL;
using DeliveryService.BLL;
using DeliveryService.GUI.View;

namespace DeliveryService.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.RegisterDALDependencies();
            services.RegisterBLLDependencies();
            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel mainViewModel = new MainViewModel(
                serviceProvider.GetService<IDeliveryService>(), serviceProvider.GetService<IProductService>(),
                serviceProvider.GetService<ITransportService>(), serviceProvider.GetService<IPlaceService>()
            );
            MainWindow mainWindow = new MainWindow { DataContext = mainViewModel };
            mainWindow.Show();
        }
    }
}
