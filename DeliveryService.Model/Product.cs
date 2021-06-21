using System;

namespace DeliveryService.Model
{
    public class Product : Base
    {
        public ProductType ProductType { get; private set; }

        public string Name { get; private set; }
        public int    Size { get; private set; }
        public int    Weight { get; private set; }

        public Product(ProductType ProductType, string Name, int Size, int Weight)
        {
            this.ProductType = ProductType;
            this.Name = Name;
            this.Size = Size;
            this.Weight = Weight;
        }
    }
}

