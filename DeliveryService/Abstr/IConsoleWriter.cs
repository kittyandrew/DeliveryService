using DeliveryService.Model;
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
        void ShowProducts(IEnumerable<ProductModel> productModels);
        void ShowPlaces(IEnumerable<PlaceModel> placeModels);
        void ShowDelivery(DeliveryModel deliveryModel);
    }
}
