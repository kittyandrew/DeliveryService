using System;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TransportType type1 = new TransportType { Name = "SUV", MaxSize = 25, MaxWeight = 50, Speed = 100 };
            TransportType type2 = new TransportType { Name = "Van", MaxSize = 75, MaxWeight = 200, Speed = 80 };
            TransportType type3 = new TransportType { Name = "Truck", MaxSize = 300, MaxWeight = 750, Speed = 45 };

            List<Transport> vehicles = new List<Transport>();
            vehicles.Add(new Transport { TransportType = type1 });
            vehicles.Add(new Transport { TransportType = type1 });
            vehicles.Add(new Transport { TransportType = type1 });

            vehicles.Add(new Transport { TransportType = type2 });
            vehicles.Add(new Transport { TransportType = type2 });
            vehicles.Add(new Transport { TransportType = type2 });

            vehicles.Add(new Transport { TransportType = type3 });
            vehicles.Add(new Transport { TransportType = type3 });

            Console.WriteLine("Available vehicles:");
            foreach (Transport vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

            List<Place> deliveryPlaces = new List<Place>();
            deliveryPlaces.Add(new Place { Distance = 100, Traffic = 0.4 });
            deliveryPlaces.Add(new Place { Distance = 25, Traffic = 0.9 });
            deliveryPlaces.Add(new Place { Distance = 46, Traffic = 0.34 });
            deliveryPlaces.Add(new Place { Distance = 145, Traffic = 0.1 });
            deliveryPlaces.Add(new Place { Distance = 60, Traffic = 0.5 });

            Console.WriteLine("Available delivery places:");
            foreach (Place deliveryPlace in deliveryPlaces)
            {
                Console.WriteLine(deliveryPlace);
            }
        }
    }
}
