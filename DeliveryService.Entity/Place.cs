using System;

namespace DeliveryService.Entity
{
    public class Place : Base<int>
    {
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Traffic { get; set; }

        public override string ToString()
        {
            return $"Place(Id={Id}, Name={Name}, Distance={Distance}, Traffic={Traffic})";
        }
    }
}
