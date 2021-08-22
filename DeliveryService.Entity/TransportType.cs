using System;

namespace DeliveryService.Entity
{
    public class TransportType : Base<int>
    {
        private static int nextId = 1;
        public string Name { get; set; }
        public double MaxSize { get; set; }
        public double MaxWeight { get; set; }
        public double Speed { get; set; }

        public TransportType(string name, double maxSize, double maxWeight, double speed)
        {
            Id = nextId++;
            Name = name;
            MaxSize = maxSize;
            MaxWeight = maxWeight;
            Speed = speed;
        }
    }
}
