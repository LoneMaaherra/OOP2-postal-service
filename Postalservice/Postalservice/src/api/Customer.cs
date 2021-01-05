using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    class Customer
    {
        private int Id;
        private string Name;
        private string Street;
        private int ZipCode;
        private string City;
        private string Country;

        public Customer(int id)
        {
            //something
        }

        public Customer(Dictionary<string, string> values)
        {
            Id = Int32.Parse(values["Id"]);
            Name = values["Name"];
            Street = values["Street"];
            ZipCode = Int32.Parse(values["ZipCode"]);
            City = values["City"];
            Country = values["Country"];
            AddCustomerToDatabase();
        }

        public static bool CustomerExist(int id)
        {
            return false;
        }

        private void AddCustomerToDatabase()
        {
           DBConnectionManger.InsertToAddress(Name, Street, ZipCode, City, Country);
        }

        public void GetParcelFrom()
        {

        }

        public void GetParcelTo()
        {

        }
    }
}
