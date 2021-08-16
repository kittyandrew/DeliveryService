using System;

namespace DeliveryService.Entity
{
    public class Product : Base<int>
    {

        public string Name { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }

        public int? ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public override string ToString()
        {
            return $"Product(Id={Id}, Type={ProductType}, Name='{Name}', Size={Size}, Weight={Weight})";
        }
    }
}

