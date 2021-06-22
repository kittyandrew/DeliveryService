using System;
using System.Collections.Generic;
using DeliveryService.Dao;
using DeliveryService.Model;
using DeliveryService.Logic;

namespace DeliveryService
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            DaoObject dao = new DaoObject();
            TransportProc transportProc = new TransportProc(dao);

            List<Product> productCart = new List<Product>();
            productCart.Add(new Product(ProductType.Food, "Box of apples", 10, 25));
            productCart.Add(new Product(ProductType.Convenience, "Unbranded Toothpaste", 2, 1));
            productCart.Add(new Product(ProductType.Dairy, "Milk", 3, 3));

            foreach (Product product in productCart)
            {
                dao.ProductDao.Create(product);
            }

            Console.WriteLine("Creating products:");
            foreach (Product Item in dao.ProductDao.GetAll())
            {
                Console.WriteLine(Item);
            }

            Console.WriteLine("Creating delivery:");
            DeliveryPlace deliveryPlace = new DeliveryPlace(productCart, 200);
            transportProc.AddDelivery(deliveryPlace);
            Console.WriteLine(deliveryPlace);
        }
    }
}
