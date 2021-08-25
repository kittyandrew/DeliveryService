using System;
using System.Collections.Generic;

namespace DeliveryService.Entity
{
    public class ProductType : Base<int>
    {
        private static int nextId = 1;
        public string Name { get; set; }
        public ICollection<TransportType> TransportTypes { get; set; }
        
        public ProductType(string name)
        {
            Id = nextId++;
            Name = name;
            TransportTypes = new List<TransportType>();
        }
    }
}
