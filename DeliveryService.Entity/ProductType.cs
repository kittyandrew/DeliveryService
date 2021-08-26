using System;
using System.Collections.Generic;

namespace DeliveryService.Entity
{
    public class ProductType : Base<int>
    {
        public string Name { get; set; }
        public virtual ICollection<TransportForProduct> TransportForProducts { get; set; }

        public ProductType()
        {

        }
        public ProductType(string name)
        {
            Name = name;
            TransportForProducts = new List<TransportForProduct>();
        }
    }
}
