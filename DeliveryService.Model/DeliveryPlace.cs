using System;
using System.Linq;
using System.Collections.Generic;

namespace DeliveryService.Model
{
    public class DeliveryPlace : Base
    {
        public int Distance { get; private set; }
        public List<Product> Products { get; }

        public DeliveryPlace(List<Product> products, int distance)
        {
            this.Products = products;
            this.Distance = distance;
        }

        public int GetTotalDeliverySize()
        {
            return Products.Aggregate(0, (total, t) => total + t.Size);
        }

        public int GetTotalDeliveryWeight()
        {
            return Products.Aggregate(0, (total, t) => total + t.Weight);
        }

        public override string ToString()
        {
            return "DeliveryPlace(Products='" + Products.Count + " Items', Distance=" + Distance + ")";
        }
    }
}
