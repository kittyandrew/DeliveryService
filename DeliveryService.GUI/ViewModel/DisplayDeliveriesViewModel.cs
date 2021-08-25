using DeliveryService.BLL.Abstr.Services;
using DeliveryService.Entity;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.GUI.ViewModel
{
    public class DisplayDeliveriesViewModel : BaseViewModel
    {

        private readonly IDeliveryService DeliveryService;
        public ObservableCollection<Delivery> Deliveries { get; set; }
        
        public DisplayDeliveriesViewModel(IEventAggregator eventAggregator, IDeliveryService deliveryService) : base(eventAggregator)
        {
            DeliveryService = deliveryService;
            Deliveries = new ObservableCollection<Delivery>(DeliveryService.GetAllDeliveries());
        }

        public void RepopulateDeliveries()
        {
            Deliveries.Clear();
            foreach (Delivery deliveryModel in DeliveryService.GetAllDeliveries())
                Deliveries.Add(deliveryModel);

            // Always set last added element as "selected"
            if (Deliveries.Any())
                SelectedDelivery = Deliveries.Last();
            else
                SelectedDelivery = null;
        }
    }
}