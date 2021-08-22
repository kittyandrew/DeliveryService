using System;

namespace DeliveryService.Entity
{
    public class Product : Base<int>
    {
        private static int nextId = 1;
        public string Name { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }

        public int ProductTypeId { get; set; }

        public Product(string name, double size, double weight, int productTypeId)
        {
            Id = nextId++;
            Name = name;
            Size = size;
            Weight = weight;
            ProductTypeId = productTypeId;
        }
    }
}

