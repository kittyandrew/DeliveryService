using System;
using System.Collections.Generic;

namespace DeliveryService.Model
{
    public class DeliveryPlace : Base
    {
        public int Distance { get; private set; }
        public List<Product> Products { get; }

        public DeliveryPlace(int Distance)
        {
            this.Distance = Distance;
        }
    }
}
