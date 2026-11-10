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
    class VehicleType
    {
        #region Private fields
        private int _vehicleTypeID;
        private string _name;
        private decimal _complexity;
        #endregion
        #region Public properties
        public int VehicleTypeID
        {
            get => _vehicleTypeID;
            set => _vehicleTypeID = value >= 0
                ? value
                : throw new ArgumentException("Vehicle Type ID must be zero or positive.");
        }

        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrEmpty(value?.Trim())
                ? value.Trim()
                : throw new ArgumentException("Vehicle Type Name cannot be empty.");
        }

        public decimal Complexity
        {
            get => _complexity;
            set => _complexity = (value >= 0)
                ? value
                : throw new ArgumentException("Vehicle Complexity must be zero or positive.");
        }
        #endregion
        #region Constructors
        public VehicleType() { }

        public VehicleType(int VehicleTypeID, string Name, decimal Complexity)
        {
            this.VehicleTypeID = VehicleTypeID;
            this.Name = Name;
            this.Complexity = Complexity;
        }
        #endregion
        #region Validation
        // basic checks to ensure that a potential vehicle type is valid
        public static List<string> ValidateVehicleType(string Name, decimal Complexity)
        {
            List<string> Errors = new List<string>();

            if (string.IsNullOrEmpty(Name?.Trim()))
                Errors.Add("Vehicle type name cannot be empty.");

            if (Name.Length > 50)
                Errors.Add("Vehicle type name cannot be longer than 50 characters.");

            if (Complexity < 0)
                Errors.Add("Complexity must be zero or positive.");

            if (Complexity > 5)
                Errors.Add("Complexity cannot exceed 5.");

            return Errors;
        }
        #endregion

        #region Create

        // basic add logic to insert a new vehicle type into the database
        public static string AddVehicleType(VehicleType NewType)
        {
            try
            {
                string Query = @"
                    INSERT INTO VehicleTypes
                    (Name, Complexity)
                    VALUES
                    (@Name, @Complexity)";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@Name", NewType.Name);
                    cmd.Parameters.AddWithValue("@Complexity", NewType.Complexity);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null;
            }
            catch (Exception e)
            {
                return "Error adding Vehicle Type: " + e.Message;
            }
        }
        #endregion
        #region Read

        // basic read logic to return all vehicle types that have not been deleted
        public static List<VehicleType> RetrieveVehicleTypes()
        {
            List<VehicleType> Result = new List<VehicleType>();

            try
            {
                DataTable DataResult = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM VehicleTypes WHERE DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.Fill(DataResult);
                }

                foreach (DataRow row in DataResult.Rows)
                    Result.Add(FromDataRow(row));

                return Result;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error retrieving vehicle types: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // method to retrive a specific vehicle type given its id in the table
        public static VehicleType RetrieveByVehicleTypeID(int id)
        {
            try
            {
                DataTable DataResult = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM VehicleTypes WHERE VehicleTypeID = @VehicleTypeID AND DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.SelectCommand.Parameters.AddWithValue("@VehicleTypeID", id);
                    Adapter.Fill(DataResult);
                }

                // if a vehicle type was found
                return DataResult.Rows.Count > 0
                    ? FromDataRow(DataResult.Rows[0])
                    : null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error retrieving vehicle type: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion
        #region Update
        // basic logic to update a vehicle type with new information in the database
        public static string SaveVehicleType(VehicleType ExistingType)
        {
            try
            {
                string Query = @"
            UPDATE VehicleTypes
            SET Name = @Name,
                Complexity = @Complexity
            WHERE VehicleTypeID = @VehicleTypeID";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@VehicleTypeID", ExistingType.VehicleTypeID);
                    cmd.Parameters.AddWithValue("@Name", ExistingType.Name);
                    cmd.Parameters.AddWithValue("@Complexity", ExistingType.Complexity);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null; // success
            }
            catch (Exception ex)
            {
                return "Error updating vehicle type record: " + ex.Message;
            }
        }

        #endregion
        #region Delete
        // basic delete logic to ensure that a vehicle type is not being used
        // before flagging it as deleted
        public static string DeleteVehicleType(int id)
        {
            try
            {
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        IF EXISTS (
                            SELECT 1 FROM Vehicles
                            WHERE VehicleTypeID = @VehicleTypeID
                            AND DateDeleted IS NULL
                        )
                        BEGIN
                            RAISERROR('Vehicle type is in use and cannot be deleted.', 16, 1);
                        RETURN;
                        END

                        UPDATE VehicleTypes
                        SET DateDeleted = GETDATE()
                        WHERE VehicleTypeID = @VehicleTypeID
                        AND DateDeleted IS NULL;";

                    cmd.Parameters.AddWithValue("@VehicleTypeID", id);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
            }
            catch (Exception ex)
            {
                return "Vehicle type delete unsuccessful:\n- " + ex.Message;
            }
        }
        #endregion
        #region Mapping

        // parse a vehicle type given its row representation in the database
        public static VehicleType FromDataRow(DataRow row)
        {
            return new VehicleType(
                (int)row["VehicleTypeID"],
                row["Name"].ToString(),
                (decimal)row["Complexity"]
            );
        }
        #endregion
        #region Search
        // filter the vehicle types based on the type of search, field to search and search substring
        public static List<VehicleType> GetVehicleTypesByField(string SearchTerm, string SearchType, string Field)
        {
            List<VehicleType> Results = new List<VehicleType>();

            try
            {
                DataTable Table = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    // change the query based on the search type
                    $"SELECT * FROM VehicleTypes WHERE {Field} {(SearchType == "Exact" ? "=" : "LIKE")} @Value AND DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.SelectCommand.Parameters.AddWithValue(
                        "@Value", SearchType == "Exact" ? SearchTerm : "%" + SearchTerm + "%");

                    Adapter.Fill(Table);
                }

                foreach (DataRow row in Table.Rows)
                    Results.Add(FromDataRow(row));

                return Results;
            }
            catch
            {
                return new List<VehicleType>();
            }
        }
        #endregion
    }
}
