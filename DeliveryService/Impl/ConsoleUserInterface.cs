using Microsoft.Extensions.DependencyInjection;
using DeliveryService.Abstr;
using DeliveryService.BLL.Abstr;
using DeliveryService.Model;
using DeliveryService.DAL.Abstr;
using DeliveryService.BLL;
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
        private ICollection<ProductModel> products;
        private ICollection<PlaceModel> places;

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
            DeliveryModel delivery = null;
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

        private DeliveryModel OrderDelivery()
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

            IEnumerable<ProductModel> _product = products.Where(p => p.Id == productId);
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

            IEnumerable<PlaceModel> _place = places.Where(p => p.Id == placeId);
            if (!_place.Any())
            {
                _consoleWriter.Warn("Could not find a place with such ID");
                return null;
            }
            DeliveryModel delivery = _deliveryService.MakeDelivery(_product.First(), _place.First());
            _consoleWriter.Info("You've ordered a delivery");
            return delivery;
        }
    }
}
