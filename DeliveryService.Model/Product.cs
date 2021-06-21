using System;

namespace DeliveryService.Model
{
    public class Product : Base
    {
        public ProductType Type { get; private set; }

        public string Name { get; private set; }
        public int    Size { get; private set; }
        public int    Weight { get; private set; }

        public Product(ProductType Type, string Name, int Size, int Weight)
        {
            this.Type = Type;
            this.Name = Name;
            this.Size = Size;
            this.Weight = Weight;
        }

        public override string ToString()
        {
            return "Product(Type=" + Type + ", Name='" + Name + "', Size=" + Size + ", Weight=" + Weight + ")";
        }
    }
}

