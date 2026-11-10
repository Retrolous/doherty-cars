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
    /// represents a customer in the system 
    /// structural validation, i.e. ensuring that an input value is valid, will occur in the setter method
    /// "business" validation, i.e. ensuring that an input value adheres to a format that isn't necessarily critical if not followed, will occur in a helper method
    class Customer
    {
        #region Private fields
        private int _customerID;
        private string _firstName;
        private string _surname;
        private string _email;
        private string _phoneNumber;
        #endregion
        #region Public properties
        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value >= 0 
                ? value // if value is positive
                : throw new ArgumentException("Customer ID must be zero or positive."); // else
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = !string.IsNullOrWhiteSpace(value)
                ? value.Trim() // if value is not empty
                : throw new ArgumentException("First name cannot be empty."); // else
        }

        public string Surname
        {
            get => _surname;
            set => _surname = !string.IsNullOrWhiteSpace(value)
                ? value.Trim() // if value is not empty
                : throw new ArgumentException("Surname cannot be empty."); // else
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // if value is empty
                {
                    _email = null; // no email provided, don't validate
                    return;
                }

                string trimmed = value.Trim();
                if (!Validation.IsValidEmail(trimmed)) // if email is not properly formatted
                    throw new ArgumentException("Email must be properly formatted.");

                _email = trimmed; // set email if valid
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = string.IsNullOrWhiteSpace(value) 
                ? null // if field is blank
                : value.Trim(); // else
        }
        #endregion
        #region Constructors
        public Customer() { }

        public Customer(
            int CustomerID,
            string FirstName,
            string Surname,
            string Email,
            string PhoneNumber)
        {
            this.CustomerID = CustomerID;
            this.FirstName = FirstName;
            this.Surname = Surname;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
        }
        #endregion
        #region Validation

        // validation which ensures that provided values both adhere to the restraints provided by the database and
        // are reasonable
        public static List<string> ValidateCustomer(
            int CustomerID,
            string Firstname,
            string Surname,
            string Email,
            string PhoneNumber)
        {
            List<string> Errors = new List<string>();

            if (CustomerID < 0)
                Errors.Add("Customer ID must be zero or positive.");

            if (string.IsNullOrWhiteSpace(Firstname))
                Errors.Add("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(Surname))
                Errors.Add("Surname cannot be empty.");

            if (!string.IsNullOrWhiteSpace(Email) && !Validation.IsValidEmail(Email))
                Errors.Add("Email must be properly formatted.");

            if (Firstname.Length > 50)
                Errors.Add("First name cannot be longer than 50 characters");

            if (Surname.Length > 50)
                Errors.Add("Surname cannot be longer than 50 characters");

            if (Email.Length > 50)
                Errors.Add("Email cannot be longer than 50 characters");

            if (PhoneNumber.Length > 15)
                Errors.Add("Phone number cannot be longer than 15 characters");

            return Errors;
        }
        #endregion
        #region Create

        // adds a new customer to the database
        // returns an error string, with null indicating a successful operation
        public static string AddCustomer(Customer NewCustomer)
        {
            try
            {
                string Query = @"
                    INSERT INTO Customers (Firstname, Surname, Email, PhoneNumber)
                    VALUES (@Firstname, @Surname, @Email, @PhoneNumber)";

                // connect to the database and populate the command with the respective parameters, then execute
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@Firstname", NewCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@Surname", NewCustomer.Surname);
                    cmd.Parameters.AddWithValue("@Email", (object)NewCustomer.Email ?? DBNull.Value); // if no email has been provided, store it as null
                    cmd.Parameters.AddWithValue("@PhoneNumber", (object)NewCustomer.PhoneNumber ?? DBNull.Value); // ditto to phone number

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null;
            }
            catch (Exception Ex)
            {
                // sql error prevented record from being added
                return "Error adding customer: " + Ex.Message;
            }
        }
        #endregion
        #region Retrieve
        // fetches all customers from the database
        public static List<Customer> RetrieveCustomers()
        {
            // stores all customers retrieved from the database
            List<Customer> Results = new List<Customer>();

            try
            {
                DataTable Table = new DataTable();

                // connect to the database, and populate the table with all records in the customer table
                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Customers WHERE DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.Fill(Table);
                }

                // parse customer objects from the provided records, and add to list
                foreach (DataRow Row in Table.Rows)
                    Results.Add(FromDataRow(Row));

                return Results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // return an empty list regardless to ensure the system gracefully handles a server error
                return null;
            }
        }

        // fetches a single customer record with the given id
        public static Customer RetrieveByCustomerID(int id)
        {
            try
            {
                DataTable Table = new DataTable();

                // get all customers from the database WITH the provided id, and fill the table with them
                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Customers WHERE CustomerID = @CustomerID AND DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.SelectCommand.Parameters.AddWithValue("@CustomerID", id);
                    Adapter.Fill(Table);
                }

                // return null if no customer was found with that id, or the very first customer with that id (which should be unique regardless)
                return Table.Rows.Count > 0 ? FromDataRow(Table.Rows[0]) : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // return null to still indicate no customer found
                return null;
            }
        }
        #endregion
        #region Update
        // saves the existing customer in the database with new details
        public static string SaveCustomer(Customer ExistingCustomer)
        {
            try
            {
                string query = @"
                UPDATE Customers
                SET Firstname = @Firstname,
                Surname = @Surname,
                Email = @Email,
                PhoneNumber = @PhoneNumber
                WHERE CustomerID = @CustomerID";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(query, Connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", ExistingCustomer.CustomerID);
                    cmd.Parameters.AddWithValue("@Firstname", ExistingCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@Surname", ExistingCustomer.Surname);
                    cmd.Parameters.AddWithValue("@Email", (object)ExistingCustomer.Email ?? DBNull.Value); // handles empty emails and phone numbers
                    cmd.Parameters.AddWithValue("@PhoneNumber", (object)ExistingCustomer.PhoneNumber ?? DBNull.Value);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null; // success
            }
            catch (Exception ex)
            {
                return "Error updating customer record: " + ex.Message;
            }
        }
        #endregion
        #region Delete
        // deletes the customer record with the provided id from the database, as well as associated records
        public static string DeleteCustomer(int id)
        {
            try
            { 
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = Connection.CreateCommand())
                {
                    // ensure that deletes are propagated i.e. all associated records are deleted as well
                    cmd.CommandText = @"
                                    UPDATE sasp
                        SET DateDeleted = GETDATE()
                        FROM ServiceAppointmentsServicesParts sasp
                        JOIN ServiceAppointments sa ON sa.AppointmentID = sasp.AppointmentID
                        JOIN Vehicles v ON v.VehicleID = sa.VehicleID
                        WHERE v.CustomerID = @CustomerID
                        AND sasp.DateDeleted IS NULL;

                        UPDATE sas
                        SET DateDeleted = GETDATE()
                        FROM ServiceAppointmentsServices sas
                        JOIN ServiceAppointments sa ON sa.AppointmentID = sas.AppointmentID
                        JOIN Vehicles v ON v.VehicleID = sa.VehicleID
                        WHERE v.CustomerID = @CustomerID
                        AND sas.DateDeleted IS NULL;

                        UPDATE sa
                        SET DateDeleted = GETDATE()
                        FROM ServiceAppointments sa
                        JOIN Vehicles v ON v.VehicleID = sa.VehicleID
                        WHERE v.CustomerID = @CustomerID
                        AND sa.DateDeleted IS NULL;
              
                        UPDATE Vehicles
                        SET DateDeleted = GETDATE()
                        WHERE CustomerID = @CustomerID
                        AND DateDeleted IS NULL;

                        UPDATE Customers
                        SET DateDeleted = GETDATE()
                        WHERE CustomerID = @CustomerID
                        AND DateDeleted IS NULL;
                    ";
                    cmd.Parameters.AddWithValue("@CustomerID", id);
                    Connection.Open();                  
                    cmd.ExecuteNonQuery();
                   
                    return null;
                }
            }
            catch
            {
               return "Customer delete unsuccessful. Please contact the administrator.";
            }
        }
        #endregion
        #region Mapping

        // creates a new customer object using fields in the provided datarow object
        public static Customer FromDataRow(DataRow Row)
        {
            return new Customer(
                (int)Row["CustomerID"],
                Row["Firstname"].ToString(),
                Row["Surname"].ToString(),
                Row["Email"] == DBNull.Value ? null : Row["Email"].ToString(), // handles empty emails and phone numbers
                Row["PhoneNumber"] == DBNull.Value ? null : Row["PhoneNumber"].ToString()
            );
        }
        #endregion
        #region Search
        // searches all customer records in the database against the provided criteria
        public static List<Customer> RetrieveCustomersByField(string SearchTerm, string SearchType, string Field)
        {
            List<Customer> Results = new List<Customer>();

            try
            {
                DataTable Table = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    // check if it's exact or contains search
                    $"SELECT * FROM Customers WHERE {Field} {(SearchType == "Exact" ? "=" : "LIKE")} @Value AND DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.SelectCommand.Parameters.AddWithValue(
                        "@Value", // if it's exact, just put the string in, otherwise surround the string with wildcards
                        SearchType == "Exact" ? SearchTerm : "%" + SearchTerm + "%");

                    Adapter.Fill(Table);
                }

                foreach (DataRow Row in Table.Rows)
                    Results.Add(FromDataRow(Row));

                return Results;
            }
            catch
            {
                return new List<Customer>();
            }
        }
        #endregion
    }
}
