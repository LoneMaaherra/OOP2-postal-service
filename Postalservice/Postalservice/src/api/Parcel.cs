using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    public class Parcel
    {
        public string ShipmentId { get; set; }
        public Address AddressFrom { get; set; }
        public Address AddressTo { get; set; }
        public List<Transport> TransferHistory { get; set; } 


        public Parcel()
        {
            
        }
    }
}
