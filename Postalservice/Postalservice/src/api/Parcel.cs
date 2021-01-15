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
        public Status Status { get; set; }
        public Address AddressFrom { get; set; }
        public Address AddressTo { get; set; }
        public List<Transport> TransferHistory { get; set; }


        public Parcel(string id)
        {
            Dictionary<string, string> values = DBConnectionManger.GetPackage(id);

            ShipmentId = values["ShipmentId"];
            Status = (Status)Int32.Parse(values["Status"]);
            AddressFrom = GetAddress(DBConnectionManger.GetAddress(values["AddressFrom"]));
            AddressTo = GetAddress(DBConnectionManger.GetAddress(values["AddressTo"]));
        }

        public Parcel(Dictionary<string, string> parcelToValues, Dictionary<string, string> parcelFromValues, int locationPO)
        {
            AddressFrom = GetAddress(parcelFromValues);
            AddressTo = GetAddress(parcelToValues);
            Status = Status.Processing;
            Guid newGuid = Guid.NewGuid();
            ShipmentId = newGuid.ToString();
            DBConnectionManger.InsertToPackage(newGuid, Int32.Parse(AddressTo.Id), Int32.Parse(AddressFrom.Id), (int)Status, locationPO);
        }


        private Address GetAddress(Dictionary<string, string> addressDict)
        {
            bool exist = Address.AddressExist(addressDict["Name"], addressDict["Street"], addressDict["ZipCode"], addressDict["City"], addressDict["Country"]);

            if (exist)
            {
                return new Address(DBConnectionManger.GetAddressId(addressDict["Name"], addressDict["Street"], addressDict["ZipCode"], addressDict["City"], addressDict["Country"]).ToString()); 
            }
            else
            {
                return new Address(addressDict);
            }
        }

        public void ChangeStatus(Status status)
        {
            DBConnectionManger.SetPackageStatus(ShipmentId, status);
        }
    }
}
