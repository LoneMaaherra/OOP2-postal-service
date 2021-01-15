using System;
using System.Collections.Generic;
using System.Data;
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

        public static void InsertToPostalOffice(string name, string zipCode)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Vehicle (ZipCode, Name) VALUES (@0, @1)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", zipCode));
                insertCommand.Parameters.Add(new SqlParameter("1", name));

                insertCommand.ExecuteNonQuery();
            }
        }

        public static Dictionary<string, string> GetPostalOffice(int id)
        {
            Dictionary<string, string> poDict = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PostalOffice WHERE id=@0", conn);
                command.Parameters.Add(new SqlParameter("0", id));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        poDict["Id"] = reader[0].ToString();
                        poDict["ZipCode"] = reader[1].ToString();
                        poDict["Name"] = reader[2].ToString();
                    }
                }
            }
            return poDict;
        }

        public static List<int> GetAllPostOffices()
        {
            List<int> ListOfOffices = new List<int>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand getCommand = new SqlCommand("SELECT Id FROM PostalOffice", conn);

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfOffices.Add((int)reader[0]);
                    }
                }
            }
            return ListOfOffices;
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

        public static Dictionary<string,string> GetPackage(string id)
        {
            Dictionary<string, string> PackageDict = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Package WHERE ShipmentId =@0", conn);
                command.Parameters.Add(new SqlParameter("0", id));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackageDict["ShipmentId"] = reader[0].ToString();
                        PackageDict["AddressTo"] = reader[1].ToString();
                        PackageDict["AddressFrom"] = reader[2].ToString();
                        PackageDict["Status"] = reader[3].ToString();
                    }
                }
            }
            return PackageDict;
        }

        public static List<string> GetPackagesToAddress(string addressId) 
        {
            List<string> PackagesList = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT ShipmentId FROM Package WHERE AddressTo =@0", conn);
                command.Parameters.Add(new SqlParameter("0", addressId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackagesList.Add(reader[0].ToString());
                    }
                }
            }
            return PackagesList;
        }

        public static List<string> GetPackagesFromAddress(string addressId) 
        {
            List<string> PackagesList = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT ShipmentId FROM Package WHERE AddressFrom =@0", conn);
                command.Parameters.Add(new SqlParameter("0", addressId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackagesList.Add(reader[0].ToString());
                    }
                }
            }
            return PackagesList;
        }

        public static void InsertToVehicle(string regNr, int type, int maxWeight, int maxVolume, int status, int postOffice)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Vehicle (RegNr, Type, MaxWeight, MaxVolume, Status, PostOffice) VALUES (@0, @1, @2, @3, @4, @5)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", regNr));
                insertCommand.Parameters.Add(new SqlParameter("1", type));
                insertCommand.Parameters.Add(new SqlParameter("2", maxWeight));
                insertCommand.Parameters.Add(new SqlParameter("3", maxVolume));
                insertCommand.Parameters.Add(new SqlParameter("4", status));
                insertCommand.Parameters.Add(new SqlParameter("5", postOffice));

                insertCommand.ExecuteNonQuery();
            }
        }

        public static Dictionary<string,string> GetVehicle(string regNr)
        {
            Dictionary<string, string> vehicleDict = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Vehicle WHERE RegNr =@0", conn);
                command.Parameters.Add(new SqlParameter("0", regNr));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehicleDict["RegNr"] = reader[0].ToString();
                        vehicleDict["Type"] = reader[1].ToString();
                        vehicleDict["MaxWeight"] = reader[2].ToString();
                        vehicleDict["MaxVolume"] = reader[3].ToString();
                        vehicleDict["Status"] = reader[4].ToString();
                        vehicleDict["PostOffice"] = reader[5].ToString();
                    }
                }
            }
            return vehicleDict;
        }

       
        public static List<string> GetAllVehicles()
        {
            List<string> regNrs = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT RegNr FROM Vehicle", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        regNrs.Add(reader[0].ToString());
                    }
                }
            }
            return regNrs;
        }

        public static List<string> GetVehiclesAtPO(string postalOfficeId)
        {
            List<string> VehicleList = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT RegNr FROM Vehicle WHERE PostOffice =@0 AND Status = @1", conn);
                command.Parameters.Add(new SqlParameter("0", postalOfficeId));
                command.Parameters.Add(new SqlParameter("1", VehicleStatus.Parked));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VehicleList.Add(reader[0].ToString());
                    }
                }
            }
            return VehicleList;
        }

        public static void InsertToTransport(string vehicle, int toPO, int fromPO, DateTime? dateSent, DateTime? dateArrived, DateTime prelDeparture)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Transport (Vehicle, ToPO, FromPO, DateSent, DateArrived, PrelDeparture) VALUES (@0, @1, @2, @3, @4, @5)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", vehicle));
                insertCommand.Parameters.Add(new SqlParameter("1", toPO));
                insertCommand.Parameters.Add(new SqlParameter("2", fromPO));
                insertCommand.Parameters.Add(new SqlParameter("3", dateSent));
                insertCommand.Parameters.Add(new SqlParameter("4", dateArrived));
                insertCommand.Parameters.Add(new SqlParameter("5", prelDeparture));

                insertCommand.ExecuteNonQuery();
            }
        }

        public static Dictionary<string, string> GetTransport(int id)
        {
            Dictionary<string, string> transportDict = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Transport WHERE id=@0", conn);
                command.Parameters.Add(new SqlParameter("0", id));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transportDict["Id"] = reader[0].ToString();
                        transportDict["Vehicle"] = reader[1].ToString();
                        transportDict["ToPO"] = reader[2].ToString();
                        transportDict["FromPO"] = reader[3].ToString();
                        transportDict["DateSent"] = reader[4].ToString();
                        transportDict["DateArrived"] = reader[5].ToString();
                        transportDict["PrelDeparture"] = reader[6].ToString();
                    }
                }
            }
            return transportDict;
        }

        public static int GetTransportId(string vehicle, int toPO, int fromPO, DateTime? dateSent, DateTime? dateArrived, DateTime prelDeparture)
        {
            int Id = -1;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand getCommand = new SqlCommand("SELECT Id FROM Transport WHERE Vehicle =@0 AND ToPO = @1 AND FromPO = @2 AND DateSent =@3 AND DateArrived = @4 AND PrelDeparture =@5", conn);
                getCommand.Parameters.Add(new SqlParameter("0", vehicle));
                getCommand.Parameters.Add(new SqlParameter("1", toPO));
                getCommand.Parameters.Add(new SqlParameter("2", fromPO));
                getCommand.Parameters.Add(new SqlParameter("3", dateSent));
                getCommand.Parameters.Add(new SqlParameter("4", dateArrived));
                getCommand.Parameters.Add(new SqlParameter("5", prelDeparture));

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

        public static List<int> GetParcelsInTransport(int transportId)
        {
            List<int> ListOfParcels = new List<int>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand getCommand = new SqlCommand("SELECT ShipmentId FROM PackageTransport WHERE TransportId =@0", conn);
                getCommand.Parameters.Add(new SqlParameter("0", transportId));

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfParcels.Add((int)reader[0]);
                    }
                }
            }
            return ListOfParcels;
        }

        public static T GetSQLReaderValue<T>(object sqlDataReaderValue)
        {
            if(typeof(T) == typeof(DateTime?))
            {
                return (sqlDataReaderValue == System.DBNull.Value) ? null
                  : (T)Convert.ToDateTime(sqlDataReaderValue);
            }
        
            if (sqlDataReaderValue == System.DBNull.Value)
            {
                  ? (T)null
                  : (T)Convert.ToDateTime(sqlDataReaderValue);
            }
        }
        
        public static DateTime? ConvertFromDBNull(object sqlDataReaderValue)
        {
            return (sqlDataReaderValue == System.DBNull.Value)
                    ? (DateTime?)null
                    : (DateTime?)Convert.ToDateTime(sqlDataReaderValue);
        }

        public static void AddParameter<T>(SqlCommand sqlCommand, string position, T parameter, SqlDbType sqlDbType)
        {
            sqlCommand.Parameters.Add(position, sqlDbType);
            sqlCommand.Parameters[position].Value =
                        ((object)parameter) ?? DBNull.Value;            
        }
    }
}
