using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    public class Address
    {
        public string Id;
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address(string id)
        {           
            Dictionary<string, string> AddressDict = DBConnectionManger.GetAddress(id);

            Id = AddressDict["Id"];
            Name = AddressDict["Name"];
            Street = AddressDict["Street"];
            ZipCode = AddressDict["ZipCode"];
            City = AddressDict["City"];
            Country = AddressDict["Country"];
        }

       
        public Address(Dictionary<string, string> addressDict)
        {
            DBConnectionManger.InsertToAddress(addressDict["Name"], addressDict["Street"], addressDict["ZipCode"], addressDict["City"], addressDict["Country"]);
            Id = DBConnectionManger.GetAddressId(addressDict["Name"], addressDict["Street"], addressDict["ZipCode"], addressDict["City"], addressDict["Country"]).ToString();
            Name = addressDict["Name"];
            Street = addressDict["Street"];
            ZipCode = addressDict["ZipCode"];
            City = addressDict["City"];
            Country = addressDict["Country"];
        }

        public static bool AddressExist(string name, string street, string zipCode, string city, string country)
        {
            return DBConnectionManger.GetAddressId(name, street, zipCode, city, country) != -1;
        }
    }
}
