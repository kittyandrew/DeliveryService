using DeliveryService.BLL.Abstr.Services;
using DeliveryService.Entity;
using DeliveryService.GUI.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.GUI.ViewModel
{
    public class CreateDeliveryViewModel : BaseViewModel
    {
        private readonly DisplayDeliveriesViewModel DisplayDeliveriesViewModel;
        private readonly IDeliveryService DeliveryService;
        private readonly IProductService ProductService;
        private readonly IPlaceService PlaceService;

        private Product selectedProduct;
        private Place selectedPlace;

        public ObservableCollection<Place> Places { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        public RelayCommand MakeDeliveryCommand { get; private set; }

        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        public Place SelectedPlace
        {
            get { return selectedPlace; }
            set
            {
                selectedPlace = value;
                OnPropertyChanged("SelectedPlace");
            }
        }

        public CreateDeliveryViewModel(
            IEventAggregator eventAggregator,
            DisplayDeliveriesViewModel displayDeliveriesViewModel,
            IDeliveryService deliveryService, IProductService productService,
            IPlaceService placeService
        ) : base(eventAggregator)
        {
            DisplayDeliveriesViewModel = displayDeliveriesViewModel;
            DeliveryService = deliveryService;
            ProductService = productService;
            PlaceService = placeService;

            Places = new ObservableCollection<Place>(PlaceService.GetAllPlaces());
            Products = new ObservableCollection<Product>(ProductService.GetAllProducts());

            MakeDeliveryCommand = new RelayCommand(obj => MakeDelivery());
        }
        private void MakeDelivery()
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("You have to choose some product first!", "Warning!");
                return;
            }
            if (selectedPlace == null)
            {
                MessageBox.Show("You have to choose some place first!", "Warning!");
                return;
            }
            DisplayDeliveriesViewModel.SelectedDelivery = DeliveryService.MakeDelivery(selectedProduct, selectedPlace);
            DisplayDeliveriesViewModel.RepopulateDeliveries();
            MessageBox.Show(PrettyPrintNewDelivery(DisplayDeliveriesViewModel.SelectedDelivery), "Successfully created new delivery!");
        }

        private string PrettyPrintNewDelivery(Delivery deliveryModel)
        {
            return $"{"Arives at:",-13}{deliveryModel.DeliveryTime}\n"
                 + $"{"Place:",-14}{deliveryModel.Place.Name}\n"
                 + $"{"Distance:",-11}{deliveryModel.Place.Distance}\n"
                 + $"{"Traffic %:",-13}{deliveryModel.Place.Traffic}\n"
                 + $"{"Vehicle:",-13}{deliveryModel.Transport.TransportType.Name}\n"
                 + $"{"Product:",-12}{deliveryModel.Product.Name}\n";
        }
    }
}
