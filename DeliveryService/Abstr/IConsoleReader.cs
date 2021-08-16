using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Abstr
{
    public interface IConsoleReader
    {
        char GetTask();
        int GetProductId();
        int GetPlaceId();
    }
}
