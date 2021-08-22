using System;

namespace DeliveryService.Entity
{
    public class Place : Base<int>
    {
        private static int nextId = 1;
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Traffic { get; set; }

        public Place(string name, double distance, double traffic)
        {
            Id = nextId++;
            Name = name;
            Distance = distance;
            Traffic = traffic;
        }
    }
}
