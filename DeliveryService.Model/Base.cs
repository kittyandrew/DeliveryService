using System;

namespace DeliveryService.Model
{
    public abstract class Base
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
