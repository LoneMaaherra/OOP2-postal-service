using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postalservice.src.api
{
    public class DBConnectionManger
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory;
        private static string appPath = path.Substring(0, path.IndexOf(@"\bin\"));
        public static string CONNECTION_STRING = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 
                                          {appPath}\src\db\PostalServiceDB.mdf; 
                                          Integrated Security = True";

        public static void InsertToAddress(string name, string street, string zipCode, string city, string country)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Address (Name, Street, ZipCode, City, Country) VALUES (@0, @1, @2, @3, @4)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", name));
                insertCommand.Parameters.Add(new SqlParameter("1", street));
                insertCommand.Parameters.Add(new SqlParameter("2", zipCode));
                insertCommand.Parameters.Add(new SqlParameter("3", city));
                insertCommand.Parameters.Add(new SqlParameter("4", country));

                insertCommand.ExecuteNonQuery();
            }
        }



        public static void InsertToCustomer(string id, int addressId, string mobileNumber)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Customer (CustomerId, Address, MobileNumber) VALUES (@0, @1, @2)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", id));
                insertCommand.Parameters.Add(new SqlParameter("1", addressId));
                insertCommand.Parameters.Add(new SqlParameter("2", mobileNumber));


                insertCommand.ExecuteNonQuery();
            }
        }

        public static int GetAddressId(string name, string street, string zipCode, string city, string country)
        {
            int Id = -1;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand getCommand = new SqlCommand("SELECT Id FROM Address WHERE Name =@0 AND Street = @1 AND ZipCode = @2 AND City =@3 AND Country = @4 ", conn);
                getCommand.Parameters.Add(new SqlParameter("0", name));
                getCommand.Parameters.Add(new SqlParameter("1", street));
                getCommand.Parameters.Add(new SqlParameter("2", zipCode));
                getCommand.Parameters.Add(new SqlParameter("3", city));
                getCommand.Parameters.Add(new SqlParameter("4", country));

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Id == -1) { Id = (int)reader[0]; }
                        else break;
                    }
                }
            }
            return Id;
        }

        public static Dictionary<string, string> GetAddress(string Id)
        {
            Dictionary<string, string> AddressDict = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand join = new SqlCommand("SELECT * FROM Address WHERE Id =@0", conn);
                join.Parameters.Add(new SqlParameter("0", Id));

                using (SqlDataReader reader = join.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AddressDict["Id"] = reader[0].ToString();
                        AddressDict["Name"] = reader[1].ToString();
                        AddressDict["Street"] = reader[2].ToString();
                        AddressDict["ZipCode"] = reader[3].ToString();
                        AddressDict["City"] = reader[4].ToString();
                        AddressDict["Country"] = reader[5].ToString();
                    }
                }
            }
            return AddressDict;
        }

        public static Dictionary<string, string> GetCustomer(string Id)
        {
            Dictionary<string, string> CustomerDict = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand join = new SqlCommand("SELECT * FROM Customer INNER JOIN Address ON Address.Id = Customer.Address WHERE CustomerId =@0", conn);
                join.Parameters.Add(new SqlParameter("0", Id));

                using (SqlDataReader reader = join.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerDict["Id"] = reader[0].ToString();
                        CustomerDict["MobileNumber"] = reader[2].ToString();
                        CustomerDict["Name"] = reader[4].ToString();
                        CustomerDict["Street"] = reader[5].ToString();
                        CustomerDict["ZipCode"] = reader[6].ToString();
                        CustomerDict["City"] = reader[7].ToString();
                        CustomerDict["Country"] = reader[8].ToString();
                    }
                }
            }
            return CustomerDict;
        }

        public static int GetCustomerAddressID(string customerId)
        {
            int Id = -1;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT Address FROM Customer WHERE CustomerId=@0", conn);
                command.Parameters.Add(new SqlParameter("0", customerId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Id == -1) { Id = (int)reader[0]; }
                        else break;
                    }
                }
            }
            return Id;
        }

        public static int GetOfficeId(string name, string zipCode)
        {
            int Id = -1;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT Id FROM PostalOffice WHERE Name=@0 AND ZipCode=@1", conn);
                command.Parameters.Add(new SqlParameter("0", name));
                command.Parameters.Add(new SqlParameter("1", zipCode));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Id == -1) { Id = (int)reader[0]; }
                        else break;
                    }
                }
            }
            return Id;
        }

        public static void InsertToPackage(Guid shipmentId, int addressTo, int addressFrom, int status)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Package (ShipmentId, AddressTo, AddressFrom, Status) VALUES (@0, @1, @2, @3)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", shipmentId));
                insertCommand.Parameters.Add(new SqlParameter("1", addressTo));
                insertCommand.Parameters.Add(new SqlParameter("2", addressFrom));
                insertCommand.Parameters.Add(new SqlParameter("3", status));


                insertCommand.ExecuteNonQuery();
            }

        }
    }
}
