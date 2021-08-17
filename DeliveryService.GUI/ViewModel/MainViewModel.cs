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
using DeliveryService.Model;
using System.Windows.Controls;

namespace DeliveryService.GUI.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDeliveryService DeliveryService;
        private readonly IProductService ProductService;
        private readonly ITransportService TransportService;
        private readonly IPlaceService PlaceService;

        private ProductModel selectedProduct;
        private PlaceModel selectedPlace;
        private DeliveryModel selectedDelivery;

        public ObservableCollection<PlaceModel> Places { get; set; }
        public ObservableCollection<DeliveryModel> Deliveries { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }

        public RelayCommand MakeDeliveryCommand { get; private set; }
        public RelayCommand CancelDeliveryCommand { get; private set; }

        public ProductModel SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        public PlaceModel SelectedPlace
        {
            get { return selectedPlace; }
            set
            {
                selectedPlace = value;
                OnPropertyChanged("SelectedPlace");
            }
        }

        public DeliveryModel SelectedDelivery
        {
            get { return selectedDelivery; }
            set
            {
                selectedDelivery = value;
                OnPropertyChanged("SelectedDelivery");
            }
        }

        public MainViewModel(
            IDeliveryService deliveryService, IProductService productService,
            ITransportService transportService, IPlaceService placeService
        )
        {
            DeliveryService = deliveryService;
            ProductService = productService;
            TransportService = transportService;
            PlaceService = placeService;

            Deliveries = new ObservableCollection<DeliveryModel>(DeliveryService.GetAllDeliveries());
            Places = new ObservableCollection<PlaceModel>(PlaceService.GetAllPlaces());
            Products = new ObservableCollection<ProductModel>(ProductService.GetAllProducts());

            MakeDeliveryCommand = new RelayCommand(obj => MakeDelivery());
            CancelDeliveryCommand = new RelayCommand(obj => CancelDelivery());
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
            DeliveryModel deliveryModel = DeliveryService.MakeDelivery(SelectedProduct, SelectedPlace);
            SelectedDelivery = deliveryModel;
            RepopulateDeliveries();
            MessageBox.Show(DisplayDelivery(deliveryModel), "Successfully created new delivery!");
        }

        private string DisplayDelivery(DeliveryModel deliveryModel)
        {
            return $"{"Arives at:", -12}{deliveryModel.DeliveryTime}\n"
                 + $"{"Place:", -14}{deliveryModel.PlaceModel.Name}\n"
                 + $"{"Distance:", -11}{deliveryModel.PlaceModel.Distance}\n"
                 + $"{"Traffic %:", -13}{deliveryModel.PlaceModel.Traffic}\n"
                 + $"{"Vehicle:", -13}{deliveryModel.TransportModel.TransportTypeModel.Name}\n"
                 + $"{"Product:", -12}{deliveryModel.ProductModel.Name}\n";
        }

        private void CancelDelivery()
        {
            if (selectedDelivery == null)
            {
                MessageBox.Show("You have to choose delivery to cancel first!", "Warning!");
                return;
            }
            DeliveryService.CancelDelivery(selectedDelivery);
            SelectedDelivery = null;
            RepopulateDeliveries();
            MessageBox.Show("Your delivery was cancelled!", "Success!");
        }

        private void RepopulateDeliveries()
        {
            Deliveries.Clear();
            foreach (DeliveryModel deliveryModel in DeliveryService.GetAllDeliveries())
            {
                Deliveries.Add(deliveryModel);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
