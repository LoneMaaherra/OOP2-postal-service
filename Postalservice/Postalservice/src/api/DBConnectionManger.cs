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

        public static void InsertToAddress(string name, string street, int zipCode, string city, string country)
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

    }
}
