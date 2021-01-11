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


        //public Parcel(string id)
        //{
        //    Dictionary<string, string> values = DBConnectionManger.GetCustomer(id);

        //    Id = values["Id"];
        //    Name = values["Name"];
        //    Street = values["Street"];
        //    ZipCode = values["ZipCode"];
        //    City = values["City"];
        //    Country = values["Country"];         
        //}

        public Parcel(Dictionary<string, string> parcelToValues, Dictionary<string, string> parcelFromValues)
        {
            Address.AddressExist(parcelToValues["Name"], parcelToValues["Street"], parcelToValues["ZipCode"], parcelToValues["City"], parcelToValues["Country"]);

            Address.AddressExist(parcelFromValues["Name"], parcelFromValues["Street"], parcelFromValues["ZipCode"], parcelFromValues["City"], parcelFromValues["Country"]);

            AddCustomerToDatabase();
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
    }
}
