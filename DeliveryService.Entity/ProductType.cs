using System;

namespace DeliveryService.Entity
{
    public class ProductType : Base<int>
    {
        private static int nextId = 1;
        public string Name { get; set; }
        public int TransportTypeId { get; set; }
        
        public ProductType(string name, int transportTypeId)
        {
            Id = nextId++;
            Name = name;
            TransportTypeId = transportTypeId;
        }
    }
}
