using DeliveryService.BLL.Abstr.Services;
using DeliveryService.BLL.Impl;
using DeliveryService.Entity;
using DeliveryService.GUI.Events;
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
        
        public DisplayDeliveriesViewModel(IEventAggregator eventAggregator, ServiceCollection services) : base(eventAggregator)
        {
            DeliveryService = services.deliveryService;
            Deliveries = new ObservableCollection<Delivery>(DeliveryService.GetAllDeliveries());

            // Managing events for deliveries re-render.
            EventAggregator.GetEvent<UpdateDeliveriesEvent>().Subscribe(RepopulateDeliveries, true);
        }

        private void RepopulateDeliveries()
        {
            // Don't re-assign the variable, because it's an ObservableCollection.
            Deliveries.Clear();
            foreach (Delivery deliveryModel in DeliveryService.GetAllDeliveries())
                Deliveries.Add(deliveryModel);

            // Always set last added element as "selected", if it's present.
            if (Deliveries.Any())
                SelectedDelivery = Deliveries.Last();
            else
                SelectedDelivery = null;
        }
    }
}