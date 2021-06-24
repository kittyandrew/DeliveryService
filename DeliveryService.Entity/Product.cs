using System;

namespace DeliveryService.Entity
{
    public class Product : Base<int>
    {
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public string Name { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Product(Id={Id}, Type={ProductType}, Name='{Name}', Size={Size}, Weight={Weight})";
        }
    }
}

