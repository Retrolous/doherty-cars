using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Petkunas__Lukas___Doherty_Cars
{
    class DBConnect
    {
        // provides a method to create a connection to the local SQL database
        // the connection string is dynamically adjusted to point to the correct database file at runtime
        public static SqlConnection ConnectionToDB()
        {
            // dynamically modify the connection string to point to the database file in the current directory
            // environment.CurrentDirectory ensures it always points to the folder where the executable is running
            string DynamicConnectionString = Properties.Settings.Default.ConnectionString;
            string PathToDB = @"=""" + Environment.CurrentDirectory + @"\DoCarsDB.mdf";
            DynamicConnectionString = DynamicConnectionString.Replace(@"=""", PathToDB);

            // return the connection object configured with the updated connection string
            return new SqlConnection(DynamicConnectionString);
        }
    }
}
