using DeliveryService.BLL.Abstr.Services;
using DeliveryService.BLL.Impl;
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
        private readonly IDeliveryService DeliveryService;
        public RelayCommand CancelDeliveryCommand { get; private set; }

        public CancelDeliveryViewModel(IEventAggregator eventAggregator, ServiceCollection services) : base(eventAggregator)
        {
            DeliveryService = services.deliveryService;

            CancelDeliveryCommand = new RelayCommand(obj => CancelDelivery());
        }

        private void CancelDelivery()
        {
            // Making sure there is anything to cancel.
            if (!VerifyDeliveryDataOrWarn()) return;

            // Calling delivery service to cancel selected delivery.
            DeliveryService.CancelDelivery(SelectedDelivery);

            // Notifying DisplayDeliveries ViewModel that we want to re-render deliveries.
            EventAggregator.GetEvent<UpdateDeliveriesEvent>().Publish();

            // Notify user about the happy path.
            MessageBox.Show("Your delivery was cancelled!", "Success!");
        }

        private bool VerifyDeliveryDataOrWarn()
        {
            if (SelectedDelivery == null)
            {
                MessageBox.Show("You have to choose delivery to cancel first!", "Warning!");
                return false;
            }

            return true;
        }
    }
}
