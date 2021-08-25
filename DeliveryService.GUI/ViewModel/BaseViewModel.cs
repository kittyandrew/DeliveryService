using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DeliveryService.BLL.Abstr;
using System.Windows.Controls;
using DeliveryService.BLL.Abstr.Services;
using DeliveryService.Entity;
using Prism.Events;
using DeliveryService.GUI.Events;

namespace DeliveryService.GUI.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly IEventAggregator EventAggregator;
        private Delivery selectedDelivery { get; set; }
        public Delivery SelectedDelivery
        {
            get => selectedDelivery;
            set
            {
                selectedDelivery = value;
                OnPropertyChanged("SelectedDelivery");
                EventAggregator.GetEvent<SelectedDeliveryEvent>().Publish(selectedDelivery);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public BaseViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            EventAggregator.GetEvent<SelectedDeliveryEvent>().Subscribe(d => selectedDelivery = d, true);
        }
    }
}
