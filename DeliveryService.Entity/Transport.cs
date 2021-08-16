using System;

namespace DeliveryService.Entity
{
    public class Transport: Base<int>
    {
        public DateTime FreeBy { get; set; }

        public int? TransportTypeId { get; set; }
        public virtual TransportType TransportType { get; set; }

        public override string ToString()
        {
            return $"Transport(Id={Id}, Type={TransportType})";
        }
    }
}
