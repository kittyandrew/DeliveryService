using System;

namespace DeliveryService.Entity
{
    public class Product : Base<int>
    {
        private static int nextId = 1;
        public string Name { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public ProductType ProductType { get; set; }

        public Product(string name, double size, double weight, ProductType productType)
        {
            Id = nextId++;
            Name = name;
            Size = size;
            Weight = weight;
            ProductType = productType;
        }
    }
}

