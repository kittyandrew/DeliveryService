using System;
using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Logic
{
    public interface IDeliveryProc
    {
        int GetMaxDistance();

        (Guid, Guid) MakeDelivery(List<Product> products, int distance);
        void FinishDelivery(Guid transportId, Guid deliveryPlaceId);
        double GetApproximateTime(int distance);
    }
}
