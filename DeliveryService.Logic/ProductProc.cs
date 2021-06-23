using System;
using System.Configuration;
using DeliveryService.Dao;
using DeliveryService.Model;

namespace DeliveryService.Logic
{
    public class ProductProc : IProductProc
    {
        private DaoObject dao;
        private readonly int maxSize;
        private readonly int maxWeight;

        public ProductProc(DaoObject dao)
        {
            this.dao = dao;
            maxSize = Convert.ToInt32(ConfigurationManager.AppSettings.Get("VehicleMaxSize"));
            maxWeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("VehicleMaxWeight"));
        }

        public int GetMaxSize()
        {
            return maxSize;
        }

        public int GetMaxWeight()
        {
            return maxWeight;
        }

        public Guid MakeProduct(ProductType productType, string name, int size, int weight)
        {
            // Validate product type:
            if (!Enum.IsDefined(typeof(ProductType), productType))
                throw new ArgumentException($"Product type must be a valid ProductType enum: '{productType}'!");

            if (name == "")
                throw new ArgumentException("Error: Product name can't be an empty string!");

            // Validate product size:
            if (size <= 0 || size > GetMaxSize())
                throw new ArgumentException($"Product type must be a valid size, between '0' and '{GetMaxSize()}': '{size}'!");

            // Validate product weight:
            if (size <= 0 || size > GetMaxWeight())
                throw new ArgumentException($"Product type must be a valid weight, between '0' and '{GetMaxWeight()}': '{weight}'!");

            Product product = new Product(productType, name, size, weight);
            dao.ProductDao.Create(product);
            return product.Id;
        }

        public Product GetProduct(String guid)
        {
            if (guid == "")
                throw new ArgumentException("Product id must not be an empty string!");

            try
            {
                return dao.ProductDao.Get(new Guid(guid));
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
