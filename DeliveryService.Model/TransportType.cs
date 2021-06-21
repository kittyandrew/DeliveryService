using System;

namespace DeliveryService.Model
{
    public enum TransportType
    {
        SUV,  // Can deliver only tiny small products.
        VAN,  // Medium sized vehicle, can contain freezer for foods.
        TRUCK,  // Huge truck, which can deliver any products in huge amounts. 
    }
}
