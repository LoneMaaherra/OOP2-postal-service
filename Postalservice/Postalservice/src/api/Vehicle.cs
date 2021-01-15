using System;
using System.Collections.Generic;

namespace Postalservice.src.api
{
    public class Vehicle
    {
        public string RegNr { get; set; }
        public VehicleType Type { get; set; } 
        public int MaxWeight { get; set; }
        public int MaxVolume { get; set; }
        public VehicleStatus Status { get; set; }
        public PostalOffice LocationPO { get; set; }

        public Vehicle(string regNr)
        {
            Dictionary<string, string> vehicleDict = DBConnectionManger.GetVehicle(regNr);
            RegNr = regNr;
            Type = (VehicleType)Int32.Parse(vehicleDict["Type"]);
            MaxWeight = Int32.Parse(vehicleDict["MaxWeight"]);
            MaxVolume = Int32.Parse(vehicleDict["MaxVolume"]);
            Status = (VehicleStatus)Int32.Parse(vehicleDict["Status"]);
            LocationPO = new PostalOffice(vehicleDict["PostOffice"]);
        }

        public Vehicle(string regNr, VehicleType type, int maxWeight, int maxVolume, VehicleStatus status, PostalOffice postOffice)
        {
            DBConnectionManger.InsertToVehicle(regNr, (int)type, maxWeight, maxVolume, (int)status, Int32.Parse(postOffice.Id));
            RegNr = regNr;
            Type = type;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            Status = status;
            LocationPO = postOffice;
        }

        public override string ToString()
        {
            return $"{RegNr} {Type}";
        }
    }
}
