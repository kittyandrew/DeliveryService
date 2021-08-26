using System;

namespace DeliveryService.Entity
{
    public class TransportType : Base<int>
    {
        public string Name { get; set; }
        public double MaxSize { get; set; }
        public double MaxWeight { get; set; }
        public double Speed { get; set; }

        public TransportType(string name, double maxSize, double maxWeight, double speed)
        {
            Name = name;
            MaxSize = maxSize;
            MaxWeight = maxWeight;
            Speed = speed;
        }
    }
}
