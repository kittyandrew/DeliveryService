using System;
using DeliveryService.Dao;
using DeliveryService.Model;

namespace DeliveryService
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            DaoObject dao = new DaoObject();

            dao.ProductDao.Create(new Product(ProductType.Food, "Box of apples", 10, 25));
            dao.ProductDao.Create(new Product(ProductType.Convenience, "Unbranded Toothpaste", 2, 1));
            dao.ProductDao.Create(new Product(ProductType.Dairy, "Milk", 3, 3));

            foreach (Product Item in dao.ProductDao.GetAll())
            {
                Console.WriteLine(Item);
            }
        }
    }
}
