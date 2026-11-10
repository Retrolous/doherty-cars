using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace Petkunas__Lukas___Doherty_Cars
{
    // rerepsents a staff member in the system
    class Staff
    {
        #region Private fields
        private int _staffID;
        private string _firstname;
        private string _surname;
        private string _username;
        private string _password;
        private int _roleID;
        #endregion
        #region Public properties
        public int StaffID
        {
            get => _staffID;
            set => _staffID = value >= 0
                ? value
                : throw new ArgumentException("Staff ID must be greater than or equal to 0.");
        }

        public string Firstname
        {
            get => _firstname;
            set => _firstname = !string.IsNullOrWhiteSpace(value)
                ? value.Trim()
                : throw new ArgumentException("Firstname cannot be empty.");
        }

        public string Surname
        {
            get => _surname;
            set => _surname = !string.IsNullOrWhiteSpace(value)
                ? value.Trim()
                : throw new ArgumentException("Surname cannot be empty.");
        }

        public string Username
        {
            get => _username;
            set => _username = !string.IsNullOrWhiteSpace(value)
                ? value.Trim()
                : throw new ArgumentException("Username cannot be empty.");
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public int RoleID
        {
            get => _roleID;
            set => _roleID = value > 0
                ? value
                : throw new ArgumentException("Role ID must be greater than 0.");
        }
        #endregion

        #region Constructors
        public Staff()
        {

        }
        public Staff(
            int StaffID, 
            string Firstname, 
            string Surname,
            string Username,
            string Password,
            int RoleID)
        {
            this.StaffID = StaffID;
            this.Firstname = Firstname;
            this.Surname = Surname;
            this.Username = Username;
            this.Password = Password;
            this.RoleID = RoleID;
        }
        #endregion
        #region Create
        // adds a new staff member to the staff table
        public static string AddStaff(Staff NewStaff)
        {
            try
            {
                string Query = @"
                    INSERT INTO Staff
                    (Firstname, Surname, Username, Password, RoleID)
                    VALUES
                    (@Firstname, @Surname, @Username, @Password, @RoleID)";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@Firstname", NewStaff.Firstname);
                    cmd.Parameters.AddWithValue("@Surname", NewStaff.Surname);
                    cmd.Parameters.AddWithValue("@Username", NewStaff.Username);
                    cmd.Parameters.AddWithValue("@Password", HashPassword(NewStaff.Password));
                    cmd.Parameters.AddWithValue("@RoleID", NewStaff.RoleID);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null;
            }
            catch (Exception ex)
            {
                return "Error when adding staff member: " + ex.Message;
            }
        }
        #endregion
        #region Retrieve
        // return all staff members present on the system
        public static List<Staff> RetrieveStaffMembers()
        {
            List<Staff> Result = new List<Staff>();

            try
            {
                DataTable DataResult = new DataTable();

                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Staff WHERE DateDeleted IS NULL",
                    DBConnect.ConnectionToDB()))
                {
                    Adapter.Fill(DataResult);
                }

                foreach (DataRow Record in DataResult.Rows)
                {
                    Result.Add(FromDataRow(Record));
                }

                return Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving staff records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // return a staff member given their id in the table
        public static Staff RetrieveByStaffID(int id)
        {
            try
            {
                DataTable DataResult = new DataTable();

                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Staff WHERE StaffID = @StaffID AND DateDeleted IS NULL",
                    DBConnect.ConnectionToDB()))
                {
                    Adapter.SelectCommand.Parameters.AddWithValue("@StaffID", id);
                    Adapter.Fill(DataResult);
                }

                // if a staff member has been returned
                return DataResult.Rows.Count > 0
                    ? FromDataRow(DataResult.Rows[0])
                    : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving staff member: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // return a staff object who has the same username and password provided
        public static Staff Login(string Username, string Password)
        {
            List<Staff> Matches = GetStaffByField(Username, "Exact", "Username");

            foreach (Staff staff in Matches)
            {

                // hash the provided password using the salt from the password hash stored in the database
                byte[] HashBytes = Convert.FromBase64String(staff.Password);

                byte[] Salt = new byte[16];
                Array.Copy(HashBytes, 0, Salt, 0, 16);

                var Pbkdf2 = new Rfc2898DeriveBytes(Password, Salt, 75623);
                byte[] Hash = Pbkdf2.GetBytes(20);

                bool Match = true;
                for (int i = 0; i < 20; i++)
                {
                    if (HashBytes[i + 16] != Hash[i])
                    {
                        // if the hash differs i.e. the password differs
                        Match = false;
                        break;
                    }
                }

                // if the password is correct and the username matches, return that staff members
                if (Match) return staff;
            }

            return null;
        }
        #endregion
        #region Update

        // save new details for a staff member in the database
        public static string SaveStaff(Staff ExistingStaff)
        {
            try
            {
                string Query = $"UPDATE Staff SET Firstname = @Firstname , Surname = @Surname , Username = @Username{(ExistingStaff.Password == "" ? "" : ", Password = @Password")}, RoleID = @RoleID WHERE StaffID = @StaffID";
                // modify the query based on whether a new password is to be stored or not
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@StaffID", ExistingStaff.StaffID);
                    cmd.Parameters.AddWithValue("@Firstname", ExistingStaff.Firstname);
                    cmd.Parameters.AddWithValue("@Surname", ExistingStaff.Surname);
                    cmd.Parameters.AddWithValue("@Username", ExistingStaff.Username);
                    cmd.Parameters.AddWithValue("@RoleID", ExistingStaff.RoleID);
                    // if a new password is to be stored
                    if (ExistingStaff.Password != "") cmd.Parameters.AddWithValue("@Password", ExistingStaff.Password);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null;
            }
            catch (Exception ex)
            {
                return "Error when updating staff record: " + ex.Message;
            }
        }

        #endregion
        #region Delete
        public static string DeleteStaff(int id)
        {
            try
            {
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        SET NOCOUNT ON;

                        IF EXISTS (
                        SELECT 1
                        FROM ServiceAppointments
                        WHERE StaffID = @StaffID
                        AND DateDeleted IS NULL
                        )
                        BEGIN
                            RAISERROR('Staff member is assigned to service appointments and cannot be deleted.', 16, 1);
                            RETURN;
                        END

                        UPDATE Staff
                        SET DateDeleted = GETDATE()
                        WHERE StaffID = @StaffID
                        AND DateDeleted IS NULL;";

                    // check if the staff member is in any appointment before attempting to delete them. if they are, raise an error
                    cmd.Parameters.AddWithValue("@StaffID", id);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
            }
            catch (Exception ex)
            {
                return "Staff delete unsuccessful:\n- " + ex.Message;
            }
        }
        #endregion
        #region Search
        public static List<Staff> GetStaffByField(string searchTerm, string searchType, string field)
        {
            List<Staff> result = new List<Staff>();

            try
            {
                string query = searchType == "Exact"
                    ? $"SELECT * FROM Staff WHERE {field} = @Value AND DateDeleted IS NULL"
                    : $"SELECT * FROM Staff WHERE {field} LIKE @Value AND DateDeleted IS NULL";

                using (var adapter = new SqlDataAdapter(query, DBConnect.ConnectionToDB()))
                {
                    adapter.SelectCommand.Parameters.AddWithValue(
                        "@Value",
                        searchType == "Exact" ? searchTerm : $"%{searchTerm}%");

                    DataTable dataResult = new DataTable();
                    adapter.Fill(dataResult);

                    foreach (DataRow row in dataResult.Rows)
                    {
                        result.Add(FromDataRow(row));
                    }
                }

                return result;
            }
            catch
            {
                return new List<Staff>();
            }
        }
        #endregion
        #region Validation
        // basic checks to ensure that the details provided would form a valid staff object
        public static List<string> ValidateStaff(
            int StaffID,
            string Firstname,
            string Surname,
            string Username,
            int RoleID,
            string Password)
        {
            List<string> Errors = new List<string>();

            if (StaffID < 0)
                Errors.Add("Staff ID must be greater than or equal to 0");

            if (string.IsNullOrWhiteSpace(Firstname))
                Errors.Add("First name cannot be empty");

            if (string.IsNullOrWhiteSpace(Surname))
                Errors.Add("Surname cannot be empty");

            if (string.IsNullOrWhiteSpace(Username))
                Errors.Add("Username cannot be empty");

            if (RoleID < 0)
                Errors.Add("Role ID must be greater than or equal to 0");

            if (Firstname.Length > 50)
                Errors.Add("First name cannot be longer than 50 characters");

            if (Surname.Length > 50)
                Errors.Add("Surname cannot be longer than 50 characters");

            if (Username.Any(c => char.IsWhiteSpace(c)))
                Errors.Add("Username cannot contain spaces.");

            if (!Username.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '.'))
                Errors.Add("Username can only contain letters, numbers, underscores, or full stops.");

            if (Password.Length < 8 && !string.IsNullOrWhiteSpace(Password))
                Errors.Add("Password must be at least 8 characters.");

            if (Username.Length < 3 && !string.IsNullOrWhiteSpace(Username))
                Errors.Add("Username must be at least 3 characters");

            if (Username.Length > 50)
                Errors.Add("Username cannot be longer than 50 characters");

            if (Password.Length > 128)
                Errors.Add("Password cannot be longer than 128 characters");

            return Errors;
        }
        #endregion
        #region Misc
        // return the authorisation level of the current staff member object, which is based on their role
        public int GetAuthorisationLevel() => Role.RetrieveByRoleID(this.RoleID).AuthorisationLevel;

        private static string HashPassword(string PlainPassword)
        {
            // create a 16-byte salt
            byte[] Salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(Salt);

            // use PBKDF2 to hash the password along with the salt
            var Pbkdf2 = new Rfc2898DeriveBytes(PlainPassword, Salt, 75623);
            byte[] Hash = Pbkdf2.GetBytes(20);

            // combine the salt and hash bytes
            byte[] HashBytes = new byte[36];
            Array.Copy(Salt, 0, HashBytes, 0, 16);
            Array.Copy(Hash, 0, HashBytes, 16, 20);

            // Convert the combined salt and hash to a base64 string
            return Convert.ToBase64String(HashBytes);
        }

        // parse a staff member given their row representation in the database
        public static Staff FromDataRow(DataRow row)
        {
            return new Staff(
                (int)row["StaffID"],
                row["Firstname"].ToString(),
                row["Surname"].ToString(),
                row["Username"].ToString(),
                row["Password"].ToString(),
                (int)row["RoleID"]
            );
        }
        #endregion
















    }
}
