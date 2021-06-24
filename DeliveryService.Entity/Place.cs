using System;

namespace DeliveryService.Entity
{
    public class Place : Base<int>
    {
        public double Distance { get; set; }
        public double Traffic { get; set; }

        public override string ToString()
        {
            return $"Place(Id={Id}, Distance={Distance}, Traffic={Traffic})";
        }
    }
}
