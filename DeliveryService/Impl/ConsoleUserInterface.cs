using Microsoft.Extensions.DependencyInjection;
using DeliveryService.Abstr;
using DeliveryService.BLL.Abstr.Services;
using DeliveryService.DAL.Abstr;
using DeliveryService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Impl
{
    public class ConsoleUserInterface : IConsoleUserInterface
    {
        private readonly IProductService _productService;
        private readonly IPlaceService _placeService;
        private readonly IDeliveryService _deliveryService;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConsoleReader _consoleReader;
        private ICollection<Product> products;
        private ICollection<Place> places;

        public ConsoleUserInterface(IProductService productService, IPlaceService placeService,
            IDeliveryService deliveryService,
            IConsoleWriter consoleWriter, IConsoleReader consoleReader)
        {
            _productService = productService;
            _placeService = placeService;
            _deliveryService = deliveryService;
            _consoleWriter = consoleWriter;
            _consoleReader = consoleReader;
            products = _productService.GetAllProducts().ToList();
            places = _placeService.GetAllPlaces().ToList();
        }

        public void Show()
        {
            bool running = true;
            char task;
            Delivery delivery = null;
            while (running)
            {
                _consoleWriter.ShowInstructions();
                task = _consoleReader.GetTask();
                switch (task)
                {
                    case '1':
                        _consoleWriter.ShowProducts(products);
                        break;
                    case '2':
                        _consoleWriter.ShowPlaces(places);
                        break;
                    case '3':
                        delivery = OrderDelivery();
                        break;
                    case '4':
                        if (delivery != null) _consoleWriter.ShowDelivery(delivery);
                        else _consoleWriter.Warn("First you must order a delivery");
                        break;
                    case '5':
                        if (delivery == null)
                        {
                            _consoleWriter.Warn("First you must order a delivery");
                            break;
                        }
                        _deliveryService.CancelDelivery(delivery);
                        delivery = null;
                        _consoleWriter.Info("Your delivery was cancelled");
                        break;
                    case 'q':
                        running = false;
                        break;
                }
            }
        }

        private Delivery OrderDelivery()
        {
            int productId;
            try
            {
                productId = _consoleReader.GetProductId();
            }
            catch (Exception e) when (e is FormatException || e is OverflowException)
            {
                _consoleWriter.Warn("Entered value is an unacceptable product ID");
                return null;
            };

            IEnumerable<Product> _product = products.Where(p => p.Id == productId);
            if (!_product.Any())
            {
                _consoleWriter.Warn("Could not find a product with such ID");
                return null;
            }

            int placeId;
            try
            {
                placeId = _consoleReader.GetPlaceId();
            }
            catch (Exception e) when (e is FormatException || e is OverflowException)
            {
                _consoleWriter.Warn("Entered value is an unacceptable place ID");
                return null;
            };

            IEnumerable<Place> _place = places.Where(p => p.Id == placeId);
            if (!_place.Any())
            {
                _consoleWriter.Warn("Could not find a place with such ID");
                return null;
            }
            Delivery delivery = _deliveryService.MakeDelivery(_product.First(), _place.First());
            _consoleWriter.Info("You've ordered a delivery");
            return delivery;
        }
    }
}
