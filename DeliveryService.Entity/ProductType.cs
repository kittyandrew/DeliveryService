using System;

namespace DeliveryService.Entity
{
    public class ProductType : Base<int>
    {
        public string Name { get; set; }
        public int? TransportTypeId { get; set; }
        public virtual TransportType TransportType { get; set; }

        public override string ToString()
        {
            return $"ProductType(Id={Id}, Name={Name}, TransportType={TransportType})";
        }
    }
}
