using System;
using System.Collections.Generic;

namespace Postalservice.src.api
{
    public class PostalOffice
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public PostalOffice(string id)
        {
            Dictionary<string, string> PODict = DBConnectionManger.GetPostalOffice(Int32.Parse(id));
            Id = id;
            Name = PODict["Name"];
            ZipCode = PODict["ZipCode"];
        }

        public PostalOffice(string name, string zipCode)
        {
            DBConnectionManger.InsertToPostalOffice(name, zipCode);
            Id = DBConnectionManger.GetOfficeId(name, zipCode).ToString();
            Name = name;
            ZipCode = zipCode;
        }

        public static bool OfficeExist(string name, string zipCode)
        {
            return DBConnectionManger.GetOfficeId(name, zipCode) != -1;
        }

        public override string ToString()
        {
            return $"{Name} {ZipCode}";
        }
    }
}
