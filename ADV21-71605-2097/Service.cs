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
    class Service
    {
        #region Private fields
        private int _serviceID;
        private string _name;
        private string _description;
        private int _durationHours;
        private decimal _price;
        #endregion

        #region Public properties
        public int ServiceID
        {
            get => _serviceID;
            set => _serviceID = value >= 0
                ? value
                : throw new ArgumentException("Service ID must be zero or positive.");
        }

        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrWhiteSpace(value)
                ? value.Trim()
                : throw new ArgumentException("Service name cannot be empty.");
        }

        public string Description
        {
            get => _description;
            set
            {
                if (value?.Length > 500)
                    throw new ArgumentException("Description cannot exceed 500 characters.");
                _description = value?.Trim() ?? "";
            }
        }

        public int DurationHours
        {
            get => _durationHours;
            set => _durationHours = (value > 0 && value <= 10)
                ? value
                : throw new ArgumentException("Duration must be between 1 and 10 hours.");
        }

        public decimal Price
        {
            get => _price;
            set => _price = value >= 0
                ? value
                : throw new ArgumentException("Price cannot be negative.");
        }
        #endregion

        #region Constructors
        public Service() { }

        public Service(int ServiceID, string Name, string Description, int DurationHours, decimal Price)
        {
            this.ServiceID = ServiceID;
            this.Name = Name;
            this.Description = Description;
            this.DurationHours = DurationHours;
            this.Price = Price;
        }
        #endregion

        #region Validation
        // basic checks to ensure that the details provided would form a valid service object
        public static List<string> ValidateService(int ServiceID, string Name, string Description, int DurationHours, decimal Price)
        {
            List<string> Errors = new List<string>();

            if (ServiceID < 0)
                Errors.Add("Service ID must be greater than or equal to 0");

            if (string.IsNullOrWhiteSpace(Name))
                Errors.Add("Service name cannot be empty.");

            if(Name.Length > 50)
                Errors.Add("Service name cannot exceed 50 characters");
           
            if (Description?.Length > 500)
                Errors.Add("Description cannot exceed 500 characters.");

            if (DurationHours <= 0 || DurationHours > 10)
                Errors.Add("Duration must be between 1 and 10 hours.");

            if (Price < 0)
                Errors.Add("Price cannot be negative.");

            return Errors;
        }
        #endregion

        #region Create
        // add a new service into the Services table
        public static string AddService(Service NewService)
        {
            try
            {
                string Query = @"
                    INSERT INTO Services (Name, Description, DurationHours, Price)
                    VALUES (@Name, @Description, @DurationHours, @Price)";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@Name", NewService.Name);
                    cmd.Parameters.AddWithValue("@Description", NewService.Description);
                    cmd.Parameters.AddWithValue("@DurationHours", NewService.DurationHours);
                    cmd.Parameters.AddWithValue("@Price", NewService.Price);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null; // success
            }
            catch (Exception ex)
            {
                return "Error adding service:\n" + ex.Message;
            }
        }
        #endregion

        #region Retrieve
        // get all services from the Services table
        public static List<Service> RetrieveServices()
        {
            List<Service> Results = new List<Service>();
            try
            {
                DataTable Table = new DataTable();
                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Services WHERE DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.Fill(Table);
                }

                foreach (DataRow row in Table.Rows)
                    Results.Add(FromDataRow(row));

                return Results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error retrieving services:\n- " + ex.Message);
                return null;
            }
        }

        // get a service given its id
        public static Service RetrieveByServiceID(int id)
        {
            try
            {
                DataTable Table = new DataTable();
                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Services WHERE ServiceID = @ServiceID AND DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.SelectCommand.Parameters.AddWithValue("@ServiceID", id);
                    Adapter.Fill(Table);
                }

                // if any services had that id
                return Table.Rows.Count > 0 ? FromDataRow(Table.Rows[0]) : null;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Delete

        // delete a service given its id
        // services will not be deleted if they are currently being used in an appointment
        public static string DeleteService(int id)
        {
            try
            {
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                    IF EXISTS (
                        SELECT 1
                        FROM ServiceAppointmentsServices -- assuming junction table
                        WHERE ServiceID = @ServiceID
                     AND DateDeleted IS NULL
                    )
                    BEGIN
                        THROW 50000, 'Service is currently used in service appointments and cannot be deleted.', 1;
                    END

                    UPDATE Services
                    SET DateDeleted = GETDATE()
                    WHERE ServiceID = @ServiceID
                    AND DateDeleted IS NULL;"; ;

                    cmd.Parameters.AddWithValue("@ServiceID", id);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
            }
            catch(Exception ex)
            {
                return "Service delete unsuccessful:\n" + ex.Message;
            }
        }
        #endregion

        #region Mapping
        // parses a service given its row representation in the table
        public static Service FromDataRow(DataRow row)
        {
            return new Service(
                (int)row["ServiceID"],
                row["Name"].ToString(),
                row["Description"].ToString(),
                (int)row["DurationHours"],
                (decimal)row["Price"]
            );
        }
        #endregion

        // update an existing service with new details
        public static string SaveService(Service ExistingService)
        {
            try
            {
                string Query = @"
            UPDATE Services
            SET Name = @Name,
                Description = @Description,
                DurationHours = @DurationHours,
                Price = @Price
            WHERE ServiceID = @ServiceID";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@ServiceID", ExistingService.ServiceID);
                    cmd.Parameters.AddWithValue("@Name", ExistingService.Name);
                    cmd.Parameters.AddWithValue("@Description", ExistingService.Description);
                    cmd.Parameters.AddWithValue("@DurationHours", ExistingService.DurationHours);
                    cmd.Parameters.AddWithValue("@Price", ExistingService.Price);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null; // success
            }
            catch (Exception ex)
            {
                return "Error updating service record:\n" + ex.Message;
            }
        }


        #region Search
        public static List<Service> GetServicesByField(string SearchTerm, string SearchType, string Field)
        {
            List<Service> Results = new List<Service>();
            try
            {
                DataTable Table = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    $"SELECT * FROM Services WHERE {Field} {(SearchType == "Exact" ? "=" : "LIKE")} @Value AND DateDeleted IS NULL",
                    Connection)) // modify the search query depending on the search type
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
                return new List<Service>();
            }
        }
        #endregion
    }
}
