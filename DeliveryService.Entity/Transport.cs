using System;

namespace DeliveryService.Entity
{
    public class Transport: Base<int>
    {
        private static int nextId = 1;
        public DateTime FreeBy { get; set; }
        public TransportType TransportType { get; set; }

        public Transport(DateTime freeBy, TransportType transportType)
        {
            Id = nextId++;
            FreeBy = freeBy;
            TransportType = transportType;
        }
    }
}
