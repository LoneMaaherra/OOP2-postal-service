using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    public enum Status
    {
        Processing,
        InTransit,
        ReadyForPickup,
        Delivered
    }
}
