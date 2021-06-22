using System;

namespace DeliveryService.Model
{
    public class Product : Base
    {
        public ProductType Type { get; private set; }

        public string Name { get; private set; }
        public int    Size { get; private set; }
        public int    Weight { get; private set; }

        public Product(ProductType type, string name, int size, int weight)
        {
            this.Type = type;
            this.Name = name;
            this.Size = size;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return "Product(Type=" + Type + ", Name='" + Name + "', Size=" + Size + ", Weight=" + Weight + ")";
        }
    }
}

