using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    class Role
    {
        #region Private fields
        private int _roleID;
        private string _name;
        private int _authorisationLevel;
        private string _sector;
        #endregion
        #region Public properties
        public int RoleID
        {
            get => _roleID;
            set => _roleID = value >= 0
                ? value
                : throw new ArgumentException("Role ID must be zero or positive.");
        }

        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrWhiteSpace(value)
                ? value.Trim()
                : throw new ArgumentException("Role name cannot be empty.");
        }

        public int AuthorisationLevel
        {
            get => _authorisationLevel;
            set => _authorisationLevel = value >= 0
                ? value
                : throw new ArgumentException("Authorisation level must be zero or positive.");
        }

        public string Sector
        {
            get => _sector;
            set => _sector = !string.IsNullOrWhiteSpace(value)
                ? value.Trim()
                : throw new ArgumentException("Sector cannot be empty.");
        }
        #endregion
        #region Constructors
        public Role() { }

        public Role(int RoleID, string Name, int AuthorisationLevel, string Sector)
        {
            this.RoleID = RoleID;
            this.Name = Name;
            this.AuthorisationLevel = AuthorisationLevel;
            this.Sector = Sector;
        }
        #endregion
        #region Validation
        // basic validation to ensure that the given details would form a valid role object
        public static List<string> ValidateRole(string Name, int AuthorisationLevel, string Sector)
        {
            List<string> Errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
                Errors.Add("Role name cannot be empty.");

            if (Name.Length > 50)
                Errors.Add("Role name cannot be longer than 50 characters.");

            if (Sector.Length > 50)
                Errors.Add("Sector name cannot be longer than 50 characters.");

            if (AuthorisationLevel < 0)
                Errors.Add("Authorisation level must be zero or positive.");

            if (string.IsNullOrWhiteSpace(Sector))
                Errors.Add("Sector cannot be empty.");
            return Errors;
        }
        #endregion
        #region Create
        // add a new role record into the Roles table
        public static string AddRole(Role NewRole)
        {
            try
            {
                string Query = @"
                    INSERT INTO Roles (Name, AuthorisationLevel, Sector)
                    VALUES (@Name, @AuthorisationLevel, @Sector)";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@Name", NewRole.Name);
                    cmd.Parameters.AddWithValue("@AuthorisationLevel", NewRole.AuthorisationLevel);
                    cmd.Parameters.AddWithValue("@Sector", NewRole.Sector);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null;
            }
            catch (Exception ex)
            {
                return "Error adding role:\n" + ex.Message;
            }
        }
        #endregion
        #region Retrieve
        // get all roles from the roles table
        public static List<Role> RetrieveRoles()
        {
            List<Role> results = new List<Role>();

            try
            {
                DataTable table = new DataTable();

                using (var connection = DBConnect.ConnectionToDB())
                using (var adapter = new SqlDataAdapter(
                    "SELECT * FROM Roles WHERE DateDeleted IS NULL",
                    connection))
                {
                    adapter.Fill(table);
                }

                foreach (DataRow row in table.Rows)
                    results.Add(FromDataRow(row));

                return results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving role records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // get a specific role given its id
        public static Role RetrieveByRoleID(int id)
        {
            try
            {
                DataTable Table = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Roles WHERE RoleID = @RoleID AND DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.SelectCommand.Parameters.AddWithValue("@RoleID", id);
                    Adapter.Fill(Table);
                }

                // if there is a role with that id
                return Table.Rows.Count > 0 ? FromDataRow(Table.Rows[0]) : null;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region Delete
        // delete a role from the table given its id
        public static string DeleteRole(int id)
        {
            try
            {
                using (var connection = DBConnect.ConnectionToDB())
                using (var cmd = connection.CreateCommand())
                {
                    // checks if any staff members already have that role
                    // if they do, throw an error
                    cmd.CommandText = @"
                        SET NOCOUNT ON;

    
                        IF EXISTS (
                            SELECT 1
                            FROM Staff
                            WHERE RoleID = @RoleID
                            AND DateDeleted IS NULL
                        )
                        BEGIN
                            RAISERROR('Role is assigned to staff members and cannot be deleted.', 16, 1);
                            RETURN;
                        END

   
                        UPDATE Roles
                        SET DateDeleted = GETDATE()
                        WHERE RoleID = @RoleID
                        AND DateDeleted IS NULL;";

                    cmd.Parameters.AddWithValue("@RoleID", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
            }
            catch (Exception ex)
            {
                return "Role delete unsuccessful:\n- " + ex.Message;
            }
        }

        // see if the authorisation level provided is greater than or equal to the one required, either outputting nothing or an appropriate error message
        public static string CheckAuthorised(int AuthorisationGiven, int AuthorisationRequired)
        {

            if (AuthorisationGiven >= AuthorisationRequired) return null;
            Dictionary<int, string> LevelToPermissions = new Dictionary<int, string>
           {
               {0, "Read-only" },
               {1, "Restricted write"},
               {2, "Unrestricted write"}
           };

            return "This action requires \"" + LevelToPermissions[AuthorisationRequired] + "\" permission, but you have \"" + LevelToPermissions[AuthorisationGiven] + "\"";
        }
        #endregion
        #region Mapping
        // parses a role given its row representation in the table
        public static Role FromDataRow(DataRow row)
        {
            return new Role(
                (int)row["RoleID"],
                row["Name"].ToString(),
                (int)row["AuthorisationLevel"],
                row["Sector"].ToString()
            ) ;
        }
        #endregion
        #region Save
        // update a role in the roles table with new details
        public static string SaveRole(Role ExistingRole)
        {
            try
            {
                string Query = @"
            UPDATE Roles
            SET Name = @Name,
                AuthorisationLevel = @AuthorisationLevel,
                Sector = @Sector
            WHERE RoleID = @RoleID";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@RoleID", ExistingRole.RoleID);
                    cmd.Parameters.AddWithValue("@Name", ExistingRole.Name);
                    cmd.Parameters.AddWithValue("@AuthorisationLevel", ExistingRole.AuthorisationLevel);
                    cmd.Parameters.AddWithValue("@Sector", ExistingRole.Sector);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null; // success
            }
            catch (Exception ex)
            {
                return "Error updating role record:\n" + ex.Message;
            }
        }
        #endregion
        #region Search
        // return all roles that match the provided critera
        public static List<Role> GetRolesByField(string SearchTerm, string SearchType, string Field)
        {
            List<Role> Results = new List<Role>();

            try
            {
                DataTable Table = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    // update the query depending on the search type
                    $"SELECT * FROM Roles WHERE {Field} {(SearchType == "Exact" ? "=" : "LIKE")} @Value AND DateDeleted IS NULL",
                    Connection))
                {
                    if (SearchType == "Exact")
                        Adapter.SelectCommand.Parameters.AddWithValue("@Value", SearchTerm);
                    else
                        Adapter.SelectCommand.Parameters.AddWithValue("@Value", "%" + SearchTerm + "%");

                    Adapter.Fill(Table);
                }

                foreach (DataRow row in Table.Rows)
                    Results.Add(FromDataRow(row));

                return Results;
            }
            catch
            {
                return new List<Role>();
            }
        }
        #endregion
    }
}
