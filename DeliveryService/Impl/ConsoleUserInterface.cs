﻿using DeliveryService.Abstr;
using DeliveryService.BLL.Abstr.Services;
using DeliveryService.DAL.Abstr;
using DeliveryService.BLL.Impl;
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
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConsoleReader _consoleReader;
        private readonly ServiceCollection _services;
        private readonly ICollection<Product> products;
        private readonly ICollection<Place> places;

        public ConsoleUserInterface(
            ServiceCollection services,
            IConsoleWriter consoleWriter,
            IConsoleReader consoleReader
        )
        {
            _services = services;
            _consoleWriter = consoleWriter;
            _consoleReader = consoleReader;
            products = services.productService.GetAllProducts().ToList();
            places = services.placeService.GetAllPlaces().ToList();
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
                        _services.deliveryService.CancelDelivery(delivery);
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

            Delivery delivery = _services.deliveryService.MakeDelivery(_product.First(), _place.First());
            _consoleWriter.Info("You've ordered a delivery");
            return delivery;
        }
    }
}
