using System;
using System.Linq;
using System.Collections.Generic;

namespace DeliveryService.Model
{
    public class DeliveryPlace : Base
    {
        private int Distance { get; }
        private List<Product> Products { get; }

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
            return $"DeliveryPlace(Id={Id}, Products='{Products.Count} Items', Distance={Distance})";
        }
    }
}
