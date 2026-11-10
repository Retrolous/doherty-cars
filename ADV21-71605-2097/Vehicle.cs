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
    class Vehicle
    {
        #region Private properties
        private int _vehicleID;
        private int _vehicleTypeID;
        private int? _customerID;
        private string _make;
        private string _model;
        private int? _year;
        private string _VIN;
        private string _licensePlate;
        private string _condition;
        private bool _available;
        private bool _inspected;
        private double? _buyPrice;
        private double? _sellPrice;
        private string _storageLocation;

        #endregion
        #region Public properties
        public int VehicleID
        {
            get => _vehicleID;
            // validates vehicle ID before setting to ensure that it is not negative
            // value set to 0 when creating a new record, as SQL will assign one when doing so, and > 0 for an existing record
            set => _vehicleID = value >= 0
                    ? value
                    : throw new ArgumentException("Vehicle ID must be a positive number.");
        }

        public int VehicleTypeID
        {
            get => _vehicleTypeID;
            set => _vehicleTypeID = value > 0
                    ? value
                    : throw new ArgumentException("Vehicle Type ID must be a positive number.");
        }

        public int? CustomerID
        {
            get => _customerID;
            set => _customerID = (value == null || value >= 0)
                    ? value
                    : throw new ArgumentException("Customer ID must either be a positive number or null.");
        }

        public string Make
        {
            get => _make;
            set => _make = (!string.IsNullOrEmpty(value))
                ? value.Trim()
                : throw new ArgumentException("Make cannot be empty.");
        }

        public string Model
        {
            get => _model;
            set => _model = (!string.IsNullOrEmpty(value))
                ? value.Trim()
                : throw new ArgumentException("Model cannot be empty.");
        }

        public int? Year
        {
            get => _year;
            set => _year = (value == null || (value >= 1800 && value <= 2050)) 
                    ? value
                    : throw new ArgumentException("Year must be between 1800 and 2050.");
        }

        public string VIN
        {
            get => _VIN;
            set => _VIN = (!string.IsNullOrEmpty(value))
                ? value.Trim()
                : throw new ArgumentException("VIN cannot be empty.");
        }

        public string LicensePlate
        {
            get => _licensePlate;
            set => _licensePlate = value?.Trim() ?? null;
        }

        public string Condition
        {
            get => _condition;
            set => _condition = (!string.IsNullOrEmpty(value))
                ? value.Trim()
                : throw new ArgumentException("Condition cannot be empty.");
        }

        public bool Available
        {
            get => _available;
            set => _available = value;
        }

        public bool Inspected
        {
            get => _inspected;
            set => _inspected = value;
        }

        public double? BuyPrice
        {
            get => _buyPrice;
            set => _buyPrice = (value == null || value >= 0)
                    ? value
                    : throw new ArgumentException("Buy price must either be a value greater than 0 in GBP, or must be null.");
        }

        public double? SellPrice
        {
            get => _sellPrice;
            set => _sellPrice = (value == null || value >= 0)
                    ? value
                    : throw new ArgumentException("Sell price must either be a value greater than 0 in GBP, or must be null.");
        }

        public string StorageLocation
        {
            get => _storageLocation;
            set => _storageLocation = value?.Trim() ?? null;
        }

        #endregion
        #region Constructors
        public Vehicle()
        {

        }

        public Vehicle(
           int VehicleID,
           int VehicleTypeID,
           int? CustomerID,
           string Make,
           string Model,
           int? Year,
           string VIN,
           string LicensePlate,
           string Condition,
           bool Available,
           bool Inspected,
           double? BuyPrice,
           double? SellPrice,
           string StorageLocation
       )
        {
            this.VehicleID = VehicleID;
            this.VehicleTypeID = VehicleTypeID;
            this.CustomerID = CustomerID;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.VIN = VIN;
            this.LicensePlate = LicensePlate;
            this.Condition = Condition;
            this.Available = Available;
            this.Inspected = Inspected;
            this.BuyPrice = BuyPrice;
            this.SellPrice = SellPrice;
            this.StorageLocation = StorageLocation;
        }

        #endregion

        #region Create
        // method to add a new vehicle to the database
        public static string AddVehicle(Vehicle NewVehicle)
        {
            try
            {
                string Query = @"
                    INSERT INTO Vehicles
                    (
                        VehicleTypeID,
                        CustomerID,
                        Make,
                        Model,
                        Year,
                        VIN,
                        LicensePlate,
                        Condition,
                        Available,
                        Inspected,
                        BuyPrice,
                        SellPrice,
                        StorageLocation
                    )
                    VALUES
                    (
                        @VehicleTypeID,
                        @CustomerID,
                        @Make,
                        @Model,
                        @Year,
                        @VIN,
                        @LicensePlate,
                        @Condition,
                        @Available,
                        @Inspected,
                        @BuyPrice,
                        @SellPrice,
                        @StorageLocation
                    )";
                ;
                // execute the completed query
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    // ensure empty values are appropriately stored as null values
                    cmd.Parameters.AddWithValue("@VehicleTypeID", NewVehicle.VehicleTypeID);
                    cmd.Parameters.AddWithValue("@CustomerID", (object)NewVehicle.CustomerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Make", NewVehicle.Make);
                    cmd.Parameters.AddWithValue("@Model", NewVehicle.Model);
                    cmd.Parameters.AddWithValue("@Year", (object)NewVehicle.Year ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VIN", NewVehicle.VIN);
                    cmd.Parameters.AddWithValue("@LicensePlate", (object)NewVehicle.LicensePlate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Condition", NewVehicle.Condition);
                    cmd.Parameters.AddWithValue("@Available", NewVehicle.Available);
                    cmd.Parameters.AddWithValue("@Inspected", NewVehicle.Inspected);
                    cmd.Parameters.AddWithValue("@BuyPrice", (object)NewVehicle.BuyPrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellPrice", (object)NewVehicle.SellPrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StorageLocation", (object)NewVehicle.StorageLocation ?? DBNull.Value);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                return null;
            }
            catch (Exception e)
            {
                return "Error when updating database: " + e.Message;
            }
        }
        #endregion
        #region Retrieve
        public static List<Vehicle> RetrieveVehicles() // retrieves all vehicles from the database
        {
            List<Vehicle> Result = new List<Vehicle>();
            try
            {
                DataTable DataResult = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var DataAdapter = new SqlDataAdapter("SELECT * FROM Vehicles WHERE DateDeleted IS NULL", Connection))
                {
                    DataAdapter.Fill(DataResult);
                }

                // process each record in the datatable to produce a list of vehicles
                foreach (DataRow record in DataResult.Rows)
                {
                    Result.Add(FromDataRow(record));

                }
                return Result;
            }
            // in the event that any of the vehicle records are invalidly formatted, output an error message
            catch (Exception e)
            {
                MessageBox.Show("An error occurred while retrieving vehicle data: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // retrieve a specific vehicle given its id
        public static Vehicle RetrieveByVehicleID(int ID)
        {
            try
            {

                DataTable DataResult = new DataTable();
                using (var Connection = DBConnect.ConnectionToDB())
                using (var DataAdapter = new SqlDataAdapter("SELECT * FROM Vehicles WHERE VehicleID = @VehicleID", Connection))
                {
                    DataAdapter.SelectCommand.Parameters.AddWithValue("@VehicleID", ID);
                    DataAdapter.Fill(DataResult);
                }

                // tertiary statement prohibits an error if the last record is deleted i.e. the queried id isn't present
                return (DataResult.Rows.Count > 0) ? FromDataRow(DataResult.Rows[0]) : null;
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred while retrieving vehicle data:" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        // parses a vehicle given its row presentation in a table
        public static Vehicle FromDataRow(DataRow row)
        {
            return new Vehicle(
                (int)row["VehicleID"],
                (int)row["VehicleTypeID"],
                row["CustomerID"] == DBNull.Value ? null : (int?)row["CustomerID"],
                row["Make"].ToString(),
                row["Model"].ToString(),
                row["Year"] == DBNull.Value ? null : (int?)row["Year"],
                row["VIN"].ToString(),
                row["LicensePlate"] == DBNull.Value ? null : row["LicensePlate"].ToString(),
                row["Condition"].ToString(),
                (bool)row["Available"],
                (bool)row["Inspected"],
                row["BuyPrice"] == DBNull.Value ? null : (double?)(decimal)row["BuyPrice"],
                row["SellPrice"] == DBNull.Value ? null : (double?)(decimal)row["SellPrice"],
                row["StorageLocation"] == DBNull.Value ? null : row["StorageLocation"].ToString()
            );
        }

        #endregion
        #region Update
        // method to update the database with new data for the appropriate vehicle
        public static string SaveVehicle(Vehicle ExistingVehicle)
        {
            try
            {

                string Query = @"
                    UPDATE Vehicles
                    SET
                        VehicleTypeID =  @VehicleTypeID,
                        CustomerID = @CustomerID,
                        Make = @Make,
                        Model = @Model,
                        Year = @Year,
                        VIN = @VIN,
                        LicensePlate = @LicensePlate,
                        Condition = @Condition,
                        Available = @Available,
                        Inspected = @Inspected,
                        BuyPrice = @BuyPrice,
                        SellPrice = @SellPrice,
                        StorageLocation = @StorageLocation
                    WHERE VehicleID = @VehicleID;";
                ;
                // execute the completed query
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@VehicleID", ExistingVehicle.VehicleID);
                    cmd.Parameters.AddWithValue("@VehicleTypeID", ExistingVehicle.VehicleTypeID);
                    cmd.Parameters.AddWithValue("@CustomerID", (object)ExistingVehicle.CustomerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Make", ExistingVehicle.Make);
                    cmd.Parameters.AddWithValue("@Model", ExistingVehicle.Model);
                    cmd.Parameters.AddWithValue("@Year", (object)ExistingVehicle.Year ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VIN", ExistingVehicle.VIN);
                    cmd.Parameters.AddWithValue("@LicensePlate", (object)ExistingVehicle.LicensePlate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Condition", ExistingVehicle.Condition);
                    cmd.Parameters.AddWithValue("@Available", ExistingVehicle.Available);
                    cmd.Parameters.AddWithValue("@Inspected", ExistingVehicle.Inspected);
                    cmd.Parameters.AddWithValue("@BuyPrice", (object)ExistingVehicle.BuyPrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellPrice", (object)ExistingVehicle.SellPrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StorageLocation", (object)ExistingVehicle.StorageLocation ?? DBNull.Value);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                return null;
            }
            catch (Exception e)
            {
                return "Error when updating database: " + e.Message;
            }
        }
        #endregion
        #region Delete
        public static string DeleteVehicle(int vehicleID)
        {
            string Query = @"UPDATE sasp
            SET DateDeleted = GETDATE()
            FROM ServiceAppointmentsServicesParts sasp
            JOIN ServiceAppointments sa ON sa.AppointmentID = sasp.AppointmentID
            WHERE sa.VehicleID = @VehicleID
            AND sasp.DateDeleted IS NULL;

            UPDATE sas
            SET DateDeleted = GETDATE()
            FROM ServiceAppointmentsServices sas
            JOIN ServiceAppointments sa ON sa.AppointmentID = sas.AppointmentID
            WHERE sa.VehicleID = @VehicleID
            AND sas.DateDeleted IS NULL;

            UPDATE ServiceAppointments
            SET DateDeleted = GETDATE()
            WHERE VehicleID = @VehicleID
            AND DateDeleted IS NULL;

            UPDATE Vehicles
            SET DateDeleted = GETDATE()
            WHERE VehicleID = @VehicleID
            AND DateDeleted IS NULL;";
            try
            {
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
            }
            catch (Exception e)
            {
                return "Delete unsuccessful. Please contact the administrator with the following error:\n" + e.Message;
            }
        }
        #endregion
        #region Search
        // return a list of vehicles matching the search criteria provided
        public static List<Vehicle> GetVehiclesByField(string SearchTerm, string SearchType, string Field)
        {
            List<Vehicle> Result = new List<Vehicle>();
            try
            {
                DataTable DataResult = new DataTable();
                using (var Connection = DBConnect.ConnectionToDB())
                using (var DataAdapter = new SqlDataAdapter($"SELECT * FROM Vehicles WHERE {Field} {(SearchType == "Exact" ? "=" : "LIKE")} @Value AND DateDeleted IS NULL", Connection))
                {
                    if (SearchType == "Exact") DataAdapter.SelectCommand.Parameters.AddWithValue("@Value", SearchTerm);
                    // modify the query based on the search type
                    else DataAdapter.SelectCommand.Parameters.AddWithValue("@Value", "%" + SearchTerm + "%");
                    DataAdapter.Fill(DataResult);
                }

                // process each return record in the datatable to return a valid vehicle object
                foreach (DataRow record in DataResult.Rows)
                {
                    Result.Add(FromDataRow(record));
                }

                return Result;
            }
            catch
            {
                return new List<Vehicle>();
            }
        }
        #endregion
        #region Validate
        // basic check to ensure that the data provided would make a valid vehicle entity
        public static List<string> ValidateVehicleFields(
            int VehicleID,
            int VehicleTypeID,
            int? CustomerID,
            string Make,
            string Model,
            int? Year,
            string VIN,
            string LicensePlate,
            string Condition,
            bool Available,
            bool Inspected,
            double? BuyPrice,
            double? SellPrice,
            string Location
)
        {
            List<string> Errors = new List<string>();

            if (VehicleID < 0)
                Errors.Add("Vehicle ID must be greater than or equal to 0");

            if (VehicleTypeID <= 0)
                Errors.Add("Vehicle Type ID must be greater than 0");

            if (CustomerID != null && CustomerID < 0)
                Errors.Add("Customer ID must be greater than or equal to 0");

            if (string.IsNullOrWhiteSpace(Make))
                Errors.Add("Make cannot be empty");

            if (string.IsNullOrWhiteSpace(Model))
                Errors.Add("Model cannot be empty");

            if (Year != null && (Year < 1800 || Year > 2050))
                Errors.Add("Year must be between 1800 and 2050");

            if (string.IsNullOrWhiteSpace(VIN))
                Errors.Add("VIN cannot be empty");


            if (Validation.VINExists(VehicleID, VIN))
                Errors.Add("VIN must be unique");

            if (string.IsNullOrWhiteSpace(Condition))
                Errors.Add("Condition cannot be empty");

            if (BuyPrice < 0)
                Errors.Add("Buy price cannot be negative");

            if (SellPrice < 0)
                Errors.Add("Sell price cannot be negative");

            if (Make.Length > 50)
                Errors.Add("Make cannot be longer than 50 characters");
            if (Condition.Length > 50)
                Errors.Add("Condition cannot be longer than 50 characters");
            if (Model.Length > 50)
                Errors.Add("Model cannot be longer than 50 characters");

            if (VIN.Length > 50)
                Errors.Add("VIN cannot be longer than 50 characters");

            if (LicensePlate != null && LicensePlate.Length > 20)
                Errors.Add("License plate cannot be longer than 20 characters");

            if (Location.Length > 50)
                Errors.Add("Storage location cannot be longer than 50 characters");


            return Errors;
        }
        #endregion



       

      

      
        
       

      
      
    }
}
