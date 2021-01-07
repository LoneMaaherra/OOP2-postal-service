using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    public class Transport
    {
        public PostalOffice FromPO { get; set; }
        public PostalOffice ToPO { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
