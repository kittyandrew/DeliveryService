using System;

namespace DeliveryService.Entity
{
    public class Transport: Base<int>
    {
        private static int nextId = 1;
        public DateTime FreeBy { get; set; }
        public int TransportTypeId { get; set; }

        public Transport(DateTime freeBy, int transportTypeId)
        {
            Id = nextId++;
            FreeBy = freeBy;
            TransportTypeId = transportTypeId;
        }
    }
}
