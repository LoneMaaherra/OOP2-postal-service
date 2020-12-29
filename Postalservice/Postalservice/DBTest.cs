using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Postalservice
{
    public class DBTest
    {

        public static void Start()
        {
            //string conString;
            //conString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 
            //            E:\Programmering\Mölk\Postal Service\OOP2-postal-service\Postalservice\Postalservice\src\db\PostalServiceDB.mdf; 
            //            Integrated Security = True";

            //SqlConnection con = new SqlConnection(conString);

            //SqlCommand cmd = new SqlCommand("NamesAndCourses", con);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);


            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                // Trusted_Connection is used to denote the connection uses Windows Authentication
                conn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 
                                      E:\Programmering\Mölk\Postal Service\OOP2-postal-service\Postalservice\Postalservice\src\db\PostalServiceDB.mdf; 
                                      Integrated Security = True";
                conn.Open();
                // Create the command
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Address (Address, ZipCode, City, Country) VALUES (@0, @1, @2, @3)", conn);

                insertCommand.Parameters.Add(new SqlParameter("0", "Nya Tannerforsvägen 23A"));
                insertCommand.Parameters.Add(new SqlParameter("1", 58242));
                insertCommand.Parameters.Add(new SqlParameter("2", "Linköping"));
                insertCommand.Parameters.Add(new SqlParameter("3", "Sweden"));

                insertCommand.ExecuteNonQuery();

                SqlCommand command = new SqlCommand("SELECT * FROM Address WHERE Id = 10", conn);
                // Add the parameters.
                //command.Parameters.Add(new SqlParameter("0", 1));

                /* Get the rows and display on the screen! 
                 * This section of the code has the basic code
                 * that will display the content from the Database Table
                 * on the screen using an SqlDataReader. */

                //ConsoleManager.Show();
               
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Id\tAddress\tZipCode\t\tCity\t\tCountry\t");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}\t | {4}",
                            reader[0], reader[1], reader[2], reader[3], reader[4]));
                    }
                }
                Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                Console.ReadLine();
                //Console.Clear();

                SqlCommand insertCommand2 = new SqlCommand("INSERT INTO PostalOffice (ZipCode, Name) VALUES (@0, @1)", conn);
                insertCommand2.Parameters.Add(new SqlParameter("0", 58424));
                insertCommand2.Parameters.Add(new SqlParameter("1", "Ica Tannerfors"));

                insertCommand2.ExecuteNonQuery();


                SqlCommand join = new SqlCommand("SELECT * FROM PostalOffice INNER JOIN Address ON Address.ZipCode = PostalOffice.ZipCode", conn);

                using (SqlDataReader reader2 = join.ExecuteReader())
                {
                    Console.WriteLine("Id\tAddress\tZipCode\t\tCity\t\tCountry\t");
                    while (reader2.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}\t | {4}",
                            reader2[0], reader2[1], reader2[2], reader2[3], reader2[4]));
                    }
                }
                /* Above code was used to display the data from the Database table!
                 * This following section explains the key features to use 
                 * to add the data to the table. This is an example of another
                 * SQL Command (INSERT INTO), this will teach the usage of parameters and connection.*/

                Console.WriteLine("INSERT INTO command");

                // Create the command, to insert the data into the Table!
                // this is a simple INSERT INTO command!

                //SqlCommand insertCommand = new SqlCommand("INSERT INTO TableName (FirstColumn, SecondColumn, ThirdColumn, ForthColumn) VALUES (@0, @1, @2, @3)", conn);

                //// In the command, there are some parameters denoted by @, you can 
                //// change their value on a condition, in my code they're hardcoded.

                //insertCommand.Parameters.Add(new SqlParameter("0", 10));
                //insertCommand.Parameters.Add(new SqlParameter("1", "Test Column"));
                //insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
                //insertCommand.Parameters.Add(new SqlParameter("3", false));

                // Execute the command, and print the values of the columns affected through
                // the command executed.

                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                Console.WriteLine("Done! Press enter to move to the next step");
                Console.ReadLine();
                Console.Clear();

                /* In this section there is an example of the Exception case
                 * Thrown by the SQL Server, that is provided by SqlException 
                 * Using that class object, we can get the error thrown by SQL Server.
                 * In my code, I am simply displaying the error! */
                Console.WriteLine("Now the error trial!");

                // try block
                try
                {
                    // Create the command to execute! With the wrong name of the table (Depends on your Database tables)
                    SqlCommand errorCommand = new SqlCommand("SELECT * FROM someErrorColumn", conn);
                    // Execute the command, here the error will pop up!
                    // But since we're catching the code block's errors, it will be displayed inside the console.
                    errorCommand.ExecuteNonQuery();
                }
                // catch block
                catch (SqlException er)
                {
                    // Since there is no such column as someErrorColumn (Depends on your Database tables)
                    // SQL Server will throw an error.
                    Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                }
            }
            // Final step, close the resources flush dispose them. ReadLine to prevent the console from closing.
            Console.ReadLine();
        }

    }
}
