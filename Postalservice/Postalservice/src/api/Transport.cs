using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    public class Transport
    {
        public string Id { get; set; } 
        public Vehicle Vehicle { get; set; }
        public PostalOffice FromPO { get; set; }
        public PostalOffice ToPO { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime PrelDeparture { get; set; }

        public Transport(string id)
        {
            Dictionary<string, string> transportDict = DBConnectionManger.GetTransport(Int32.Parse(id));

            Id = id;
            Vehicle = new Vehicle(transportDict["Vehicle"]);
            FromPO = new PostalOffice(transportDict["FromPO"]);
            ToPO = new PostalOffice(transportDict["ToPO"]);
            Departure = string.IsNullOrEmpty(transportDict["DateSent"]) ? (DateTime?)null : DateTime.Parse(transportDict["DateSent"]);
            Arrival = string.IsNullOrEmpty(transportDict["DateArrived"]) ? (DateTime?)null : DateTime.Parse(transportDict["DateArrived"]);
            PrelDeparture = DateTime.Parse(transportDict["PrelDeparture"]);
        }

        public Transport(string vehicle, int toPO, int fromPO, DateTime? dateSent, DateTime? dateArrived, DateTime prelDeparture)
        {
           
            DBConnectionManger.InsertToTransport(vehicle, toPO, fromPO, dateSent, dateArrived, prelDeparture);

            Id = DBConnectionManger.GetTransportId(vehicle, toPO, fromPO, dateSent, dateArrived, prelDeparture).ToString();

            Vehicle = new Vehicle(vehicle);
            ToPO = new PostalOffice(toPO.ToString());
            FromPO = new PostalOffice(fromPO.ToString());
            Departure = dateSent;
            Arrival = dateArrived;
            PrelDeparture = prelDeparture;
        }

        public override string ToString()
        {
            return $"{Vehicle.Type}, {FromPO.ZipCode} - {ToPO.ZipCode}, {PrelDeparture}";
        }
    }
}
