using DeliveryService.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.GUI.Events
{
    public class SelectedDeliveryEvent : PubSubEvent<DeliveryModel>
    {

    }
}
