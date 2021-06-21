using System;
using System.Collections.Generic;

namespace DeliveryService.Model
{
    public class Transport : Base
    {
        public TransportType TransportType { get; private set; }
        public List<DeliveryPlace> DeliveryPlaces { get; }

        public int MaxSize { get; }
        public int SizeTaken { get; }
        public int MaxWeight { get; }
        public int WeightTaken { get; }
        public int Speed { get; private set; }

        public Transport(TransportType TransportType, int Speed)
        {
            this.TransportType = TransportType;
            this.Speed = Speed;
        }
    }
}
