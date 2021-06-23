using System;
using System.Collections.Generic;

namespace DeliveryService.Model
{
    public class Product : Base
    {
        public ProductType Type { get; private set; }

        public string Name   { get; private set; }
        public int    Size   { get; private set; }
        public int    Weight { get; private set; }

        public Product(ProductType type, string name, int size, int weight)
        {
            Type = type;
            Name = name;
            Size = size;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Product(Id={Id}, Type={Type}, Name='{Name}', Size={Size}, Weight={Weight})";
        }
    }
}

