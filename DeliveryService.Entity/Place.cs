using System;

namespace DeliveryService.Entity
{
    public class Place : Base<int>
    {
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Traffic { get; set; }

        public Place()
        {

        }

        public Place(string name, double distance, double traffic)
        {
            Name = name;
            Distance = distance;
            Traffic = traffic;
        }
    }
}
