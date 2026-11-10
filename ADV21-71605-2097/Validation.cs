using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace Petkunas__Lukas___Doherty_Cars
{
    public static class Validation
    {
        // ensures input string is not null or whitespace
        public static bool IsNotEmpty(string input) => !string.IsNullOrWhiteSpace(input);

        // checks if input string contains only numeric digits
        public static bool IsAllNumbers(string input) => input.All(char.IsDigit);

        // validates the format of an email address.
        // ensures:
        // - starts with letters, numbers, or some special characters (._%+-)
        // - contains an @ symbol
        // - domain name with letters, numbers, or hyphens
        // - dot followed by at least 2 letters (top level domain)
        public static bool IsValidEmail(string input) => (new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")).IsMatch(input);

        // is valid VIN i.e. is unique
        public static bool VINExists(int vehicleID, string input)
        {
            // check if another vehicle exists with that VIN and not that vehicle ID
            string Query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Vehicles WHERE VIN = @VIN AND NOT VehicleID = @VehicleID AND DateDeleted IS NULL) THEN 1 ELSE 0 END";
            try
            {
                using (SqlConnection Connection = DBConnect.ConnectionToDB())
                using (SqlCommand cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@VIN", input.Trim());
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                    Connection.Open();
                    int exists = (int)cmd.ExecuteScalar();
                    return exists == 1;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
