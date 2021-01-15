using System;
using System.Collections.Generic;

namespace Postalservice.src.api
{
    public class Customer
    {
        private string Id;
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string MobileNumber { get; set; }
        public List<Parcel> ParcelFrom { get; set; }
        public List<Parcel> ParcelTo { get; set; }


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
            ParcelTo = new List<Parcel>();
            ParcelFrom = new List<Parcel>();
            LoadParcelFrom();
            LoadParcelTo();
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
            ParcelTo = new List<Parcel>();
            ParcelFrom = new List<Parcel>();
            LoadParcelFrom();
            LoadParcelTo();
        }

        public static bool CustomerExist(string customerid)
        {
            return DBConnectionManger.GetCustomerAddressID(customerid) != -1;
        }

        private void AddCustomerToDatabase()
        {
            DBConnectionManger.InsertToAddress(Name, Street, ZipCode, City, Country);
            int AddressID = DBConnectionManger.GetAddressId(Name, Street, ZipCode, City, Country);
            if(AddressID == -1) { throw new Exception(); }
            DBConnectionManger.InsertToCustomer(Id, AddressID, MobileNumber);
        }

        public void LoadParcelFrom()
        {
            List<string> parcels = DBConnectionManger.GetPackagesFromAddress(DBConnectionManger.GetCustomerAddressID(Id).ToString());

            foreach(string p in parcels)
            {
                ParcelFrom.Add(new Parcel(p));
            }
            
        }

        public void LoadParcelTo()
        {
            List<string> parcels = DBConnectionManger.GetPackagesToAddress(DBConnectionManger.GetCustomerAddressID(Id).ToString());

            foreach (string p in parcels)
            {
                ParcelTo.Add(new Parcel(p));
            }
        }
    }
}
