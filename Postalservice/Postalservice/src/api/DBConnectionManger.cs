using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Postalservice.src.api
{
    /// <summary>
    /// DBConnectionManager handles all connections to the PostalServiceDB.
    /// </summary>
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
                AddParameter<string>(insertCommand, "0", name, SqlDbType.VarChar);
                AddParameter<string>(insertCommand, "1", street, SqlDbType.VarChar);
                AddParameter<string>(insertCommand, "2", zipCode, SqlDbType.VarChar);
                AddParameter<string>(insertCommand, "3", city, SqlDbType.VarChar);
                AddParameter<string>(insertCommand, "4", country, SqlDbType.VarChar);

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
                AddParameter<string>(insertCommand, "0", id, SqlDbType.VarChar);
                AddParameter<int>(insertCommand, "1", addressId, SqlDbType.Int);
                AddParameter<string>(insertCommand, "2", mobileNumber, SqlDbType.VarChar);

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
                AddParameter<string>(getCommand, "0", name, SqlDbType.VarChar);
                AddParameter<string>(getCommand, "1", street, SqlDbType.VarChar);
                AddParameter<string>(getCommand, "2", zipCode, SqlDbType.VarChar);
                AddParameter<string>(getCommand, "3", city, SqlDbType.VarChar);
                AddParameter<string>(getCommand, "4", country, SqlDbType.VarChar);

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //if (Id == -1) { Id = (int)reader[0]; }
                        if (Id == -1) { Id = GetSQLReaderValue<int>(reader[0]); }
                        else break;
                    }
                }
            }
            return Id;
        }

        public static Dictionary<string, string> GetAddress(string id)
        {
            Dictionary<string, string> AddressDict = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand join = new SqlCommand("SELECT * FROM Address WHERE Id =@0", conn);
                AddParameter<string>(join, "0", id, SqlDbType.Int);

                using (SqlDataReader reader = join.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AddressDict["Id"] = GetSQLReaderValue<int>(reader[0]).ToString();
                        AddressDict["Name"] = GetSQLReaderValue<string>(reader[1]);
                        AddressDict["Street"] = GetSQLReaderValue<string>(reader[2]);
                        AddressDict["ZipCode"] = GetSQLReaderValue<string>(reader[3]);
                        AddressDict["City"] = GetSQLReaderValue<string>(reader[4]);
                        AddressDict["Country"] = GetSQLReaderValue<string>(reader[5]);
                    }
                }
            }
            return AddressDict;
        }

        public static Dictionary<string, string> GetCustomer(string id)
        {
            Dictionary<string, string> CustomerDict = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand join = new SqlCommand("SELECT * FROM Customer INNER JOIN Address ON Address.Id = Customer.Address WHERE CustomerId =@0", conn);
                AddParameter<string>(join, "0", id, SqlDbType.VarChar);

                using (SqlDataReader reader = join.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerDict["Id"] = GetSQLReaderValue<string>(reader[0]);
                        CustomerDict["MobileNumber"] = GetSQLReaderValue<string>(reader[2]);
                        CustomerDict["Name"] = GetSQLReaderValue<string>(reader[4]);
                        CustomerDict["Street"] = GetSQLReaderValue<string>(reader[5]);
                        CustomerDict["ZipCode"] = GetSQLReaderValue<string>(reader[6]);
                        CustomerDict["City"] = GetSQLReaderValue<string>(reader[7]);
                        CustomerDict["Country"] = GetSQLReaderValue<string>(reader[8]);
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
                AddParameter<string>(command, "0", customerId, SqlDbType.VarChar);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Id == -1) { Id = GetSQLReaderValue<int>(reader[0]); }
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
                AddParameter<string>(command, "0", name, SqlDbType.VarChar);
                AddParameter<string>(command, "1", zipCode, SqlDbType.VarChar);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Id == -1) { Id = GetSQLReaderValue<int>(reader[0]); }
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
                AddParameter<string>(insertCommand, "0", name, SqlDbType.VarChar);
                AddParameter<string>(insertCommand, "1", zipCode, SqlDbType.VarChar);

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
                AddParameter<int>(command, "0", id, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        poDict["Id"] = GetSQLReaderValue<int>(reader[0]).ToString();
                        poDict["ZipCode"] = GetSQLReaderValue<string>(reader[1]);
                        poDict["Name"] = GetSQLReaderValue<string>(reader[2]);
                    }
                }
            }
            return poDict;
        }

        public static List<int> GetAllPostOffices()
        {
            List<int> list = new List<int>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand getCommand = new SqlCommand("SELECT Id FROM PostalOffice", conn);

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(GetSQLReaderValue<int>(reader[0]));
                    }
                }
            }
            return list;
        }

        public static void InsertToPackage(Guid shipmentId, int addressTo, int addressFrom, int status, int locationPo)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Package (ShipmentId, AddressTo, AddressFrom, Status, LocationPO) VALUES (@0, @1, @2, @3, @4)", conn);
                AddParameter<string>(insertCommand, "0", shipmentId.ToString(), SqlDbType.VarChar);
                AddParameter<int>(insertCommand, "1", addressTo, SqlDbType.Int);
                AddParameter<int>(insertCommand, "2", addressFrom, SqlDbType.Int);
                AddParameter<int>(insertCommand, "3", status, SqlDbType.Int);
                AddParameter<int>(insertCommand, "4", locationPo, SqlDbType.Int);

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
                AddParameter<string>(command, "0", id, SqlDbType.VarChar);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackageDict["ShipmentId"] = GetSQLReaderValue<string>(reader[0]);
                        PackageDict["AddressTo"] = GetSQLReaderValue<int>(reader[1]).ToString();
                        PackageDict["AddressFrom"] = GetSQLReaderValue<int>(reader[2]).ToString();
                        PackageDict["Status"] = GetSQLReaderValue<int>(reader[3]).ToString();
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
                AddParameter<string>(command, "0", addressId, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackagesList.Add(GetSQLReaderValue<string>(reader[0]));
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
                AddParameter<string>(command, "0", addressId, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackagesList.Add(GetSQLReaderValue<string>(reader[0]));
                    }
                }
            }
            return PackagesList;
        }

        public static List<string> GetAllPackagesAtPO(int poId)
        {
            List<string> PackagesList = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT ShipmentId FROM Package WHERE LocationPO=@0", conn);
                AddParameter<int>(command, "0", poId, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackagesList.Add(GetSQLReaderValue<string>(reader[0]));
                    }
                }
            }
            return PackagesList;
        }

        public static List<string> GetPackagesAtPOProcessing(int poId)
        {
            List<string> PackagesList = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT ShipmentId FROM Package WHERE LocationPO=@0 AND Status=@1", conn);
                AddParameter<int>(command, "0", poId, SqlDbType.Int);
                AddParameter<Status>(command, "1", Status.Processing, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackagesList.Add(GetSQLReaderValue<string>(reader[0]));
                    }
                }
            }
            return PackagesList;
        }

        public static List<string> GetPackagesAtPOReadyForPickup(int poId)
        {
            List<string> PackagesList = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT ShipmentId FROM Package WHERE LocationPO=@0 AND Status=@1", conn);
                AddParameter<int>(command, "0", poId, SqlDbType.Int);
                AddParameter<Status>(command, "1", Status.ReadyForPickup, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackagesList.Add(GetSQLReaderValue<string>(reader[0]));
                    }
                }
            }
            return PackagesList;
        }

        public static List<string> GetPackagesOnTransport(int transportId)
        {
            List<string> PackagesList = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT ShipmentId FROM PackageTransport WHERE TransportId=@0", conn);
                AddParameter<int>(command, "0", transportId, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PackagesList.Add(GetSQLReaderValue<string>(reader[0]));
                    }
                }
            }
            return PackagesList;
        }

        public static void SetPackageStatus(string shipmentId, Status newStatus)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("UPDATE Package SET Status=@1 WHERE ShipmentId=@0", conn);
                AddParameter<string>(command, "0", shipmentId.ToString(), SqlDbType.VarChar);
                AddParameter<Status>(command, "1", newStatus, SqlDbType.Int);

                command.ExecuteNonQuery();
            }
        }

        public static void InsertToPackageTransport(string shipmentId, int transportId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO PackageTransport (ShipmentId, TransportId) VALUES (@0, @1)", conn);
                AddParameter<string>(insertCommand, "0", shipmentId, SqlDbType.VarChar);
                AddParameter<int>(insertCommand, "1", transportId, SqlDbType.Int);

                insertCommand.ExecuteNonQuery();
            }
        }

        public static void RemoveFromPackageTransport(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("DELETE FROM PackageTransport WHERE Id=@0", conn);
                AddParameter<int>(command, "0", id, SqlDbType.Int);

                command.ExecuteNonQuery();
            }
        }

        public static int GetPackageTransportId(string shipmentId, int transportId)
        {
            int Id = -1;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT Id FROM PackageTransport WHERE ShipmentId=@0 AND TransportId=@1", conn);
                AddParameter<string>(command, "0", shipmentId, SqlDbType.VarChar);
                AddParameter<int>(command, "1", transportId, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Id == -1) { Id = GetSQLReaderValue<int>(reader[0]); }
                        else break;
                    }
                }
            }
            return Id;
        }

        public static List<int> GetPackageTransferHistory(string shipmentId)
        {
            List<int> list = new List<int>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT TransportId FROM PackageTransport WHERE ShipmentId=@0", conn);
                AddParameter<string>(command, "0", shipmentId, SqlDbType.VarChar);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(GetSQLReaderValue<int>(reader[0]));
                    }
                }
            }
            return list;
        }

        public static void InsertToVehicle(string regNr, int type, int maxWeight, int maxVolume, int status, int postOffice)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Vehicle (RegNr, Type, MaxWeight, MaxVolume, Status, PostOffice) VALUES (@0, @1, @2, @3, @4, @5)", conn);
                AddParameter<string>(insertCommand, "0", regNr, SqlDbType.VarChar);
                AddParameter<int>(insertCommand, "1", type, SqlDbType.Int);
                AddParameter<int>(insertCommand, "2", maxWeight, SqlDbType.Int);
                AddParameter<int>(insertCommand, "3", maxVolume, SqlDbType.Int);
                AddParameter<int>(insertCommand, "4", status, SqlDbType.Int);
                AddParameter<int>(insertCommand, "5", postOffice, SqlDbType.Int);

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
                AddParameter<string>(command, "0", regNr, SqlDbType.VarChar);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehicleDict["RegNr"] = GetSQLReaderValue<string>(reader[0]);
                        vehicleDict["Type"] = GetSQLReaderValue<int>(reader[1]).ToString();
                        vehicleDict["MaxWeight"] = GetSQLReaderValue<int>(reader[2]).ToString();
                        vehicleDict["MaxVolume"] = GetSQLReaderValue<int>(reader[3]).ToString();
                        vehicleDict["Status"] = GetSQLReaderValue<int>(reader[4]).ToString();
                        vehicleDict["PostOffice"] = GetSQLReaderValue<int>(reader[5]).ToString();
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
                        regNrs.Add(GetSQLReaderValue<string>(reader[0]));
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
                AddParameter<string>(command, "0", postalOfficeId, SqlDbType.VarChar);
                AddParameter<VehicleStatus>(command, "1", VehicleStatus.Parked, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VehicleList.Add(GetSQLReaderValue<string>(reader[0]));
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
                AddParameter<string>(insertCommand, "0", vehicle, SqlDbType.VarChar);
                AddParameter<int>(insertCommand, "1", toPO, SqlDbType.Int);
                AddParameter<int>(insertCommand, "2", fromPO, SqlDbType.Int);
                AddParameter<DateTime?>(insertCommand, "3", dateSent, SqlDbType.DateTime);
                AddParameter<DateTime?>(insertCommand, "4", dateArrived, SqlDbType.DateTime);
                AddParameter<DateTime>(insertCommand, "5", prelDeparture, SqlDbType.DateTime);

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
                AddParameter<int>(command, "0", id, SqlDbType.Int);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transportDict["Id"] = GetSQLReaderValue<int>(reader[0]).ToString();
                        transportDict["Vehicle"] = GetSQLReaderValue<string>(reader[1]);
                        transportDict["ToPO"] = GetSQLReaderValue<int>(reader[2]).ToString();
                        transportDict["FromPO"] = GetSQLReaderValue<int>(reader[3]).ToString();
                        transportDict["DateSent"] = GetDateTimeFromSqlReaderValue(reader[4]).ToString();
                        transportDict["DateArrived"] = GetDateTimeFromSqlReaderValue(reader[5]).ToString();
                        transportDict["PrelDeparture"] = GetDateTimeFromSqlReaderValue(reader[6]).ToString();
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
                AddParameter<string>(getCommand, "0", vehicle, SqlDbType.VarChar);
                AddParameter<int>(getCommand, "1", toPO, SqlDbType.Int);
                AddParameter<int>(getCommand, "2", fromPO, SqlDbType.Int);
                AddParameter<DateTime?>(getCommand, "3", dateSent, SqlDbType.DateTime);
                AddParameter<DateTime?>(getCommand, "4", dateArrived, SqlDbType.DateTime);
                AddParameter<DateTime>(getCommand, "5", prelDeparture, SqlDbType.DateTime);

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Id == -1) { Id = GetSQLReaderValue<int>(reader[0]); }
                        else break;
                    }
                }
            }
            return Id;
        }

        public static List<string> GetParcelsInTransport(int transportId)
        {
            List<string> ListOfParcels = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand getCommand = new SqlCommand("SELECT ShipmentId FROM PackageTransport WHERE TransportId =@0", conn);
                AddParameter<int>(getCommand, "0", transportId, SqlDbType.Int);

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfParcels.Add(GetSQLReaderValue<string>(reader[0]));
                    }
                }
            }
            return ListOfParcels;
        }

        public static List<int> GetTransportsToPO(int poId)
        {
            List<int> list = new List<int>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand getCommand = new SqlCommand("SELECT Id FROM Transport WHERE ToPO=@0", conn);
                AddParameter<int>(getCommand, "0", poId, SqlDbType.Int);

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(GetSQLReaderValue<int>(reader[0]));
                    }
                }
            }
            return list;
        }

        public static List<int> GetTransportsFromPO(int poId)
        {
            List<int> list = new List<int>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand getCommand = new SqlCommand("SELECT Id FROM Transport WHERE FromPO=@0", conn);
                AddParameter<int>(getCommand, "0", poId, SqlDbType.Int);

                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(GetSQLReaderValue<int>(reader[0]));
                    }
                }
            }
            return list;
        }

        public static T GetSQLReaderValue<T>(object sqlDataReaderValue)
        {
            return (sqlDataReaderValue == System.DBNull.Value) ? default
                  : (T)sqlDataReaderValue;
        }
        
        public static DateTime? GetDateTimeFromSqlReaderValue(object sqlDataReaderValue)
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
