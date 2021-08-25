﻿using System;
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
using System.Windows.Input;
using DeliveryService.BLL.Impl;
using DeliveryService.GUI.Commands;
using Prism.Events;
using DeliveryService.GUI.Events;

namespace DeliveryService.GUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _createDeliveryViewModel;
        private BaseViewModel _cancelDeliveryViewModel;
        private BaseViewModel selectedViewModel;
        private DisplayDeliveriesViewModel displayDeliveriesViewModel;

        public readonly IDeliveryService DeliveryService;
        public readonly IProductService ProductService;
        public readonly IPlaceService PlaceService;

        public RelayCommand UpdateViewCommand { get; private set; }

        public BaseViewModel SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }
        public BaseViewModel DisplayDeliveriesViewModel
        {
            get => displayDeliveriesViewModel;
        }

        public MainViewModel(IEventAggregator eventAggregator, ServiceCollection services) : base(eventAggregator)
        {
            DeliveryService = services.deliveryService;
            ProductService = services.productService;
            PlaceService = services.placeService;

            UpdateViewCommand = new RelayCommand(obj => ChangeViewModel(obj));
            displayDeliveriesViewModel = new DisplayDeliveriesViewModel(eventAggregator, DeliveryService);
            _createDeliveryViewModel = new CreateDeliveryViewModel(
                EventAggregator, displayDeliveriesViewModel,
                DeliveryService, ProductService, PlaceService
            );
            _cancelDeliveryViewModel = new CancelDeliveryViewModel(
                EventAggregator, displayDeliveriesViewModel, DeliveryService
            );
        }

        private void ChangeViewModel(object parameter)
        {
            switch (parameter.ToString())
            {
                case "CreateDelivery":
                    SelectedViewModel = _createDeliveryViewModel;
                    break;

                case "CancelDelivery":
                    SelectedViewModel = _cancelDeliveryViewModel;
                    break;

                case null:
                    throw new ArgumentException("Update view command requires a valid argument!");
            }
        }
    }
}
