using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    class Customer
    {
        private string Id;
        private string Name;
        private string Street;
        private string ZipCode;
        private string City;
        private string Country;
        private string MobileNumber;
        

        public Customer(string id)
        {
            Dictionary<string, string> values = DBConnectionManger.GetCustomer(id);

            Id = values["Id"];
            Name = values["Name"];
            Street = values["Street"];
            ZipCode = values["ZipCode"];
            City = values["City"];
            Country = values["Country"];
            MobileNumber = values["MobileNumber"];
        }

        public Customer(Dictionary<string, string> values)
        {
            Id = values["Id"];
            Name = values["Name"];
            Street = values["Street"];
            ZipCode = values["ZipCode"];
            City = values["City"];
            Country = values["Country"];
            MobileNumber = values["MobileNumber"];
            AddCustomerToDatabase();
        }

        public static bool CustomerExist(string id)
        {
            return DBConnectionManger.GetCustomerAddressID(id) != -1;
        }

        private void AddCustomerToDatabase()
        {
            DBConnectionManger.InsertToAddress(Name, Street, ZipCode, City, Country);
            int AddressID = DBConnectionManger.FindAddressID(Name, Street, ZipCode, City, Country);
            if(AddressID == -1) { throw new Exception(); }
            DBConnectionManger.InsertToCustomer(Id, AddressID, MobileNumber);
        }

        public void GetParcelFrom()
        {

        }

        public void GetParcelTo()
        {

        }
    }
}
