using DeliveryService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Abstr
{
    public interface IConsoleWriter
    {
        void ShowInstructions();
        void Warn(string warning);
        void Info(string message);
        void ShowProducts(IEnumerable<Product> product);
        void ShowPlaces(IEnumerable<Place> place);
        void ShowDelivery(Delivery delivery);
    }
}
