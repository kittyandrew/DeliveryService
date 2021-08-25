using System.Windows;
using DeliveryService.GUI.ViewModel;
using DeliveryService.BLL.Abstr;
using DeliveryService.DAL;
using DeliveryService.BLL;
using DeliveryService.GUI.View;
using DeliveryService.BLL.Impl;
using Prism.Events;

namespace DeliveryService.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceCollection services;
        private readonly IEventAggregator eventAggregator;

        public App()
        {
            services = new ServiceCollection();
            eventAggregator = new EventAggregator();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel mainViewModel = new MainViewModel(eventAggregator, services);
            MainWindow mainWindow = new MainWindow { DataContext = mainViewModel };
            mainWindow.Show();
        }
    }
}
