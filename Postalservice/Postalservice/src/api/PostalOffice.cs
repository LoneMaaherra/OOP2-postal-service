using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    public class PostalOffice
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public PostalOffice(string name, string zipCode)
        {
            Name = name;
            ZipCode = zipCode;
        }

        public static bool OfficeExist(string name, string zipCode)
        {
            return DBConnectionManger.GetOfficeId(name, zipCode) != -1;
        }
    }
}
