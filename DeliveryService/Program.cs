using System;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TransportType type1 = new TransportType("SUV", 25, 50, 100);
            TransportType type2 = new TransportType("Van", 75, 200, 80);
            TransportType type3 = new TransportType("Truck", 300, 750, 45);

            List<Transport> vehicles = new List<Transport>();
            vehicles.Add(new Transport(type1));
            vehicles.Add(new Transport(type1));
            vehicles.Add(new Transport(type1));

            vehicles.Add(new Transport(type2));
            vehicles.Add(new Transport(type2));
            vehicles.Add(new Transport(type2));

            vehicles.Add(new Transport(type3));
            vehicles.Add(new Transport(type3));

            Console.WriteLine("Available vehicles:");
            foreach (Transport vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

            List<Place> deliveryPlaces = new List<Place>();
            deliveryPlaces.Add(new Place(100, 0.4));
            deliveryPlaces.Add(new Place(25,  0.9));
            deliveryPlaces.Add(new Place(46,  0.34));
            deliveryPlaces.Add(new Place(145, 0.1));
            deliveryPlaces.Add(new Place(60,  0.5));

            Console.WriteLine("Available delivery places:");
            foreach (Place deliveryPlace in deliveryPlaces)
            {
                Console.WriteLine(deliveryPlace);
            }
        }
    }
}
