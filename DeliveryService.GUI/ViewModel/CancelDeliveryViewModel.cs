using DeliveryService.BLL.Abstr.Services;
using DeliveryService.Entity;
using DeliveryService.GUI.Commands;
using DeliveryService.GUI.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.GUI.ViewModel
{
    public class CancelDeliveryViewModel : BaseViewModel
    {
        private readonly DisplayDeliveriesViewModel DisplayDeliveriesViewModel;
        private readonly IDeliveryService DeliveryService;
        public RelayCommand CancelDeliveryCommand { get; private set; }

        public CancelDeliveryViewModel(
            IEventAggregator eventAggregator,
            DisplayDeliveriesViewModel displayDeliveriesViewModel,
            IDeliveryService deliveryService
        ) : base(eventAggregator)
        {
            DisplayDeliveriesViewModel = displayDeliveriesViewModel;
            DeliveryService = deliveryService;

            CancelDeliveryCommand = new RelayCommand(obj => CancelDelivery());
        }

        private void CancelDelivery()
        {
            if (SelectedDelivery == null)
            {
                MessageBox.Show("You have to choose delivery to cancel first!", "Warning!");
                return;
            }
            DeliveryService.CancelDelivery(SelectedDelivery);
            DisplayDeliveriesViewModel.RepopulateDeliveries();
            MessageBox.Show("Your delivery was cancelled!", "Success!");
        }
    }
}
