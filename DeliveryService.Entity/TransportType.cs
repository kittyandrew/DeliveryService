using System;

namespace DeliveryService.Entity
{
    public class TransportType : Base<int>
    {
        public string Name { get; set; }
        public double MaxSize { get; set; }
        public double MaxWeight { get; set; }
        public double Speed { get; set; }

        public override string ToString()
        {
            return $"TransportType(Id={Id}, Name={Name}, MaxSize={MaxSize}, MaxWeight={MaxWeight}, Speed={Speed})";
        }
    }
}
